using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATOS
{
    public class Medico
    {
        private String dniMedico;

        private String nombre;

        private String apellido;

        private Especialidad especialidad;

        private IList<Box> boxes;

        private boolean libre;

        public Medico(String dni, String nombre, String apeliido, Especialidad especialidad)
        {
            this.dniMedico = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.especialidad = especialidad;
            boxes = new List<Box>();
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

        public IList<Box> Boxes
        {
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    this.boxes.Add(value[i]);
                }
            }
            get { return this.boxes; }
        }

        public boolean Libre
        {
            get { return this.libre; }
            set { this.libre = value; }
        }

        public override bool Equals(Medico med)
        {
            return this.DniMedico == med.DniMedico;
        }

        public override int GetHashCode()
        {
            return this.DniMedico.GetHashCode();
        }

    }
}
