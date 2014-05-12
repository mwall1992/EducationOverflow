<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="QuestionSummaryDataSource">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
            <asp:BoundField DataField="Likes" HeaderText="Likes" SortExpression="Likes" />
            <asp:BoundField DataField="Dislikes" HeaderText="Dislikes" SortExpression="Dislikes" />
            <asp:BoundField DataField="MostCommonSummaryAdjective" HeaderText="MostCommonSummaryAdjective" SortExpression="MostCommonSummaryAdjective" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="QuestionSummaryDataSource" runat="server" SelectMethod="SelectQuestionsFromUserView" TypeName="Business.QuestionFromUserView"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
