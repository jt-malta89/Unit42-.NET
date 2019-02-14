using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectGettersSetters;
using DataAccess;

namespace ApplicationLogic
{
    public class TeacherService
    {
        //Default Constructor
        public TeacherService() { }

        //Loading the teacher record based on the Teacher's Id Card no
        public static Teacher Load(string idCardNo)
        {
            return TeacherDA.Load(idCardNo);
        }

        public static List<Teacher> Load()
        {
            return TeacherDA.Load();
        }


        private static bool ValidateModel(Teacher teacher)
        {
            //Checking if the teacher's ID Card is NULL or Empty
            if (string.IsNullOrEmpty(teacher.IdCard))
            {
                //Teacher object is not compliant. ID Card is not valid
                return false;
            }

            //Teacher object is validated and is good to be saved
            return true;
        }

        public static bool Save(Teacher teacher)
        {

            bool isValid = ValidateModel(teacher);

            if (isValid)
            {
                return TeacherDA.Save(teacher);
            }

            return isValid;
        }
    }
}
