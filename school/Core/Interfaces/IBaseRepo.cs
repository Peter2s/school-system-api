using school.Core.Models;
using System.Collections.Generic;

namespace school.Core.Interfaces
{
    public interface IBaseRepo<T> where T : BaseModel
    {
        public Task<IReadOnlyList<T>> getList(int page, int limit);
        public Task<IReadOnlyList<T>> getList();
        public Task<IReadOnlyList<T>> AddMany(List<T> rows);
        public int getCount();
    }
}
