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
            /*db = (DBPruebas)Session["db"];
            IList<Especialidad> esp = (IList<Especialidad>)db.selectAllEspecialidades();
            for (int i=0; i < esp.Count; i++)
            {
                DropDownListEspecialidad.Items.Insert("");
            }*/
            
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            //Session["db"] = db;
        }

        protected void DropDownListEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}