<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EducationOverflow.Default" %>
<%@ Register TagPrefix="uc" TagName="PopularQuestionList" Src="~/UserControls/PopularQuestionsControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" Runat="Server">
    <h1>
        Welcome to Education Overflow
    </h1>
    <p>
        Education Overflow is an experimental site that leverages information from the Stack Exchange
        Network in an attempt to replicate effective learning environments. The site is simple and effective.
        You can learn and grow in a few simple steps:
    </p>
    <ol>
        <li>Sign Up or Log in</li>
        <li>Choose a question</li>
        <li>Learn something new or challenge yourself by answering the question independently</li>
    </ol>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" Runat="Server">
    <h3>
        Popular Questions
    </h3>
    <uc:PopularQuestionList id="PopularQuestionList1" runat="server" MaxResultCount="6" />
</asp:Content>
