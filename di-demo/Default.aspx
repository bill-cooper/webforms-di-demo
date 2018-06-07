<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="di_demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Retrieve Employee Data.</p>
        <p>
            <asp:Button ID="submitButton" runat="server" Text="Submit" class="btn btn-primary btn-lg" OnClick="submitButton_Click" />
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        </p>

        <div id="employeeData" runat="server" visible="false">
            <div class="row" runat="server">
                <div class="col-md-3">ID</div>
                <div class="col-md-9">
                    <asp:Label ID="LabelId" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row" runat="server">
                <div class="col-md-3">First Name</div>
                <div class="col-md-9">
                    <asp:Label ID="LabelFirstName" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row" runat="server">
                <div class="col-md-3">Last Name</div>
                <div class="col-md-9">
                    <asp:Label ID="LabelLastName" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row" runat="server">
                <div class="col-md-3">Date of Birth</div>
                <div class="col-md-9">
                    <asp:Label ID="LabelDob" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div id="divError" class="has-error" style="color: red" runat="server" visible="false">
        Please provide a valid ID
    </div>

</asp:Content>
