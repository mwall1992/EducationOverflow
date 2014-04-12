<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/DefaultLayoutNoSidebar.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EducationOverflow.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" runat="server">
    Status
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header_content" runat="server">
    Header
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" runat="server">
    <form id="form1" runat="server">
    <h1>Register<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Default.aspx">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
        </asp:CreateUserWizard>
        </h1>
    </form>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footer_content" runat="server">
</asp:Content>
