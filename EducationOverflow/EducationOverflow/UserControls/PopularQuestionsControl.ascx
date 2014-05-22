<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopularQuestionsControl.ascx.cs" Inherits="EducationOverflow.UserControls.PopularQuestionsControl" %>

<script runat="server">
    const int MIN_RESULT_COUNT = 0;
    private int maxResultCount = 1;
    public int MaxResultCount {
        get {
            return maxResultCount;
        }    
    
        set {
            if (value < MIN_RESULT_COUNT) {
                throw new ArgumentException(
                    string.Format("MaxResultCount must be greater than or equal to {0}.", MIN_RESULT_COUNT)
                );
            }

            maxResultCount = value;
        }
    }

    protected void Page_Load(Object sender, EventArgs e) {
        if (!IsPostBack) {
            PopularQuestionsDataSource.SelectParameters["maxResultCount"].DefaultValue = MaxResultCount.ToString();
        }
    }
</script>

<asp:Repeater ID="PopularQuestionsRepeater" runat="server" DataSourceID="PopularQuestionsDataSource">
    <ItemTemplate>
        <div class="question-title">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Id", "~/Content/MemberPages/Question.aspx?id={0}") %>'><%# Eval("Title") %></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="PopularQuestionsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SelectPopularQuestions" TypeName="Business.PopularQuestions">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="maxResultCount" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
