<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="Metal_add.aspx.cs" Inherits="WebApp3001_2.Metal_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Add new metal</h3>

    <table cellspacing="15" class="metalsTable">

    <tr>
            <td style="width: 95px">

                Type</td>
            <td>

                <asp:TextBox ID="txtType" runat="server" Width="300px"></asp:TextBox>

            </td>
        </tr>
    <tr>
            <td style="width: 95px">

                Price</td>
            <td>

                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>

            </td>
        </tr>
    <tr>
            <td style="width: 95px">

                Weight</td>
            <td>

                <asp:TextBox ID="txtWeight" runat="server" Width="300px"></asp:TextBox>

            </td>
        </tr>
    <tr>
            <td style="width: 95px">

                Image</td>
            <td>

                <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" OnClick="btnUploadImage_Click" />
            </td>
        </tr>
                            </table>

    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

</asp:Content>
