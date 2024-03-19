using CourseApp.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

GetMenues();
GroupController groupController = new();
StudentController studentController = new();


while (true)
{
Operation: string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);

    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GroupCreate:
                groupController.Create();
                break;

            case (int)OperationType.DeleteGroup:
                groupController.Delete(); break;

            case (int)OperationType.GetAllGroups:
                groupController.GetAll(); break;

            case (int)OperationType.GetGroupById:
                groupController.GetById(); break;

            case (int)OperationType.UpdateGroup:
                groupController.UpdateGroup(); break;

            case (int)OperationType.GetAllGroupsByRoom:
                groupController.GetAllGroupsByRoom(); break;

            case (int)OperationType.GetAllGroupsByTeacher:
                groupController.GetAllGroupsByTeacher(); break;

            case (int)OperationType.CreateStudent:
                studentController.Create(); break;

            case (int)OperationType.GetStudentById:
                studentController.GetById(); break;

            case (int)OperationType.DeleteStudent:
                studentController.Delete(); break;

            case (int)OperationType.UpdateStudent:
                studentController.UpdateStudent(); break;

            case (int)OperationType.GetAllStudentsByGroupId:
                studentController.GetallStudetsByGroupId(); break;

            case (int)OperationType.SearchGroupsByName:
                groupController.SerchGroupByName(); break;

            case (int)OperationType.GetStudentByAge:
                studentController.GetStudentByAge();break;

            case (int)OperationType.SearchStdentsByNameOrSurname:
                studentController.SearchStudentByNameOrSurname();break;









            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong,please choose again");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong,please add operation again");
        goto Operation;
    }





}









static void GetMenues()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                     Menu Operations                     ║");
    Console.WriteLine("╠══════╦══════════════════════════════════════════════════╣");
    Console.WriteLine("║ Code ║                 Operation                        ║");
    Console.WriteLine("╠══════╬══════════════════════════════════════════════════╣");
    Console.WriteLine("║   1  ║ Create Group                                     ║");
    Console.WriteLine("║   2  ║ Update Group                                     ║");
    Console.WriteLine("║   3  ║ Delete Group                                     ║");
    Console.WriteLine("║   4  ║ Get Group by Id                                  ║");
    Console.WriteLine("║   5  ║ Get all Groups by Teacher                        ║");
    Console.WriteLine("║   6  ║ Get all Groups by Room                           ║");
    Console.WriteLine("║   7  ║ Get all Groups                                   ║");
    Console.WriteLine("║   8  ║ Create Student                                   ║");
    Console.WriteLine("║   9  ║ Update Student                                   ║");
    Console.WriteLine("║  10  ║ Get Student by Id                                ║");
    Console.WriteLine("║  11  ║ Delete Student                                   ║");
    Console.WriteLine("║  12  ║ Get Students by Age                              ║");
    Console.WriteLine("║  13  ║ Get all students by Group Id                     ║");
    Console.WriteLine("║  14  ║ Search Groups by Name                            ║");
    Console.WriteLine("║  15  ║ Search students by Name/Surname                  ║");
    Console.WriteLine("╚══════╩══════════════════════════                           ");
}

