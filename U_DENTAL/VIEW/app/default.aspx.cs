using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U_DENTAL.BBDD;

namespace U_DENTAL.VIEW.app
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["db"] == null)
            {
                Session["db"] = new DBPruebas();
            }
        }
    }
}