<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EducationOverflow.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" Runat="Server">
    Status
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header_content" Runat="Server">
    Header
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" Runat="Server">
    <form id="form1" runat="server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.<br />
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="UserId" DataSourceID="UserDataSource" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="UserDataSource" runat="server" DeleteMethod="DeleteUser" InsertMethod="InsertUser" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectUsers" TypeName="Business.Business" UpdateMethod="UpdateUser">
            <DeleteParameters>
                <asp:Parameter Name="originalUserId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="userId" Type="Int32" />
                <asp:Parameter Name="firstName" Type="String" />
                <asp:Parameter Name="lastName" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="dateOfBirth" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="firstName" Type="String" />
                <asp:Parameter Name="lastName" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="dateOfBirth" Type="DateTime" />
                <asp:Parameter Name="originalUserId" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <br />
&nbsp;</form>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" Runat="Server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="footer_content" Runat="Server">
    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
	tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
	proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
</asp:Content>
