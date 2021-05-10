using HealthyHabit.DAL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.BL.Abstract;
using HealthyHabit.BL.Implementation;
using HealthyHabit.Models;
using HealthyHabit.ViewModel.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Wpf.Core;

namespace HealthyHabit.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public string CompanyLabel { get => "Healthy habbit"; }
        public DbContext SystemContext { get; private set; }
        public IAuthenticationService<SystemContextSQL> authenticationService { get; private set; }



        public LoginViewModel(SystemContextSQL context, IAuthenticationService<SystemContextSQL> authenticationService)
        {
            this.SystemContext = context;
            this.authenticationService = authenticationService;
        }
    }
}
