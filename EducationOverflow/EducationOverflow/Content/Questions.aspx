<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Questions" %>
<%@ Register TagPrefix="uc" TagName="PopularQuestionList" Src="~/UserControls/PopularQuestionsControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
    <link rel="stylesheet" type="text/css" href="../Style Sheets/RepeaterStyles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="QuestionSummaryDataSource">
        <ItemTemplate>
            <div class="question-element">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("QuestionId", "~/Content/MemberPages/Question.aspx?QuestionId={0}") %>'><%# Eval("Title") %></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="QuestionSummaryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectQuestionSummaries" TypeName="Business.QuestionSummary"></asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
    <h3>
        Popular Questions
    </h3>
    <uc:PopularQuestionList id="PopularQuestionList1" runat="server" MaxResultCount="10" />
</asp:Content>
