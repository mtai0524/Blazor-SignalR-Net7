using BlazorServer.Data;
using BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _ctx;
        public PersonService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public bool AddUpdate(Person person)
        {
            try
            {
                if (person.Id == 0)
                    _ctx.Person.Add(person);
                else
                    _ctx.Person.Update(person);
                _ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Person>> GetAllAsync()
        {
            // Lấy danh sách người từ cơ sở dữ liệu hoặc nguồn dữ liệu của bạn
            return await _ctx.Person.ToListAsync(); // Đây chỉ là một ví dụ, thực hiện theo cách của bạn
        }

        public bool Delete(int id)
        {
            try
            {
                var person = FindById(id);
                if (person == null)
                    return false;
                _ctx.Person.Remove(person);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Person FindById(int id)
        {
            return _ctx.Person.Find(id);
        }

        public List<Person> GetAll()
        {
            return _ctx.Person.ToList();
        }
    }
}
