﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="FeedbackDetails.aspx.cs" Inherits="EducationOverflow.Content.AdminPages.FeedbackDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>
        Question Feedback Details
    </h1>
    <asp:DetailsView ID="FeedbackDetailsView" runat="server" AutoGenerateRows="False" DataSourceID="QuestionFeedbackDetailsDataSource" 
        AutoGenerateDeleteButton="True" Height="100%" Width="100%">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Question Id" SortExpression="Id" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="API Site Parameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="UpVotes" HeaderText="Up Votes" SortExpression="UpVotes" />
            <asp:BoundField DataField="DownVotes" HeaderText="Down Votes" SortExpression="DownVotes" />
            <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" HtmlEncode="false" />
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:CheckBoxField DataField="Liked" HeaderText="Liked" SortExpression="Liked" />
            <asp:BoundField DataField="SummaryAdjective" HeaderText="Summary Adjective" SortExpression="SummaryAdjective" />
        </Fields>
        <EmptyDataTemplate>
            The specified question feedback does not exist (see query string parameters in url).
            <p>
                <asp:HyperLink ID="QuestionFeedbackLink" runat="server" NavigateUrl="~/Content/AdminPages/Feedback.aspx">Click here to return to the main question feedback page.</asp:HyperLink>
            </p>
        </EmptyDataTemplate>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="QuestionFeedbackDetailsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="SelectQuestionFeedbackDetails" DeleteMethod="DeleteQuestionFeedback" TypeName="Business.QuestionFeedbackDetails">
        <SelectParameters>
            <asp:QueryStringParameter Name="userId" QueryStringField="UserId" Type="Int64" />
            <asp:QueryStringParameter Name="questionId" QueryStringField="QuestionId" Type="Int64" />
        </SelectParameters>
        <DeleteParameters>
            <asp:QueryStringParameter Name="userId" QueryStringField="UserId" Type="Int64" />
            <asp:QueryStringParameter Name="questionId" QueryStringField="QuestionId" Type="Int64" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
