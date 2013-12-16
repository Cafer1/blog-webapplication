﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin1.aspx.cs" Inherits="WebApplication1.General.Admin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/admin.css" rel="stylesheet" />
    <title></title>
</head>
<form id="form1" runat="server">
    <body>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="verymaindiv">
            <header>
                <h1>Wellcome to Admin Panel</h1>
            </header>
            <section>
                <article>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="mainbar">
                                <asp:GridView ID="GridViewComments" runat="server" AutoGenerateColumns="false" DataKeyNames="YorumId"
                                    BorderStyle="Solid" BorderWidth="3px" BorderColor="#000000"
                                    RowStyle-HorizontalAlign="Center" AlternatingRowStyle-HorizontalAlign="Center"
                                    OnRowDataBound="GridViewComments_RowDataBound" AllowPaging="true" PageSize="5"
                                    OnPageIndexChanging="GridViewComments_PageIndexChanging" GridLines="Horizontal" BackColor="#f3f3f3"
                                    EditRowStyle-Font-Bold="true" HeaderStyle-ForeColor="#000000">
                                    <Columns>
                                        <asp:BoundField DataField="YorumId" HeaderText="Yorum Numarası" />
                                        <asp:BoundField DataField="YorumIcerik" HeaderText="İçerik" />
                                        <asp:BoundField DataField="MakaleID" HeaderText="Makale Numarası" />
                                        <asp:BoundField DataField="User_id" HeaderText="Kullanıcı Numarası" />
                                        <asp:BoundField DataField="Tarih" HeaderText="Tarih" />
                                        <asp:BoundField DataField="Onay" HeaderText="Onay Durumu" />

                                        <asp:TemplateField HeaderText="İşlemler" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="btn_Deneme1" OnClick="btn_Deneme1_Click" ImageUrl="~/Images/onay.png" CommandName="Onay" CommandArgument='<%# Eval("YorumId")%>' />
                                                <asp:ImageButton runat="server" ID="btn_Deneme2" OnClick="btn_Deneme2_Click" ImageUrl="../Images/sil.png" CommandArgument='<%# Eval("YorumId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>Kayıt Bulunamadı !</EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </article>
            </section>

            <nav class="vertical_menu">
                <ul>
                    <li>Comments
                    </li>
                    <li>Topics
                    </li>
                    <li>Tags
                    </li>
                </ul>
            </nav>

            <footer>
                <h3>Copy Right Cafer Kaya</h3>
            </footer>

        </div>
</form>
</body>
</html>
