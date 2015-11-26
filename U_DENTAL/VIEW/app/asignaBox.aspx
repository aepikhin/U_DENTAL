<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asignaBox.aspx.cs" Inherits="U_DENTAL.VIEW.app.asignaBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asigna Box</title>
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
                <td class="TdToRight"><asp:Label ID="LabelBoxesOcupados" runat="server" Text="Boxes Ocupados"></asp:Label></td>
                <td colspan="2">
                    <asp:ListBox ID="ListBoxBoxesOcupados" runat="server" OnSelectedIndexChanged="ListBoxBoxesOcupados_SelectedIndexChanged"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelBoxesLibres" runat="server" Text="Boxes Libres para asignar paciente"></asp:Label></td>
                <td><asp:ListBox ID="ListBoxBoxesLibres" runat="server" OnSelectedIndexChanged="ListBoxBoxesLibres_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                </td>
                <td><asp:DropDownList ID="DropDownListPacientesParaAsignar" runat="server" OnSelectedIndexChanged="DropDownListPacientesParaAsignar_SelectedIndexChanged">
                    <asp:ListItem>Pacientes</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td class="TdToRight"></td>
            <td colspan="2">
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click"  />
            </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
