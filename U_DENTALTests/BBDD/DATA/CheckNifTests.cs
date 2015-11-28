using Microsoft.VisualStudio.TestTools.UnitTesting;
using U_DENTAL.BBDD.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U_DENTAL.BBDD.DATA.Tests
{
    [TestClass()]
    public class CheckNifTests
    {
        [TestMethod()]
        public void CheckTest()
        {
            Assert.IsFalse(CheckNif.Check("05265124X", false)); // Mi NIE sin letra delante, también valido.
            Assert.IsTrue(CheckNif.Check("5265124X", false));
            Assert.IsTrue(CheckNif.Check("15265124X", false));
            Assert.IsFalse(CheckNif.Check("X5265124X", false)); // Mi NIE real.
            Assert.IsTrue(CheckNif.Check("123", false));
            Assert.IsTrue(CheckNif.Check("123213123", false));
        }
    }
}