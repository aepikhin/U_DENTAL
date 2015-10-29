using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATOS
{
    public class Especialidad
    {
        private String nombre;

        public Especialidad(String nombre)
        {
            this.nombre = nombre;
        }

        public String Nombre
        {
            get { return this.nombre; }
        }

        public override bool Equals(Especialidad esp)
        {
            return this.Nombre == esp.Nombre;
        }

        public override int GetHashCode()
        {
            return this.Nombre.GetHashCode();
        }
    }
}
