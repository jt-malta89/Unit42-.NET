using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLogic;
using ObjectGettersSetters;
using DataAccess;

namespace LearningDomain
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void IntiStudentList()
        {
            //var student is loaded with the teacher list
            var students = StudentService.Load();

            //For every student object, attributes are binded to the respective form component.
            foreach (var student in students)
            {
                this.txtName.Text = student.Name;
                this.txtSurname.Text = student.Surname;
                this.txtSubject.Text = student.Subject;
                this.txtIDCard.Text = student.IdCard;
                this.txtClass.Text = student.ClassStudent;
                this.txtAddress.Text = student.Address;
                this.txtDOB.Text = Convert.ToString(student.DateOfBirth);
                this.txtContactNo.Text = Convert.ToString(student.ContactNo);
            }
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            //initialize the method IntiStudentList
            IntiStudentList();
            //the button Updated will be disabled on form load
            this.btnUpdate.Enabled = false;
        }

        //This method will clear the component from any submitted text
        public void clearComponents()
        {
            this.txtAddress.Text = "";
            this.txtName.ResetText();
            this.txtSurname.Text = "";
            this.txtClass.Text = "";
            this.txtContactNo.Text = "";
            this.txtDOB.Text = "";
            this.txtIDCard.Text = "";       
            this.txtSubject.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Calling the clearComponent method on Clear Button Click event
            clearComponents();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtName.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only Alphabetical Characters" + this.txtName.Text + "is not valid", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Component text is reset
            this.txtName.ResetText();
            //component is given back focus
            this.txtName.Focus();
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtAddress.Text, "^[a-zA-Z0-9 ]"))
            {
                MessageBox.Show("This textbox accepts only Alphabetical Characters", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtAddress.ResetText();

            //component is given back focus
            this.txtAddress.Focus();
        }

        private void txtIDCard_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtIDCard.Text, "^[a-zA-Z0-9]"))
            {
                MessageBox.Show("This textbox accepts only Alphabetical Characters and Numeric Characters", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtIDCard.ResetText();

            //component is given back focus
            this.txtIDCard.Focus();
        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtContactNo.Text, "^[0-9]"))
            {
                MessageBox.Show("This textbox accepts only Numeric Characters a", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtContactNo.ResetText();

            //component is given back focus
            this.txtContactNo.Focus();

        }       

        private void txtSurname_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtSurname.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only Alphabetical Characters" + this.txtName.Text + "is not valid", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtSurname.ResetText();

            //component is given back focus
            this.txtSurname.Focus();
        }

        private void txtClass_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtClass.Text, "^[a-zA-Z0-9]"))
            {
                MessageBox.Show("This textbox accepts only Alphabetical Characters and Numeric Characters", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtClass.ResetText();

            //component is given back focus
            this.txtClass.Focus();
        }

        private void txtSubject_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtSubject.Text, "^[a-zA-Z0-9]"))
            {
                MessageBox.Show("This textbox accepts only Alphabetical Characters and Numeric Characters", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtSubject.ResetText();

            //component is given back focus
            this.txtSubject.Focus();
        }

        public void SearchStudent()
        {
            //calling the clear component method to clear text from the latter
            clearComponents();

            String userInput = Microsoft.VisualBasic.Interaction.InputBox("Please enter Student ID Card", "Search Student Record");

            var student = StudentService.Load(userInput);
            //Checking if user input matches a record in our student folder
            //and is not null.
            if (student != null)
            {
                this.txtName.Text = student.Name;
                this.txtSurname.Text = student.Surname;
                this.txtSubject.Text = student.Subject;
                this.txtIDCard.Text = student.IdCard;
                this.txtClass.Text = student.ClassStudent;
                this.txtAddress.Text = student.Address;
                this.txtDOB.Text = Convert.ToString(student.DateOfBirth);
                this.txtContactNo.Text = Convert.ToString(student.ContactNo);               
                //the update button will be tured to enabled.
                this.btnUpdate.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Records Found with given Student IDCard: " + userInput, "Search output");
                this.btnUpdate.Enabled = false;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //calling the searchStudent method 
            SearchStudent();
        }

        public void UpdateStudent()
        {
            Student myStudent = new Student();
            myStudent.Name = this.txtName.Text;
            myStudent.Surname = this.txtSurname.Text;
            myStudent.IdCard = this.txtIDCard.Text;
            myStudent.Subject = this.txtSubject.Text;
            myStudent.ClassStudent = this.txtClass.Text;
            myStudent.Address = this.txtAddress.Text;
            myStudent.DateOfBirth = DateTime.Parse(this.txtDOB.Text.ToString());          
            myStudent.ContactNo = Convert.ToInt32(this.txtContactNo.Text);

            //Updating the student record
            StudentService.Save(myStudent);

            //Showing a message to the user informing him that the update was successful
            MessageBox.Show("Student Record Updated Successfully", "Update Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //setting the button update to disabled
            this.btnUpdate.Enabled = false;

            //Calling the clear componet method to dispose from any text
            clearComponents();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //calling the UpdateTeacher method
            UpdateStudent();
        }

        public void AddStudent()
        {

            //creating a new EMPTY instance of the teacher object
            Student myStudent = new Student();

            //creating attributes for our teacher object
            String StudentID, name, surname, address, subject, StudentClass;
            int contact = 0;      
            DateTime dob;
            Boolean quit = true;

            do
            {

                StudentID = this.txtIDCard.Text;
                if (StudentID != null)
                {
                    if (StudentID == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Student ID Card is required. Please do not leave the name empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the name component with the specified error
                        this.erpProvider.SetError(this.txtIDCard, "Student ID Card is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                //assigning the userinput in textbox txtName to the string variable name
                name = this.txtName.Text;
                if (name != null)
                {
                    if (name == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Student name is required. Please do not leave the name empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the name component with the specified error
                        this.erpProvider.SetError(this.txtName, "Student name is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                //assigning the userinput in textbox txtSurname to the string variable name
                surname = this.txtSurname.Text;
                if (surname != null)
                {
                    if (surname == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Student surname is required. Please do not leave the name empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the name component with the specified error
                        this.erpProvider.SetError(this.txtSurname, "Student surname is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                //assigning the userinput in textbox txtAddress to the string variable name
                address = this.txtAddress.Text;
                if (address != null)
                {
                    if (address == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Student address is required. Please do not leave the Address empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the Address component with the specified error
                        this.erpProvider.SetError(this.txtAddress, "Student address is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                //assigning the userinput in textbox txt to the string variable name
                subject = this.txtSubject.Text;
                if (subject != null)
                {
                    if (subject == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Student subject is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtSubject, "Student subject is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                //assigning the userinput in textbox txtName to the string variable name
                StudentClass = this.txtClass.Text;
                if (StudentClass != null)
                {
                    if (StudentClass == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Student class is required. Please do not leave the name empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the name component with the specified error
                        this.erpProvider.SetError(this.txtClass, "Student class is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                contact = int.Parse(this.txtContactNo.Text);
                if (contact != 0)
                {
                    if (contact == 0)
                    {
                        //Error message to the user
                        MessageBox.Show("Student contact is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtContactNo, "Student contact is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }

                dob = DateTime.Parse(this.txtDOB.Text);
                if (dob != null)
                {
                    if (dob > DateTime.Today)
                    {
                        //Error message to the user
                        MessageBox.Show("Student date of birth is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtDOB, "Student date of birth is required.");
                        quit = true;
                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }
                }
                else
                {
                    return;
                }                

                myStudent.Name = name;
                myStudent.Subject = subject;
                myStudent.Surname = surname;
                myStudent.IdCard = StudentID;
                myStudent.Address = address;
                myStudent.ClassStudent = StudentClass;
                myStudent.ContactNo = contact;
                myStudent.DateOfBirth = dob;
                StudentService.Save(myStudent);
                MessageBox.Show("New Student successfully added to the database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearComponents();

            } while (quit == true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WelcomeForm myWelcome = new WelcomeForm();
            myWelcome.Show();
            this.Hide();
        }
    }
}
