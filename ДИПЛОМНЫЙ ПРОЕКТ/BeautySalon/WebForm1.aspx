<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BeautySalon.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="КодЗаявки" DataSourceID="SqlDataSource1" EmptyDataText="Нет записей для отображения.">
            <Columns>
                <asp:BoundField DataField="КодЗаявки" HeaderText="КодЗаявки" ReadOnly="True" SortExpression="КодЗаявки" />
                <asp:BoundField DataField="Имя" HeaderText="Имя" SortExpression="Имя" />
                <asp:BoundField DataField="Дата" HeaderText="Дата" SortExpression="Дата" />
                <asp:BoundField DataField="КодУслуга" HeaderText="КодУслуга" SortExpression="КодУслуга" />
                <asp:BoundField DataField="Телефон" HeaderText="Телефон" SortExpression="Телефон" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Примечание" HeaderText="Примечание" SortExpression="Примечание" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AnastasiaConnectionString1 %>" DeleteCommand="DELETE FROM [Заявка] WHERE [КодЗаявки] = @КодЗаявки" InsertCommand="INSERT INTO [Заявка] ([Имя], [Дата], [КодУслуга], [Телефон], [Email], [Примечание]) VALUES (@Имя, @Дата, @КодУслуга, @Телефон, @Email, @Примечание)" ProviderName="<%$ ConnectionStrings:AnastasiaConnectionString1.ProviderName %>" SelectCommand="SELECT [КодЗаявки], [Имя], [Дата], [КодУслуга], [Телефон], [Email], [Примечание] FROM [Заявка]" UpdateCommand="UPDATE [Заявка] SET [Имя] = @Имя, [Дата] = @Дата, [КодУслуга] = @КодУслуга, [Телефон] = @Телефон, [Email] = @Email, [Примечание] = @Примечание WHERE [КодЗаявки] = @КодЗаявки">
            <DeleteParameters>
                <asp:Parameter Name="КодЗаявки" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Имя" Type="String" />
                <asp:Parameter Name="Дата" Type="DateTime" />
                <asp:Parameter Name="КодУслуга" Type="Int32" />
                <asp:Parameter Name="Телефон" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Примечание" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Имя" Type="String" />
                <asp:Parameter Name="Дата" Type="DateTime" />
                <asp:Parameter Name="КодУслуга" Type="Int32" />
                <asp:Parameter Name="Телефон" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Примечание" Type="String" />
                <asp:Parameter Name="КодЗаявки" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
    </form>
</body>
</html>
