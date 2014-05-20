<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="UserInfoDataSource" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="RowError" HeaderText="RowError" SortExpression="RowError" />
            <asp:BoundField DataField="RowState" HeaderText="RowState" ReadOnly="True" SortExpression="RowState" />
            <asp:CheckBoxField DataField="HasErrors" HeaderText="HasErrors" ReadOnly="True" SortExpression="HasErrors" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="UserInfoDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectUser" TypeName="Business.User">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="userId" QueryStringField="UserId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
</asp:Content>
