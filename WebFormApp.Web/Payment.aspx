<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WebFormApp.Web.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>

    <title></title>
</head>
<body>
    <nav class="navbar navbar-light bg-light">
        <span class="navbar-brand mb-0 h1">Call Payment API</span>
    </nav>

    <form action="https://testsecureacceptance.cybersource.com/pay" method="post">

        <% foreach (var item in formParameters)
            {%>
        <input class="btn btn-primary" type="hidden" id='<%= item.Key %>' name='<%= item.Key %>' value='<%= item.Value %>' />
        <%}%>

        <input type="submit" value="Submit" />
    </form>

</body>
</html>
