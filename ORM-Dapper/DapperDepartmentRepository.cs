using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM Departments;").ToList();
        }


        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
new { departmentName = newDepartmentName });
        }

    }
}
