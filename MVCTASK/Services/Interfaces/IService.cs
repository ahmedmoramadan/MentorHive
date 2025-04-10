namespace MVCTASK.Services.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        void delete(int id);
        T GetbyId(int id);
        int save();
    }
}
