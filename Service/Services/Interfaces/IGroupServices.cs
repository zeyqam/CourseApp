

using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupServices
    {
        void Create(Group data);
        void Delete(int? id);
        void Update(Group data);
        Group GetById(int? id);
        List<Group> GetAll();
        List<Group> GetByName(string searchText);

    }
}
