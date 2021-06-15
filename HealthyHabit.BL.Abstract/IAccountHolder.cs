namespace HealthyHabit.BL.Abstract
{
    public interface IAccountHolder<User>
    where User : class
    {
        void SetUser(User user);
        User GetUser();
    }
}
