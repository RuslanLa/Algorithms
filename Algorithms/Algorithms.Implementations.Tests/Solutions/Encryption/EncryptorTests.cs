using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Implementations.Solutions.Encryption;
using Shouldly;
using Xunit;

namespace Algorithms.Implementations.Tests.Solutions.Encryption
{
    public class EncryptorTests
    {
        private readonly  Encryptor _encryptor = new Encryptor();

        [Theory]
        [InlineData("if man was meant to stay on the ground god would have given us roots", "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau")]
        [InlineData("chillout", "clu hlt io")]
        public void Encrypt(string input, string expected)
        {
            _encryptor.Encrypt(input).ShouldBe(expected);
        }
    }
}
