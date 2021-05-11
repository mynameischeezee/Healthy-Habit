using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.DAL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using HealthyHabit.ViewModel;

namespace HealthyHabit.Tests
{
    public class HashTests
    {
        
        [Fact]
        public void HashTestStringIsEqualsToTestString()
        {
            IHashService hash = new HashService();
            Assert.Equal("TestString",hash.DeHash(hash.Hash("TestString")));
        }
    }
}
