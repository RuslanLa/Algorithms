"use strict";

/**Solution for the Hackerrank Issue https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem */

const fs = require("fs");

process.stdin.resume();
process.stdin.setEncoding("utf-8");

let inputString = "";
let currentLine = 0;

process.stdin.on("data", inputStdin => {
  inputString += inputStdin;
});

process.stdin.on("end", _ => {
  inputString = inputString
    .replace(/\s*$/, "")
    .split("\n")
    .map(str => str.replace(/\s*$/, ""));

  main();
});

function readLine() {
  return inputString[currentLine++];
}

function prepareFrequenciesArray(expenditure, d) {
  const counts = Array.from({ length: 201 }, () => 0);
  for (let i = 0; i < d; i++) {
    counts[expenditure[i]]++;
  }
  return counts;
}

function findMedianFromFrequencies(counts, count) {
  let middle = Math.ceil(count / 2);
  let firstMiddle;
  let isEven = count % 2 == 0;
  let sum = 0;
  for (let i = 0; i < counts.length; i++) {
    if (counts[i] == 0) {
      continue;
    }
    sum += counts[i];
    if (isEven && sum === middle) {
      firstMiddle = i;
      continue;
    }
    if (sum < middle) {
      continue;
    }
    if (firstMiddle) {
      return (firstMiddle + i) / 2;
    }
    return i;
  }
}

function recalculateFrequencies(counts, prevValue, newValue) {
  counts[prevValue]--;
  counts[newValue]++;
  return counts;
}

// Entry function
function activityNotifications(expenditure, d) {
  let frequencies = prepareFrequenciesArray(expenditure, d);
  let median = findMedianFromFrequencies(frequencies, d);

  let counter = 0;
  for (let i = d; i < expenditure.length; i++) {
    if (expenditure[i] >= median * 2) {
      counter++;
    }
    frequencies = recalculateFrequencies(
      frequencies,
      expenditure[i - d],
      expenditure[i]
    );
    median = findMedianFromFrequencies(frequencies, d);
  }
  return counter;
}

function main() {
  const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

  const nd = readLine().split(" ");

  const n = parseInt(nd[0], 10);

  const d = parseInt(nd[1], 10);

  const expenditure = readLine()
    .split(" ")
    .map(expenditureTemp => parseInt(expenditureTemp, 10));

  let result = activityNotifications(expenditure, d);

  ws.write(result + "\n");

  ws.end();
}
