using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.Implementations.Solutions.BreadCrumb
{
    /// <summary>
    /// Solution for https://www.codewars.com/kata/563fbac924106b8bf7000046/csharp
    /// </summary>
    public class BreadCrumbGenerator
    {
        private class Crumb
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        private readonly string _template = "<a href=\"{0}/\">{1}</a>";
        private readonly string _homeSpan = "<span class=\"active\">HOME</span>";
        private readonly string _homeA = "<a href=\"/\">HOME</a>";
        private readonly string _lastTemplate = "<span class=\"active\">{0}</span>";
        private static readonly Regex _expression  = new Regex("^(((ht|f)tp(s?))://)?(www.)?[a-zA-Z0-9-._]+\\.[a-z]{2,3}/((?<part>(?!index)[a-zA-Z0-9-]+)(/)?(\\.(html|htm|php|asp))?)*(\\#[a-zA-Z0-9-.])?(\\?[a-zA-Z0-9-.=&])?");
        public string Generate(string url, string separator)
        {
            var parts = GetPreparedParts(url).ToArray();
            if (parts.Length == 0)
            {
                return _homeSpan;
            }
            IEnumerable<string> prefix = new []{ _homeA };
            if (parts.Length > 1)
            {
                prefix = prefix.Concat(parts.Take(parts.Length - 1).Select(ToInactiveHtmlElement));
            }

            var last = parts.Last();
            var postFix = String.Format(_lastTemplate, last.Name);
            return String.Join(separator, prefix.Concat(new []{ postFix }));
        }

        private string ToInactiveHtmlElement(Crumb crumb) => String.Format(_template, crumb.Url, crumb.Name);

        private IEnumerable<Crumb> GetPreparedParts(string url) => PrepareParts(GetParts(url));

        private IEnumerable<Crumb> PrepareParts(IEnumerable<Crumb> parts)
        {
            return parts.Select(x => new Crumb()
            {
                Name = Acronomize(SplitWords(ToUpperCase(x.Name))),
                Url = x.Url
            });
        }

        private string SplitWords(string part) => part.Replace("-", " ");
        private string ToUpperCase(string part) => part.ToUpper();

        private string Acronomize(string word)
        {
            if (word.Length <= 30 || !word.Contains(" "))
            {
                return word;
            }

            return Regex.Replace(word, @"(?!\b)[a-zA-Z]|\s|((THE|OF|IN|FROM|BY|WITH|AND|OR|FOR|TO|AT|A)(\s|$))", String.Empty);
        }

        private IEnumerable<Crumb> GetParts(string url)
        {
            var group = _expression.Match(url).Groups["part"].Captures;
            var prev = String.Empty;
            foreach (var capture in group)
            {
                var value = ((Capture) capture).Value;
                yield return new Crumb()
                {
                    Name = ((Capture) capture).Value,
                    Url = prev += $"/{value}"
                };
            }
        }
    }
}
