using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeepLClient.Extensions
{
    internal static class HashExtensions
    {
        /// <summary>
        /// Hashes the provided input
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static string GetHash(this HashAlgorithm hashAlgorithm, string input)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-7.0
            var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (var t in data) sBuilder.Append(t.ToString("x2"));
            return sBuilder.ToString();
        }
    }
}
