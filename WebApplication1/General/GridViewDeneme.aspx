<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GridViewDeneme.aspx.cs" Inherits="WebApplication1.General.GridViewDeneme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../js/jquery-1.9.1.js"></script>
    <script src="../js/jquery-ui-1.10.3.custom.js"></script>

    <script type="text/javascript">

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="maindivvv">
        <div >
            <div id="maindivv">
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
                                            <asp:ImageButton runat="server" ID="btn_Deneme1" OnClick="btn_Deneme1_Click" ImageUrl="~/Images/onay.png" CommandName="Onay" CommandArgument='<%# Eval("YorumId")%>'/>
                                            <asp:ImageButton runat="server" ID="btn_Deneme2" OnClick="btn_Deneme2_Click" ImageUrl="../Images/sil.png" CommandArgument='<%# Eval("YorumId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Kayıt Bulunamadı !</EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        <%--<asp:Button ID="btn_Deneme1_External" runat="server" Text="Button" OnClick="btn_Deneme1_External_Click" Style="display: none;"/>
        <asp:Button ID="btn_Deneme2_External" runat="server" Text="Button" />--%>
        <%--<asp:Button ID="btn_Show_Comment" Text="Manage Comments" runat="server" OnClientClick="OpenDetayDialog(); return false;" />--%>
    </div>


</asp:Content>
