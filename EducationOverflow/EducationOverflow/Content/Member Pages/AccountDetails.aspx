<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.AccountDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="UserInfoDataSource" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="UserInfoDataSource" runat="server" SelectMethod="SelectUser" TypeName="Business.User" DeleteMethod="DeleteUser" InsertMethod="InsertUser" UpdateMethod="UpdateUser">
        <DeleteParameters>
            <asp:Parameter Name="originalUserId" Type="Int64" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <asp:Parameter Name="dateOfBirth" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="userId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <asp:Parameter Name="dateOfBirth" Type="DateTime" />
            <asp:Parameter Name="originalUserId" Type="Int64" />
            <asp:Parameter Name="userId" Type="Int64" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
