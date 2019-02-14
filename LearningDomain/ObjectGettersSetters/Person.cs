using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGettersSetters
{
    [Serializable]
    public class Person
    {
        //Private Attributes for Encapsulation
        private string p_Name, p_Surname, p_IdCard, p_Address;
        private DateTime p_DateofBirth;
        private int p_ContactNo;

        //Default Constructor
        public Person() { }

        //Overloaded Constructor
        //In the overloaded constructor all the parameters will be passed for any instance of the class Person.
        public Person(string Name, string Surname, string IdCard, string Address, DateTime DOB, int ContactNo)
        {
            this.p_Name = Name;
            this.p_Surname = Surname;
            this.p_IdCard = IdCard;
            this.p_Address = Address;
            this.p_DateofBirth = DOB;
            this.p_ContactNo = ContactNo;
        }

        //--------------------Get Set Methods--------------------------


        public string Name
        {
            get
            {
                return this.p_Name;
            }
            set
            {
                this.p_Name = value;
            }
        }

        public string Surname
        {
            get
            {
                return this.p_Surname;
            }
            set
            {
                this.p_Surname = value;
            }
        }

        public string IdCard
        {
            get
            {
                return this.p_IdCard;
            }
            set
            {
                this.p_IdCard = value;
            }
        }

        public string Address
        {
            get
            {
                return this.p_Address;
            }
            set
            {
                this.p_Address = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.p_DateofBirth;
            }
            set
            {
                this.p_DateofBirth = value;
            }
        }

        public int ContactNo
        {
            get
            {
                return this.p_ContactNo;
            }
            set
            {
                this.p_ContactNo = value;
            }
        }

    }
}
