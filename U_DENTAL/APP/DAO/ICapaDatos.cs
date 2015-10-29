using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U_DENTAL.DDBB.DATA;

namespace U_DENTAL.APP.DAO
{
    interface ICapaDatos
    {
        Especialidad altaEspecialidad(String especialidad);

        IList<Box> AsignaEspecialidadExpediente(Especialidad especialidad);

        IList<Especialidad> AsignaMedicoExpediente(Medico medico);

        Expediente altaExpediente(String nombre, String apellidos, DateTime fechaNac, Char sexo);

        Medico altaMedico(String dni, String nombre, String apellido, Especialidad especialidad);

        Box altaBox();

        void updateExpediente();

        int insertExpediente(String nombre, String apellidos, DateTime fechaNac, char sexo);

        Boolean insertMedico(String dni, String nombre, String apeliido, Especialidad especialidad);

        Boolean insertEspecialidad(String nombre);

        int insertBox();

        IList<Expediente> selectAllExpedientes();

        Expediente selectExpediente(int nExpediente);

        IList<Expediente> selectExpedientes(String nombre, String apellido);

        IList<Medico> selectAllMedicos();

        Medico selectMedico(String dniMedico);

        IList<Medico> selectMedicos(Especialidad especialidad);

        IList<Especialidad> selectAllEspecialidades();

        Especialidad selectEspecialidad(String especialidad);

        IList<Box> selectAllBoxes();

        Box selectBox(int idBox);

        IList<Expediente> selectExpedientes(Box box);

        IList<Box> asignaEspecialidadExpediente(Especialidad especialidad);

        IList<Especialidad> asignaMedicoExpediente(Medico medico);
    }
}
