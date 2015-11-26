using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U_DENTAL.BBDD.DATA
{
    public class Expediente
    {
        private int nExpediente;

        private String nombre;

        private String apellido;

        private DateTime fechaNac;

        private Char sexo;

        private Medico medico;

        private String tratamiento;

        private String tipoDiagnostico;

        private String diagnostico;

        private Especialidad especialidad;

        public Expediente(int nExpediente, String nombre, String apellidos, DateTime fechaNac, char sexo)
        {
            this.nExpediente = nExpediente;
            this.nombre = nombre;
            this.apellido = apellidos;
            this.fechaNac = fechaNac;
            this.sexo = sexo;
        }

        public int NExpediente
        {
            get { return this.nExpediente; }
        }

        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public String Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public DateTime FechaNac
        {
            get { return this.fechaNac; }
            set { this.fechaNac = value; }
        }

        public Char Sexo
        {
            get { return this.sexo; }
            set { this.sexo = value; }
        }

        public Medico Medico
        {
            get { return this.medico; }
            set { this.medico = value; }
        }

        public String Tratamiento
        {
            get { return this.tratamiento; }
            set { this.tratamiento = value; }
        }

        public String TipoDiagnostico
        {
            get { return this.tipoDiagnostico; }
            set { this.tipoDiagnostico = value; }
        }

        public String Diagnostico
        {
            get { return this.diagnostico; }
            set { this.diagnostico = value; }
        }

        public Especialidad Especialidad
        {
            get { return this.especialidad; }
            set { this.especialidad = value; }
        }

        public bool Equals(Expediente exp)
        {
            return this.NExpediente == exp.NExpediente;
        }

        public override int GetHashCode()
        {
            return this.NExpediente.GetHashCode();
        }
    }
}
