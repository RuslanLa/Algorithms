"use strict";
//@ts-check

/**Solution for the  https://www.hackerrank.com/challenges/journey-to-the-moon/problem*/
const fs = require("fs");

process.stdin.resume();
process.stdin.setEncoding("utf-8");

let input = "";
let inputString = [];
let currentLine = 0;

process.stdin.on("data", inputStdin => {
  input += inputStdin;
});

process.stdin.on("end", _ => {
  inputString = input
    .replace(/\s*$/, "")
    .split("\n")
    .map(str => str.replace(/\s*$/, ""));

  main();
});

function readLine() {
  return inputString[currentLine++];
}

function calculateFactorial(n) {
  let result = 1;
  for (let i = 2; i <= n; i++) {
    result *= i;
  }
  return result;
}

function buildGroups(n, astronaut) {
  let astronautsGroups = Array.from({ length: n }, () => null);
  let groupNum = 1;
  let groups = new Map();
  for (let i = 0; i < astronaut.length; i++) {
    let first = astronaut[i][0];
    let second = astronaut[i][1];
    if (astronautsGroups[first] == null && astronautsGroups[second] == null) {
      astronautsGroups[first] = groupNum;
      astronautsGroups[second] = groupNum;
      groups.set(groupNum, [first, second]);
      groupNum++;
      continue;
    }
    if (astronautsGroups[first] == null || astronautsGroups[second] == null) {
      let existingGroupNum =
        astronautsGroups[first] || astronautsGroups[second];
      let group = groups.get(existingGroupNum);
      group.push(astronautsGroups[first] ? second : first);
      groups.set(existingGroupNum, group);
      astronautsGroups[first] = existingGroupNum;
      astronautsGroups[second] = existingGroupNum;
      continue;
    }
    let minGroupNum = Math.min(
      astronautsGroups[first],
      astronautsGroups[second]
    );
    let maxGroupNum = Math.max(
      astronautsGroups[first],
      astronautsGroups[second]
    );
    if (minGroupNum === maxGroupNum) {
      continue;
    }
    let maxGroupParticipants = groups.get(maxGroupNum);
    for (let i = 0; i < maxGroupParticipants.length; i++) {
      astronautsGroups[maxGroupParticipants[i]] = minGroupNum;
    }
    groups.delete(maxGroupNum);
    let minGroupParticipants = groups.get(minGroupNum);
    groups.set(minGroupNum, minGroupParticipants.concat(maxGroupParticipants));
  }
  return { astronautsGroups: astronautsGroups, groups: groups };
}

function getSameCountryCounts(n, astronaut) {
  let { astronautsGroups, groups } = buildGroups(n, astronaut);
  let groupsLengths = [...groups].map(
    ([_groupNum, participants]) => participants.length
  );
  for (let groupNum of astronautsGroups) {
    if (groupNum == null) {
      groupsLengths.push(1);
    }
  }
  return groupsLengths;
}

// Complete the journeyToMoon function below.
function journeyToMoon(n, astronaut) {
  if (astronaut.length == 0) {
    return calculateFactorial(n);
  }
  let sameCountryCounts = getSameCountryCounts(n, astronaut);
  if (sameCountryCounts.length <= 1) {
    return 0;
  }
  let result = sameCountryCounts[0] * sameCountryCounts[1];
  let sumOfPrevious = sameCountryCounts[0] + sameCountryCounts[1];
  for (let i = 2; i < sameCountryCounts.length; i++) {
    result += sumOfPrevious * sameCountryCounts[i];
    sumOfPrevious += sameCountryCounts[i];
  }
  return result;
}

function main() {
  const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

  const np = readLine().split(" ");

  const n = parseInt(np[0], 10);

  const p = parseInt(np[1], 10);

  let astronaut = Array(p);

  for (let i = 0; i < p; i++) {
    astronaut[i] = readLine()
      .split(" ")
      .map(astronautTemp => parseInt(astronautTemp, 10));
  }

  let result = journeyToMoon(n, astronaut);

  ws.write(result + "\n");

  ws.end();
}
