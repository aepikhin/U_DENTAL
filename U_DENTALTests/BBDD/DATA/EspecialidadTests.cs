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
    public class EspecialidadTests
    {
        [TestMethod()]
        public void EspecialidadTest()
        {
            Especialidad a = new Especialidad("esp1");
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Especialidad a = new Especialidad("esp1");
            Especialidad b = new Especialidad("esp1");
            Especialidad c = new Especialidad("esp2");
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(c.Equals(a));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Especialidad a = new Especialidad("esp1");
            Assert.AreEqual(a.GetHashCode(), "esp1".GetHashCode());
            Assert.AreNotEqual(a.GetHashCode(), "esp2".GetHashCode());
        }

        [TestMethod()]
        public void GetterSetterTest()
        {
            Especialidad esp = new Especialidad("esp1");

            //Getters
            Assert.AreEqual(esp.Nombre, "esp1");
            Assert.AreNotEqual(esp.Nombre, "esp2");
        }
    }
}