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


                    _groupService.Create(new Group { Name = name, Room = roomStr, Teacher = teacher });
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
            var response = _groupService.GetAll();
            foreach (var item in response)
            {
                string data = $" Id:{item.Id},  Group name: {item.Name}, Group room : {item.Room},Group teacher:{item.Teacher}";
                Console.WriteLine(data);
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
                    Group group = _groupService.GetById(id);
                    if (group != null)
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
            Console.WriteLine("Enter the ID of the group:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectFormat = int.TryParse(idStr, out id);



            if (isCorrectFormat)
            {




                try
                {
                    Group existingGroup = _groupService.GetById(id);
                    if (existingGroup != null)
                    {
                        Console.WriteLine($"Current Group Name: {existingGroup.Name}");
                        Console.Write("Enter new Group Name: ");
                        string newName = Console.ReadLine();

                        Console.WriteLine($"Current Teacher: {existingGroup.Teacher}");
                        Console.Write("Enter new Teacher: ");
                        string newTeacher = Console.ReadLine();

                        Console.WriteLine($"Current Room: {existingGroup.Room}");
                        Console.Write("Enter new Room: ");
                        string newRoom = Console.ReadLine();

                        existingGroup.Name = newName;
                        existingGroup.Teacher = newTeacher;
                        existingGroup.Room = newRoom;

                        _groupService.Update(existingGroup);
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
                Console.WriteLine("Invalid input. Please enter a valid group ID.");

            }




            
        }
        public void GetAllGroupsByRoom()
        {
            Console.WriteLine("Enter the room number:");
            string roomNumber = Console.ReadLine();

            Console.WriteLine($"Groups in Room {roomNumber}:");
            List<Group> groups = _groupService.GetAllGroupsByRoom(group => group.Room == roomNumber);
            if (groups.Any())
            {
                foreach (var group in groups)
                {
                    Console.WriteLine($"Group ID: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}");
                }
            }
            else
            {
                Console.WriteLine("No groups found for the specified room number.");
            }

        }
        public void GetAllGroupsByTeacher()
        {
            Console.WriteLine("Enter the teacher's name:");
            string teacherName = Console.ReadLine();

            Console.WriteLine($"Groups by Teacher {teacherName}:");
            List<Group> groups = _groupService.GetAllGroupsByTeacher(group => group.Teacher == teacherName);
            if (groups.Any())
            {
                foreach (var group in groups)
                {
                    Console.WriteLine($"Group ID: {group.Id}, Name: {group.Name}, Room: {group.Room}");
                }
            }
            else
            {
                Console.WriteLine("No groups found for the specified teacher.");
            }
        }
    }
}
