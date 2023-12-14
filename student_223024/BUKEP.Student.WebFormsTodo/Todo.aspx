<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todo.aspx.cs" Inherits="BUKEP.Student.WebFormsTodo.Todo"%>

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

        .container2 {
            border: 2px solid black;
            border-radius: 15px;
            padding-right: 30px;
        }

        .title {
            font-size: 24px;
            font-weight: bold;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <div class="row">
                <b class="col-3 float-start title">Список задач</b>
                <b class="col-7">&nbsp;</b>
                <asp:Button runat="server" class="btn btn-primary col-5 float-end col-lg-2" OnClick="NewTaskButton_Click" Text="Создать новую задачу" />
            </div>
            <br />
            <asp:Table ID="TaskTable" runat="server" CssClass="table" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Задача</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Описание</asp:TableHeaderCell>
                    <asp:TableHeaderCell>&nbsp;</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <asp:Panel runat="server" ID="EditPanel" CssClass="container vertical-left container2" Visible="false">
            <h2>Задача</h2>
            <asp:textbox runat="server" placeholder="Введите заголовок задачи..." ID="taskNameEntry" CssClass="form-control"/>
            <br />
            <a>Описание задачи:</a>
            <asp:textbox runat="server" placeholder="Введите описание задачи..." ID="taskDescriptionEntry" CssClass="form-control"/>
            <br />
            <div class="row justify-content-end">
                <asp:Button runat="server" OnClick="CancelEdit_Click" Text="Отменить" CssClass="btn btn-secondary col-3 float-end col-lg-2" />
                <asp:Button runat="server" OnClick="ConfirmEdit_Click" Text="Сохранить" CssClass="btn btn-success col-3 float-end col-lg-2" />
            </div>
            <br />
        </asp:Panel>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    </body>
</html>
