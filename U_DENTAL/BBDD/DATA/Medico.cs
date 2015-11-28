using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U_DENTAL.BBDD.DATA
{
    public class Medico
    {
        private String dniMedico;

        private String nombre;

        private String apellido;

        private Especialidad especialidad;

        private Boolean libre;

        public Medico(String dni, String nombre, String apellido, Especialidad especialidad)
        {
            this.dniMedico = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.especialidad = especialidad;
            this.libre = true;
        }

        public String DniMedico
        {
            get { return this.dniMedico; }
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

        public Especialidad Especialidad
        {
            get { return this.especialidad; }
        }

        public Boolean Libre
        {
            get { return this.libre; }
            set { this.libre = value; }
        }

        public bool Equals(Medico med)
        {
            return this.DniMedico == med.DniMedico;
        }

        public override int GetHashCode()
        {
            return this.DniMedico.GetHashCode();
        }

    }
}
