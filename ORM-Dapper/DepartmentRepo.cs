using System;
using Dapper;

namespace ORM_Dapper
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly System.Data.IDbConnection _conn;

        public DepartmentRepo(System.Data.IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@newDepartmentName)", new { newDepartmentName });
        }
    }
}

