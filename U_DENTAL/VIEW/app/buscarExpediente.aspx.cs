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
    public partial class buscarExpediente : System.Web.UI.Page
    {
        DBPruebas db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Session["db"];
            TextBuscar.Focus();
            if (!IsPostBack)
            {
                ListBoxEncontrados.Items.Insert(0, new ListItem("Expediente a mostrar", "0"));
                ListBoxEncontrados.SelectedIndex = 0;
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            ListBoxEncontrados.Items.Clear();
            if (RadioButtonListBuscar.SelectedValue == "NEXP")
            {
                int nexp = 0;
                if (int.TryParse(TextBuscar.Text, out nexp))
                {
                    Expediente exp = db.selectExpediente(nexp);
                    if (exp != null)
                        ListBoxEncontrados.Items.Insert(0, new ListItem(nexp + " " + exp.Nombre + " " + exp.Apellido, "" + nexp));
                    else
                        ListBoxEncontrados.Items.Insert(0, new ListItem("No existe el expediente", "0"));
                } else
                {
                    ListBoxEncontrados.Items.Insert(0, new ListItem("No existe el expediente", "0"));
                }
            }
            else if (RadioButtonListBuscar.SelectedValue == "NOMB")
            {
                IList<Expediente> exps = (IList<Expediente>)db.selectExpedientesNombre(TextBuscar.Text);
                addExpedientes(exps, "No existe nadie con este nombre");
            }
            else
            {
                IList<Expediente> exps = (IList<Expediente>)db.selectExpedientesApellidos(TextBuscar.Text);
                addExpedientes(exps, "No existe nadie con estos apellidos");
            }
            ListBoxEncontrados.SelectedIndex = 0;
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if(ListBoxEncontrados.SelectedIndex >= 0 && ListBoxEncontrados.SelectedValue != "0")
            {
                Session["nexp"] = ListBoxEncontrados.SelectedValue;
                Response.Redirect("~/VIEW/app/modificarExpediente.aspx");
            } else ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Datos incorrectos!');", true);
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected void ListBoxEncontrados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addExpedientes(IList<Expediente> exps, String Mensaje)
        {
            foreach (Expediente exp in exps)
            {
                ListBoxEncontrados.Items.Insert(0, new ListItem(exp.NExpediente + " " + exp.Nombre + " " + exp.Apellido, "" + exp.NExpediente));
            }
            if (exps.Count == 0)
                ListBoxEncontrados.Items.Insert(0, new ListItem(Mensaje, "0"));
        }
    }
}