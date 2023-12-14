<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deletion.aspx.cs" Inherits="BUKEP.Student.WebFormsTodo.Deletion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <title>Delete</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="DeletionPanel" runat="server" CssClass="container">
            <h1>Удаление задачи</h1>
            <p runat="server" id="QuestionLabel"></p>
            <div class="row">
                <b class="col-8">&nbsp;</b>
                <asp:Button runat="server" Text="Отмена" PostBackUrl="~/Todo.aspx" CssClass="btn btn-secondary col-2"/>
                <asp:Button runat="server" Text="Удалить" OnClick="DeleteButton_Click" CssClass="btn btn-danger col-2"/>
            </div>
        </asp:Panel>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
