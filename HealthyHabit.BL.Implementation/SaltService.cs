using HealthyHabit.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HealthyHabit.BL.Implementation
{
    public class SaltService : ISaltService
    {
        public string Generate()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}
