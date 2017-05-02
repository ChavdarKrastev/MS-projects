<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Metali.aspx.cs" Inherits="WebApp3001_2.Metali" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Select a type:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="sds_type" DataTextField="type" DataValueField="type">
    </asp:DropDownList>
    <asp:SqlDataSource ID="sds_type" runat="server" ConnectionString="<%$ ConnectionStrings:MetalsConnection %>" SelectCommand="SELECT DISTINCT [type] FROM [metali] ORDER BY [type]"></asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>
