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
    public class ExpedienteTests
    {
        [TestMethod()]
        public void ExpedienteTest()
        {
            Expediente a = new Expediente(1, "n", "a", DateTime.Today, 'H');
            Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Expediente a = new Expediente(1, "n", "a", DateTime.Today, 'H');
            Expediente b = new Expediente(1, "n1", "a1", DateTime.Today, 'M');
            Expediente c = new Expediente(2, "n1", "a1", DateTime.Today, 'M');
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(c.Equals(a));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Expediente a = new Expediente(1, "n", "a", DateTime.Today, 'H');
            Assert.AreEqual(a.GetHashCode(), 1);
            Assert.AreNotEqual(a.GetHashCode(), 2);
        }

        [TestMethod()]
        public void GetterSetterTest()
        {
            Expediente exp = new Expediente(1, "n", "a", DateTime.Today, 'H');

            // Setters
            exp.Nombre = "nombre";
            exp.Apellido = "apellido";
            exp.FechaNac = DateTime.Parse("12/12/1912");
            exp.Sexo = 'M';
            exp.Especialidad = (new Especialidad("esp1"));
            exp.Medico = new Medico("dni", "n", "a", new Especialidad("esp1"));
            exp.TipoDiagnostico = "leve";
            exp.Diagnostico = "diag";
            exp.Tratamiento = "trat";

            //Getters
            Assert.AreEqual(exp.NExpediente, 1);
            Assert.AreNotEqual(exp.NExpediente, 2);

            Assert.AreEqual(exp.Nombre, "nombre");
            Assert.AreNotEqual(exp.Nombre, "n");

            Assert.AreEqual(exp.Apellido, "apellido");
            Assert.AreNotEqual(exp.Apellido, "a");

            Assert.AreEqual(exp.FechaNac, DateTime.Parse("12/12/1912"));
            Assert.AreNotEqual(exp.FechaNac, DateTime.Today);

            Assert.AreEqual(exp.Sexo, 'M');
            Assert.AreNotEqual(exp.Sexo, 'H');

            Assert.AreEqual(exp.Especialidad.Nombre, "esp1");
            Assert.AreNotEqual(exp.Especialidad.Nombre, "esp2");

            Assert.AreEqual(exp.Medico.DniMedico, "dni");
            Assert.AreNotEqual(exp.Medico.DniMedico, "dni2");

            Assert.AreEqual(exp.TipoDiagnostico, "leve");
            Assert.AreNotEqual(exp.TipoDiagnostico, "grave");

            Assert.AreEqual(exp.Diagnostico, "diag");
            Assert.AreNotEqual(exp.Diagnostico, "diag2");

            Assert.AreEqual(exp.Tratamiento, "trat");
            Assert.AreNotEqual(exp.Tratamiento, "trat2");
        }

    }
}