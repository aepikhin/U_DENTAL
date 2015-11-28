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
    public class BoxTests
    {
        [TestMethod()]
        public void BoxTest()
        {
            Box a = new Box(1);
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Box a = new Box(1);
            Box b = new Box(1);
            Box c = new Box(2);
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(c.Equals(a));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Box a = new Box(1);
            Assert.AreEqual(a.GetHashCode(), 1);
            Assert.AreNotEqual(a.GetHashCode(), 2);
        }

        [TestMethod()]
        public void GetterSetterTest()
        {
            Box box = new Box(1);
            IList<Especialidad> esp = new List<Especialidad>() { new Especialidad("esp1"), new Especialidad("esp2") };
            Expediente exp = new Expediente(1, "n", "a", DateTime.Today, 'H');

            // Setters
            box.Especialidades = esp;
            box.Cliente = exp;

            //Getters
            Assert.AreEqual(box.IdBox, 1);
            Assert.AreNotEqual(box.IdBox, 2);

            CollectionAssert.AreEqual(box.Especialidades.ToArray(), esp.ToArray());
            CollectionAssert.AreNotEqual(box.Especialidades.ToArray(), new List<Especialidad>() { new Especialidad("esp1") }.ToArray());

            Assert.AreEqual(box.Cliente, exp);
            Assert.AreNotEqual(box.Cliente, new Expediente(2, "n", "a", DateTime.Today, 'H'));
        }
    }
}