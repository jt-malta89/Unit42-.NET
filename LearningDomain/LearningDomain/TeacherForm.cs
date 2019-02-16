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
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }


        private void IntiTeacherList()
        {
            //var teachers is loaded with the teacher list
            var teachers = TeacherService.Load();

            //For every teacher's object, attributes are binded to the respective form component.
            foreach (var teacher in teachers)
            {
                this.txtName.Text = teacher.Name;
                this.txtSurname.Text = teacher.Surname;
                this.txtSubject.Text = teacher.Subject;
                this.txtIDCard.Text = teacher.IdCard;
                this.txtClass.Text = teacher.ClassTeacher;
                this.txtAddress.Text = teacher.Address;

                this.txtDOB.Text = Convert.ToString(teacher.DateOfBirth);
                this.txtContactNo.Text = Convert.ToString(teacher.ContactNo);
                this.txtSalary.Text = Convert.ToString(teacher.Salary);

            }
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            //initialize the method IntiTeacherList
            IntiTeacherList();

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
            this.txtSalary.Text = "";
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

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            //Checking the the submitted characters are not numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.txtSalary.Text, "^[0-9.]"))
            {
                MessageBox.Show("This textbox accepts only Numeric Characters", "Text Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Component text is reset
            this.txtSalary.ResetText();

            //component is given back focus
            this.txtSalary.Focus();
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

        public void SearchTeacher()
        {
            //calling the clear component method to clear text from the latter
            clearComponents();

            String userInput = Microsoft.VisualBasic.Interaction.InputBox("Please enter Teacher ID Card", "Search Teacher Record");

            var teachers = TeacherService.Load(userInput);

            //Checking if user input matches a record in our teacher folder
            //and is not null.
            if (teachers != null)
            {
                this.txtName.Text = teachers.Name;
                this.txtSurname.Text = teachers.Surname;
                this.txtSubject.Text = teachers.Subject;
                this.txtIDCard.Text = teachers.IdCard;
                this.txtClass.Text = teachers.ClassTeacher;
                this.txtAddress.Text = teachers.Address;

                this.txtDOB.Text = Convert.ToString(teachers.DateOfBirth);
                this.txtContactNo.Text = Convert.ToString(teachers.ContactNo);
                this.txtSalary.Text = Convert.ToString(teachers.Salary);

                //the update button will be tured to enabled.
                this.btnUpdate.Enabled = true;
            }

            else
            {
                MessageBox.Show("No Records Found with given Teacher IDCard: " + userInput, "Search output");

                this.btnUpdate.Enabled = false;

            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //calling the searchTeacher method 
            SearchTeacher();
        }

        public void UpdateTeacher()
        {
            Teacher myTeacher = new Teacher();
            myTeacher.Name = this.txtName.Text;
            myTeacher.Surname = this.txtSurname.Text;
            myTeacher.IdCard = this.txtIDCard.Text;
            myTeacher.Subject = this.txtSubject.Text;
            myTeacher.ClassTeacher = this.txtClass.Text;
            myTeacher.Address = this.txtAddress.Text;
            myTeacher.DateOfBirth = DateTime.Parse(this.txtDOB.Text.ToString());
            myTeacher.Salary = float.Parse(this.txtSalary.Text);
            myTeacher.ContactNo = Convert.ToInt32(this.txtContactNo.Text);

            //Updating the teacher record
            TeacherService.Save(myTeacher);

            //Showing a message to the user informing him that the update was successful
            MessageBox.Show("Teacher Record Updated Successfully", "Update Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //setting the button update to disabled
            this.btnUpdate.Enabled = false;

            //Calling the clear componet method to dispose from any text
            clearComponents();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //calling the UpdateTeacher method
            UpdateTeacher();
        }

        public void AddTeacher()
        {

            //creating a new EMPTY instance of the teacher object
            Teacher myTeacher = new Teacher();

            //creating attributes for our teacher object
            String TeacherID, name, surname, address, subject, TeacherClass;
            int contact = 0;
            float salary = 0F;
            DateTime dob;
            Boolean quit = true;

            do
            {
                //assigning the userinput in textbox txtName to the string variable name
                name = this.txtName.Text;

                if (name != null)
                {
                    if (name == "")
                    {
                        //Error message to the user
                        MessageBox.Show("Teacher's name is required. Please do not leave the name empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the name component with the specified error
                        this.erpProvider.SetError(this.txtName, "Teacher's name is required.");

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
                        MessageBox.Show("Teacher's surname is required. Please do not leave the name empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the name component with the specified error
                        this.erpProvider.SetError(this.txtSurname, "Teacher's Surname is required.");

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
                        MessageBox.Show("Teacher's Address is required. Please do not leave the Address empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the Address component with the specified error
                        this.erpProvider.SetError(this.txtAddress, "Teacher's Address is required.");

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
                        MessageBox.Show("Teacher's subject is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtsubject, "Teacher's subject is required.");

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
                    if (TeacherID == 0)
                    {

                        //Error message to the user
                        MessageBox.Show("Teacher's subject is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtsubject, "Teacher's subject is required.");

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

                if (DataObject != null)
                {
                    if (DataObject > DateTime.Today)
                    {
                        //Error message to the user
                        MessageBox.Show("Teacher's subject is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtsubject, "Teacher's subject is required.");

                        quit = true;

                        break;
                    }
                    else
                    {
                        quit = false;
                        this.erpProvider.Dispose();
                    }

                    else
                     {
                        return;
                    }
                }

                salary = float.Parse(this.txtSalary.Text);

                if (salary != 0)
                {
                    if (salary == 0)
                    {

                        //Error message to the user
                        MessageBox.Show("Teacher's subject is required. Please do not leave the subject empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //Setting the Error provider to the subject component with the specified error
                        this.erpProvider.SetError(this.txtsubject, "Teacher's subject is required.");

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

                myTeacher.Name = name;
                myTeacher.Subject = subject;
                myTeacher.Surname = surname;
                myTeacher.Salary = salary;
                myTeacher.IdCard = TeacherID;
                myTeacher.Address = address;
                myTeacher.ClassTeacher = TeacherClass;
                myTeacher.ContactNO = contact;
                myTeacher.DateOfBirth = dob;

                TeacherService.Save(myTeacher);

                MessageBox.Show("New Teacher successfully added to the datase", "Success", MessageBoxButtons.Ok, MessageBoxIcon.Information);
                clearComponents();



            } while (quit == true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTeacher();
        }
    }
