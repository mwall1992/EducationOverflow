<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EducationOverflow.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" Runat="Server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
    <br />
    <asp:Repeater ID="ExampleRepeater" runat="server" DataSourceID="RepeaterDataSource">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                </li>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="RepeaterDataSource" runat="server" SelectMethod="SelectQuestionId" TypeName="Business.QuestionId"></asp:ObjectDataSource>
&nbsp;
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" Runat="Server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
</asp:Content>
