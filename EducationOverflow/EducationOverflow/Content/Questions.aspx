<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
    <link rel="stylesheet" type="text/css" href="../Style Sheets/RepeaterStyles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:Repeater ID="QuestionRepeater" runat="server" DataSourceID="QuestionDataSource">
        <ItemTemplate>
            <div class="QuestionElement">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Id", "~/Content/Member Pages/Question.aspx?id={0}") %>'><%# Eval("Title") %></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="QuestionDataSource" runat="server" SelectMethod="SelectQuestionId" TypeName="Business.QuestionId"></asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
</asp:Content>
