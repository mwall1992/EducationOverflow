<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="ReportQuestion.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.ReportQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ReportedQuestionsDataSource">
        <Columns>
            <asp:BoundField DataField="OptionalDescription" HeaderText="OptionalDescription" SortExpression="OptionalDescription" />
            <asp:BoundField DataField="PredefinedDescription" HeaderText="PredefinedDescription" SortExpression="PredefinedDescription" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="SiteName" HeaderText="SiteName" SortExpression="SiteName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ReportedQuestionsDataSource" runat="server" SelectMethod="SelectQuestionsFromUserView" TypeName="Business.UserReportedQuestions">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="userId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
