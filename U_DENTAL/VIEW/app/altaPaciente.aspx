<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="altaPaciente.aspx.cs" Inherits="U_DENTAL.VIEW.app.altaPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta Paciente</title>
    <link href="css/styles.css" rel="stylesheet" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img alt="Logo UDental" id="logo" class="auto-style1" src="images/logo-dental-pao_1.jpg" />

    </div>
    <div id="page-content">
        <table class="content">
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelNombre" runat="server" Text="Nombre"></asp:Label></td>
                <td colspan="2"><asp:TextBox ID="TextNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelApellidos" runat="server" Text="Apellidos"></asp:Label></td>
                <td colspan="2"><asp:TextBox ID="TextApellidos" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelFechaNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label></td>
                <td>
                    <asp:Label ID="LabelDia" runat="server" Text="Día"></asp:Label><br />
                    <asp:Label ID="LabelMes" runat="server" Text="Mes"></asp:Label><br />
                    <asp:Label ID="LabelAnio" runat="server" Text="Año"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListDias" runat="server" OnSelectedIndexChanged="DropDownListDias_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <asp:DropDownList ID="DropDownListMeses" runat="server" OnSelectedIndexChanged="DropDownListMeses_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <asp:DropDownList ID="DropDownListAnios" runat="server" OnSelectedIndexChanged="DropDownListAnios_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelSexo" runat="server" Text="Sexo"></asp:Label></td>
                <td colspan="2">
                    <asp:RadioButtonList ID="RadioButtonListSexo" runat="server">
                        <asp:ListItem Value="H" Selected="True">Hombre</asp:ListItem>
                        <asp:ListItem Value="M">Mujer</asp:ListItem>
                    </asp:RadioButtonList>
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
