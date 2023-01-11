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
            _database.CreateTableAsync<TipServiciu>().Wait();
            _database.CreateTableAsync<ListaServiciu>().Wait();
        }
        public Task<int> SaveServiciuAsync(Serviciu serviciu)
        {
            if (serviciu.ID != 0)
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }
        public Task<List<Serviciu>> GetServiciuAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }

        internal Task SaveListaServiciuAsync(ListaServiciu ls)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveListaServiciutAsync(ListaServiciu listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<ListaServiciu>> GetListaServiciuAsync(int shoplistid)
        {
            return _database.QueryAsync<ListaServiciu>(
            "select S.ID, S.Description from Serviciu P"
            + " inner join ListaServiciu LS"
            + " on S.ID = LS.ProductID where LS.ShopListID = ?",shoplistid);
        }

        internal Task DeleteListaServiciuAsync(ListaServiciu slist)
        {
            throw new NotImplementedException();
        }
    }
}

