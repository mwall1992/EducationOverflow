<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="QuestionHistory.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.QuestionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>
        Question and Answer History
    </h1>
    <asp:GridView ID="UserAnswersGridView" runat="server" AllowPaging="True" DataSourceID="UserAnswersDataSource"
        AutoGenerateColumns="False" Height="100%" Width="100%" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Question Title" SortExpression="Title" />
            <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
            <asp:BoundField DataField="IsAnswered" HeaderText="Is Answered" SortExpression="IsAnswered" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# string.Format("~/Content/MemberPages/Question.aspx?AnswerId={0}&QuestionId={1}",
                        HttpUtility.UrlEncode(Eval("UserAnswerId").ToString()), HttpUtility.UrlEncode(Eval("Id").ToString())) %>'
                        Text="View Answer" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            You have no saved answers.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="UserAnswersDataSource" runat="server" SelectMethod="SelectUserAnswers" TypeName="Business.UserAnswers">
        <SelectParameters>
            <asp:Parameter Name="userId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>