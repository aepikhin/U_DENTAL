using Microsoft.VisualStudio.TestTools.UnitTesting;
using U_DENTAL.BBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U_DENTAL.BBDD.DATA;

namespace U_DENTAL.BBDD.Tests
{
    [TestClass()]
    public class DBPruebasTests
    {

        DBPruebas dbInstancia;

        private DBPruebas fabrica()
        {
            if (dbInstancia == null)
                dbInstancia = new DBPruebas();
            return dbInstancia;
        }

        [TestMethod()]
        public void DBPruebasTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db);
        }

        [TestMethod()]
        public void selectAllDiagnosticosTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db.selectAllDiagnosticos());
        }

        [TestMethod()]
        public void asignaEspecialidadExpedienteTest()
        {
            DBPruebas db = fabrica();
            int exp = db.insertExpediente("n", "a", DateTime.Today, 'H');
            db.insertEspecialidad("espPR1");
            Assert.IsNull(db.selectExpediente(exp).Especialidad);
            db.asignaEspecialidadExpediente(db.selectExpediente(exp), db.selectEspecialidad("espPR1"));
            Assert.AreEqual(db.selectExpediente(exp).Especialidad.Nombre, db.selectEspecialidad("espPR1").Nombre);
        }

        [TestMethod()]
        public void asignaMedicoExpedienteTest()
        {
            DBPruebas db = fabrica();
            int exp = db.insertExpediente("n", "a", DateTime.Today, 'H');
            db.insertMedico("dniPR2", "n", "a", new Especialidad("espPR2"));
            Assert.IsNull(db.selectExpediente(exp).Medico);
            db.asignaMedicoExpediente(db.selectExpediente(exp), db.selectMedico("dniPR2"));
            Assert.AreEqual(db.selectExpediente(exp).Medico.DniMedico, db.selectMedico("dniPR2").DniMedico);
        }

        [TestMethod()]
        public void insertBoxTest()
        {
            DBPruebas db = fabrica();
            int iBoxes = db.selectAllBoxes().Count;
            db.insertBox();
            int iBoxes2 = db.selectAllBoxes().Count;
            Assert.AreNotEqual(iBoxes, iBoxes2);
        }

        [TestMethod()]
        public void insertEspecialidadTest()
        {
            DBPruebas db = fabrica();
            int iEsp= db.selectAllEspecialidades().Count;
            db.insertEspecialidad("espPR4");
            int iEsp2 = db.selectAllEspecialidades().Count;
            Assert.AreNotEqual(iEsp, iEsp2);
            Assert.AreEqual(db.selectEspecialidad("espPR4").Nombre, new Especialidad("espPR4").Nombre);
        }

        [TestMethod()]
        public void insertExpedienteTest()
        {
            DBPruebas db = fabrica();
            int iExp = db.selectAllExpedientes().Count;
            int exp = db.insertExpediente("n", "a", DateTime.Today, 'H');
            int iExp2 = db.selectAllExpedientes().Count;
            Assert.AreNotEqual(iExp, iExp2);
            Assert.AreEqual(db.selectExpediente(exp).NExpediente, exp);
        }

        [TestMethod()]
        public void insertMedicoTest()
        {
            DBPruebas db = fabrica();
            int iMed = db.selectAllMedicos().Count;
            db.insertMedico("dniPR6", "n", "a", new Especialidad("espPR6"));
            int iMed2 = db.selectAllMedicos().Count;
            Assert.AreNotEqual(iMed, iMed2);
            Assert.AreEqual(db.selectMedico("dniPR6").DniMedico, new Medico("dniPR6", "n1", "a1", new Especialidad("espPR6")).DniMedico);
        }

        [TestMethod()]
        public void selectAllBoxesTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db.selectAllBoxes());
        }

        [TestMethod()]
        public void selectAllEspecialidadesTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db.selectAllEspecialidades());
        }

        [TestMethod()]
        public void selectAllExpedientesTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db.selectAllExpedientes());
        }

        [TestMethod()]
        public void selectAllMedicosTest()
        {
            DBPruebas db = fabrica();
            Assert.IsNotNull(db.selectAllMedicos());
        }

        [TestMethod()]
        public void selectBoxTest() // 2 tipos
        {
            DBPruebas db = fabrica();
            int iBox = db.insertBox();
            Assert.AreEqual(db.selectBox(iBox).IdBox, iBox);
            int exp = db.insertExpediente("n", "a", DateTime.Today, 'H');
            db.selectBox(iBox).Cliente = db.selectExpediente(exp);
            Assert.AreEqual(db.selectBox(iBox).Cliente.NExpediente, db.selectExpediente(exp).NExpediente);
        }

        [TestMethod()]
        public void selectEspecialidadTest()
        {
            DBPruebas db = fabrica();
            db.insertEspecialidad("espPR12");
            Assert.AreEqual(db.selectEspecialidad("espPR12").Nombre, new Especialidad("espPR12").Nombre);
        }

        [TestMethod()]
        public void selectExpedienteTest() // 2 tipos
        {
            DBPruebas db = fabrica();
            int iExp = db.insertExpediente("n", "a", DateTime.Today, 'H');
            Assert.AreEqual(db.selectExpediente(iExp).NExpediente, iExp);
            int iBox = db.insertBox();
            db.selectBox(iBox).Cliente = db.selectExpediente(iExp);
            Assert.AreEqual(db.selectExpediente(db.selectBox(iBox)), db.selectExpediente(iExp));
        }

        [TestMethod()]
        public void selectExpedientesTest()
        {
            DBPruebas db = fabrica();
            db.insertMedico("dniPR14", "n", "a", new Especialidad("espPR14"));
            int iExp = db.insertExpediente("n", "a", DateTime.Today, 'H');
            int iExp2 = db.insertExpediente("n", "a", DateTime.Today, 'M');
            IList<Expediente> exp = new List<Expediente>() { db.selectExpediente(iExp), db.selectExpediente(iExp2) };
            exp[0].Especialidad = db.selectMedico("dniPR14").Especialidad;
            exp[1].Especialidad = db.selectMedico("dniPR14").Especialidad;
            exp[0].Medico = db.selectMedico("dniPR14");
            exp[1].Medico = db.selectMedico("dniPR14");
            int iBox = db.insertBox();
            db.selectBox(iBox).Especialidades = new List<Especialidad>() { db.selectMedico("dniPR14").Especialidad };
            Assert.AreEqual(db.selectExpedientes(db.selectBox(iBox)).Count, 2);
            CollectionAssert.AreEqual(db.selectExpedientes(db.selectBox(iBox)).ToArray(), exp.ToArray());
            CollectionAssert.AreNotEqual(db.selectExpedientes(db.selectBox(iBox)).ToArray(), new List<Expediente>() { exp[0] }.ToArray());
        }

        [TestMethod()]
        public void selectExpedientesNombreTest()
        {
            DBPruebas db = fabrica();
            db.insertExpediente("n15", "agreg", DateTime.Today, 'H');
            db.insertExpediente("n15", "agrer", DateTime.Today, 'M');
            Assert.AreEqual(db.selectExpedientesNombre("n15").Count, 2);
        }

        [TestMethod()]
        public void selectExpedientesApellidosTest()
        {
            DBPruebas db = fabrica();
            db.insertExpediente("dsan", "a16", DateTime.Today, 'H');
            db.insertExpediente("ndasd", "a16", DateTime.Today, 'M');
            Assert.AreEqual(db.selectExpedientesApellidos("a16").Count, 2);
        }

        [TestMethod()]
        public void selectMedicoTest()
        {
            DBPruebas db = fabrica();
            db.insertMedico("dniPR17", "n", "a", new Especialidad("espPR17"));
            Assert.AreEqual(db.selectMedico("dniPR17").DniMedico, new Medico("dniPR17", "n2", "a2", new Especialidad("espPR17")).DniMedico);
        }

        [TestMethod()]
        public void selectMedicosTest()
        {
            DBPruebas db = fabrica();
            db.insertMedico("dniPR18", "n", "a", new Especialidad("espPR18"));
            db.insertMedico("dni2PR18", "n", "a", db.selectMedico("dniPR18").Especialidad);
            IList<Medico> med = new List<Medico>() { db.selectMedico("dniPR18"), db.selectMedico("dni2PR18") };
            Assert.AreEqual(db.selectMedicos(db.selectMedico("dniPR18").Especialidad).Count, 2);
            CollectionAssert.AreEqual(db.selectMedicos(db.selectMedico("dniPR18").Especialidad).ToArray(), med.ToArray());
            CollectionAssert.AreNotEqual(db.selectMedicos(db.selectMedico("dniPR18").Especialidad).ToArray(), new List<Medico>() { db.selectMedico("dniPR18") }.ToArray());
        }
    }
}