using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Enums
{
    public enum  OperationType
    {
        GroupCreate=1,
         UpdateGroup,DeleteGroup,GetGroupById,GetAllGroupsByTeacher,GetAllGroupsByRoom,GetAllGroups,CreateStudent,
         UpdateStudent,GetStudentById,DeleteStudent,GetStudentByAge,
         GetAllStudentsByGrouId,SearchGroupsByName,SearchStdentsByNameOrSurname
    }
}
