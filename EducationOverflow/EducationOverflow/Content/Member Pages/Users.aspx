﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
    Header
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

<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
</asp:Content>
