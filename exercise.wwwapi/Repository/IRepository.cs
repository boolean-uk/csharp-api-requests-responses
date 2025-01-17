namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        List<T> GetCollection();

        T GetEntity(string name);

        T AddEntity (T entity);

        T DeleteEntity (string name);

        T UpdateEntity (string name,string newfirstname,string newlastname);
        T UpdateEntity(string name, string newnname);






    }
}
