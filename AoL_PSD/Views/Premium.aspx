<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Premium.aspx.cs" Inherits="AoL_PSD.Views.Premium" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .center-align {
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 10px;
        }

        .payment-label {
            text-align: center;
        }

        .payment-option {
            display: flex;
            align-items: center;
            justify-content: center; /* Add this line */
        }

        .payment-option input[type="radio"] {
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center;">Premium</h1>

        <div class="center-align">
            <asp:Label ID="paymentLbl" runat="server" Text="Select a payment method" CssClass="payment-label"></asp:Label>

            <div class="payment-option">
                <asp:RadioButtonList ID="paymentMethod" runat="server">
                    <asp:ListItem Text="Credit Card" Value="credit"></asp:ListItem>
                    <asp:ListItem Text="Paypal" Value="paypal"></asp:ListItem>
                    <asp:ListItem Text="Gopay" Value="gopay"></asp:ListItem>
                    <asp:ListItem Text="Indomaret" Value="indomaret"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <%--<div class="payment-option">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="Credit card" GroupName="paymentMethods" />
            </div>

            <div class="payment-option">
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Paypal" GroupName="paymentMethods" />
            </div>

            <div class="payment-option">
                <asp:RadioButton ID="RadioButton3" runat="server" Text="Gopay" GroupName="paymentMethods" />
            </div>

            <div class="payment-option">
                <asp:RadioButton ID="RadioButton4" runat="server" Text="Indomaret" GroupName="paymentMethods" />
            </div>--%>

            <asp:Button ID="submitBtn" runat="server" Text="Submit and become premium!" onClick="submitBtn_Click"/>
            <div class="errorMessage">
                <asp:Label ID="ErrorLabel" runat="server" Visible="false" BorderStyle="Solid" BackColor="Red" style="padding:20px;" Text="Please select a payment method!"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
