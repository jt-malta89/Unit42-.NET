using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ApplicationLogic;
using ObjectGettersSetters;

namespace UnitTestingTeacher
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestSaveTeacher_Fails()
        {
            Teacher teacher = new Teacher();
            bool resSaveTeacher = TeacherService.Save(teacher);
            Assert.IsFalse(resSaveTeacher);
        }

        [TestMethod]
        public void TestSaveTeacher_Succeeds()
        {
            Teacher teacher = new Teacher();
            teacher.IdCard = "59780M";
            bool resSaveTeacher = TeacherService.Save(teacher);
            Assert.IsTrue(resSaveTeacher);
        }


        [TestMethod]
        public void TestLoadTeacher_Fails()
        {
            Teacher teacher = TeacherService.Load("59780");
            Assert.IsNull(teacher);
        }

        [TestMethod]
        public void TestLoadTeacher_Succeeds()
        {

            Teacher teacher = TeacherService.Load("59780M");
            Assert.IsNotNull(teacher);
            Assert.AreEqual(teacher.IdCard, "59780M");
        }


        [TestMethod]
        public void TestLoadTeachers_Succeeds()
        {

            List<Teacher> lstTeachers = TeacherService.Load();
            Assert.IsNotNull(lstTeachers);
            Assert.IsTrue(lstTeachers.Count > 0);
            Assert.IsNotNull(lstTeachers[0]);
            Assert.IsFalse(string.IsNullOrWhiteSpace(lstTeachers[0].IdCard));
        }
    }
}