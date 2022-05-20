using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class MealsDatabase 
    {
        readonly SQLiteAsyncConnection _database;

        public MealsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Meal>().Wait();
        }

        public Task<List<Meal>> GetMealAsync()
        {
            return _database.Table<Meal>().ToListAsync();
        }
        public Task<Meal> GetMealAsync(int id)
        {
            return _database.Table<Meal>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveMealAsync(Meal mlist)
        {
            if (mlist.Id != 0)
            {
                return _database.UpdateAsync(mlist);
            }
            else
            {
                return _database.InsertAsync(mlist);
            }
        }
        public Task<int> DeleteMealAsync(Meal mlist)
        {
            return _database.DeleteAsync(mlist);
        }

        

        
    }
}
