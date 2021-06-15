using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyHabit.Models
{
    public class UserHabit : ModelTemplate
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(nameof(HabitId))]
        public Habit Habit { get; set; }
        public int? HabitId { get; set; }
        public UserHabit()
        {

        }
        public UserHabit(User user, Habit habit)
        {
            this.User = user;
            this.Habit = habit;
        }
    }
}
