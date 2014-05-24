<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="ReportedQuestionDetails.aspx.cs" Inherits="EducationOverflow.Content.AdminPages.ReportedQuestionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:DetailsView ID="ReportedQuestionDetailsView" runat="server" AutoGenerateRows="False" DataSourceID="ReportedQuestionDetailsDataSource">
        <Fields>
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="API Site Parameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="OptionalDescription" HeaderText="Optional Description" SortExpression="OptionalDescription" />
            <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
            <asp:BoundField DataField="UpVotes" HeaderText="Up Votes" SortExpression="UpVotes" />
            <asp:BoundField DataField="DownVotes" HeaderText="Down Votes" SortExpression="DownVotes" />
            <asp:BoundField DataField="Id" HeaderText="Question Id" SortExpression="Id" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="APIQuestionId" HeaderText="API Question Id" SortExpression="APIQuestionId" />
        </Fields>
    </asp:DetailsView>

    <asp:ObjectDataSource ID="ReportedQuestionDetailsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectReportedQuestionDetails" TypeName="Business.ReportedQuestionDetails">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="userId" QueryStringField="UserId" Type="Int64" />
            <asp:QueryStringParameter DefaultValue="1" Name="questionId" QueryStringField="QuestionId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
