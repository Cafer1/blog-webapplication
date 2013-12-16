<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.General.Admin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content_resize">
        <div class="mainbar">
            <div class="article">
                <h2>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    New Entry</h2>
                <div class="clr"></div>
                <ol>
                    <li>
                        <label for="name">Title</label>
                        <asp:TextBox ID="txt_Title" runat="server" Width="200px"></asp:TextBox>
                    </li>

                    <li>
                        <label for="name">Category</label>
                        <asp:DropDownList ID="ddl_Category" runat="server" Width="200px"></asp:DropDownList>
                    </li>

                    <li>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table style="text-align: center; font-family: 'Comic Sans MS'">
                                    <tr>
                                        <td>Tags</td>
                                        <td aria-orientation="horizontal" rowspan="2">&nbsp;</td>
                                        <td>Selected Tags</td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2">
                                            <asp:ListBox ID="lb_Tags" runat="server" Height="200px" Width="200px" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                        <td rowspan="2">
                                            <asp:ListBox ID="lb_Selected" runat="server" Width="200px" Height="200px" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 150px">
                                            <br />
                                            <asp:Button ID="btn_right" runat="server" Text="&gt;" Width="50px" OnClick="btn_right_Click" />
                                            <br />
                                            <asp:Button ID="btn_left" runat="server" Text="&lt;" Width="50px" OnClick="btn_left_Click" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </li>
                    <li>
                        <label for="message">Abstract</label>
                        <asp:TextBox ID="txt_abstract" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                    </li>
                    <li>
                        <label for="message">Main Text</label>
                        <asp:TextBox ID="txt_main" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                    </li>
                    <li>
                        <asp:ImageButton ID="btn_Submit" runat="server" ImageUrl="~/images/submit.gif" OnClick="btn_Submit_Click" />
                        <div class="clr"></div>
                    </li>
                </ol>
            </div>
        </div>
        <div class="clr"></div>
    </div>

</asp:Content>
