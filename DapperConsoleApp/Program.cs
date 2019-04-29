using Dapper.Models;
using Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //StudentRepository _userRep = new StudentRepository();
            //do
            //{
            //    _userRep.InsertStudent(@"INSERT INTO Students (FirstName, LastName, MiddleName, GroupId) values
            //                            (@FirstName, @LastName, @MiddleName, @GroupId)",
            //                            new Student()
            //                            {
            //                                LastName = "Rudenko",
            //                                FirstName = "Sergey",
            //                                MiddleName = "Dmitrievich",
            //                                GroupId = 1
            //                            });

            //    var students = _userRep.GetAllStudent("Select * from Students");
            //    students.ForEach(f =>
            //    {
            //        Console.WriteLine($"{f.Id}\t{f.LastName}\t{f.FirstName}\t{f.MiddleName}");
            //    });
            //} while (Console.ReadKey().Key == ConsoleKey.Escape);

            do
            {
                int choice = 0;
                bool check = false;
                while (!check)
                {
                    Console.Clear();
                    Console.Write("\tБаза данных студентов\n" +
                        "1) Добавить данные\n" +
                        "2) Обновить данные\n" +
                        "3) Удалить данные\n\n" +
                        "4) Посмотреть данные\n" +
                        "Ваш выбор: ");
                    check = int.TryParse(Console.ReadLine(), out choice);
                    if (choice < 1 || choice > 4)
                        check = false;
                }

                if(choice == 1)
                {
                    StudentRepository repository = new StudentRepository();

                    string[] properties = { "Имя: ", "Фамилия: ", "Отчество: ", "Номер группы: " };
                    string[] data = new string[properties.Length];
                    int groupId = 0;

                    Console.WriteLine("Введите данные о студенте");
                    for (int i = 0; i < properties.Length; i++)
                    {
                        Console.Write(properties[i]);
                        data[i] = Console.ReadLine();
                        if (properties[i] == "Номер группы")
                            groupId = repository.GetGroupId(data[i]);
                    }

                    int counter = 0;
                    Student student = new Student();
                    student.FirstName = data[counter++];
                    student.LastName = data[counter++];
                    student.MiddleName = data[counter];
                    student.GroupId = groupId;
                }
            } while (Console.ReadKey().Key == ConsoleKey.Escape);
        }
    }
}
