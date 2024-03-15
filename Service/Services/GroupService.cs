using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupServices
    {
        private readonly IGroupRepository _groupRepo;
        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }
        public void Create(Group data)
        {
            if (data == null) throw new ArgumentNullException();
        }

        public void Delete(int? id)
        {
            if(id==null) throw new ArgumentNullException();
            Group group = _groupRepo.GetById((int)id);
        }

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetByName(string searchText)
        {
            throw new NotImplementedException();
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
