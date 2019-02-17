using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectGettersSetters;
using DataAccess;

namespace ApplicationLogic
{
    public class StudentService
    {
        //Default Constructor
        public StudentService() { }

        //Loading the teacher record based on the Teacher's Id Card no
        public static Student Load(string idCardNo)
        {
            return StudentDA.Load(idCardNo);
        }

        public static List<Student> Load()
        {
            return StudentDA.Load();
        }


        private static bool ValidateModel(Student student)
        {
            //Checking if the teacher's ID Card is NULL or Empty
            if (string.IsNullOrEmpty(student.IdCard))
            {
                //Student object is not compliant. ID Card is not valid
                return false;
            }

            //Student object is validated and is good to be saved
            return true;
        }

        public static bool Save(Student student)
        {

            bool isValid = ValidateModel(student);

            if (isValid)
            {
                return StudentDA.Save(student);
            }

            return isValid;
        }
    }
}
