using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U_DENTAL.BBDD;
using U_DENTAL.BBDD.DATA;
using System.Globalization;

namespace U_DENTAL.VIEW.app
{
    public partial class altaPaciente : System.Web.UI.Page
    {
        DBPruebas db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Session["db"];

            // Dias
            for (int i=31; i > 0; i--){
                DropDownListDias.Items.Insert(0, new ListItem(i.ToString(), (i > 9) ? i.ToString() : "0" + i));
            }
            DropDownListDias.SelectedIndex = 0;

            // Meses
            DropDownListMeses.Items.Insert(0, new ListItem("Diciembre", "12"));
            DropDownListMeses.Items.Insert(0, new ListItem("Noviembre", "11"));
            DropDownListMeses.Items.Insert(0, new ListItem("Octubre", "10"));
            DropDownListMeses.Items.Insert(0, new ListItem("Septiembre", "09"));
            DropDownListMeses.Items.Insert(0, new ListItem("Agosto", "08"));
            DropDownListMeses.Items.Insert(0, new ListItem("Julio", "07"));
            DropDownListMeses.Items.Insert(0, new ListItem("Junio", "06"));
            DropDownListMeses.Items.Insert(0, new ListItem("Mayo", "05"));
            DropDownListMeses.Items.Insert(0, new ListItem("Abril", "04"));
            DropDownListMeses.Items.Insert(0, new ListItem("Marzo", "03"));
            DropDownListMeses.Items.Insert(0, new ListItem("Febrero", "02"));
            DropDownListMeses.Items.Insert(0, new ListItem("Enero", "01"));
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
            if(TextNombre.Text.Trim() != "" && TextApellidos.Text.Trim() != "")
            {
                db.insertExpediente(TextNombre.Text, TextApellidos.Text, getFecha(), RadioButtonListSexo.SelectedValue[0]);
                Response.Redirect("~/VIEW/app/grabado.aspx");
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        private DateTime getFecha()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string dateString = DropDownListDias.SelectedValue + DropDownListMeses.SelectedValue + DropDownListAnios.SelectedValue;
            string format = "ddMMyyyy";
            return DateTime.ParseExact(dateString, format, provider);
        }
    }
}