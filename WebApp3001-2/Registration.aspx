<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApp3001_2.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 693px">

        <tr>
            <td> Name:</td>
            <td> 
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="#"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Password</td>
            <td> 
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="#"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> Confirm Password:</td>
            <td> 
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="161px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirm" ErrorMessage="#"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> E-mail:</td>
            <td> 
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="#"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td> 
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirm" ControlToValidate="txtPassword" ErrorMessage="Passwords have to be the same"></asp:CompareValidator>
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
