<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscarExpediente.aspx.cs" Inherits="U_DENTAL.VIEW.app.buscarExpediente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Buscar Expediente</title>
    <link href="css/styles.css" rel="stylesheet" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Logo UDental" id="logo" class="auto-style1" src="images/logo-dental-pao_1.jpg" /></div>
        <div id="page-content">
            <table class="content">
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelBuscar" runat="server" Text="Buscar por NºEXP o nombre y apellidos"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="TextBuscar" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TdToRight">
                    <asp:RadioButtonList ID="RadioButtonListBuscar" runat="server">
                        <asp:ListItem Value="NEXP" Selected="True">Nº Expediente</asp:ListItem>
                        <asp:ListItem Value="NOMB">Nombre</asp:ListItem>
                        <asp:ListItem Value="APEL">Apellidos</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan="2">
                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" TabIndex="2" />
                </td>
            </tr>
            <tr>
            <td class="TdToRight">
                <asp:ListBox ID="ListBoxEncontrados" runat="server" OnSelectedIndexChanged="ListBoxEncontrados_SelectedIndexChanged" AutoPostBack="True" TabIndex="3"></asp:ListBox>
            </td>
            <td colspan="2">
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" OnClick="ButtonAceptar_Click" TabIndex="4" />
                <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" TabIndex="5"  />
            </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
