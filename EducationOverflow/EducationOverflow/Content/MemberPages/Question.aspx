<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Style Sheets/QuestionStyles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <!-- Question Title -->
    <div runat="server" id="title" class="title">
        <h3 runat="server" id="generatedTitle"></h3>
    </div>

    <!-- Question Body -->
    <div runat="server" id="question" class="question"></div>
    
    <!-- Answer -->
    <div id="answer">
        <h3>Your Answer:</h3>
        <textarea id="myAnswerTextArea" class="input-box" cols="50" name="S1" rows="10"></textarea><asp:Button ID="HintButton" runat="server" OnClick="HintButton_Click" Text="Request Hint" />
&nbsp;<asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Save My Answer" />
        <asp:Button ID="SolutionButton" runat="server" OnClick="SolutionButton_Click" Text="View Solution" />
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
    <h3>Question Information</h3>
    <p>
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
    </p>
    <h3>Report Question</h3>
    <p>
        Remember to read through the question and check your answer against the provided answer.
    </p>
    <div class="report-question-component">
        <h4>What's wrong?</h4>
        <asp:RadioButtonList ID="ReportedReasonList" runat="server" DataSourceID="ReportedQuestionReasonDataSource" DataTextField="Description" DataValueField="ReasonId">
        </asp:RadioButtonList>
        <asp:ObjectDataSource ID="ReportedQuestionReasonDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectReportedQuestionReasons" TypeName="Business.ReportedQuestionReason"></asp:ObjectDataSource>
    </div>
    <div class="report-question-component">
        <h4>Description of issue:</h4>
        <asp:TextBox ID="ReportDescription" runat="server" class="input-box" TextMode="MultiLine" Rows="4"></asp:TextBox>
        <asp:Button ID="ReportQuestionButton" runat="server" OnClick="ReportQuestionButton_Click" Text="Report Question" />
        <div>
            <asp:RequiredFieldValidator ID="ReportedReasonValidator" runat="server" ControlToValidate="ReportedReasonList" ErrorMessage="* A reason for reporting a question must be selected." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="DescriptionFieldValidator" runat="server" ControlToValidate="ReportDescription" ErrorMessage="* A description of the issue is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
</asp:Content>
