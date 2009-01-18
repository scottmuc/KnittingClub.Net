namespace KnittingClub.DataAccess
{
    public interface IRepository<T>
    {
        T GetById(object id);
        T[] GetAll();

        void Save(T entity);
        void Update(T entity);
    }
}