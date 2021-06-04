using HealthyHabit.BL.Abstract;
using HealthyHabit.DAL.Implementation;
using HealthyHabit.Models;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HealthyHabit.BL.Implementation.Class
{
    /// <summary>
    /// Class for generic itemlist on main menu for RadioButton + Label area.
    /// </summary>
    public class MarkHabitUnit
    {
        public string DateStringFormat { get; set; }
        public HabitCompleteDate habitCompleteDate { get; set; }
        public IHabitCompleteDateService<SystemContextSQL,Habit,HabitCompleteDate> HabitCompleteDateService { get; set; }
        public SystemContextSQL systemContextSQL { get; set; }
        public bool IsMarked { get; set; }
        public MarkHabitUnit(SystemContextSQL systemContextSQL,HabitCompleteDate habitComplete, string FormatedDate, bool isMarked, IHabitCompleteDateService<SystemContextSQL, Habit, HabitCompleteDate> habitCompleteDateService)
        {
            this.DateStringFormat = FormatedDate;
            this.habitCompleteDate = habitComplete;
            this.IsMarked = isMarked;
            this.HabitCompleteDateService = habitCompleteDateService;
            this.systemContextSQL = systemContextSQL;
        }
        public ICommand TestCommand
        {
            get { return new DelegateCommand<object>(_TestCommand, SureUCan); }
        }
        private void _TestCommand(object param)
        {
            this.HabitCompleteDateService.AddProgress(systemContextSQL,this.habitCompleteDate.Habit, new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(DateStringFormat)));
            //else
            //{
            //    this.IsMarked = false;
            //    this.HabitCompleteDateService.Remove(systemContextSQL, habitCompleteDate);
            //}
        }
        private bool SureUCan(object param)
        {
            return true;
        }
    }
}
