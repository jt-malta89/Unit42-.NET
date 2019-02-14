using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGettersSetters
{
    [Serializable]
    //Inheritance
    public class Student : Person
    {

        //Student Attributes
        private string s_Subject, s_Class;

        //Default Constructor
        public Student() { }

        //overloaded Constructor
        public Student(string Name, string Surname, string IdCard, string Address, DateTime DOB, int ContactNo, string Subject, string ClassName)

            : base(Name, Surname, IdCard, Address, DOB, ContactNo)
        {
            this.s_Subject = Subject;
            this.s_Class = ClassName;

        }

        //Get and Set Methods
        public string Subject
        {
            get
            {
                return this.s_Subject;
            }
            set
            {
                this.s_Subject = value;
            }
        }

        public string ClassStudent
        {
            get
            {
                return this.s_Class;
            }
            set
            {
                this.s_Class = value;
            }
        }
    }
}
