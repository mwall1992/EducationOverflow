<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Questions" %>
<%@ Register TagPrefix="uc" TagName="PopularQuestionList" Src="~/UserControls/PopularQuestionsControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
    <link rel="stylesheet" type="text/css" href="../Style Sheets/RepeaterStyles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="QuestionGridView" runat="server" AllowPaging="True" DataSourceID="QuestionSummaryDataSource" 
        DataKeyNames="QuestionId" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Site Name" SortExpression="Name" />
            <asp:BoundField DataField="Title" HeaderText="Question" SortExpression="Title" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# string.Format("~/Content/MemberPages/Question.aspx?QuestionId={0}",
                        HttpUtility.UrlEncode(Eval("QuestionId").ToString())) %>'
                        Text="Attempt Question" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            There are not questions.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="QuestionSummaryDataSource" runat="server" SelectMethod="SelectQuestionSummaries" TypeName="Business.QuestionSummary">
    </asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
    <h3>
        Popular Questions
    </h3>
    <uc:PopularQuestionList id="PopularQuestionList1" runat="server" MaxResultCount="10" />
</asp:Content>
