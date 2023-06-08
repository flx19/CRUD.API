using One.HR.DataAccess;

namespace one.hr.api.Services
{
    public interface IGenericCRUDService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);

        public Task<T> Create(T T);
        public Task<T> Update(int id, T T);
        public Task<bool> Delete(int id);
    }
}
