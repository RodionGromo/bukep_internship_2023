<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todo.aspx.cs" Inherits="BUKEP.Student.WebFormsTodo.Todo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta content="width=device-width, initial-scale=1" name="viewport"/>
    
    <title>Todo</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <style>
        .vertical-left {
            display: flex;
            flex-flow:column;
        }

        .title {
            font-size: 24px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <b class="col-5 float-start">Список задач</b>
                <b class="col-5">&nbsp;</b>
                <asp:Button runat="server" class="col-5 float-end col-lg-2" OnClick="NewTaskButton_Click" Text="Создать новую задачу" />
            </div>
            <asp:Table ID="TaskTable" runat="server" CssClass="table" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Задача</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Описание</asp:TableHeaderCell>
                    <asp:TableHeaderCell>&nbsp;</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <asp:Panel runat="server" ID="EditPanel" CssClass="container vertical-left" Visible="false">
            <h2>Задача</h2>
            <asp:textbox runat="server" placeholder="Введите заголовок задачи..." ID="taskNameEntry" />
            <p>Описание задачи:</p>
            <asp:textbox runat="server" placeholder="Введите описание задачи..." ID="taskDescriptionEntry" />
            <asp:Button runat="server" OnClick="CancelEdit_Click" Text="Отменить"/>
            <asp:Button runat="server" OnClick="ConfirmEdit_Click" Text="Сохранить"/>
        </asp:Panel>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    </form>
    
    </body>
</html>
