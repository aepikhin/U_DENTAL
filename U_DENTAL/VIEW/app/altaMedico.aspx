<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="altaMedico.aspx.cs" Inherits="U_DENTAL.VIEW.app.altaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alta Medico</title>
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
                <td class="TdToRight"><asp:Label ID="LabelDni" runat="server" Text="DNI"></asp:Label></td>
                <td colspan="2"><asp:TextBox ID="TextDni" runat="server" TabIndex="1"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelNombre" runat="server" Text="Nombre"></asp:Label></td>
                <td colspan="2"><asp:TextBox ID="TextNombre" runat="server" TabIndex="2"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelApellidos" runat="server" Text="Apellidos"></asp:Label></td>
                <td colspan="2"><asp:TextBox ID="TextApellidos" runat="server" TabIndex="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="TdToRight"><asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad"></asp:Label></td>
                <td colspan="2"><asp:DropDownList ID="DropDownListEspecialidad" runat="server" OnSelectedIndexChanged="DropDownListEspecialidad_SelectedIndexChanged" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Nombre" TabIndex="4">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="selectAllEspecialidades" TypeName="U_DENTAL.BBDD.DBPruebas"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td class="TdToRight"></td>
                <td colspan="2">
                    <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" OnClick="ButtonAceptar_Click" TabIndex="5" />
                    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" TabIndex="6"  />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
