using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppilication.Repository.Models;

namespace TestAppilication.Repository
{
    public class BankRepository : BankInterface
    {
        private readonly WebApiDbContext _context;
        public BankRepository (WebApiDbContext context)
        {
            _context = context;
        }
        public  async Task<TblBank> Create(TblBank Bank)
        {
            _context.TblBanks.Add(Bank);
            await _context.SaveChangesAsync();
            return Bank;
        }

        public  async Task Delete(int Id)
        {
            var BankToDelete = await _context.TblBanks.FindAsync(Id);
            _context.TblBanks.Remove(BankToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TblBank>> Get()
        {
            //return await _context.TblBanks.ToListAsync();
            return _context.TblBanks.FromSqlRaw<TblBank>("proc_getBanks").ToList();
        }

        public async Task<TblBank> Get(int Id)
        {
            return _context.TblBanks.FromSqlRaw<TblBank>("proc_getBank", Id).ToList().FirstOrDefault();
            //return await _context.TblBanks.FindAsync(Id);
        }

        public async Task Update(TblBank Bank)
        {
            _context.Entry(Bank).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
