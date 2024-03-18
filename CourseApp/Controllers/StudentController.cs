using Service.Services.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Helpers.Extensions;
using Domain.Models;

namespace CourseApp.Controllers
{
    public  class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        GroupService _groupService = new GroupService();
        public void Create()
        {
            if (_groupService.GetAll().Count == 0)
            {
                ConsoleColor.Yellow.WriteConsole("No groups found. Please create a group first.");
                return;
            }

            ConsoleColor.Cyan.WriteConsole("Add student name: ");
        Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            ConsoleColor.Cyan.WriteConsole("Add age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                ConsoleColor.Red.WriteConsole("Age must be a positive number.");
                return;
            }

            ConsoleColor.Cyan.WriteConsole("Add surname: ");
            Surname: string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Surname cannot be empty or whitespace.");
                goto Surname;
            }

            try
            {
                _studentService.Create(new Student { Name = name, Age = age, Surname = surname });
                ConsoleColor.Green.WriteConsole("Data successfully added");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }
        }
        public void GetById()
        {
            ConsoleColor.Cyan.WriteConsole("Add student id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectFormat = int.TryParse(idStr, out id);
            if (isCorrectFormat)
            {
                try
                {
                    if (id <= 0)
                    {
                        Console.WriteLine("Invalid ID. ID must be greater than zero.");
                        return;
                    }
                    Student student = _studentService.GetById(id);
                    if (student != null)
                    {
                        ConsoleColor.Green.WriteConsole($"Group name: {student.Name},Teacher: {student.Age},Room:{student.Surname}");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong,please add again");
                goto Id;
            }
        }
        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Add Group id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectFormat = int.TryParse(idStr, out id);
            if (isCorrectFormat)
            {
                try
                {
                    _studentService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong,please add again");
                goto Id;
            }
        }
        public void UpdateStudent()
        {
            Console.WriteLine("Enter the ID of the student:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectFormat = int.TryParse(idStr, out id);



            if (isCorrectFormat)
            {




                try
                {
                    Student existingStudent = _studentService.GetById(id);
                    if (existingStudent != null)
                    {
                        Console.WriteLine($"Current Student Name: {existingStudent.Name}");
                        Console.Write("Enter new Student Name: ");
                        string newName = Console.ReadLine();

                        Console.WriteLine($"Current Surname: {existingStudent.Surname}");
                        Console.Write("Enter new Teacher: ");
                        string newSurname = Console.ReadLine();

                        Console.WriteLine($"Current age: {existingStudent.Age}");
                        Console.Write("Enter new Age: ");
                        string newAgeStr = Console.ReadLine();
                        int newAge;
                        if (!int.TryParse(newAgeStr, out newAge) || newAge <= 0)
                        {
                            Console.WriteLine("Invalid input. Age must be a positive number.");
                            goto Id;
                        }

                        existingStudent.Name = newName;
                        existingStudent.Surname = newSurname;
                        existingStudent.Age = newAge;

                        _studentService.Update(existingStudent);
                        Console.WriteLine("Group updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Group not found");
                        goto Id;
                    }
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                    goto Id;
                }



            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");

            }





        }
        public void GetAll()
        {
            var response = _studentService.GetAll();
            foreach (var item in response)
            {
                string data = $" Id:{item.Id},  student name: {item.Name}, Student age: {item.Age},Student surname:{item.Surname}";
                Console.WriteLine(data);
            }

        }


    }

}
