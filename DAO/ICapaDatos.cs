using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO
{
    interface ICapaDatos
    {
        Especialidad altaEspecialidad(String especialidad);

        IList<Box> AsignaEspecialidadExpediente(Especialidad especialidad);

        IList<Especialidad> AsignaMedicoExpediente(Medico medico);

        Expediente altaExpediente(String nombre, String apellidos, Date fechaNac, Char sexo);

        Medico altaMedico(String dni, String nombre, String apeliido, Especialidad especialidad);

        Box altaBox();

        void updateExpediente();
    }
}
