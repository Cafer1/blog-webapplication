<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReadMore.aspx.cs" Inherits="WebApplication1.ReadMore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rpt_Icerik" runat="server">
        <ItemTemplate>
            <div class="article">
                <h2><span><%#Eval("Baslik")%></span></h2>
                <div class="clr"></div>              
                <h3><b><p><%#Eval("Icerik")%></p></b></h3>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
