<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="ReportedQuestionDetails.aspx.cs" Inherits="EducationOverflow.Content.AdminPages.ReportedQuestionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ReportedQuestionDetailsDataSource" Height="50px" Width="125px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="APISiteParameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="OptionalDescription" HeaderText="OptionalDescription" SortExpression="OptionalDescription" />
            <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
            <asp:BoundField DataField="UpVotes" HeaderText="UpVotes" SortExpression="UpVotes" />
            <asp:BoundField DataField="DownVotes" HeaderText="DownVotes" SortExpression="DownVotes" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="APIQuestionId" HeaderText="APIQuestionId" SortExpression="APIQuestionId" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>

    <asp:ObjectDataSource ID="ReportedQuestionDetailsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectReportedQuestionDetails" TypeName="Business.ReportedQuestionDetails">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="userId" QueryStringField="UserId" Type="Int64" />
            <asp:QueryStringParameter DefaultValue="1" Name="questionId" QueryStringField="QuestionId" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
