using E_Shopping.Convert;
using E_Shopping.Model;
using E_Shopping.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Class
{
    public class EmailService
    {
        public static void sendEmail(ObservableCollection<ORDER> cart,Stack<object> stackview, DateTime dateTime)
        {
            PaymentOptionsViewModel paymentOptionsViewModel = stackview.Pop() as PaymentOptionsViewModel;

            DeliveryOptionViewModel deliveryOptionViewModel = stackview.Pop() as DeliveryOptionViewModel;

            ShippingDetailsViewModel shippingDetailsViewModel = (stackview.Pop() as ShippingDetailsViewModel);

            if (shippingDetailsViewModel.email==null||shippingDetailsViewModel.email=="" )
            {
                return;
            }


            ConvertStringToCurrency  convertStringToCurrency = new ConvertStringToCurrency();
            string deliveryoptions = "";
            string paymentoptions = "";
            double total = 0;
            foreach (ORDER cartItem in cart)
            {
                PRODUCT p = DataProvider.ins.DB.PRODUCTs.Where(m => m.id == cartItem.idProduct).FirstOrDefault();
                total += Double.Parse((p.price*cartItem.quantity).ToString());
            }
            if (deliveryOptionViewModel.sameDayDelivery)
            {
                deliveryoptions = "Same day delivery";
                total += deliveryOptionViewModel.sameDayDeliveryPrice;

            }
            else if (deliveryOptionViewModel.businessDelivery)
            {
                deliveryoptions = "Business delivery";
                total += deliveryOptionViewModel.businessDeliveryPrice;

            }
            else
            {
                deliveryoptions = "Standard Delivery";
                total += deliveryOptionViewModel.standardDeliveryPrice;

            }


            if (paymentOptionsViewModel.payOnDelivery)
            {
                paymentoptions = "Pay On Delivery";
            }
            else if (paymentOptionsViewModel.creditCard)
            {
                paymentoptions = "Credit Card (Visa, MasterCard or Discover)";
            }
            else
            {
                paymentoptions = "American Express";
            }




            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            //client.Timeout = 100000;
            client.Timeout = 0;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;


            client.Credentials = new NetworkCredential("footballmanagement111@gmail.com", "upovphfgbfmhacux");
            MailMessage msg = new MailMessage();
            msg.To.Add(shippingDetailsViewModel.email);//chuyển  thành mail người dùng
            msg.From = new MailAddress("footballmanagement111@gmail.com");
            msg.Subject = "Order Details";

            StringBuilder productList = new StringBuilder();
            productList.AppendLine("Buyer Info: " + "David");//Sửa lại thành tên của chủ tài khoản
            productList.AppendLine("Receiver Info: ");
            productList.AppendLine("Name: " + shippingDetailsViewModel.firstNanme +" "+ shippingDetailsViewModel.lastNanme);
            productList.AppendLine("Email: " + shippingDetailsViewModel.email);
            productList.AppendLine("Phone number: " + shippingDetailsViewModel.phoneNumber);
            productList.AppendLine("Address: " + shippingDetailsViewModel.address);
            productList.AppendLine("Note: " + shippingDetailsViewModel.note);
            productList.AppendLine("Delivery Options: " + deliveryoptions);
            productList.AppendLine("Payment Options: " + paymentoptions);
            productList.AppendLine("Total Price: " + total +"đ");
            productList.AppendLine("Order date: " + dateTime.ToString());
            productList.AppendLine();
            foreach (ORDER product in cart)
            {
                //Attachment imageAttachment = new Attachment(product.image, "image/jpeg");
                //message.Attachments.Add(imageAttachment);
                //productList.AppendLine(product.name + " - $" + product.Price);
                productList.AppendLine("Name: " + product.prodductName);
                productList.AppendLine("Quantity: " + product.quantity);
                productList.AppendLine("Price: " + product.productPrice * product.quantity+"đ");
                productList.AppendLine();
            }


            msg.Body = productList.ToString();
            var send = client.SendMailAsync(msg);
            
        }
    }
}
