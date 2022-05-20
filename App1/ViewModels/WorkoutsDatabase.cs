using App1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class WorkoutsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public WorkoutsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Workout>().Wait();
        }

        public Task<List<Workout>> GetWorkoutAsync()
        {
            return _database.Table<Workout>().ToListAsync();
        }
        public Task<Workout> GetWorkoutAsync(int id)
        {
            return _database.Table<Workout>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveWorkoutAsync(Workout wlist)
        {
            if (wlist.Id != 0)
            {
                return _database.UpdateAsync(wlist);
            }
            else
            {
                return _database.InsertAsync(wlist);
            }
        }
        public Task<int> DeleteWorkoutAsync(Workout wlist)
        {
            return _database.DeleteAsync(wlist);
        }
    }
}
