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

        public void asignaEspecialidadExpediente(Expediente expediente, Especialidad especialidad)
        {
            expediente.Especialidad = especialidad;
        }

        public void asignaMedicoExpediente(Expediente expediente, Medico medico)
        {
            expediente.Medico = medico;
        }

        public int insertBox()
        {
            this.boxes.Add(new Box(this.box += 1));
            return this.box;
        }

        public bool insertEspecialidad(string nombre)
        {
            if (this.especialidades.Any(x => x.Nombre == nombre))
                return false;
            this.especialidades.Add(new Especialidad(nombre));
            return true;
        }

        public int insertExpediente(string nombre, string apellidos, DateTime fechaNac, char sexo)
        {
            this.expedientes.Add(new Expediente(this.expediente += 1, nombre, apellidos, fechaNac, sexo));
            return this.expediente;
        }

        public bool insertMedico(string dni, string nombre, string apellido, Especialidad especialidad)
        {
            if (this.medicos.Any(x => x.DniMedico == dni))
                return false;
            this.medicos.Add(new Medico(dni, nombre, apellido, especialidad));
            return true;
        }

        public IList<Box> selectAllBoxes()
        {
            return this.boxes;
        }

        public IList<Especialidad> selectAllEspecialidades()
        {
            return this.especialidades;
        }

        public IList<Expediente> selectAllExpedientes()
        {
            return this.expedientes;
        }

        public IList<Medico> selectAllMedicos()
        {
            return this.medicos;
        }

        public Box selectBox(int idBox)
        { // La ids empiezan en 1.
            return this.boxes[idBox - 1]; 
        }

        public Especialidad selectEspecialidad(string especialidad)
        {
            foreach (Especialidad espe in this.especialidades)
                if (espe.Nombre == especialidad)
                    return espe;
            return null;
        }

        public Expediente selectExpediente(int nExpediente)
        { // La ids empiezan en 1.
            return this.expedientes[nExpediente - 1];
        }

        public Expediente selectExpediente(Box box)
        {
            foreach (Box tempBox in this.boxes)
                if (tempBox.Equals(box))
                    return tempBox.Cliente;
            return null;
        }

        public IList<Expediente> selectExpedientes(Box box)
        {
            IList<Expediente> tempExpe = new List<Expediente>();
            foreach (Expediente expe in this.expedientes)
                if (expe.Medico.Libre && box.Especialidades.Contains(expe.Especialidad))
                    tempExpe.Add(expe);
            return tempExpe;
        }

        public IList<Expediente> selectExpedientes(string nombre, string apellido)
        {
            IList<Expediente> tempExpe = new List<Expediente>();
            foreach (Expediente expe in this.expedientes)
                if (expe.Nombre == nombre && expe.Apellido == apellido)
                    tempExpe.Add(expe);
            return tempExpe;
        }

        public IList<Expediente> selectExpedientes(string dniMedico)
        {
            IList<Expediente> tempExpe = new List<Expediente>();
            foreach (Expediente expe in this.expedientes)
                if (expe.Medico.DniMedico == dniMedico)
                    tempExpe.Add(expe);
            return tempExpe;
        }

        public Medico selectMedico(string dniMedico)
        {
            foreach (Medico medico in this.medicos)
                if (medico.DniMedico == dniMedico)
                    return medico;
            return null;
        }

        public IList<Medico> selectMedicos(Especialidad especialidad)
        {
            IList<Medico> tempMedicos = new List<Medico>();
            foreach (Medico medico in this.medicos)
                if (medico.Especialidad == especialidad)
                    tempMedicos.Add(medico);
            return tempMedicos;
        }

        private void inicializarDatos()
        {
            // Expedientes / Clientes
            this.insertExpediente("Nombre 1", "Apellido 1", DateTime.Parse("12/12/1912"), 'H');
            this.insertExpediente("Nombre 2", "Apellido 2", DateTime.Parse("13/11/1912"), 'M');
            this.insertExpediente("Nombre 3", "Apellido 3", DateTime.Parse("14/10/1912"), 'H');
            this.insertExpediente("Nombre 4", "Apellido 4", DateTime.Parse("15/09/1912"), 'M');

            // Especialidades
            this.insertEspecialidad("Especialidad 1");
            this.insertEspecialidad("Especialidad 2");
            this.insertEspecialidad("Especialidad 3");
            this.insertEspecialidad("Especialidad 4");

            // Medicos
            this.insertMedico("12345678A", "Medico 1", "ApellidoMedico 1", this.selectEspecialidad("Especialidad 1"));
            this.insertMedico("12345678B", "Medico 2", "ApellidoMedico 2", this.selectEspecialidad("Especialidad 1"));
            this.insertMedico("12345678C", "Medico 3", "ApellidoMedico 3", this.selectEspecialidad("Especialidad 2"));
            this.insertMedico("12345678D", "Medico 4", "ApellidoMedico 4", this.selectEspecialidad("Especialidad 2"));

            // Boxes
            int temp;
            temp = this.insertBox();
            this.insertBox();
            this.insertBox();
            this.insertBox();
        }
    }
}