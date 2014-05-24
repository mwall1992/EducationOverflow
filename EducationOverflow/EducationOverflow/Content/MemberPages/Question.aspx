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
    <div runat="server" id="question" class="question-answer-component"></div>
    
    <!-- Question Hints -->
    <h3>Hints:</h3>
    <asp:Repeater ID="HintRepeater" runat="server" DataSourceID="HintsDataSource">
        <ItemTemplate>
            <div id="HintContainer" runat="server" visible="false">
                <asp:HiddenField ID="APIAnswerIdField" runat="server" Value='<%# Eval("APIAnswerId") %>' />
                <asp:HiddenField ID="HintDateViewed" runat="server" />
                <h4>Hint <%# Container.ItemIndex + 1 %>:</h4>
                <div runat="server" id="HintBodyContainer" class="question-answer-component">
                    <asp:Label ID="HintLabel" runat="server" Text='<%# Eval("Body") %>'></asp:Label>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="HintsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectAnswers" TypeName="Business.Answer">
        <SelectParameters>
            <asp:QueryStringParameter Name="questionId" QueryStringField="QuestionId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Button ID="HintButton" runat="server" OnClick="HintButton_Click" Text="Request Hint" CausesValidation="False" />

    <!-- Solution -->
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="SolutionUpdatePanel" runat="server" UpdateMode="Conditional" Visible="true">
        <Triggers>
            <asp:AsyncPostBackTrigger controlid="SolutionButton" eventname="Click" />
        </Triggers>
        <ContentTemplate>
            <h3>Solution:</h3>
            <div runat="server" id="SolutionContainer" class="question-answer-component">
                <asp:Label ID="SolutionLabel" runat="server">Be sure that you have answered the question to the best of your ability before viewing the answer.</asp:Label>
            </div>
            <asp:Button ID="SolutionButton" runat="server" OnClick="SolutionButton_Click" Text="View Solution" CausesValidation="False" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="SolutionUpdateProgress" runat="server" AssociatedUpdatePanelID="SolutionUpdatePanel" DisplayAfter="100">
        <ProgressTemplate>
            Retrieving solution...
        </ProgressTemplate>
    </asp:UpdateProgress>

    <!-- Answer -->
    <div id="answer">
        <h3>Your Answer:</h3>
        <asp:TextBox ID="myAnswerTextBox" runat="server" CssClass="input-box" TextMode="MultiLine" Rows="10"></asp:TextBox>
    </div>

    <!-- Notes -->
    <div id="notes">
        <h3>Notes:</h3>
        <asp:TextBox ID="NotesTextBox" runat="server" CssClass="input-box" TextMode="MultiLine" Rows="4"></asp:TextBox>
    </div>

    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Save My Answer" CausesValidation="False" />
    
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
