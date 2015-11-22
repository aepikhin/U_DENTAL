using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U_DENTAL.VIEW.app
{
    public partial class altaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Dias
            for(int i=31; i > 0; i--){
                DropDownListDias.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
            }
            DropDownListDias.SelectedIndex = 0;

            // Meses
            DropDownListMeses.Items.Insert(0, new ListItem("Diciembre", "12"));
            DropDownListMeses.Items.Insert(0, new ListItem("Noviembre", "11"));
            DropDownListMeses.Items.Insert(0, new ListItem("Octubre", "10"));
            DropDownListMeses.Items.Insert(0, new ListItem("Septiembre", "9"));
            DropDownListMeses.Items.Insert(0, new ListItem("Agosto", "8"));
            DropDownListMeses.Items.Insert(0, new ListItem("Julio", "7"));
            DropDownListMeses.Items.Insert(0, new ListItem("Junio", "6"));
            DropDownListMeses.Items.Insert(0, new ListItem("Mayo", "5"));
            DropDownListMeses.Items.Insert(0, new ListItem("Abril", "4"));
            DropDownListMeses.Items.Insert(0, new ListItem("Marzo", "3"));
            DropDownListMeses.Items.Insert(0, new ListItem("Febrero", "2"));
            DropDownListMeses.Items.Insert(0, new ListItem("Enero", "1"));
            DropDownListMeses.SelectedIndex = 0;

            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                DropDownListAnios.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
            }
            DropDownListAnios.SelectedIndex = 0;


        }

        protected void DropDownListDias_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownListMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownListAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }
    }
}