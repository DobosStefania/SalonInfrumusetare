using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SalonInfrumusetare.Models;

namespace SalonInfrumusetare.Data
{
    public class ServiciuDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ServiciuDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Serviciu>().Wait();
        }
        public Task<List<Serviciu>> GetServiciuAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }
        public Task<Serviciu> GetServiciuAsync(int id)
        {
            return _database.Table<Serviciu>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveServiciuAsync(Serviciu slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu slist)
        {
            return _database.DeleteAsync(slist);
        }


    }
}
