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
        private string _transaction_no;
        private string _trans_message;
        private string _return_status;
        private double _time_elapsed;
        private WxPayData quickpayreturn;

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
            _totalPay = 0.01;
            settings.Set_Urls();
        }

        #region properties
        public string Barcode { get; set; } = "123456789987654321";

        public string ProductDescription { get; set; } = "Mc. BigMAX Combo";

        public string Transaction_NO {
            get { return _transaction_no; }
            set {
                if (Transaction_NO != value)
                {
                    _transaction_no = value;
                    OnPropertyChanged("Transaction_NO");
                }
            }
        }

        public string Return_Status
        {
            get { return _return_status; }
            set
            {
                if (Return_Status != value)
                {
                    _return_status = value;
                    OnPropertyChanged("Return_Status");
                }
            }
        }

        public string TransMessage {
            get { return _trans_message; }
            set
            {
                if (TransMessage != value)
                {
                    _trans_message = value;
                    OnPropertyChanged("TransMessage");
                }
            }
        }

        public double TimeElapsed
        {
            get { return _time_elapsed; }
            set
            {
                if (TimeElapsed != value)
                {
                    _time_elapsed = value;
                    OnPropertyChanged("TimeElapsed");
                }
            }
        }

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
            var start = DateTime.Now;//请求开始时间
            try
            {
                //                string result = MicroPay.Run(ProductDescription, (Math.Floor(_totalPay * 100)).ToString(), Barcode);
                quickpayreturn =  MicroPay.Run(ProductDescription, (Math.Floor(_totalPay * 100)).ToString(), Barcode);
            }
            catch (WxPayException ex)
            {
                ShowMessage(ex.ToString());
            }
            catch(Exception ex)
            {
                ShowMessage(ex.ToString());
            }

            var end = DateTime.Now;//请求开始时间
            int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时
            TimeElapsed = timeCost / 1000.0;
            Transaction_NO = quickpayreturn.GetValue("transaction_id").ToString();
            TransMessage = "T_id: " + quickpayreturn.GetValue("transaction_id").ToString() + "; "
                            + "trade_no: " + quickpayreturn.GetValue("out_trade_no").ToString() + "; "
                            + "total: " + quickpayreturn.GetValue("total_fee").ToString() + "; ";
            Return_Status = quickpayreturn.GetValue("result_code").ToString();
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

        //public string GetTransNumber(WxPayData data)
        //{
        //    string result = string.Empty;

        //    foreach (KeyValuePair<string, object> pair in data)
        //    {
        //        if (pair.Key == "transaction_id")
        //        {
        //            result += pair.Key + " " + pair.Value.ToString() + ";";
        //        }
        //        if (pair.Key == "out_trade_no")
        //        {
        //            result += pair.Key + " " + pair.Value.ToString() + ";";
        //        }
        //        if (pair.Key == "total_fee")
        //        {
        //            result += pair.Key + " " + Convert.ToDouble(pair.Value.ToString()) / 100 + ";";
        //        }
        //    }
        //    return result;
        //}
    }
}
