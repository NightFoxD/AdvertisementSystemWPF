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
        public readonly SQLiteAsyncConnection _database;
        public DataAccess(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Announcment>().Wait();
            _database.CreateTableAsync<Models.Application>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<Company>().Wait();
            _database.CreateTableAsync<ContractType>().Wait();
            _database.CreateTableAsync<Course>().Wait();
            _database.CreateTableAsync<Education>().Wait();
            _database.CreateTableAsync<Experience>().Wait();
            _database.CreateTableAsync<Language>().Wait();
            _database.CreateTableAsync<Link>().Wait();
            _database.CreateTableAsync<PositionLevel>().Wait();
            _database.CreateTableAsync<Saved>().Wait();
            _database.CreateTableAsync<Skill>().Wait();
            _database.CreateTableAsync<SubCategory>().Wait();
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<UserData>().Wait();
            _database.CreateTableAsync<WorkTime>().Wait();
            _database.CreateTableAsync<WorkType>().Wait();
        }    
        //--------- Announcment ---------//
        public List<Announcment> GetAnnouncmentList()
        {
            return _database.Table<Announcment>().ToListAsync().Result;
        }
        public List<Announcment> GetAnnouncmentList(Company company)
        {
            return _database.Table<Announcment>().Where(item=>item.CompanyID == company.CompanyID).ToListAsync().Result;
        }
        public Task Add_Announcment(Announcment announcment)
        {
            return _database.InsertAsync(announcment);
        }
        public Task Update_Announcment(Announcment announcment)
        {
            return _database.UpdateAsync(announcment);
        }
        public Task Delete_Announcment(Announcment announcment)
        {
            return _database.DeleteAsync(announcment);
        }
        //--------- Application ---------//
        public List<Models.Application> GetApplicationList()
        {
            return _database.Table<Models.Application>().ToListAsync().Result;
        }
        public List<Models.Application> GetApplicationList(AnnouncmentItem announcment)
        {
            return _database.Table<Models.Application>().Where(item=>item.AnnouncmentID == announcment.AnnouncmentID).ToListAsync().Result;
        }
        public List<Models.Application> GetApplicationList(User user)
        {
            return _database.Table<Models.Application>().Where(item=>item.UserID == user.UserID).ToListAsync().Result;
        }
        public int Add_Application(Models.Application application)
        {
            return _database.InsertAsync(application).Result;
        }
        public Task Update_Application(Models.Application application)
        {
            return _database.UpdateAsync(application);
        }
        public int Delete_Application(Models.Application application)
        {
            return _database.DeleteAsync(application).Result;
        }
        //--------- Category ---------//
        public List<Category> GetCategoryList()
        {
            return _database.Table<Category>().ToListAsync().Result;
        }
        public int Add_Category(Category category)
        {
            return _database.InsertAsync(category).Result;
        }
        public Task Update_Category(Category category)
        {
            return _database.UpdateAsync(category);
        }
        public Task Delete_Category(Category category)
        {
            return _database.DeleteAsync(category);
        }
        //--------- Company ---------//
        public List<Company> GetCompanyList()
        {
            return _database.Table<Company>().ToListAsync().Result;
        }
        public Company GetCompany(string Login, string Password)
        {
            try
            {
                return _database.Table<Company>().Where(item => item.Login == Login && item.Password == Password).FirstAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public Company GetCompany(string Login)
        {
            
            try
            {
                return _database.Table<Company>().Where(item => item.Login == Login).FirstOrDefaultAsync(null).Result;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public Company GetCompanyFromID(int id)
        {
            return _database.Table<Company>().Where(item => item.CompanyID == id).FirstAsync().Result;
        }
        public int Add_Company(Company company)
        {
            return _database.InsertAsync(company).Result;
        }
        public Task Update_Company(Company company)
        {
            return _database.UpdateAsync(company);
        }
        public Task Delete_Company(Company company)
        {
            return _database.DeleteAsync(company);
        }
        //--------- ContractType ---------//
        public List<ContractType> GetContractList()
        {
            return _database.Table<ContractType>().ToListAsync().Result;
        }
        public int Add_ContractType(ContractType item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_ContractType(ContractType item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_ContractType(ContractType item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- Course ---------//
        public Task<List<Course>> GetCourseList()
        {
            return _database.Table<Course>().ToListAsync();
        }
        public Task Add_Course(Course course)
        {
            return _database.InsertAsync(course);
        }
        public Task Update_Course(Course course)
        {
            return _database.UpdateAsync(course);
        }
        public Task Delete_Course(Course course)
        {
            return _database.DeleteAsync(course);
        }
        //--------- Education ---------//
        public Task<List<Education>> GetEducationList()
        {
            return _database.Table<Education>().ToListAsync();
        }
        public Task<List<Education>> GetEducationList(User user)
        {
            return Task.FromResult(_database.Table<Education>().Where(item => item.UserID == user.UserID).ToListAsync().Result);
        }
        public int Add_Education(Education education)
        {
            return _database.InsertAsync(education).Result;
        }
        public int Add_Education(Education education, User user)
        {
            education.UserID = user.UserID;
            return _database.InsertAsync(education).Result;
        }
        public Task Update_Education(Education education)
        {
            return _database.UpdateAsync(education);
        }
        public int Delete_Education(Education education)
        {
            return _database.DeleteAsync(education).Result;
        }
        //--------- Experience ---------//
        public Task<List<Experience>> GetExperienceList()
        {
            return _database.Table<Experience>().ToListAsync();
        }
        public Task<List<Experience>> GetExperienceList(User user)
        {
            return Task.FromResult(_database.Table<Experience>().Where(experience=> experience.UserID == user.UserID).ToListAsync().Result);
        }
        public Task<Experience> GetUserExperience(int id)
        {
            return Task.FromResult(_database.Table<Experience>().Where(experience => experience.UserID == id).ToListAsync().Result.First());
        }
        public int Add_Experience(Experience experience,User user)
        {
            experience.UserID = user.UserID;
            return _database.InsertAsync(experience).Result;
        }
        public Task Update_Experience(Experience experience)
        {
            return _database.UpdateAsync(experience);
        }
        public int Delete_Experience(Experience experience)
        {
            return _database.DeleteAsync(experience).Result;
        }
        //--------- Language ---------//
        public Task<List<Language>> GetLanguageList()
        {
            return _database.Table<Language>().ToListAsync();
        }
        public Task<List<Language>> GetLanguageList(User user)
        {
            return Task.FromResult(_database.Table<Language>().Where(item => item.UserID == user.UserID).ToListAsync().Result);
        }
        public int Add_Language(Language language)
        {
            return _database.InsertAsync(language).Result;
        }
        public int Add_Language(Language language,User user)
        {
            language.UserID = user.UserID;
            return _database.InsertAsync(language).Result;
        }
        public Task Update_Language(Language language)
        {
            return _database.UpdateAsync(language);
        }
        public int Delete_Language(Language language)
        {
            return _database.DeleteAsync(language).Result;
        }
        //--------- Link ---------//
        public Task<List<Link>> GetLinkList()
        {
            return _database.Table<Link>().ToListAsync();
        }
        public Task<List<Link>> GetLinkList(User user)
        {
            return Task.FromResult(_database.Table<Link>().Where(item => item.User == user.UserID).ToListAsync().Result);
        }
        public Task Add_Link(Link link)
        {
            return _database.InsertAsync(link);
        }
        public int Add_Link(Link link,User user)
        {
            link.User = user.UserID;
            return _database.InsertAsync(link).Result;
        }
        public Task Update_Link(Link link)
        {
            return _database.UpdateAsync(link);
        }
        public int Delete_Link(Link link)
        {
            return _database.DeleteAsync(link).Result;
        }
        //--------- PositionLevel ---------//
        public List<PositionLevel> GetPositionLevelList()
        {
            return _database.Table<PositionLevel>().ToListAsync().Result;
        }
        public int Add_PositionLevel(PositionLevel item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_PositionLevel(PositionLevel item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_PositionLevel(PositionLevel item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- Saved ---------//
        public Task<List<Saved>> GetSavedList()
        {
            return _database.Table<Saved>().ToListAsync();
        }
        public Task Add_Saved(Saved saved)
        {
            return _database.InsertAsync(saved);
        }
        public Task Update_Saved(Saved saved)
        {
            return _database.UpdateAsync(saved);
        }
        public Task Delete_Saved(Saved saved)
        {
            return _database.DeleteAsync(saved);
        }
        //--------- Skill ---------//
        public Task<List<Skill>> GetSkillList()
        {
            return _database.Table<Skill>().ToListAsync();
        }
        public Task<List<Skill>> GetSkillList(User user)
        {
            return Task.FromResult(_database.Table<Skill>().Where(item => item.UserID == user.UserID).ToListAsync().Result);
        }
        public int Add_Skills(Skill skill)
        {
            return _database.InsertAsync(skill).Result;
        }
        public int Add_Skills(Skill skill,User user)
        {
            skill.UserID = user.UserID;
            return _database.InsertAsync(skill).Result;
        }
        public Task Update_Skills(Skill skill)
        {
            return _database.UpdateAsync(skill);
        }
        public Task Delete_Skills(Skill skill)
        {
            return _database.DeleteAsync(skill);
        }
        //--------- Subcategory ---------//
        public Task<List<SubCategory>> GetSubcategoryList()
        {
            return _database.Table<SubCategory>().ToListAsync();
        }
        public Task Add_SubCategory(SubCategory subCategory)
        {
            return _database.InsertAsync(subCategory);
        }
        public Task Update_SubCategory(SubCategory subCategory)
        {
            return _database.UpdateAsync(subCategory);
        }
        public Task Delete_SubCategory(SubCategory subCategory)
        {
            return _database.DeleteAsync(subCategory);
        }
        //--------- User ---------//
        public Task<List<User>> GetUserList()
        {
            return _database.Table<User>().ToListAsync();
        }
        public async void InserUser(UserData newUserData)
        {
            await _database.InsertAsync(new User());
            User newUser = GetUserList().Result.Last();
            newUser.UserDataID = newUserData.UserDataID;
            _database.UpdateAsync(newUser);

        }
        public Task UpdateUser(User user)
        {
            return _database.UpdateAsync(user);
        }
        public Task DelUser(User removeUser)
        {
            return _database.DeleteAsync(removeUser);
        }
        
        public Task<int> SavePersonAsync(User person)
        {
            return _database.InsertAsync(person);
        }
        
        //--------- UserData ---------//
        public Task<List<UserData>> GetUserDataList()
        {
            return _database.Table<UserData>().ToListAsync();
        }
        public int InsertUserData(UserData newUser)
        {
            return _database.InsertAsync(newUser).Result;
        }
        public Task UpdateUserData(UserData newUser)
        {
            return _database.UpdateAsync(newUser);
        }
        public void DelUserData(UserData removeUser)
        {
            _database.DeleteAsync(removeUser);
        }
        
        public bool SearchUser(string login)
        {
            if (_database.Table<UserData>().Where(user => user.Login == login).ToListAsync().Result.Count > 0)
            {
                return true;
            }
            return false;
        }
        public UserData SearchUser(string login, string password)
        {
            try
            {
                return _database.Table<UserData>().Where(user => user.Login == login && user.Password == password).FirstAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public UserData GetUserFromLogin(string login)
        {
            try
            {
                return _database.Table<UserData>().Where(user => user.Login == login).ToListAsync().Result.First();
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public User GetUserFromDataID(int? id)
        {
            try
            {
                return _database.Table<User>().Where(user => user.UserDataID == id).ToListAsync().Result.First();
            }
            catch (Exception)
            {
                return null;
            }

        }
        public User GetUserInformations(UserData user)
        {
            return _database.Table<User>().Where(item => item.UserDataID == user.UserDataID).ToArrayAsync().Result.First();
        }
        //--------- WorkTime ---------//
        public List<WorkTime> GetWorkTimeList()
        {
            return _database.Table<WorkTime>().ToListAsync().Result;
        }
        public int Add_WorkTime(WorkTime item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_WorkTime(WorkTime item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_WorkTime(WorkTime item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- WorkType ---------//
        public List<WorkType> GetWorkTypeList()
        {
            return _database.Table<WorkType>().ToListAsync().Result;
        }
        public int Add_WorkType(WorkType item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_WorkType(WorkType item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_WorkType(WorkType item)
        {
            return _database.DeleteAsync(item).Result;
        }
    }
}
