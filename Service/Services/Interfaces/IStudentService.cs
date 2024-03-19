using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student data);
        void Delete(int? id);
        void Update(Student updateStudent);
        Student GetById(int? id);
        
        
        
        List<Student> GetStudentsByAge(int age);
        List<Student> GetAllStudentsByGroupId(int groupId);
        
        List<Student> SearchStudentsByNameOrSurname(string nameOrSurname);
        List<Student>SearchByname(string name);
    }
}
