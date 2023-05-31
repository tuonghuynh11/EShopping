using E_Shopping.Class;
using E_Shopping.Model;
using E_Shopping.PopUp;
using E_Shopping.UserControlBar.Screen;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class PaymentOptionsViewModel : BaseViewModel
    {
        //Attribute
        private bool _payOnDelivery;
        public bool payOnDelivery
        {
            get => _payOnDelivery;
            set
            {
                _payOnDelivery = value;
                OnPropertyChanged();
            }
        }

        private bool _creditCard;
        public bool creditCard
        {
            get => _creditCard;
            set
            {
                _creditCard = value;
                OnPropertyChanged();
                cardName = "";
                cardNumber = "";
                cardExp = DateTime.Today;
                cardCSV = "";
            }
        }

        private bool _americanCard;
        public bool americanCard
        {
            get => _americanCard;
            set
            {
                _americanCard = value; OnPropertyChanged();
                cardName = "";
                cardNumber = "";
                cardExp = DateTime.Today;
                cardCSV = "";
            }
        }



        private string _cardName;
        public string cardName
        {
            get => _cardName;
            set
            {
                _cardName = value;
                OnPropertyChanged();
            }
        }
        private string _cardNumber;
        public string cardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }


        private DateTime _cardExp;
        public DateTime cardExp
        {
            get => _cardExp;
            set
            {
                _cardExp = value;
                OnPropertyChanged();
            }
        }
        private string _cardCSV;
        public string cardCSV
        {
            get => _cardCSV;
            set
            {
                _cardCSV = value;
                OnPropertyChanged();
            }
        }
        public ICommand BackToDeliveryDetailCommand { get; set; }
        public ICommand FinishOrderCommand { get; set; }
        //notify
        public ValidationNotify notify = new ValidationNotify();
        public SucceedNotify succeedNotify = new SucceedNotify();
        public PaymentOptionsViewModel()
        {
            payOnDelivery = true;
            creditCard = americanCard = false;
            BackToDeliveryDetailCommand = new RelayCommand<PaymentOptions>((p) => {
                return true;
            },
            (p) => {
                ShippingAddressViewModel.removeViewToStack();
            }
            );

            FinishOrderCommand = new RelayCommand<PaymentOptions>((p) => {
                return true;
            },
           (p) =>
           {
               RECEIPT receipt = new RECEIPT();
               double total = 0;
               int idcard = 0;
               List<ORDER> temp = ShippingAddressViewModel.Instance.listItem.ToList();
               if (payOnDelivery)
               {
                   SucceedNotify succeed = new SucceedNotify();
                   succeed.content.Text = "Your items will delivery in some days!!";
                   succeed.content.FontSize = 20;
                   succeed.ShowDialog();
                   EmailService.sendEmail(ShippingAddressViewModel.Instance.listItem,ShippingAddressViewModel.stackView,DateTime.Now);
                 
                   foreach (ORDER order in ShippingAddressViewModel.Instance.listItem.ToList())
                   {
                       total += (double)order.quantity * order.productPrice;
                       ORDER o = DataProvider.ins.DB.ORDERS.Find(order.id);
                       o.status = 1;
                       DataProvider.ins.DB.SaveChanges();
                   }
                   ShippingAddressViewModel.stackView.Clear();
                   MainViewModel.returnToEmptyCard();
               }
               else if (creditCard)
               {
                   if (checkCreditCard(p))
                   {
                       EmailService.sendEmail(ShippingAddressViewModel.Instance.listItem, ShippingAddressViewModel.stackView, DateTime.Now);
                       PAYMENTINFORMATION payment = new PAYMENTINFORMATION() {typeOfCard=1,cardNumber=cardNumber,ownName=cardName,expDate=cardExp,csv=cardCSV  };
                       DataProvider.ins.DB.PAYMENTINFORMATIONs.Add(payment);
                       DataProvider.ins.DB.SaveChanges();
                      idcard = payment.id;
                       foreach (ORDER order in ShippingAddressViewModel.Instance.listItem.ToList())
                       {
                           total += (double)order.quantity * order.productPrice;
                           ORDER o = DataProvider.ins.DB.ORDERS.Find(order.id);
                           o.status = 1;
                           DataProvider.ins.DB.SaveChanges();
                       }
                       MainViewModel.returnToEmptyCard();
                   }
                   else
                   {
                       reset(p);
                       return;
                   }

               }
               else
               {
                   if (checkAmericanCard(p))
                   {
                       EmailService.sendEmail(ShippingAddressViewModel.Instance.listItem, ShippingAddressViewModel.stackView, DateTime.Now);
                       PAYMENTINFORMATION payment = new PAYMENTINFORMATION() { typeOfCard = 2, cardNumber = cardNumber, ownName = cardName, expDate = cardExp, csv = cardCSV };
                       DataProvider.ins.DB.PAYMENTINFORMATIONs.Add(payment);
                       DataProvider.ins.DB.SaveChanges();
                       idcard = payment.id;
                       foreach (ORDER order in ShippingAddressViewModel.Instance.listItem.ToList())
                       {
                           total += (double)order.quantity * order.productPrice;
                           ORDER o = DataProvider.ins.DB.ORDERS.Find(order.id);
                           o.status = 1;
                           DataProvider.ins.DB.SaveChanges();
                       }
                       MainViewModel.returnToEmptyCard();
                   }
                   else
                   {
                       reset(p);
                       return;
                   }

               }


               DataProvider.ins.DB.DELIVERies.Add(DeliveryOptionViewModel.deliveryInfo);
               DataProvider.ins.DB.RECEIVERINFORMATIONs.Add(ShippingDetailsViewModel.receiverInfo);
               DataProvider.ins.DB.SaveChanges();
               //DELIVERY delv = DataProvider.ins.DB.Database.SqlQuery<DELIVERY>("SELECT TOP(1) *  FROM DELIVERY ORDER BY ID DESC ").FirstOrDefault<DELIVERY>();
               //RECEIVERINFORMATION rev= DataProvider.ins.DB.Database.SqlQuery<RECEIVERINFORMATION>("SELECT TOP(1) *  FROM RECEIVERINFORMATION ORDER BY ID DESC ").FirstOrDefault<RECEIVERINFORMATION>();

               //Check giftCode
               if (ShippingAddressViewModel.Instance.idGiftCode!=null)
               {
                   DISCOUNT discount = DataProvider.ins.DB.DISCOUNTs.Where(u => u.id == ShippingAddressViewModel.Instance.idGiftCode).FirstOrDefault();
                   discount.status = "Used";
                   DataProvider.ins.DB.SaveChanges();

               }


               //Mốt sửa idCustomer thành id user
               if (idcard==0)
               {
                   receipt = new RECEIPT() { idCustomer = AccessUser.currentUser.id, receiverInfo = ShippingDetailsViewModel.receiverInfo.id, typeOfDelivery = DeliveryOptionViewModel.deliveryInfo.id, totalCost = (long)total, idDiscount = ShippingAddressViewModel.Instance.idGiftCode, saleValue = (long)ShippingAddressViewModel.Instance.saleTax, date = DateTime.Today, status = 0 };

               }
               else
               {
                   receipt = new RECEIPT() { idCustomer = AccessUser.currentUser.id, receiverInfo = ShippingDetailsViewModel.receiverInfo.id, paymentInfo = idcard, typeOfDelivery = DeliveryOptionViewModel.deliveryInfo.id, totalCost = (long)total,idDiscount=ShippingAddressViewModel.Instance.idGiftCode,saleValue=(long)ShippingAddressViewModel.Instance.saleTax, date = DateTime.Today, status = 0 };
               }
               DataProvider.ins.DB.RECEIPTs.Add(receipt);
               DataProvider.ins.DB.SaveChanges();

               //RECEIPT rec = DataProvider.ins.DB.Database.SqlQuery<RECEIPT>("SELECT TOP(1) *  FROM RECEIPT ORDER BY ID DESC ").FirstOrDefault<RECEIPT>();

               foreach(ORDER o in temp)
               {
                   ORDERSRECEIPT or = new ORDERSRECEIPT() { idOrder = o.id, idReceipt = receipt.id };
                   DataProvider.ins.DB.ORDERSRECEIPTs.Add(or);
                   DataProvider.ins.DB.SaveChanges();
               }
               ShippingDetailsViewModel.receiverInfo = new RECEIVERINFORMATION();
               DeliveryOptionViewModel.deliveryInfo = new DELIVERY();
           }
           );
        }

        public bool checkCreditCard(PaymentOptions p)
        {
            if (p.cardNumbertb.Text.Trim().Length !=16)
            {
                notify = new ValidationNotify("Card number has 16 numbers!!!");
                notify.ShowDialog();
                return false;
            }
            if (p.cvctb.Text.Trim().Length != 3)
            {
                notify = new ValidationNotify("CVC has 3 numbers!!!");
                notify.ShowDialog();
                return false;
            }
            ProgressBar progressBar = new ProgressBar();

            try
            {
                StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings.Get("StripeKey"));
                string[] expireDate = p.expCreditCarddate.Text.Split('/');

                var opttoken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = p.cardNumbertb.Text,
                        ExpMonth = expireDate[0],
                        ExpYear = expireDate[2],
                        Cvc = p.cvctb.Text,
                    },

                };

                var tokenService = new TokenService();
                Token striptionToken = tokenService.Create(opttoken);

                var options = new ChargeCreateOptions
                {
                    Amount = Int32.Parse(ShippingAddressViewModel.Instance.totalDue.ToString()),// value is cent currency
                    Currency = "vnd",
                    Description = "test transaction",
                    Source = striptionToken.Id
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);
                progressBar.Show();
                if (charge.Paid)
                {
                    progressBar.Close();
                    succeedNotify.ShowDialog();
                    return true;
                }
                else
                {
                    progressBar.Close();
                    notify = new ValidationNotify("Faied!");
                    notify.ShowDialog();
                    return false;
                }

            }
            catch (Exception ex)
            {
                progressBar.Close();
                notify.content.Text = ex.Message;
                notify.ShowDialog();
                return false;
            }
            return false;
        }


        public bool checkAmericanCard(PaymentOptions p)
        {
            if (p.americancardNumbertb.Text.Trim().Length != 15)
            {
                notify = new ValidationNotify("Card number has 15 numbers!!!");
                notify.ShowDialog();
                return false;
            }
            if (p.americancvctb.Text.Trim().Length != 4)
            {
                notify = new ValidationNotify("CVC has 4 numbers!!!");
                notify.ShowDialog();
                return false;
            }
            ProgressBar progressBar = new ProgressBar();

            try
            {
                StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings.Get("StripeKey"));
                string[] expireDate = p.americanexpCreditCarddate.Text.Split('/');

                var opttoken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = p.americancardNumbertb.Text,
                        ExpMonth = expireDate[0],
                        ExpYear = expireDate[2],
                        Cvc = p.americancvctb.Text,
                    },

                };

                var tokenService = new TokenService();
                Token striptionToken = tokenService.Create(opttoken);

                var options = new ChargeCreateOptions
                {
                    Amount = Int32.Parse(ShippingAddressViewModel.Instance.totalDue.ToString()),// value is cent currency
                    Currency = "vnd",
                    Description = "test transaction",
                    Source = striptionToken.Id
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);

                progressBar.Show();
                if (charge.Paid)
                {
                    progressBar.Close();
                    succeedNotify.ShowDialog();
                    return true;
                }
                else
                {
                    progressBar.Close();
                    notify = new ValidationNotify("Faied!");
                    notify.ShowDialog();
                    return false;
                }

            }
            catch (Exception ex)
            {
                progressBar.Close();
                notify.content.Text = ex.Message;
                notify.ShowDialog();
                return false;
            }
            return false;
        }

        public void reset(PaymentOptions p)
        {
            p.nameOfOwntb.Text = "";
            p.americannameOfOwntb.Text = "";
            p.cardNumbertb.Text = "";
            p.americancardNumbertb.Text = "";

            p.expCreditCarddate.Text = "";
            p.americanexpCreditCarddate.Text = "";
            p.cvctb.Text = "";
            p.americancvctb.Text = "";

        }
    }

}
