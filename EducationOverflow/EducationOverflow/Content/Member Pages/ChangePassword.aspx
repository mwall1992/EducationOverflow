<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EducationOverflow.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
    Header
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>Change Password</h1>
    <asp:ChangePassword ID="ChangePassword1" runat="server" ContinueDestinationPageUrl="~/Default.aspx">
    </asp:ChangePassword>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
