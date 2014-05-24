<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="FeedbackDetails.aspx.cs" Inherits="EducationOverflow.Content.AdminPages.FeedbackDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:DetailsView ID="FeedbackDetailsView" runat="server" AutoGenerateRows="False" DataSourceID="QuestionFeedbackDetailsDataSource">
        <Fields>
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
            <asp:CheckBoxField DataField="Liked" HeaderText="Liked" SortExpression="Liked" />
            <asp:BoundField DataField="SummaryAdjective" HeaderText="Summary Adjective" SortExpression="SummaryAdjective" />
            <asp:BoundField DataField="Id" HeaderText="Question Id" SortExpression="Id" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="API Site Parameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="APIQuestionId" HeaderText="API Question Id" SortExpression="APIQuestionId" />
            <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
            <asp:BoundField DataField="UpVotes" HeaderText="Up Votes" SortExpression="UpVotes" />
            <asp:BoundField DataField="DownVotes" HeaderText="Down Votes" SortExpression="DownVotes" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="QuestionFeedbackDetailsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectQuestionFeedbackDetails" TypeName="Business.QuestionFeedbackDetails">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="userId" QueryStringField="UserId" Type="Int64" />
            <asp:QueryStringParameter DefaultValue="1" Name="questionId" QueryStringField="QuestionId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
