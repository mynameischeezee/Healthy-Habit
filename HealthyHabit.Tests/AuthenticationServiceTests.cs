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
    public class AuthenticationServiceTests
    {
        private IAuthenticationService<SystemContextSQL> AuthenticationService;

        [Fact]
        public void RegisterLoginTest()
        {

        }
    }
}
