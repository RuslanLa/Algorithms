using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.BreadCrumb;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.BreadCrumb
{
    public class BreadCrumbGeneratorTests
    {
        private readonly BreadCrumbGenerator _breadCrumbGenerator;

        public BreadCrumbGeneratorTests()
        {
            _breadCrumbGenerator = new BreadCrumbGenerator();
        }
        [Theory]
        [InlineData("mysite.com/pictures/holidays.html", " : ", "<a href=\"/\">HOME</a> : <a href=\"/pictures/\">PICTURES</a> : <span class=\"active\">HOLIDAYS</span>")]
        [InlineData("www.codewars.com/users/GiacomoSorbi?ref=CodeWars", " / ", "<a href=\"/\">HOME</a> / <a href=\"/users/\">USERS</a> / <span class=\"active\">GIACOMOSORBI</span>")]
        [InlineData("www.very-long-site_name-to-make-a-silly-yet-meaningful-example.com/users/giacomo-sorbi",
            " + ", "<a href=\"/\">HOME</a> + <a href=\"/users/\">USERS</a> + <span class=\"active\">GIACOMO SORBI</span>")]
        [InlineData("http://linkedin.it/files/kamehameha-transmutation-from/login.asp?rank=recent_first&hide=sold", 
            " - ",
           "<a href=\"/\">HOME</a> - <a href=\"/files/\">FILES</a> - <a href=\"/files/kamehameha-transmutation-from/\">KAMEHAMEHA TRANSMUTATION FROM</a> - <span class=\"active\">LOGIN</span>")]
        [InlineData("http://agcpartners.co.uk/skin-meningitis-of-bioengineering-insider-research/#conclusion", 
            " : ",
            "<a href=\"/\">HOME</a> : <span class=\"active\">SMBIR</span>")]
        public void Generate(string url, string separator, string result)
        {
            var actual = _breadCrumbGenerator.Generate(url, separator);
            actual.ShouldBe(result);
        }
    }
}
