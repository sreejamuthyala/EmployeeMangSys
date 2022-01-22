using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Infrastructure
{
    public class CompaniesRepository : ICRUDRepository<Companies, int>
    {
        CompanyDbContext _db;

        public CompaniesRepository(CompanyDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Companies> GetAll()
        {
            return _db.Company.ToList();
        }

        public Companies GetDetails(int id)
        {
             return _db.Company.FirstOrDefault(c=>c.CompanyId==id);
        }
        public void Create(Companies item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var obj = _db.Company.FirstOrDefault(c=>c.CompanyId==id);
            if(obj==null)
                return;
            _db.Company.Remove(obj);
            _db.SaveChanges();
        }

        public void update(Companies item)
        {
             var obj = _db.Company.FirstOrDefault(c=>c.CompanyId==item.CompanyId);
            if(obj==null)
                return;
            obj.CompanyName=item.CompanyName;
            obj.CompanyAddress=item.CompanyAddress;
            obj.City=item.City;
            obj.Country=item.Country;
            obj.PostalCode=item.PostalCode;
            _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

        }
    }
}