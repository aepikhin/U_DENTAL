<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="U_DENTAL.VIEW.app._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>U Dental</title>
    <link href="css/styles.css" rel="stylesheet" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img alt="Logo UDental" id="logo" class="auto-style1" src="images/logo-dental-pao_1.jpg" />
    </div>
    <div id="menu_container">
        <asp:Menu ID="Menu1" runat="server" Font-Size="X-Large" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" ForeColor="White">
            <Items>
                <asp:MenuItem Text="Alta Paciente" Value="Alta Paciente" NavigateUrl="~/VIEW/app/altaPaciente.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Alta Medico" Value="Alta Medico" NavigateUrl="~/VIEW/app/altaMedico.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Buscar Expediente" Value="Buscar Expediente" NavigateUrl="~/VIEW/app/buscarExpediente.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Asigna Box" Value="Asigna Box" NavigateUrl="~/VIEW/app/asignaBox.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    </form>
</body>
</html>
