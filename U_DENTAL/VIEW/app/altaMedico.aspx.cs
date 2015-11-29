using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U_DENTAL.BBDD;
using U_DENTAL.BBDD.DATA;
using U_DENTAL.APP.DAO;

namespace U_DENTAL.VIEW.app
{
    public partial class altaMedico : System.Web.UI.Page
    {
        ICapaDatos db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Session["db"];
            TextDni.Focus();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if(TextNombre.Text.Trim() != "" && TextApellidos.Text.Trim() != "" && !CheckNif.Check(TextDni.Text, false))
            {
                if (!db.insertMedico(TextDni.Text, TextNombre.Text, TextApellidos.Text, db.selectEspecialidad(DropDownListEspecialidad.SelectedValue)))
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Medico existente!');", true);
                else
                    Response.Redirect("~/VIEW/app/grabado.aspx");
            } else ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Datos incorrectos!');", true);
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected void DropDownListEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}