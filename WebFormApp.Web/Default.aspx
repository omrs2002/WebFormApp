<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormApp.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>Call The Weather Service</h2>
            <br />
            <div class="main-content">

                <div>
                    <label for="itId">ID:</label>
                    <input type="text" id="itId" size="5" />
                    <input type="button" value="Search" onclick="show(0);" />
                    <p id="item" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <div>
                <ul id="items" />
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/StashedJSfile.js"></script>
    <script src="Scripts/ServicesScripts.js"></script>

    <script type="text/javascript">  
        $(document).ready(function () {
            show(1);
        });

        function show(showall)
        {
            NetworkUtils.TestService.renderWeatherCast(showall);
            WebUtils.Messaging.sweetAlert('msg from web util');
        }

    </script>

</asp:Content>
