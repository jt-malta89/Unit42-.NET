using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ObjectGettersSetters;

namespace DataAccess
{
    public class StudentDA
    {
        //Declaring constant variable to create Student Folder path in the solution root folder
        private const string StudentFolder = "data\\student\\";

        //Declaring constant variable to set the TeacherFile extension to .bin
        private const string StudentFileTypeExtension = ".bin";


        //Default Constructor
        public StudentDA() { }

        private static void CreateStudentFolder()
        {
            //Checking into the Operating System directory if the Student folder exists or not
            if (!Directory.Exists(StudentFolder))
            {
                //If the folder does not exists the application will add the Teacher folder into the director
                Directory.CreateDirectory(StudentFolder);
            }

        }

        private static string GetStudentFilePath(string idCardNo)
        {
            //Calling the CreateTeacherFolder method to check if the Folder extists to save the teacher file in
            CreateStudentFolder();

            //setting the file path with file name and extension
            string targetPath = string.Format(StudentFolder + "{0}" + StudentFileTypeExtension, idCardNo);

            return targetPath;
        }

        public static bool Save(Student student)
        {
            try
            {
                //Making an instance of the binary formatter to save the object of type Teacher
                BinaryFormatter myBinaryFormatter = new BinaryFormatter();

                //Setting the targer path through the Teacher's IDcard
                string targetPath = GetStudentFilePath(student.IdCard);

                //Making use of the USING functionality to dispose of date in case of unhanded error exception
                using (StreamWriter myStreamWriter = new StreamWriter(targetPath, false, Encoding.UTF8))
                {
                    //Serialization
                    myBinaryFormatter.Serialize(myStreamWriter.BaseStream, student);
                }
                return true;
            }
            catch (System.Runtime.Serialization.SerializationException se)
            {
                //Showing the exception
                throw se;
            }
        }

        public static Student Load(string idCardNo)
        {
            //setting the target path with the IDCardNo
            string targetPath = GetStudentFilePath(idCardNo);

            //checking if file exists
            if (File.Exists(targetPath))
            {
                //getting the target path formatted through the idcard
                BinaryFormatter myBinaryFormatter = new BinaryFormatter();

                //StreamReader to read the serialzed teacher object
                using (StreamReader myStreamReader = new StreamReader(targetPath))
                {
                    //deserialization
                    return myBinaryFormatter.Deserialize(myStreamReader.BaseStream) as Student;
                }
            }

            return null;
        }


        //Load method that return Student object to a list
        public static List<Student> Load()
        {
            //Creating an instance of the list with data type Student using Generics
            List<Student> myList = new List<Student>();

            //passing the location of the student folder
            string targetPath = StudentFolder;

            //Checking if the folder already exists in the directory
            if (Directory.Exists(targetPath))
            {
                //if targetpath exists
                DirectoryInfo myDirectoryInfo = new DirectoryInfo(targetPath);

                //loading all files with .bin extension into the file info array
                FileInfo[] files = myDirectoryInfo.GetFiles("*" + StudentFileTypeExtension);

                //Making an instance of BinaryFormatter
                BinaryFormatter myBinaryFormatter = new BinaryFormatter();

                //For Loop to iterate all the files within the File Arrayb 
                foreach (var file in files)
                {
                    string path = file.FullName;
                    using (StreamReader myStreamReader = new StreamReader(path))
                    {
                        //adding student object to my list and do deserialization
                        myList.Add(myBinaryFormatter.Deserialize(myStreamReader.BaseStream) as Student);
                    }
                }
            }

            //return the list of objects of type Student
            return myList;
        }
    }
}
