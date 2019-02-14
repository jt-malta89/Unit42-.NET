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
    public class TeacherDA
    {
        //Declaring constant variable to create Teacher Folder path in the solution root folder
        private const string TeacherFolder = "data\\teachers\\";

        //Declaring constant variable to set the TeacherFile extension to .bin
        private const string TeachersFileTypeExtension = ".bin";


        //Default Constructor
        public TeacherDA() { }

        private static void CreateTeacherFolder()
        {
            //Checking into the Operating System directory if the Teacher folder exists or not
            if (!Directory.Exists(TeacherFolder))
            {
                //If the folder does not exists the application will add the Teacher folder into the director
                Directory.CreateDirectory(TeacherFolder);
            }

        }

        private static string GetTeacherFilePath(string idCardNo)
        {
            //Calling the CreateTeacherFolder method to check if the Folder extists to save the teacher file in
            CreateTeacherFolder();

            //setting the file path with file name and extension
            string targetPath = string.Format(TeacherFolder + "{0}" + TeachersFileTypeExtension, idCardNo);

            return targetPath;
        }

        public static bool Save(Teacher teacher)
        {
            try
            {
                //Making an instance of the binary formatter to save the object of type Teacher
                BinaryFormatter myBinaryFormatter = new BinaryFormatter();

                //Setting the targer path through the Teacher's IDcard
                string targetPath = GetTeacherFilePath(teacher.IdCard);

                //Making use of the USING functionality to dispose of date in case of unhanded error exception
                using (StreamWriter myStreamWriter = new StreamWriter(targetPath, false, Encoding.UTF8))
                {
                    //Serialization
                    myBinaryFormatter.Serialize(myStreamWriter.BaseStream, teacher);
                }
                return true;
            }
            catch (System.Runtime.Serialization.SerializationException se)
            {
                //Showing the exception
                throw se;
            }
        }

        public static Teacher Load(string idCardNo)
        {
            //setting the target path with the IDCardNo
            string targetPath = GetTeacherFilePath(idCardNo);

            //checking if file exists
            if (File.Exists(targetPath))
            {
                //getting the target path formatted through the idcard
                BinaryFormatter myBinaryFormatter = new BinaryFormatter();

                //StreamReader to read the serialzed teacher object
                using (StreamReader myStreamReader = new StreamReader(targetPath))
                {
                    //deserialization
                    return myBinaryFormatter.Deserialize(myStreamReader.BaseStream) as Teacher;
                }
            }

            return null;
        }


        //Load method that return Teachers object to a list
        public static List<Teacher> Load()
        {
            //Creating an instance of the list with data type Teacher using Generics
            List<Teacher> myList = new List<Teacher>();

            //passing the location of the teachers folder
            string targetPath = TeacherFolder;

            //Checking if the folder already exists in the directory
            if (Directory.Exists(targetPath))
            {
                //if targetpath exists
                DirectoryInfo myDirectoryInfo = new DirectoryInfo(targetPath);

                //loading all files with .bin extension into the file info array
                FileInfo[] files = myDirectoryInfo.GetFiles("*" + TeachersFileTypeExtension);

                //Making an instance of BinaryFormatter
                BinaryFormatter myBinaryFormatter = new BinaryFormatter();

                //For Loop to iterate all the files within the File Arrayb 
                foreach (var file in files)
                {
                    string path = file.FullName;
                    using (StreamReader myStreamReader = new StreamReader(path))
                    {
                        //adding teacher object to my list and do deserialization
                        myList.Add(myBinaryFormatter.Deserialize(myStreamReader.BaseStream) as Teacher);
                    }
                }
            }

            //return the list of objects of type Teacher
            return myList;
        }
    }
}
