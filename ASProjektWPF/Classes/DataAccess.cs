using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ASProjektWPF.Models;

namespace ASProjektWPF.Classes
{
    public class DataAccess
    {
        readonly SQLiteAsyncConnection _database;

        public DataAccess(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AccountType>().Wait();
            _database.CreateTableAsync<Announcment>().Wait();
            _database.CreateTableAsync<Models.Application>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<Company>().Wait();
            _database.CreateTableAsync<Course>().Wait();
            _database.CreateTableAsync<Education>().Wait();
            _database.CreateTableAsync<Experience>().Wait();
            _database.CreateTableAsync<Language>().Wait();
            _database.CreateTableAsync<Link>().Wait();
            _database.CreateTableAsync<Saved>().Wait();
            _database.CreateTableAsync<Skill>().Wait();
            _database.CreateTableAsync<SubCategory>().Wait();
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<UserData>().Wait();
            _database.CreateTableAsync<WorkingDays>().Wait();
        }

        public Task<List<User>> GetPeopleAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SavePersonAsync(User person)
        {
            return _database.InsertAsync(person);
        }
        public Task<int> InsertUserData(UserData newUser)
        {
            MessageBox.Show(newUser.Login + newUser.Password + newUser.AccountTypeID + "");
            return _database.InsertAsync(newUser);
        }
        public bool SearchUser(string login)
        {
            if (_database.Table<UserData>().Where(user => user.Login == login).ToListAsync().Result.Count > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<UserData> GetUserFromLogin(string login)
        {
            return  _database.Table<UserData>().Where(user => user.Login == login).ToListAsync().Result.First();
        }
    }
}
