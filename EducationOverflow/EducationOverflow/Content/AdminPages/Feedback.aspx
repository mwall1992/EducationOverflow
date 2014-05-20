<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="EducationOverflow.Content.Admin_Pages.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="QuestionId,userId" 
        DataSourceID="QuestionFeedbackSummaryDataSource" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User Id" ReadOnly="True" SortExpression="UserId" />
            <asp:BoundField DataField="QuestionId" HeaderText="Question Id" ReadOnly="True" SortExpression="QuestionId" />
            <asp:BoundField DataField="ApiSiteParameter" HeaderText="API Site Parameter" ReadOnly="True" SortExpression="ApiSiteParameter" />
            <asp:BoundField DataField="QuestionTitle" HeaderText="Title" ReadOnly="True" SortExpression="Title"  />
            <asp:BoundField DataField="Liked" HeaderText="Liked" ReadOnly="True" SortExpression="Liked" />
            <asp:BoundField DataField="SummaryAdjective" HeaderText="Summary Adjective" ReadOnly="True" SortExpression="SummaryAdjective" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="True" SortExpression="LastName" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="QuestionFeedbackSummaryDataSource" runat="server" 
        SelectMethod="SelectQuestionFeedbackSummaries" TypeName="Business.QuestionFeedbackSummary"></asp:ObjectDataSource>
</asp:Content>
