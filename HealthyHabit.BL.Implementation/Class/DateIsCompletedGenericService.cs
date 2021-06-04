using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace HealthyHabit.BL.Implementation.Class
{
    public class DateIsCompletedGenericService
    {
        public SystemContextSQL systemContext { get; set; }
        public IHabitCompleteDateService<SystemContextSQL, Habit, HabitCompleteDate> HabitCompleteDateService { get; set; }
        public IHabitService<SystemContextSQL, User, Habit, Color, Plant> HabitService { get; set; }
        public IUserHabitService<SystemContextSQL, User, Habit> UserHabitService { get; set; }
        public IAccountHolder<User> Account { get; set; }
        public DateIsCompletedGenericService(SystemContextSQL systemContextSQL, IHabitCompleteDateService<SystemContextSQL, Habit, HabitCompleteDate> habitCompleteDateService, IHabitService<SystemContextSQL, User, Habit, Color, Plant> habitService, IUserHabitService<SystemContextSQL, User, Habit> userHabitService)
        {
            this.systemContext = systemContextSQL;
            this.HabitCompleteDateService = habitCompleteDateService;
            this.HabitService = habitService;
            this.UserHabitService = userHabitService;
            this.Account = new AccountHolder();
        }
        public ObservableCollection<DateIsCompletedGeneric> InitiAlizeGenericUnit()
        {
            ObservableCollection<DateIsCompletedGeneric> dateIsCompletedGenerics = new ObservableCollection<DateIsCompletedGeneric>();
            List<Habit> habits = UserHabitService.GetHabitsByUser(systemContext, Account.GetUser());
            foreach (Habit loophabit in habits)
            {
                DateIsCompletedGeneric dateIsCompletedGeneric = new DateIsCompletedGeneric(loophabit);
                List<HabitCompleteDate> HabitCompleteDateList = HabitCompleteDateService.GetAllForHabit(systemContext, loophabit);
                if (HabitCompleteDateList.Count < 7)
                {
                    var aboba = HabitCompleteDateList;
                    dateIsCompletedGeneric.FirstPartUnits = SetFirstPart(HabitCompleteDateList, loophabit);
                    dateIsCompletedGeneric.CurrentPartUnits = dateIsCompletedGeneric.FirstPartUnits;
                }
                else if (HabitCompleteDateList.Count >= 14)
                {
                    dateIsCompletedGeneric.FirstPartUnits = SetFirstPart(HabitCompleteDateList, loophabit);
                    dateIsCompletedGeneric.SecondPartUnits = SetSecondPart(HabitCompleteDateList, loophabit);
                    dateIsCompletedGeneric.ThirdPartUnits = SetThirdPart(HabitCompleteDateList, loophabit);
                    dateIsCompletedGeneric.CurrentPartUnits = dateIsCompletedGeneric.ThirdPartUnits;
                }
                else if (HabitCompleteDateList.Count >= 7 && HabitCompleteDateList.Count < 15)
                {
                    dateIsCompletedGeneric.FirstPartUnits = SetFirstPart(HabitCompleteDateList, loophabit);
                    dateIsCompletedGeneric.SecondPartUnits = SetSecondPart(HabitCompleteDateList,loophabit);
                    dateIsCompletedGeneric.CurrentPartUnits = dateIsCompletedGeneric.SecondPartUnits;
                }

                dateIsCompletedGenerics.Add(dateIsCompletedGeneric);
            }
            return dateIsCompletedGenerics;
        }
        private List<MarkHabitUnit> SetFirstPart(List<HabitCompleteDate> habits, Habit habit)
        {
            List<MarkHabitUnit> markHabitUnitsFirst = new List<MarkHabitUnit>();
            for (int i = 0; i <= 6; i++)
            {
                try
                {
                    if (habits[i] == null)
                    {
                        markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext,new HabitCompleteDate(habit), habit.DateCreated.AddDays(i * habit.Frequency).ToString("dd", new CultureInfo("uk-UA")),false,HabitCompleteDateService));
                    }
                    else
                    {
                        markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, habits[i], habits[i].CompleteDate.ToString("dd", new CultureInfo("uk-UA")), true, HabitCompleteDateService));
                    }
                }
                catch
                {
                    markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, new HabitCompleteDate(habit), habit.DateCreated.AddDays(i * habit.Frequency).ToString("dd", new CultureInfo("uk-UA")), false, HabitCompleteDateService));
                }
            }
            return markHabitUnitsFirst;
        }
        private List<MarkHabitUnit> SetSecondPart(List<HabitCompleteDate> habits, Habit habit)
        {
            List<MarkHabitUnit> markHabitUnitsFirst = new List<MarkHabitUnit>();
            for (int i = 7; i <= 13; i++)
            {
                try
                {
                    if (habits[i] == null)
                    {
                        markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, new HabitCompleteDate(habit), habit.DateCreated.AddDays(i * habit.Frequency).ToString("dd", new CultureInfo("uk-UA")), false, HabitCompleteDateService));
                    }
                    else
                    {
                        markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, habits[i], habits[i].CompleteDate.ToString("dd", new CultureInfo("uk-UA")), true, HabitCompleteDateService));
                    }
                }
                catch
                {
                    markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, new HabitCompleteDate(habit), habit.DateCreated.AddDays(i * habit.Frequency).ToString("dd", new CultureInfo("uk-UA")), false, HabitCompleteDateService));
                }
            }
            return markHabitUnitsFirst;
        }
        private List<MarkHabitUnit> SetThirdPart(List<HabitCompleteDate> habits, Habit habit)
        {
            List<MarkHabitUnit> markHabitUnitsFirst = new List<MarkHabitUnit>();
            for (int i = 14; i <= 20; i++)
            {
                try
                {
                    if (habits[i] == null)
                    {
                        markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, new HabitCompleteDate(habit), habit.DateCreated.AddDays(i * habit.Frequency).ToString("dd", new CultureInfo("uk-UA")), false, HabitCompleteDateService));
                    }
                    else
                    {
                        markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, habits[i], habits[i].CompleteDate.ToString("dd", new CultureInfo("uk-UA")), true, HabitCompleteDateService));
                    }
                }
                catch
                {
                    markHabitUnitsFirst.Add(new MarkHabitUnit(systemContext, new HabitCompleteDate(habit), habit.DateCreated.AddDays(i * habit.Frequency).ToString("dd", new CultureInfo("uk-UA")), false, HabitCompleteDateService));
                }
            }
            return markHabitUnitsFirst;
        }

    }
}
