﻿using E_Shopping.Model;
using E_Shopping.ViewModel;
using E_Shopping.UserControlBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using E_Shopping.Class;

namespace E_Shopping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        
            InitializeComponent();

            this.DataContext = new MainViewModel();
      
           


        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            //Mốt chuyển thành idUser
            Person currentUser = new Person() { id = 2, idRole = 1 };

            //Mốt check xem currentUser là customer hay assistant
            string text = messageTb.Text.ToString();
            if (text==null||text=="")
            {
                return;
            }
            (this.DataContext as MainViewModel).chatBox.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = currentUser.id, content = text, isSend = currentUser.idRole == 1 ? 0 : 1 });
            DataProvider.ins.DB.CHATBOXes.Add(new Model.CHATBOX() { idAssistant = 3, idCustomer = currentUser.id, content = text, isSend = currentUser.idRole == 1 ? 0 : 1 });
            DataProvider.ins.DB.SaveChanges();
            messageTb.Text = "";
            MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);
        }

        private void Flipper_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageList.ScrollIntoView(MessageList.Items[MessageList.Items.Count - 1]);

        }

        private void controlBar_VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ControlBarUC obj = sender as ControlBarUC;
            ControlBarViewModel vm = obj.DataContext as ControlBarViewModel;
            if ((bool)e.NewValue)
            {
                vm.VisibleCommand.Execute(obj as UserControl);
            }
        }
    }
}
