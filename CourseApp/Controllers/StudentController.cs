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
    public class StudentController
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        GroupService _groupService = new GroupService();
        public void Create()
        {
            Console.WriteLine("Creating a new student:");

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                Console.WriteLine("Invalid age. Age must be a positive number.");
                return;
            }

            Console.Write("Enter student surname: ");
            string surname = Console.ReadLine();

            // Get existing groups
            var groups = _groupService.GetAll();
            if (groups.Count == 0)
            {
                Console.WriteLine("No groups found. Please create a group first.");
                return;
            }

            // Display existing groups for selection
            Console.WriteLine("Existing groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"ID: {group.Id}, Name: {group.Name}, Room: {group.Room}, Teacher: {group.Teacher}");
            }

            Console.Write("Enter group ID for the student: ");
            if (!int.TryParse(Console.ReadLine(), out int groupId) || groupId <= 0)
            {
                Console.WriteLine("Invalid group ID. Please enter a positive integer.");
                return;
            }

            // Check if the selected group ID exists
            if (!groups.Any(g => g.Id == groupId))
            {
                Console.WriteLine($"Group with ID {groupId} does not exist.");
                return;
            }


            try
            {
                _studentService.Create(new Student { Name = name, Age = age, Surname = surname, GroupId = groupId });
                var group = _groupService.GetById(groupId);
                Console.WriteLine($"Student {name} {surname} created successfully and assigned to the group: {group.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the student: {ex.Message}");
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
            Console.Write("Enter the ID of the student to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = _studentService.GetById(id);
                if (student != null)
                {
                    _studentService.Delete(id);
                    Console.WriteLine($"Student with ID {id} has been deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }
        public void UpdateStudent()
        {
            Console.Write("Enter the ID of the student to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var student = _studentService.GetById(id);
                if (student != null)
                {
                    Console.WriteLine($"Current student details: ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Surname: {student.Surname}, Group ID: {student.GroupId}");

                    Console.Write("Enter new student name: ");
                    string newName = Console.ReadLine();

                    Console.Write("Enter new student age: ");
                    if (int.TryParse(Console.ReadLine(), out int newAge) && newAge > 0)
                    {
                        Console.Write("Enter new student surname: ");
                        string newSurname = Console.ReadLine();


                        student.Name = newName;
                        student.Age = newAge;
                        student.Surname = newSurname;

                        _studentService.Update(student);
                        Console.WriteLine($"Student with ID {id} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for age. Please enter a valid positive integer.");
                    }
                }
                else
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
            }
        }

        public void GetStudentByAge()

        {
            Console.Write("Enter the age to filter students: ");
            if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
            {
                var students = _studentService.GetStudentsByAge(age);
                if (students.Count > 0)
                {
                    Console.WriteLine($"Students found with age {age}:");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Surname: {student.Surname}, Group ID: {student.GroupId}");
                    }
                }
                else
                {
                    Console.WriteLine("No students found with the specified age.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid age (a positive integer).");
            }
        }
        public void GetallStudetsByGroupId()
        {
            Console.Write("Enter the group ID to filter students: ");
            if (int.TryParse(Console.ReadLine(), out int groupId) && groupId > 0)
            {
                var students = _studentService.GetAllStudentsByGroupId(groupId);
                if (students.Count > 0)
                {
                    Console.WriteLine($"Students found in group {groupId}:");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Surname: {student.Surname}, Group ID: {student.GroupId}");
                    }
                }
                else
                {
                    Console.WriteLine($"No students found in group {groupId}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid group ID (a positive integer).");
            }
        }
        public void SearchStudentByNameOrSurname()
        {
            Console.WriteLine("Enter the name or surname:");
            string nameOrSurname = Console.ReadLine();
            var students = _studentService.SearchStudentsByNameOrSurname(nameOrSurname);
            if (students != null && students.Any())
            {
                Console.WriteLine("\nMatching Students:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Group ID: {student.GroupId}");
                }
            }
            else
            {
                Console.WriteLine("No students found with the given name or surname.");
            }
        }





    }

}
