using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveUserAsync(User ulist)
        {
                return _database.InsertAsync(ulist);
            
        }
        public Task<int> DeleteUserAsync(User ulist)
        {
            return _database.DeleteAsync(ulist);
        }
    }
}
