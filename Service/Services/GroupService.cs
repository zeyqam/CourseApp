using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private int count = 1;
        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }
        public void Create(Group data)
        {
            if (data is null) throw new ArgumentNullException();
            data.Id = count;
            _groupRepo.Create(data);
            count++;
        }

        public void Delete(int? id)
        {
            if(id==null) throw new ArgumentNullException();
            Group group = _groupRepo.GetById((int)id);
            if (group is null) throw new NotFoundException(ResponseMessage.DataNotFound);
            _groupRepo.Delete(group);
        }

        public List<Group> GetAll()
        {
            return _groupRepo.GetAll();
        }

        public List<Group> GetAllGroupsByRoom(Func<Group, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroupsByTeacher(Func<Group, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Group GetById(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Group group = _groupRepo.GetById((int)id);
            if (group is null) throw new NotFoundException(ResponseMessage.DataNotFound);
            return group;
        }

        

        public void Update(Group data)
        {
            _groupRepo.Update(data); 
        }
    }
}
