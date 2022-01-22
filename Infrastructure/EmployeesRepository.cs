using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.Infrastructure
{
    public class EmployeesRepository : ICRUDRepository<Employees, int>
    {
        EmployeeDbContext _db;

        public EmployeesRepository(EmployeeDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Employees> GetAll()
        {
            return _db.Employee.ToList();
        }

        public Employees GetDetails(int id)
        {
             return _db.Employee.FirstOrDefault(c=>c.EmployeeId==id);
        }
        public void Create(Employees item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var obj = _db.Employee.FirstOrDefault(c=>c.EmployeeId==id);
            if(obj==null)
                return;
            _db.Employee.Remove(obj);
            _db.SaveChanges();
        }

        public void update(Employees item)
        {
             var obj = _db.Employee.FirstOrDefault(c=>c.EmployeeId==item.EmployeeId);
            if(obj==null)
                return;
            obj.LastName=item.LastName;
            obj.FirstName= item.FirstName;
            obj.BirthDate=item.BirthDate;
            obj.HireDate=item.HireDate;
            obj.Address=item.Address;
            obj.City=item.City;
            obj.Region=item.Region;
            obj.PostalCode=item.PostalCode;
            obj.Country=item.Country;
            obj.HomePhone=item.HomePhone;
            obj.DepartmentId=item.DepartmentId;
            obj.ProjectId=item.ProjectId;
            _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

        }
    }
}