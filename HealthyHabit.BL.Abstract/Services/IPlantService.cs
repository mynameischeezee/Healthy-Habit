namespace HealthyHabit.BL.Abstract
{
    public interface IPlantService<Datacontext, TPlant>
    where Datacontext : class
    where TPlant : class
    {
        void Create(Datacontext datacontext, string previewpath, string stage0path, string stage1path, string stage2path, string stage3path, string stage4path, string stage5path, string stage6path, string stage7path, string name);
        void Remove(Datacontext datacontext, TPlant Plant);
        void Change(Datacontext datacontext, string previewpath, string stage0path, string stage1path, string stage2path, string stage3path, string stage4path, string stage5path, string stage6path, string stage7path, string name);
    }
}
