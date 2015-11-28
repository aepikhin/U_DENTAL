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
    public class MedicoTests
    {
        [TestMethod()]
        public void MedicoTest()
        {
            Medico a = new Medico("dni", "n", "a", new Especialidad("e"));
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Medico a = new Medico("dni", "n", "a", new Especialidad("e"));
            Medico b = new Medico("dni", "n", "a", new Especialidad("e"));
            Medico c = new Medico("dni1", "n", "a", new Especialidad("e"));
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(c.Equals(a));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Medico a = new Medico("dni", "n", "a", new Especialidad("e"));
            Assert.AreEqual(a.GetHashCode(), "dni".GetHashCode());
            Assert.AreNotEqual(a.GetHashCode(), "dni1".GetHashCode());
        }

        [TestMethod()]
        public void GetterSetterTest()
        {
            Medico med = new Medico("dni", "n", "a", new Especialidad("esp1"));

            // Setters
            med.Nombre = "nombre";
            med.Apellido = "apellido";
            med.Libre = false;

            //Getters
            Assert.AreEqual(med.DniMedico, "dni");
            Assert.AreNotEqual(med.DniMedico, "dni2");

            Assert.AreEqual(med.Nombre, "nombre");
            Assert.AreNotEqual(med.Nombre, "n");

            Assert.AreEqual(med.Apellido, "apellido");
            Assert.AreNotEqual(med.Apellido, "a");

            Assert.AreEqual(med.Especialidad.Nombre, "esp1");
            Assert.AreNotEqual(med.Especialidad.Nombre, "esp2");

            Assert.IsFalse(med.Libre);
        }
    }
}