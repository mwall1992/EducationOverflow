<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="EducationOverflow.Content.Member_Pages.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataSourceID="QuestionDataSource" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="Length" HeaderText="Length" ReadOnly="True" SortExpression="Length" />
            <asp:BoundField DataField="Length" HeaderText="Name" SortExpression="Length" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="QuestionDataSource" runat="server" SelectMethod="SelectQuestionTags" TypeName="Business.QuestionTag">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="questionId" QueryStringField="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" runat="server">
</asp:Content>
