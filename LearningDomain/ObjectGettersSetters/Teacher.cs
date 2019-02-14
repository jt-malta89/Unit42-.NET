using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGettersSetters
{
    [Serializable]
    public class Teacher : Person
    {
        //Teacher Attributes
        private string t_Subject, t_Class;
        private float t_Salary;

        //Default Constructor
        public Teacher() { }

        //overloaded Constructor
        public Teacher(string Name, string Surname, string IdCard, string Address, DateTime DOB, int ContactNo, string Subject, string ClassName, float Salary)

            : base(Name, Surname, IdCard, Address, DOB, ContactNo)
        {
            this.t_Subject = Subject;
            this.t_Class = ClassName;
            this.t_Salary = Salary;
        }

        public string Subject
        {
            get
            {
                return this.t_Subject;
            }
            set
            {
                this.t_Subject = value;
            }
        }

        public string ClassTeacher
        {
            get
            {
                return this.t_Class;
            }
            set
            {
                this.t_Class = value;
            }
        }

        public float Salary
        {
            get
            {
                return this.t_Salary;
            }
            set
            {
                this.t_Salary = value;
            }
        }
    }
}
