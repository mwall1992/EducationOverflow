<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="SignOut.aspx.cs" Inherits="EducationOverflow.SignOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
    Header
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:Button ID="SignOutButton" runat="server" OnClick="SignOutButton_Click" Text="Sign Out" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
