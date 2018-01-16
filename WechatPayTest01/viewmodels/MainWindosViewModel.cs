using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using WechatPayTest01.Business;
using WechatPayTest01.lib;

namespace WechatPayTest01.viewmodels
{
    class MainWindosViewModel: INotifyPropertyChanged
    {
        private double _totalPay = 0;

        SettingViewModel settings = new SettingViewModel();

        #region ICommand
        public ICommand QuickPay_Command { get; set; }
        public ICommand OrderQuery_Command { get; set; }
        public ICommand Refund_Command { get; set; }
        public ICommand RefundQuery_Command { get; set; }
        public ICommand DownloadBills_Command { get; set; }
        #endregion ICommand

        public MainWindosViewModel()
        {
            QuickPay_Command = new RelayCommand(new Action<object>(QuickPay));
            OrderQuery_Command = new RelayCommand(new Action<object>(QueryOrder));
            Refund_Command = new RelayCommand(new Action<object>(RefundPayment));
            RefundQuery_Command = new RelayCommand(new Action<object>(RefundQuery));
            DownloadBills_Command = new RelayCommand(new Action<object>(DownloadBills));
            _totalPay = 37.75;
            settings.Set_Urls();
        }

        #region properties
        public string Barcode { get; set; } = "123456789987654321";

        public string ProductDescription { get; set; } = "Mc. BigMAX Combo";

        public string Transaction_NO { get; set; }

        public string TransMessage { get; set; }

        public string TimeElapsed { get; set; }

        public double TotalPay {
            get { return _totalPay; }
            set
            {
                if (TotalPay != value)
                {
                    _totalPay = value;
                    OnPropertyChanged("TotalPay");
                }
            }
        }
        #endregion properties


        public void QuickPay(object obj)
        {
            if ( string.IsNullOrWhiteSpace(Barcode))
            {
                ShowMessage("Scanning the QC code prior to submit");
            }

            if (_totalPay == 0.0)
            {
                ShowMessage("no payment");
            }

            if (string.IsNullOrWhiteSpace(ProductDescription))
            {
                ShowMessage("please input the production description");
            }
            try
            {
                string result = MicroPay.Run(ProductDescription, (_totalPay * 100).ToString(), Barcode);
            }
            catch (WxPayException ex)
            {
                ShowMessage(ex.ToString());
            }
            catch(Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        public void RefundPayment(object obj)
        {
            if (string.IsNullOrWhiteSpace(Transaction_NO))
            {
                ShowMessage("please input the production description");
            }
            try
            {
                string result = OrderQuery.Run(Transaction_NO, null);//调用订单查询业务逻辑
            }
            catch (WxPayException ex)
            {
                ShowMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        public void QueryOrder(object obj)
        {
            if (string.IsNullOrWhiteSpace(Transaction_NO))
            {
                ShowMessage("please input the production description");
            }
            try
            {
                string result = OrderQuery.Run(Transaction_NO, null);//调用订单查询业务逻辑
            }
            catch (WxPayException ex)
            {
                ShowMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        public void RefundQuery(object obj)
        {
            if (string.IsNullOrWhiteSpace(Transaction_NO))
            {
                ShowMessage("please input the production description");
            }
            try
            {
                string result = OrderQuery.Run(Transaction_NO, null);//调用订单查询业务逻辑
            }
            catch (WxPayException ex)
            {
                ShowMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        public void DownloadBills(object obj)
        {
            if (string.IsNullOrWhiteSpace(Transaction_NO))
            {
                ShowMessage("please input the production description");
            }
            try
            {
                string result = OrderQuery.Run(Transaction_NO, null);//调用订单查询业务逻辑
            }
            catch (WxPayException ex)
            {
                ShowMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString());
            }
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(Barcode + _totalPay.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
