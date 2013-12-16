<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="WebApplication1.General.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbar">


        <asp:Repeater ID="rpt_Makale" runat="server">
            <ItemTemplate>
                <div class="article">
                    <div class="clr"></div>
                    <h2><%#Eval("Baslik") %></h2>
                    <p>
                        <p><%#Eval("Icerik") %></p>
                        May 27, 2010 <span>&nbsp;&bull;&nbsp;</span> <a href="#"><strong>Edit</strong></a>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <p>Tagged:</p>
        <asp:DataList ID="dl_Tags" runat="server" RepeatDirection="Horizontal">
            <ItemTemplate>
                <a href="#"> <%#Eval("EtiketAd")%></a>
            </ItemTemplate>
            <SeparatorTemplate>
                ,
            </SeparatorTemplate>
        </asp:DataList>


        <h2>
            <asp:Label ID="lbl_Comment_Count" runat="server" Text="Responses"></asp:Label>
        </h2>
        <br />

        <asp:Repeater ID="rpt_Comment" runat="server">
            <ItemTemplate>
                <div class="article">
                    <div class="clr"></div>
                    <a href="#">
                        <img src="../images/userpic.gif" width="40" height="40" alt="" class="userpic" /></a>
                    <p>
                        <a href="#"><%#Eval("Name")%></a> Says:<br />
                        <%#Eval("Tarih")%>
                    </p>
                    <p style="word-wrap: break-word;"><%#Eval("YorumIcerik")%></p>
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


        <div class="article">
            <asp:Panel ID="pnl_Comment" runat="server">
                <h2><span>Leave a</span> Reply</h2>
                <div class="clr"></div>
                <form action="#" method="post" id="leavereply">
                    <ol>
                        <li>
                            <label for="message">Your Message</label>
                            <asp:TextBox ID="txt_Comment" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                        </li>
                        <li>
                            <asp:ImageButton ID="btn_Comment" runat="server" ImageUrl="~/images/submit.gif" OnClick="btn_Comment_Click" />
                            <div class="clr"></div>
                        </li>
                    </ol>
                </form>
            </asp:Panel>
        </div>


    </div>

</asp:Content>
