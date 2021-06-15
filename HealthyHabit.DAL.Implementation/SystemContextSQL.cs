using HealthyHabit.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HealthyHabit.DAL.Implementation
{
    public class SystemContextSQL : DbContext
    {
        public DbSet<Habit> Habit { get; set; }
        public DbSet<HabitCompleteDate> HabitCompleteDate { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserHabit> UserHabit { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public SystemContextSQL(DbContextOptions<SystemContextSQL> options) : base(options)
        {
            Database.EnsureCreated();
            this.AddColors();
            this.AddFlowers();
        }
        private void AddColors()
        {
            if (this.Colors.ToList().Count == 0)
            {
                this.Colors.Add(new Color("#574b90", "Фіолетовий"));
                this.Colors.Add(new Color("#e66767", "Рожевий"));
                this.Colors.Add(new Color("#63cdda", "Голубий"));
                this.Colors.Add(new Color("#f5cd79", "Жовтий"));
                this.Colors.Add(new Color("#f19066", "Помаранчевий"));
            }
            this.SaveChanges();
        }
        private void AddFlowers()
        {
            if (this.Plants.ToList().Count == 0)
            {
                this.Plants.Add(new Plant(
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_preview.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage0.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage1.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage2.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage3.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage4.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage5.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage6.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage7.png",
                    "https://raw.githubusercontent.com/mynameischeezee/Healthy-Habit/master/HealthyHabit.View/.FlowersImages/Sunflower_test/sunflower_stage1.png",
                    "Sunflower"));
            }
            this.SaveChanges();
        }
    }
}
