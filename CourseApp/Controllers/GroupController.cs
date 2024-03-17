using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;


namespace CourseApp.Controllers
{
    public class GroupController
    {
        private readonly IGroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();
        }
        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Add name: ");
        Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            ConsoleColor.Cyan.WriteConsole("Add room: ");
        Room: string roomStr = Console.ReadLine();
            int room;
            bool isCorrectRoomFormat = int.TryParse(roomStr, out room);
            if (isCorrectRoomFormat)
            {
                ConsoleColor.Cyan.WriteConsole("Add teacher: ");
                string teacher = Console.ReadLine();

                try
                {

                    
                    _groupService.Create( new Group { Name=name,Room=roomStr,Teacher=teacher});
                    ConsoleColor.Green.WriteConsole("Data successfully added");
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                }


            }
            else
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }
        }
        public void GetAll()
        {
            var response=_groupService.GetAll();
            foreach (var item in response)
            {
                string data = $" Id:{item.Id},  Group name: {item.Name}, Group room : {item.Room},Group teacher:{item.Teacher}";
                Console.WriteLine(data);
            }

        }
        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Add Group id: ");
            Id: string idStr= Console.ReadLine();
            int id;
            bool isCorrectFormat=int.TryParse(idStr, out id);
            if(isCorrectFormat)
            {
                try
                {
                    _groupService.Delete(id);
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
        public void GetById()
        {
            ConsoleColor.Cyan.WriteConsole("Add Group id: ");
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
                    Group group=_groupService.GetById(id);
                    if(group != null)
                    {
                        ConsoleColor.Green.WriteConsole($"Group name: {group.Name},Teacher: {group.Teacher},Room:{group.Room}");
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
        public void UpdateGroup()
        {
            Console.WriteLine("Enter the ID of the group to update:");
            int groupId = int.Parse(Console.ReadLine());

            
            Group groupToUpdate = _groupService.GetById(groupId);

            if (groupToUpdate != null)
            {
                Console.WriteLine("Enter the new name for the group:");
                string newName = Console.ReadLine();

                
                groupToUpdate.Name = newName;

               
                _groupService.Update(groupToUpdate);
                Console.WriteLine("Group updated successfully!");
            }
            else
            {
                Console.WriteLine("Group not found!");
            }
        }
    }
}
