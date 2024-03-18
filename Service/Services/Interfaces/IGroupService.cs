

using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group data);
        void Delete(int? id);
        void Update(Group data);
        Group GetById(int? id);
        List<Group> GetAll();
        List<Group> GetAllGroupsByTeacher(Func<Group,bool> predicate);
        List<Group> GetAllGroupsByRoom(Func<Group, bool> predicate);
        public List<Group> SearchGroupsByName(string name);

    }
}
