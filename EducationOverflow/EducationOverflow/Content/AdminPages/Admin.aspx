<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="EducationOverflow.Content.AdminPages.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="main_content_body_content" runat="server">
    <h1>
        Admin Portal
    </h1>
    <h4>Change Password</h4>
    <p>
        Praesent pretium libero ac accumsan adipiscing. Aliquam mattis ante nec enim sagittis, et dictum neque 
        consequat. Curabitur ultricies iaculis elit et condimentum. In hac habitasse platea dictumst. Mauris 
        dictum dignissim placerat. In ut ligula eget nibh ornare rhoncus vitae vel est. Quisque id est ornare, 
        suscipit libero nec, varius libero. Morbi tellus lectus, ornare eu dui suscipit, posuere tempus leo. 
        Nam eget elit a orci vestibulum molestie ut non neque. Duis a diam arcu.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Content/MemberAndAdminPages/ChangePassword.aspx">Click here to change your password</asp:HyperLink>
    </p>
    <h4>Question Feedback</h4>
    <p>
        Praesent pretium libero ac accumsan adipiscing. Aliquam mattis ante nec enim sagittis, et dictum neque 
        consequat. Curabitur ultricies iaculis elit et condimentum. In hac habitasse platea dictumst. Mauris 
        dictum dignissim placerat. In ut ligula eget nibh ornare rhoncus vitae vel est. Quisque id est ornare, 
        suscipit libero nec, varius libero. Morbi tellus lectus, ornare eu dui suscipit, posuere tempus leo. 
        Nam eget elit a orci vestibulum molestie ut non neque. Duis a diam arcu.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Content/AdminPages/Feedback.aspx">Click here to access the Question Feedback Panel</asp:HyperLink>
    </p>
    <h4>Reported Questions</h4>
    <p>
        Praesent pretium libero ac accumsan adipiscing. Aliquam mattis ante nec enim sagittis, et dictum neque 
        consequat. Curabitur ultricies iaculis elit et condimentum. In hac habitasse platea dictumst. Mauris 
        dictum dignissim placerat. In ut ligula eget nibh ornare rhoncus vitae vel est. Quisque id est ornare, 
        suscipit libero nec, varius libero. Morbi tellus lectus, ornare eu dui suscipit, posuere tempus leo. 
        Nam eget elit a orci vestibulum molestie ut non neque. Duis a diam arcu.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Content/AdminPages/ReportedQuestions.aspx">Click here to access the Reported Questions Panel</asp:HyperLink>
    </p>
    <h4>Sign out</h4>
    <p>
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Content/MemberAndAdminPages/SignOut.aspx">Click here to sign out</asp:HyperLink>
    </p>
</asp:Content>
