<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/bootstrap-theme.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border :5px solid red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><h3><b>User Name:</b></h3></td>
                <td>
                    <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><h3><b>Password :</b></h3></td>
                <td>
                    <asp:TextBox ID="txt_Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click" CssClass="btn-primary" Font-Bold="True" Font-Strikeout="False" ForeColor="White" Width="70px"/>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lbl_Error" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Error"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
