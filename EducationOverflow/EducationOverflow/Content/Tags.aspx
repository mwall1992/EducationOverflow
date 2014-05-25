<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="EducationOverflow.Content.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>
        Tag Information
    </h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
        DataSourceID="TagsDataSource" Height="100%" Width="100%">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Tag" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Title" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="TagsDataSource" runat="server" SelectMethod="SelectTags" TypeName="Business.TagInfo"></asp:ObjectDataSource>
</asp:Content>
