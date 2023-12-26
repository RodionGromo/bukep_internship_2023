<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deletion.aspx.cs" Inherits="BUKEP.Student.WebFormsTodo.Deletion" Title="Delete" %>

<asp:Content ID="DeletionPage" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="DeletionPanel" runat="server" CssClass="container">
        <h1>Удаление задачи</h1>
        <p runat="server" id="QuestionLabel"></p>
        <div class="row">
            <b class="col-8">&nbsp;</b>
            <asp:Button runat="server" Text="Отмена" PostBackUrl="~/Todo.aspx" CssClass="btn btn-secondary col-2" />
            <asp:Button runat="server" Text="Удалить" OnClick="DeleteButton_Click" CssClass="btn btn-danger col-2" />
        </div>
    </asp:Panel>
</asp:Content>


