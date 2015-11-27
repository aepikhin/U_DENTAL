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
    public partial class altaMedico : System.Web.UI.Page
    {
        DBPruebas db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Session["db"];
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if(TextNombre.Text.Trim() != "" && TextApellidos.Text.Trim() != "" && !CheckNif.Check(TextDni.Text, false))
            {
                db.insertMedico(TextDni.Text, TextNombre.Text, TextApellidos.Text, db.selectEspecialidad(DropDownListEspecialidad.SelectedValue));
                Response.Redirect("~/VIEW/app/grabado.aspx");
            }
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