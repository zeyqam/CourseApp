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
                studentController.UpdateStudent();break;

                case(int)OperationType.GetAllStudentsByGrouId:
                studentController.GetAll(); break;



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

    ConsoleColor.Cyan.WriteConsole(" Choose one operation:  1-Create group, 2-Update Group,3-Delete Group, 4-Get Group by Id,5-Get all Groups by Teacher,6-Get all Groups by Room,7-Get all Groups,8-Create Student,9-Update Student,10-Get Student by Id,11-Delete Student,12-Get Students by Age,13-Get all students by Group Id,14-Search Groups by Name,15-Search students by Name or Surname ");
}