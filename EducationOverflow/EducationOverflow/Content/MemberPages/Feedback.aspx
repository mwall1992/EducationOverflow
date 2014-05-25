﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="EducationOverflow.Content.MemberPages.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>
        My Feedback
    </h1>
    <asp:GridView ID="UserFeedbackGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
        AutoGenerateDeleteButton="True" DataSourceID="UserQuestionFeedbackDataSource"
        Height="100%" Width="100%" DataKeyNames="QuestionId" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Site Name" SortExpression="Name" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Liked" HeaderText="Liked" SortExpression="Liked" />
            <asp:BoundField DataField="SummaryAdjective" HeaderText="Summary Adjective" SortExpression="SummaryAdjective" />
        </Columns>
        <EmptyDataTemplate>
            You have no question feedback.
        </EmptyDataTemplate>
    </asp:GridView>

    <asp:ObjectDataSource ID="UserQuestionFeedbackDataSource" runat="server" DeleteMethod="DeleteUserQuestionFeedback" 
        OldValuesParameterFormatString="original{0}" SelectMethod="SelectUserQuestionFeedback" UpdateMethod="UpdateUserQuestionFeedback" TypeName="Business.UserQuestionFeedback">
        <DeleteParameters>
            <asp:Parameter Name="userId" Type="Int64" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="userId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
