using Core.DAL;
using Core.Models;
using Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    [TestFixture]
    public class NonQueryTests {
        [Test]
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
