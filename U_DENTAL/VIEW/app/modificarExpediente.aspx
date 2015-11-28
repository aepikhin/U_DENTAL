<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modificarExpediente.aspx.cs" Inherits="U_DENTAL.VIEW.app.modificarExpediente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Modificar Expediente</title>
    <link href="css/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Logo UDental" id="logo" class="auto-style1" src="images/logo-dental-pao_1.jpg" /></div>
        <div id="page-content">
            <table class="content">
                <tr>
                <td class="TdToRight"><asp:Label ID="LabelNExp" runat="server" Text="Nº Expediente"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxNExp" runat="server" Enabled="False"></asp:TextBox>
                </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelNombreYApellidos" runat="server" Text="Nombre y Apellidos"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxNombreYApellidos" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelEdad" runat="server" Text="Edad"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxEdad" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelSexo" runat="server" Text="Sexo"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxSexo" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad"></asp:Label></td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownListEspecialidad" runat="server" OnSelectedIndexChanged="DropDownListEspecialidad_SelectedIndexChanged" AutoPostBack="True" TabIndex="1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelMedico" runat="server" Text="Medico"></asp:Label></td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownListMedico" runat="server" OnSelectedIndexChanged="DropDownListMedico_SelectedIndexChanged" TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelBox" runat="server" Text="Box selecionado"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxBox" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelTipoDiagnostico" runat="server" Text="TipoDiagnostico"></asp:Label></td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownListTipoDiagnostico" runat="server" OnSelectedIndexChanged="DropDownListTipoDiagnostico_SelectedIndexChanged" TabIndex="3">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelDiagnostico" runat="server" Text="Diagnostico"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxDiagnostico" runat="server" Height="92px" TextMode="MultiLine" Width="221px" TabIndex="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelTratamiento" runat="server" Text="Tratamiento"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxTratamiento" runat="server" Height="92px" TextMode="MultiLine" Width="221px" TabIndex="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TdToRight">
                    </td>
                    <td colspan="2">
                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" OnClick="ButtonAceptar_Click" TabIndex="6" />
                        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" TabIndex="7"  />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
