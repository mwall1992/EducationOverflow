<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="ReportedQuestions.aspx.cs" Inherits="EducationOverflow.Content.AdminPages.ReportedQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>
        Reported Questions
    </h1>
    <asp:GridView ID="ReportedQuestionsGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        DataSourceID="ReportedQuestionSummariesDataSource" Height="100%" Width="100%">
        <Columns>
            <asp:BoundField DataField="QuestionId" HeaderText="Question Id" SortExpression="QuestionId" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="API Site Parameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="Title" HeaderText="Question Title" SortExpression="Title" />
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="ReasonId" HeaderText="Reason Id" SortExpression="ReasonId" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# string.Format("~/Content/AdminPages/ReportedQuestionDetails.aspx?UserId={0}&QuestionId={1}",
                        HttpUtility.UrlEncode(Eval("UserId").ToString()), HttpUtility.UrlEncode(Eval("QuestionId").ToString())) %>'
                        Text="View Details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No question reports were found.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ReportedQuestionSummariesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectReportedQuestionSummaries" TypeName="Business.ReportedQuestionSummary"></asp:ObjectDataSource>
</asp:Content>
