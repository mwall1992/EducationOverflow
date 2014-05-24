<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="EducationOverflow.Content.Admin_Pages.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="FeedbackGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="QuestionSummaryFeedbackDataSource">
        <Columns>
            <asp:CheckBoxField DataField="Liked" HeaderText="Liked" SortExpression="Liked" />
            <asp:BoundField DataField="SummaryAdjective" HeaderText="Summary Adjective" SortExpression="SummaryAdjective" />
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="API Site Parameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Id" HeaderText="Question Id" SortExpression="Id" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# string.Format("~/Content/AdminPages/FeedbackDetails.aspx?UserId={0}&QuestionId={1}",
                        HttpUtility.UrlEncode(Eval("UserId").ToString()), HttpUtility.UrlEncode(Eval("Id").ToString())) %>'
                        Text="View Details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No question feedback was found.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="QuestionSummaryFeedbackDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectQuestionFeedbackSummaries" TypeName="Business.QuestionFeedbackSummary"></asp:ObjectDataSource>
</asp:Content>
