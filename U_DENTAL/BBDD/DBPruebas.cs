using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using U_DENTAL.DDBB.DATA;
using U_DENTAL.APP.DAO;

namespace U_DENTAL.BBDD
{
    public class DBPruebas : ICapaDatos
    {

        private IList<Expediente> expedientes;
        private IList<Medico> medicos;
        private IList<Box> boxes;
        private IList<Especialidad> especialidades;
        private int expediente;
        private int box;

        public DBPruebas()
        {
            this.expediente = 0;
            this.box = 0;
            this.expedientes = new List<Expediente>();
            this.medicos = new List<Medico>();
            this.boxes = new List<Box>();
            this.especialidades = new List<Especialidad>();
            inicializarDatos();
        }

        public Box altaBox()
        {
            throw new NotImplementedException();
        }

        public Especialidad altaEspecialidad(string especialidad)
        {
            throw new NotImplementedException();
        }

        public Expediente altaExpediente(string nombre, string apellidos, DateTime fechaNac, char sexo)
        {
            throw new NotImplementedException();
        }

        public Medico altaMedico(string dni, string nombre, string apellido, Especialidad especialidad)
        {
            throw new NotImplementedException();
        }

        public IList<Box> asignaEspecialidadExpediente(Especialidad especialidad)
        {
            throw new NotImplementedException();
        }

        public IList<Box> AsignaEspecialidadExpediente(Especialidad especialidad)
        {
            throw new NotImplementedException();
        }

        public IList<Especialidad> asignaMedicoExpediente(Medico medico)
        {
            throw new NotImplementedException();
        }

        public IList<Especialidad> AsignaMedicoExpediente(Medico medico)
        {
            throw new NotImplementedException();
        }

        public int insertBox()
        {
            throw new NotImplementedException();
        }

        public bool insertEspecialidad(string nombre)
        {
            throw new NotImplementedException();
        }

        public int insertExpediente(string nombre, string apellidos, DateTime fechaNac, char sexo)
        {
            throw new NotImplementedException();
        }

        public bool insertMedico(string dni, string nombre, string apeliido, Especialidad especialidad)
        {
            throw new NotImplementedException();
        }

        public IList<Box> selectAllBoxes()
        {
            throw new NotImplementedException();
        }

        public IList<Especialidad> selectAllEspecialidades()
        {
            throw new NotImplementedException();
        }

        public IList<Expediente> selectAllExpedientes()
        {
            throw new NotImplementedException();
        }

        public IList<Medico> selectAllMedicos()
        {
            throw new NotImplementedException();
        }

        public Box selectBox(int idBox)
        {
            throw new NotImplementedException();
        }

        public Especialidad selectEspecialidad(string especialidad)
        {
            throw new NotImplementedException();
        }

        public Expediente selectExpediente(int nExpediente)
        {
            throw new NotImplementedException();
        }

        public IList<Expediente> selectExpedientes(Box box)
        {
            throw new NotImplementedException();
        }

        public IList<Expediente> selectExpedientes(string nombre, string apellido)
        {
            throw new NotImplementedException();
        }

        public Medico selectMedico(string dniMedico)
        {
            throw new NotImplementedException();
        }

        public IList<Medico> selectMedicos(Especialidad especialidad)
        {
            throw new NotImplementedException();
        }

        public void updateExpediente()
        {
            throw new NotImplementedException();
        }

        private void inicializarDatos()
        {
            //this.expedientes.Ad
        }
    }
}