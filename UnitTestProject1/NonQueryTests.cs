using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Core.Models;
using Core.DAL;
using System.Data.Entity;
using Core.Services;

namespace UnitTestProject1 {
    [TestClass]
    public class NonQueryTests {
        [TestMethod]
        public void CreateStudent() {
            var mockSet = new Mock<DbSet<Student>>();
            var mockCtx = new Mock<SchoolContext>();
            mockCtx.Setup(m => m.Students).Returns(mockSet.Object);

            var service = new StudentService(mockCtx.Object);
            service.AddStudent("valor", "zhong");

            mockSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once());
            mockCtx.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
