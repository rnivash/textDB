﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TextDB;

namespace textDB.Tests
{
    [TestClass]
    public class DeleteTests
    {
        [TestInitialize]
        public void TestSetup()
        {
            Notepad.Delete<Student>();
        }

        [TestMethod]
        public void DeleteEntityTest()
        {
            var entity1 = new Student
            {
                Name = "Darshan",
                Age = 13,
                Section = "A",
                CreatedOn = DateTime.Now,
                IsActive = true
            };

            Notepad.InsertValue(entity1);

            Notepad.Delete<Student>();

            var list = Notepad.Select<Student>();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DeleteSpecificEntityTest()
        {
            var entity1 = new Student
            {
                Name = "Darshan",
                Age = 13,
                Section = "A",
                IsActive = true
            };
            var entity2 = new Student
            {
                Name = "Nivash",
                Age = 34,
                Section = "B",
                IsActive = true
            };

            Notepad.InsertValue<Student>(new List<Student> { entity1, entity2 });

            Notepad.Delete<Student>(entity1);

            var list = Notepad.Select<Student>();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Nivash", list[0].Name);
        }

        [TestMethod]
        public void DeleteEntityFilterTest()
        {
            var entity1 = new Student
            {
                Name = "Darshan",
                Age = 13,
                Section = "A",
                IsActive = true
            };
            var entity2 = new Student
            {
                Name = "Nivash",
                Age = 34,
                Section = "B",
                IsActive = true
            };

            Notepad.InsertValue<Student>(new List<Student> { entity1, entity2 });

            Notepad.Delete<Student>(std => std.Name == "Nivash" && std.Age == 34);

            var list = Notepad.Select<Student>();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Darshan", list[0].Name);
        }
    }
}
