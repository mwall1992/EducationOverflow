<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    Welcome to the members only page.
    <br />
    <a runat="server" href="~/Content/Member Pages/ChangePassword.aspx">Change password</a>
    <br />
    <a runat="server" href="~/Content/Member Pages/ReportQuestion.aspx">Report Question</a>
    <br />
    <a runat="server" href="~/Content/Member Pages/AccountDetails.aspx">Account Details</a>
</asp:Content>
