using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppilication.Repository.Models;

namespace TestAppilication.Repository
{
    public interface BankInterface
    {
        Task<IEnumerable<TblBank>> Get();
        Task<TblBank> Get(int Id);
        Task<TblBank> Create(TblBank Bank);
        Task Update(TblBank Bank);
        Task Delete (int Id);
    }
}
