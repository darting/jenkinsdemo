using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests {

    [TestFixture(Ignore = true)]
    public class NUnitTest {

        [TestCase(1)]
        public void TestUsingTestcase(int a) {
            Assert.Fail("should be ignored ");
        }

    }
}

