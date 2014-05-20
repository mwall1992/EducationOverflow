<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="EducationOverflow.Content.Admin_Pages.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="QuestionSummaryFeedbackDataSource" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CheckBoxField DataField="Liked" HeaderText="Liked" SortExpression="Liked" />
            <asp:BoundField DataField="SummaryAdjective" HeaderText="SummaryAdjective" SortExpression="SummaryAdjective" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="APISiteParameter" HeaderText="APISiteParameter" SortExpression="APISiteParameter" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="DetailsLink" runat="server" NavigateUrl='<%# string.Format("~/Content/AdminPages/FeedbackDetails.aspx?UserId={0}&QuestionId={1}",
                        HttpUtility.UrlEncode(Eval("UserId").ToString()), HttpUtility.UrlEncode(Eval("Id").ToString())) %>'
                        Text="View Details" />
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:ObjectDataSource ID="QuestionSummaryFeedbackDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectQuestionFeedbackSummaries" TypeName="Business.QuestionFeedbackSummary"></asp:ObjectDataSource>
</asp:Content>
