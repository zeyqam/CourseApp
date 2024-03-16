using CourseApp.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

GetMenues();
GroupController groupController = new();


while (true)
{
   Operation: string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperationFormat=int.TryParse(operationStr, out operation);

    if(isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GroupCreate:
                groupController.Create();
                break;

                case (int)OperationType.GroupDelete:
                    groupController.Delete(); break;

                case (int)OperationType.GetAllGroups:
                    groupController.GetAll(); break;

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
    
    ConsoleColor.Cyan.WriteConsole (" Choose one operation:  1-Group create, 2-Group delete,3-Get all Groups,Update Group");
}