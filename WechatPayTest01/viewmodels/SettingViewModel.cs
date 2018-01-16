using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatPayTest01.lib;

namespace WechatPayTest01.viewmodels
{
    public class SettingViewModel: INotifyPropertyChanged
    {
        string _quickpay_url;
        string _cancelpay_url;
        string _queryorder_url;
        string _refund_url;
        string _queryrefund_url;
        string _downloadbills_url;
        string _terminalip;
        string _publicaccountid;
        string _venderid;
        string _key;
        string _appsecred;
        public SettingViewModel()
        {
            _quickpay_url = "https://api.mch.weixin.qq.com/sandboxnew/pay/micropay";
            _cancelpay_url = "https://api.mch.weixin.qq.com/sandboxnew/secapi/pay/reverse";
            _queryorder_url = "https://api.mch.weixin.qq.com/sandboxnew/pay/orderquery";
            _refund_url = "https://api.mch.weixin.qq.com/secapi/sandboxnew/pay/refund";
            _queryrefund_url = "https://api.mch.weixin.qq.com/sandboxnew/pay/refundquery";
            _downloadbills_url = "https://api.mch.weixin.qq.com/sandboxnew/pay/downloadbill";
            _terminalip = "8:8:8:8";
            _publicaccountid = "wxc2e6b1921daecd4c";
            _venderid = "1275324601";
                        _key = "AS9667881316628796815000200067SH"; 
          //  _key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456";
            _appsecred = "23c6d75af74281c4dd9371d1cdcdc16d";
        }

        public void Set_Urls()
        {
            WxPayApi.URL_QuickPay = _quickpay_url;
            WxPayApi.URL_DownloadBills = _downloadbills_url;
            WxPayApi.URL_OrderQuery = _queryorder_url;
            WxPayApi.URL_Refund = _refund_url;
            WxPayApi.URL_RefundQuery = _queryrefund_url;
            WxPayApi.KEY = _key;
            WxPayApi.App_Secred = _appsecred;
            WxPayApi.Vender_ID = _venderid;
            WxPayApi.Public_Account_ID = _publicaccountid;
            WxPayApi.Terminal_IP = _terminalip;
        }

        public string KEY
        {
            get { return _key; }
            set
            {
                if (KEY != value)
                {
                    _key = value;
                    OnPropertyChanged("KEY");
                }
            }
        }

        public string AppSecred
        {
            get { return _appsecred; }
            set
            {
                if (AppSecred != value)
                {
                    _appsecred = value;
                    OnPropertyChanged("AppSecred");
                }
            }
        }

        public string VenderID
        {
            get { return _venderid; }
            set
            {
                if (VenderID != value)
                {
                    _venderid = value;
                    OnPropertyChanged("VenderID");
                }
            }
        }

        public string PublicAccountTD
        {
            get { return _publicaccountid; }
            set
            {
                if (PublicAccountTD != value)
                {
                    _publicaccountid = value;
                    OnPropertyChanged("PublicAccountTD");
                }
            }
        }

        public string Terminal_IP
        {
            get { return _terminalip; }
            set
            {
                if (Terminal_IP != value)
                {
                    _terminalip = value;
                    OnPropertyChanged("Terminal_IP");
                }
            }
        }

        public string DownloadBills_URL
        {
            get { return _downloadbills_url; }
            set
            {
                if (DownloadBills_URL != value)
                {
                    _downloadbills_url = value;
                    WxPayApi.URL_DownloadBills = value; ;
                    OnPropertyChanged("DownloadBills_URL");
                }
            }
        }

        public string QueryRefund_URL
        {
            get { return _queryrefund_url; }
            set
            {
                if (Refund_URL != value)
                {
                    _queryrefund_url = value;
                    WxPayApi.URL_RefundQuery = value;
                    OnPropertyChanged("QueryRefund_URL");
                }
            }
        }

        public string Refund_URL
        {
            get { return _refund_url; }
            set
            {
                if (Refund_URL != value)
                {
                    _refund_url = value;
                    WxPayApi.URL_Refund = _refund_url;
                    OnPropertyChanged("Refund_URL");
                }
            }
        }

        public string QueryOrder_URL
        {
            get { return _queryorder_url; }
            set
            {
                if (QueryOrder_URL != value)
                {
                    _queryorder_url = value;
                    WxPayApi.URL_OrderQuery = _queryorder_url;
                    OnPropertyChanged("QueryOrder_URL");
                }
            }
        }

        public string CancelPay_URL
        {
            get { return _cancelpay_url; }
            set
            {
                if (CancelPay_URL != value)
                {
                    _cancelpay_url = value;
                    WxPayApi.URL_CancelPay = value;
                    OnPropertyChanged("CancelPay_URL");
                }
            }
        }

        public string QuickPay_URL
        {
            get { return _quickpay_url; }
            set
            {
                if (QuickPay_URL != value)
                {
                    _quickpay_url = value;
                    WxPayApi.URL_QuickPay = _quickpay_url;
                    OnPropertyChanged("QuickPay_URL");
                }
            }
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
