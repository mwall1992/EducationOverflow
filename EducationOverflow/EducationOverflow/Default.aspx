<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/DefaultLayout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EducationOverflow.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="status_bar_content" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main_content_body_content" Runat="Server">
    <h1>
        Welcome to Education Overflow
    </h1>
    <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vitae sodales lectus. Nunc 
        convallis augue eget tortor ornare, ut porttitor libero molestie. Quisque rhoncus velit vitae 
        diam aliquam ultrices. Proin pulvinar leo nisi, vitae blandit eros semper ut. Cras consequat, 
        leo non dapibus tempor, diam lectus dignissim sapien, a rhoncus magna justo non ligula. Fusce 
        ullamcorper ut tortor a dapibus. Phasellus eu quam ullamcorper, tincidunt nunc et, blandit mi. 
        Nunc pharetra, diam non fringilla semper, lorem lectus imperdiet elit, a imperdiet augue diam quis 
        enim. Donec laoreet, orci non euismod placerat, est nulla adipiscing nunc, ac elementum lorem lectus 
        quis sapien. Integer ullamcorper neque nec gravida iaculis. Curabitur sed augue orci. Etiam in elit 
        tellus. Praesent ipsum nunc, eleifend vel sapien sit amet, condimentum tincidunt mauris. Aenean 
        velit ligula, commodo sit amet felis sed, dictum feugiat nisi. Morbi eleifend lectus pretium lorem 
        lobortis hendrerit.
    </p>
    <p>
        Vestibulum porttitor a arcu sed varius. Aenean eget velit semper, dignissim risus ut, laoreet tortor. 
        Phasellus cursus dolor et libero porttitor faucibus sit amet ut urna. Sed orci dui, suscipit et consequat 
        sit amet, aliquam at nisl. Maecenas tempus, leo a mollis placerat, sapien turpis volutpat eros, id 
        tincidunt ante ligula ut leo. In interdum quis urna sed feugiat. Fusce consequat nisi ac libero vehicula, 
        eu venenatis est elementum. Duis placerat mi tortor, vel rutrum dui feugiat a. Mauris lorem turpis, 
        facilisis et massa nec, aliquam mattis purus. Suspendisse commodo elementum semper. Etiam sed mollis 
        augue. Nullam placerat, nulla ut vulputate feugiat, velit felis sagittis sem, in vulputate dolor risus 
        ut nibh. Nunc ac orci semper, pharetra massa a, volutpat diam. Pellentesque faucibus, ipsum vitae porta 
        lacinia, purus neque vulputate elit, nec commodo dolor nulla sed ante.
    </p>
    <p>
        Praesent pretium libero ac accumsan adipiscing. Aliquam mattis ante nec enim sagittis, et dictum neque 
        consequat. Curabitur ultricies iaculis elit et condimentum. In hac habitasse platea dictumst. Mauris 
        dictum dignissim placerat. In ut ligula eget nibh ornare rhoncus vitae vel est. Quisque id est ornare, 
        suscipit libero nec, varius libero. Morbi tellus lectus, ornare eu dui suscipit, posuere tempus leo. 
        Nam eget elit a orci vestibulum molestie ut non neque. Duis a diam arcu.
    </p>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="sidebar_content" Runat="Server">
    <h3>
        Popular Questions
    </h3>
    <asp:Repeater ID="PopularQuestionsRepeater" runat="server" DataSourceID="PopularQuestionsDataSource">
        <ItemTemplate>
            <div class="question-title">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Id", "~/Content/MemberPages/Question.aspx?id={0}") %>'><%# Eval("Title") %></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="PopularQuestionsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectPopularQuestions" TypeName="Business.PopularQuestionsUserView"></asp:ObjectDataSource>
</asp:Content>
