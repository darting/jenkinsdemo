﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using Core.DAL;
using Core.Services; 

namespace UnitTestProject1 {
    [TestClass]
    public class QueryTests {
        [TestMethod]
        public void ListAllStudents() {
            var data = new List<Student> 
            { 
                new Student { LastName = "BBB" }, 
                new Student { LastName = "ZZZ" }, 
                new Student { LastName = "AAA" }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Student>>();
            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<SchoolContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);

            var service = new StudentService(mockContext.Object);
            var students = service.ListAllStudents();

            Assert.AreEqual(3, students.Count);
            Assert.AreEqual("AAA1", students[0].LastName);
            Assert.AreEqual("BBB", students[1].LastName);
            Assert.AreEqual("ZZZ", students[2].LastName); 
        }
    }
}
