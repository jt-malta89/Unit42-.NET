using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectGettersSetters;
using ApplicationLogic;
using System.Collections.Generic;

namespace StudentTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSaveStudent_Fails()
        {
            Student student = new Student();
            bool resSaveStudent = StudentService.Save(student);
            Assert.IsFalse(resSaveStudent);
        }

        [TestMethod]
        public void TestSaveStudent_Succeeds()
        {
            Student student = new Student();
            student.IdCard = "59627M";
            bool resSaveStudent = StudentService.Save(student);
            Assert.IsTrue(resSaveStudent);
        }


        [TestMethod]
        public void TestLoadStudent_Fails()
        {
            Student student = StudentService.Load("59627");
            Assert.IsNull(student);
        }

        [TestMethod]
        public void TestLoadStudent_Succeeds()
        {

            Student student = StudentService.Load("59627M");
            Assert.IsNotNull(student);
            Assert.AreEqual(student.IdCard, "59627M");
        }


        [TestMethod]
        public void TestLoadStudents_Succeeds()
        {

            List<Student> lstStudents = StudentService.Load();
            Assert.IsNotNull(lstStudents);
            Assert.IsTrue(lstStudents.Count > 0);
            Assert.IsNotNull(lstStudents[0]);
            Assert.IsFalse(string.IsNullOrWhiteSpace(lstStudents[0].IdCard));
        }
    }
}
