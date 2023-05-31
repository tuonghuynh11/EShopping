using E_Shopping.PopUp;
using E_Shopping.Untils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class FeedBackViewModel:BaseViewModel
    {
        public ICommand sendEmailReport { get; set; }
        public ICommand openFileImageDialog { get; set; }
        public FeedBackViewModel()
        {
            sendEmailReport = new RelayCommand<Feedback>((p) => { return true; }, (p) => { sendEmail(p); });
            openFileImageDialog = new RelayCommand<Feedback>((p) => { return true; }, (p) => { openFileImage(p); });
        }
        void sendEmail(Feedback fb)
        {
            try
            {

                if (Check(fb))
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    //client.Timeout = 100000;
                    client.Timeout = 0;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    string emailAddress = "shopgo870@gmail.com";
                    string emailPassword = "jkotoxlrmbqchpqu";

                    client.Credentials = new NetworkCredential(emailAddress, emailPassword);
                    MailMessage msg = new MailMessage();
                    msg.To.Add(emailAddress);
                    msg.From = new MailAddress(emailAddress);
                    msg.Subject = fb.txbSubject.Text;
                    string bodyEmail = fb.txbEmail.Text + " đã gửi: \n" + fb.txbBody.Text;
                    msg.Body = bodyEmail;

                    if (fb.btnAttachment.Content.ToString().Contains(".jpg") ||
                        fb.btnAttachment.Content.ToString().Contains(".png") ||
                        fb.btnAttachment.Content.ToString().Contains(".pdf"))
                    {
                        foreach (string path in spliter(fb.btnAttachment.Content.ToString()))
                        {
                            Attachment atc = new Attachment(path);
                            msg.Attachments.Add(atc);
                        }
                    }
                    var send = client.SendMailAsync(msg);
                    SucceedNotify thankyouWindow = new SucceedNotify();
                    thankyouWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        void openFileImage(Feedback fb)
        {
            try
            {

                System.Windows.Forms.OpenFileDialog attachment = new System.Windows.Forms.OpenFileDialog();
                attachment.Multiselect = true;
                attachment.Filter = "Images(.jpg,.png)|*.png;*.jpg;|Pdf File|*.pdf";
                DialogResult dialogOK = attachment.ShowDialog();
                if (dialogOK == DialogResult.OK)
                {
                    string sFileNames = "";
                    foreach (string sFileName in attachment.FileNames)
                        sFileNames += ";" + sFileName;
                    sFileNames = sFileNames.Substring(1);
                    fb.btnAttachment.Content = sFileNames;
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        public bool Check(Feedback fb)
        {
            if (string.IsNullOrWhiteSpace(fb.txbEmail.Text))
            {
                ValidationNotify notifyWindow = new ValidationNotify("Vui lòng nhập email");
                notifyWindow.ShowDialog();
                fb.txbEmail.Focus();
                return false;
            }

            if (!EmailValidator.EmailIsValid(fb.txbEmail.Text))
            {
                ValidationNotify notifyWindow = new ValidationNotify("Địa chỉ email không hợp lệ");
                notifyWindow.ShowDialog();
                fb.txbSubject.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(fb.txbSubject.Text))
            {
                ValidationNotify notifyWindow = new ValidationNotify("Vui lòng nhập chủ đề");
                notifyWindow.ShowDialog();
                fb.txbSubject.Focus();
                return false;
            }



            return true;
        }

        private string[] spliter(string text) => text.Split(';');
    }
}

