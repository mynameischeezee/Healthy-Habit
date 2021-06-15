namespace HealthyHabit.BL.Abstract
{
    public interface IAuthenticationService<Datacontext>
    where Datacontext : class
    {
        void Login(Datacontext datacontext, string username, string password);
        void Register(Datacontext datacontext, string name, string username, string mail, string password);
    }
}
