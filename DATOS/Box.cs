using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA
{
    public class Box
    {

        private int idBox;

        private IList<Especialidad> especialidades;

        private Expediente cliente;

        public Box(int idBox)
        {
            this.idBox = idBox;
            this.especialidades = new List<Especialidad>();
        }

        public int IdBox
        {
            get { return this.idBox; }
        }

        public IList<Especialidad> Especialidades
        {
            get { return this.especialidades; }
            set {
                for (int i = 0; i < value.Count; i++)
                {
                    this.especialidades.Add(value[i]);
                }
            }
        }

        public Expediente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        public override bool Equals(Box box)
        {
            return this.IdBox == box.IdBox;
        }

        public override int GetHashCode()
        {
            return this.IdBox.GetHashCode();
        }
    }
}
