﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EducationOverflow.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
    Status
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
    Header
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <form id="LoginForm" runat="server">
        <asp:Login ID="Login1" runat="server">
        </asp:Login>
    </form>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
</asp:Content>
