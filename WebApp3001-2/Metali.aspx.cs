using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

namespace WebApp3001_2
{
    public partial class Metali : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }
        private void FillPage()
        {
            ArrayList metalsList = new ArrayList();

            if (!IsPostBack)
            {
                metalsList = ConnectionClass.GetMetalsByType("%");
            }
            else 
            {
                metalsList = ConnectionClass.GetMetalsByType(DropDownList1.SelectedValue);
            }
            StringBuilder sb = new StringBuilder();

            foreach (Metals metals in metalsList)
            {
                sb.Append(
                    string.Format(
                        @"<table class='metalsTable'>
            <tr>
                <th rowspan='4' width='150px'><img runat='server' src='{3}' /></th>
                <th width='50px'>type: </td>
                <td>{0} </td>
            </tr>

            <tr>
                <th>price: </th>
                <td>{1} $</td>
            </tr>

            <tr>
                <th>weight: </th>
                <td>{2} </td>
            </tr>

           </table>",

                    metals.Type, metals.Price, metals.Weight, metals.Image));
                lblOutput.Text = sb.ToString();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPage();
        }
    }
}