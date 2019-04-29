using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Models;

namespace Dapper.Repository
{
    public class StudentRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\АхметкалиА\source\repos\DapperLesson\Dapper.Repository\StudentsDB.mdf;Integrated Security=True";

        public string InsertStudent(string query, Student student)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, student);
                if (result < 1)
                    throw new Exception("Ошибка при вставке записи");
            }
            return "Вставка произошла успешно";
        }

        public List<Student> GetAllStudent(string query)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                return sql.Query<Student>(query).ToList();
            }
        }

        public int GetGroupId(string name)
        {
            using(var sql = new SqlConnection(connectionString))
            {
                return sql.Query<int>(@"Select id from Groups Wher Name = ")
            }

            return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
        }
    }
}
