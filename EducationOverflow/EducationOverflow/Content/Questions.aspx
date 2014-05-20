<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
    <link rel="stylesheet" type="text/css" href="../Style Sheets/RepeaterStyles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:Repeater ID="QuestionRepeater" runat="server" DataSourceID="QuestionSummaryDataSource">
        <ItemTemplate>
            <div class="QuestionElement">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Likes", "~/Content/Member Pages/Question.aspx?likes={0}") %>'>HyperLink</asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="QuestionSummaryDataSource" runat="server" SelectMethod="SelectQuestionURL" TypeName="Business.QuestionURL" DeleteMethod="DeleteQuestionURL" InsertMethod="InsertQuestionURL" UpdateMethod="UpdateQuestionURL">
        <DeleteParameters>
            <asp:Parameter Name="originalQuestionUrl" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="apiQuestionId" Type="Int32" />
            <asp:Parameter Name="apiSiteParameter" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="url" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="apiQuestionId" Type="Int32" />
            <asp:Parameter Name="apiSiteParameter" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="url" Type="String" />
            <asp:Parameter Name="originalUrl" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
