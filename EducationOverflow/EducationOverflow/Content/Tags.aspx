<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="EducationOverflow.Content.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Name" DataSourceID="TagsInfoDataSource">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="TagsInfoDataSource" runat="server" SelectMethod="SelectQuestionsFromUserView" TypeName="Business.TagInfo"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
