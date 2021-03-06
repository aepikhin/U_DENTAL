﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U_DENTAL.BBDD;
using U_DENTAL.APP.DAO;
using U_DENTAL.BBDD.DATA;

namespace U_DENTAL.VIEW.app
{
    public partial class asignaBox : System.Web.UI.Page
    {
        ICapaDatos db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Session["db"];
            ListBoxBoxesLibres.Focus();
            if (!IsPostBack)
            {
                IList<Box> boxes = (IList<Box>)db.selectAllBoxes();
                Expediente exp;
                for (int i=0; i < boxes.Count; i++)
                {
                    exp = db.selectExpediente(boxes[i]);
                    if(exp != null)
                    {
                        String text = "IDBOX " + boxes[i].IdBox + ",   EXP " + exp.NExpediente + ", "+ exp.Nombre + " " + exp.Apellido;
                        ListBoxBoxesOcupados.Items.Add(text);
                    } else
                    {
                        String text = "" + boxes[i].IdBox;
                        ListBoxBoxesLibres.Items.Insert(0, new ListItem(text, "" + boxes[i].IdBox));
                    }
                }
            }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if(ListBoxBoxesLibres.SelectedIndex >= 0 && DropDownListPacientesParaAsignar.SelectedValue != "0")
            {
                int box = 0, nexp = 0;
                int.TryParse(ListBoxBoxesLibres.SelectedValue, out box);
                int.TryParse(DropDownListPacientesParaAsignar.SelectedValue, out nexp);
                db.selectBox(box).Cliente = db.selectExpediente(nexp);
                db.selectBox(box).Cliente.Medico.Libre = false;
                Response.Redirect("~/VIEW/app/grabado.aspx");
            } else ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Datos incorrectos!');", true);

        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VIEW/app/default.aspx");
        }

        protected void ListBoxBoxesOcupados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBoxBoxesLibres_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListPacientesParaAsignar.Items.Clear();
            int box = 0;
            if(int.TryParse(ListBoxBoxesLibres.SelectedValue, out box))
            {
                IList<Expediente> exps = (IList<Expediente>)db.selectExpedientes(db.selectBox(box));
                foreach (Expediente exp in exps)
                {
                    DropDownListPacientesParaAsignar.Items.Insert(0, new ListItem(exp.Nombre + " " + exp.Apellido, "" + exp.NExpediente));
                }
                if (exps.Count == 0)
                    DropDownListPacientesParaAsignar.Items.Insert(0, new ListItem("No hay pacientes", "0"));
            }
            
        }

        protected void DropDownListPacientesParaAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}