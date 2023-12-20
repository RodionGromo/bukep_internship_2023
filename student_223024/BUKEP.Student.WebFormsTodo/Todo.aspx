<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Todo.aspx.cs" Inherits="BUKEP.Student.WebFormsTodo.Todo" EnableEventValidation="false" Title="Todo"%>

<asp:Content ID="TodoPage" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .vertical-left {
            display: flex;
            flex-flow:column;
        }

        .container2 {
            border: 2px solid black;
            border-radius: 15px;
            padding-right: 30px;
        }

        .widetextbox {
            max-width: none;
        }
    </style>

    <div class="container">
        <br />
        <div class="row">
            <h3 class="col-3 align-middle">Список задач</h3>
            <b class="col-6">&nbsp;</b>
            <asp:Button runat="server" class="btn btn-primary col-3" OnClick="NewTaskButton_Click" Text="Создать новую задачу" />
        </div>
        <br />
        <asp:GridView runat="server" ID="TaskView" DataKeyNames="ID" CssClass="table" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID задачи" Visible="false"/>
                <asp:BoundField DataField="Name" HeaderText="Задача" />
                <asp:BoundField DataField="Description" HeaderText="Описание" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" OnClick="EditButton_Click" Text="Изменить" CssClass="btn btn-success" />
                        <asp:Button runat="server" OnClick="DeleteButton_Click" Text="Удалить" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                Нет задач...
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <asp:Panel runat="server" ID="EditPanel" CssClass="container vertical-left container2" Visible="false">
        <h2>Задача</h2>
        <asp:textbox runat="server" placeholder="Введите заголовок задачи..." ID="taskNameEntry" CssClass="form-control widetextbox" />
        <br />
        <a>Описание задачи:</a>
        <asp:textbox runat="server" placeholder="Введите описание задачи..." ID="taskDescriptionEntry" CssClass="form-control widetextbox" />
        <br />
        <div class="row justify-content-end">
            <asp:Button runat="server" OnClick="CancelEdit_Click" Text="Отменить" CssClass="btn btn-secondary col-3 float-end col-lg-2" />
            <asp:Button runat="server" OnClick="ConfirmEdit_Click" Text="Сохранить" CssClass="btn btn-success col-3 float-end col-lg-2" CausesValidation="false" />
        </div>
        <asp:TextBox runat="server" Visible="false" ID="taskIDEntry" />
    </asp:Panel>
</asp:Content>