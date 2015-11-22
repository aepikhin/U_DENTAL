using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U_DENTAL.DDBB.DATA;

namespace U_DENTAL.APP.DAO
{
    interface ICapaDatos
    {
        void asignaEspecialidadExpediente(Expediente expediente, Especialidad especialidad);

        void asignaMedicoExpediente(Expediente expediente, Medico medico);

        int insertExpediente(String nombre, String apellidos, DateTime fechaNac, char sexo);

        Boolean insertMedico(String dni, String nombre, String apellido, Especialidad especialidad);

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
    }
}
