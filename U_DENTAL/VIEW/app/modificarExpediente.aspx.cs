using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U_DENTAL.BBDD;
using U_DENTAL.BBDD.DATA;

namespace U_DENTAL.VIEW.app
{
    public partial class modificarExpediente : System.Web.UI.Page
    {
        DBPruebas db;
        Expediente exp;
        Box box;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Session["db"];
            int nexp = 0;
            int.TryParse((String)Session["nexp"], out nexp);
            exp = db.selectExpediente(nexp);
            box = db.selectBox(exp);
            if (!IsPostBack)
            {
                TextBoxNExp.Text = "" + exp.NExpediente;
                TextBoxNombreYApellidos.Text = exp.Nombre + " " + exp.Apellido;
                TextBoxFechaNacimiento.Text = exp.FechaNac.ToShortDateString();
                TextBoxSexo.Text = exp.Sexo.ToString();

                rellenarDiagnostico();

                if(box != null)
                {
                    TextBoxBox.Text = "" + box.IdBox;
                    DropDownListEspecialidad.Items.Insert(0, new ListItem(exp.Especialidad.Nombre, "0"));
                    DropDownListEspecialidad.Enabled = false;
                    DropDownListMedico.Items.Insert(0, new ListItem(exp.Medico.Nombre + " " + exp.Medico.Apellido, "0"));
                    DropDownListMedico.Enabled = false;
                    if(exp.TipoDiagnostico != null)
                    {
                        DropDownListTipoDiagnostico.SelectedValue = exp.TipoDiagnostico;
                        TextBoxDiagnostico.Text = exp.Diagnostico;
                        TextBoxTratamiento.Text = exp.Tratamiento;
                    }
                }
                else
                {
                    foreach (Especialidad esp in db.selectAllEspecialidades())
                    {
                        DropDownListEspecialidad.Items.Insert(DropDownListEspecialidad.Items.Count, new ListItem(esp.Nombre, esp.Nombre));
                    }
                    TextBoxBox.Text = "Ninguno";
                    rellenarMedicos(db.selectEspecialidad(DropDownListEspecialidad.SelectedItem.Text));
                    DropDownListTipoDiagnostico.Enabled = false;
                    TextBoxDiagnostico.Enabled = false;
                    TextBoxTratamiento.Enabled = false;
                }
            }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (box != null)
            {
                if(TextBoxTratamiento.Text.Trim() != "" && DropDownListTipoDiagnostico.SelectedValue != "null" && TextBoxDiagnostico.Text.Trim() != "")
                {
                    exp.TipoDiagnostico = DropDownListTipoDiagnostico.SelectedValue;
                    if(exp.TipoDiagnostico == "alta")
                    {
                        db.selectBox(exp).Cliente = null;
                        exp.Medico.Libre = true;
                        exp.Medico = null;
                        exp.Especialidad = null;
                        exp.TipoDiagnostico = null;
                        exp.Diagnostico = null;
                        exp.Tratamiento = null;
                    } else
                    {
                        exp.Diagnostico = TextBoxDiagnostico.Text;
                        exp.Tratamiento = TextBoxTratamiento.Text;
                    }
                    Response.Redirect("~/VIEW/app/grabado.aspx");
                }
            }
            else
            {
                if (DropDownListMedico.SelectedValue != "0")
                {
                    Medico med = db.selectMedico(DropDownListMedico.SelectedValue);
                    db.asignaMedicoExpediente(exp, med);
                    db.asignaEspecialidadExpediente(exp, db.selectEspecialidad(DropDownListEspecialidad.SelectedValue));
                    Response.Redirect("~/VIEW/app/grabado.aspx");
                }
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected void DropDownListEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListMedico.Items.Clear();
            rellenarMedicos(db.selectEspecialidad(DropDownListEspecialidad.SelectedItem.Text));
        }

        protected void DropDownListMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rellenarMedicos(Especialidad esp)
        {
            IList<Medico> meds = db.selectMedicos(esp);
            foreach (Medico med in meds)
            {
                DropDownListMedico.Items.Insert(DropDownListMedico.Items.Count, new ListItem(med.Nombre + " " + med.Apellido, med.DniMedico));
            }
            if(meds.Count == 0)
            {
                DropDownListMedico.Items.Insert(0, new ListItem("No hay medicos libres", "0"));
            }
        }

        private void rellenarDiagnostico()
        {
            IList<String> strs = db.selectAllDiagnosticos();
            foreach (String str in strs)
            {
                DropDownListTipoDiagnostico.Items.Insert(DropDownListTipoDiagnostico.Items.Count, new ListItem(str, str));
            }
        }

        protected void DropDownListTipoDiagnostico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}