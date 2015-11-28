using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using U_DENTAL.BBDD.DATA;
using U_DENTAL.APP.DAO;

namespace U_DENTAL.BBDD
{
    public class DBPruebas : ICapaDatos
    {

        private IList<Expediente> expedientes;
        private IList<Medico> medicos;
        private IList<Box> boxes;
        private IList<Especialidad> especialidades;
        private IList<String> diagnosticos;
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
            this.diagnosticos = new List<String>();
            inicializarDatos();
        }

        public IList<String> selectAllDiagnosticos()
        {
            return this.diagnosticos;
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

        public bool insertEspecialidad(String nombre)
        {
            if (this.especialidades.Any(x => x.Nombre == nombre))
                return false;
            this.especialidades.Add(new Especialidad(nombre));
            return true;
        }

        public int insertExpediente(String nombre, String apellidos, DateTime fechaNac, char sexo)
        {
            this.expedientes.Add(new Expediente(this.expediente += 1, nombre, apellidos, fechaNac, sexo));
            return this.expediente;
        }

        public bool insertMedico(String dni, String nombre, String apellido, Especialidad especialidad)
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

        public Box selectBox(Expediente expediente)
        {
            foreach (Box tempBox in this.boxes)
                if (tempBox.Cliente != null && tempBox.Cliente.Equals(expediente))
                    return tempBox;
            return null;
        }

        public Especialidad selectEspecialidad(String especialidad)
        {
            foreach (Especialidad espe in this.especialidades)
                if (espe.Nombre == especialidad)
                    return espe;
            return null;
        }

        public Expediente selectExpediente(int nExpediente)
        { // La ids empiezan en 1.
            if (this.expedientes.Count < nExpediente || 0 >= nExpediente)
                return null;
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
                if (expe.Medico != null && expe.Medico.Libre && box.Especialidades.Contains(expe.Especialidad))
                    tempExpe.Add(expe);
            return tempExpe;
        }

        public IList<Expediente> selectExpedientesNombre(String nombre)
        {
            IList<Expediente> tempExpe = new List<Expediente>();
            foreach (Expediente expe in this.expedientes)
                if (expe.Nombre == nombre)
                    tempExpe.Add(expe);
            return tempExpe;
        }

        public IList<Expediente> selectExpedientesApellidos(String apellido)
        {
            IList<Expediente> tempExpe = new List<Expediente>();
            foreach (Expediente expe in this.expedientes)
                if (expe.Apellido == apellido)
                    tempExpe.Add(expe);
            return tempExpe;
        }

        public Medico selectMedico(String dniMedico)
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

            int temp;


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
            this.insertMedico("12345678E", "Medico 5", "ApellidoMedico 5", this.selectEspecialidad("Especialidad 3"));

            // Expedientes / Clientes
            temp = this.insertExpediente("Nombre 1", "Apellido 1", DateTime.Parse("12/12/1912"), 'H');
            this.asignaMedicoExpediente(this.selectExpediente(temp), this.selectMedico("12345678A"));
            this.asignaEspecialidadExpediente(this.selectExpediente(temp), this.selectEspecialidad("Especialidad 1"));

            temp = this.insertExpediente("Nombre 2", "Apellido 2", DateTime.Parse("13/11/1912"), 'M');
            this.asignaMedicoExpediente(this.selectExpediente(temp), this.selectMedico("12345678E"));
            this.asignaEspecialidadExpediente(this.selectExpediente(temp), this.selectEspecialidad("Especialidad 3"));

            this.insertExpediente("Nombre 3", "Apellido 3", DateTime.Parse("14/10/1912"), 'H');
            this.asignaMedicoExpediente(this.selectExpediente(temp), this.selectMedico("12345678D"));
            this.asignaEspecialidadExpediente(this.selectExpediente(temp), this.selectEspecialidad("Especialidad 2"));

            this.insertExpediente("Nombre 4", "Apellido 4", DateTime.Parse("15/09/1912"), 'M');
            this.insertExpediente("Nombre 6", "Apellido 4", DateTime.Parse("15/09/1966"), 'M');
            this.insertExpediente("Nombre 4", "Apellido 5", DateTime.Parse("15/09/1942"), 'M');

            this.insertExpediente("Pepe", "Apellido 1", DateTime.Parse("12/12/1912"), 'H');
            this.insertExpediente("Pepe", "Apellido 2", DateTime.Parse("12/12/1912"), 'M');

            // Boxes
            temp = this.insertBox();
            this.selectBox(temp).Cliente = this.selectExpediente(1);
            this.selectBox(temp).Cliente.Medico.Libre = false;
            this.selectBox(temp).Especialidades = new List<Especialidad>() { this.selectEspecialidad("Especialidad 1") };
            this.selectBox(temp).Especialidades = new List<Especialidad>() { this.selectEspecialidad("Especialidad 2") };
            temp = this.insertBox();
            this.selectBox(temp).Cliente = null;
            this.selectBox(temp).Especialidades = new List<Especialidad>() { this.selectEspecialidad("Especialidad 2") };
            temp = this.insertBox();
            this.selectBox(temp).Cliente = null;
            this.selectBox(temp).Especialidades = new List<Especialidad>() { this.selectEspecialidad("Especialidad 3") };
            temp = this.insertBox();
            this.selectBox(temp).Cliente = this.selectExpediente(2);
            this.selectBox(temp).Cliente.Medico.Libre = false;
            this.selectBox(temp).Especialidades = new List<Especialidad>() { this.selectEspecialidad("Especialidad 3") };

            // Diagnosticos
            this.diagnosticos.Add("leve");
            this.diagnosticos.Add("grave");
            this.diagnosticos.Add("muy grave");
            this.diagnosticos.Add("alta");
        }
    }
}