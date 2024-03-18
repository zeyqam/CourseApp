using Domain.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using System.Text.RegularExpressions;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private int count = 1;
        public StudentService()
        {
            _studentRepo = new StudenRepository();
        }
        public void Create(Student data)
        {
            if (data is null) throw new ArgumentNullException();
            data.Id = count;
            _studentRepo.Create(data);
            count++; ;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Student student = _studentRepo.GetById((int)id);
            if (student is null) throw new NotFoundException(ResponseMessage.DataNotFound);
            _studentRepo.Delete(student);
        }

        public Student GetById(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Student student = _studentRepo.GetById((int)id);
            if (student is null) throw new NotFoundException(ResponseMessage.DataNotFound);
            return student;
        }

        public void Update(Student updateStudent)
        {
            if (updateStudent is null) throw new NotFoundException(ResponseMessage.DataNotFound);
            Student existingGroup = _studentRepo.GetById((int)updateStudent.Id);
            if (existingGroup != null)
            {
                existingGroup.Name = updateStudent.Name;
                existingGroup.Surname = updateStudent.Surname;
                existingGroup.Age = updateStudent.Age;
            }
            else
            {
                throw new InvalidOperationException("Group not found");
            }
            if (existingGroup is null) throw new NotFoundException(ResponseMessage.DataNotFound);

            _studentRepo.Update(updateStudent);
        }

        

       

        public List<Student> GetStudentsByAge(int age)
        {
            return _studentRepo.GetAllWithExpression(student => student.Age == age);
        }

        public List<Student> GetAllStudentsByGroupId(int groupId)
        {
            return _studentRepo.GetAllWithExpression(student => student.GroupId == groupId);
        }

        

        public List<Student> SearchStudentsByNameOrSurname(string nameOrSurname)
        {
            return _studentRepo.GetAllWithExpression(student => student.Name.Contains(nameOrSurname) || student.Surname.Contains(nameOrSurname));
        }

       
    }
}
