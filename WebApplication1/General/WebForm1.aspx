<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="rptMakaleOzet" runat="server" OnItemDataBound="rptMakaleOzet_ItemDataBound">
        <ItemTemplate>
            <div class="article">
                <h2><span><%#Eval("Baslik")%></span></h2>
                <p class="infopost">Posted <span class="date">on <%#Eval("Tarih") %></span> by <a href="#">Admin</a> &nbsp;&nbsp;&nbsp;&nbsp; <a href="#" class="com">Comments <span><%#Eval("Yorum_Count") %></span></a></p>
                <div class="clr"></div>
                <div class="post_content">
                    <p style="word-wrap: break-word;"><%#Eval("Ozet") %></p>
                    <p>Tagged:</p>
                    <asp:DataList ID="dl_Tags" runat="server" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <a href="#"><%#Eval("EtiketAd")%></a>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            ,
                        </SeparatorTemplate>
                    </asp:DataList>
                    <p class="spec"><a href="Blog.aspx?id=<%#Eval("MakaleId")%>" class="rm">Read more</a></p>
                </div>
                <div class="clr"></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


    <p class="pages">
        <small>
            <asp:Label ID="lbl_paging" runat="server" Text="Label"></asp:Label>
        </small>
        <asp:HyperLink ID="hl_Prev" runat="server">Previous</asp:HyperLink>
        <asp:HyperLink ID="hl_Next" runat="server">Next</asp:HyperLink>
    </p>



</asp:Content>
