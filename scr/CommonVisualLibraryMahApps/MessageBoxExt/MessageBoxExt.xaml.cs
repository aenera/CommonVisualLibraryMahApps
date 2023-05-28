using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using CommonVisualLibraryMahApps.Annotations;
using CommonVisualLibraryMahApps.MessageBoxExt;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.SimpleChildWindow;

namespace Ext
{
	public partial class MessageBoxExt : MetroWindow, INotifyPropertyChanged
	{
	    public Boolean IsAutoCloseEnabled
	    {
	        get { return _isAutoCloseEnabled; }
	        set { _isAutoCloseEnabled = value;SendPropertyChanged("IsAutoCloseEnabled"); }
	    }
        public long AutoCloseInterval { get; set; }

        public MessageBoxResult Result { get; set; }

        private MessageBoxButton MessageBoxType { get; set; }

        public MessageBoxExt()
		{
			this.InitializeComponent();
			DataContext = this;

			IconIcon = false;
			Text = "Notification";
			IsAutoCloseEnabled = true;
			AutoCloseInterval = 5000;
		}
		public MessageBoxExt(string caption, string text, MessageExtType type, bool isAutohide = false, long autoHideInterval = 5000, string[] buttonNames = null)
		{
			this.InitializeComponent();
			DataContext = this;

			Caption = caption;
			Text = text;
			IsAutoCloseEnabled = isAutohide;
			AutoCloseInterval = autoHideInterval;
			//Buttons text
			if (buttonNames == null)
			{
				OkButtonText = "Ok";
				CancelButtonText = "Cancel";
			}
			else
			{
				if (buttonNames.Length > 0)
					OkButtonText = buttonNames[0];
				if (buttonNames.Length > 1)
					CancelButtonText = buttonNames[1];
			}
			switch (type)
			{
				case MessageExtType.Notification:
					OkButton = true;
					OkButtonGridPosition = 1;
					break;
				case MessageExtType.Confirmation:
					OkButton = true;
					OkButtonGridPosition = 2;
					CancelButton = true;
					CancelButtonGridPosition = 0;
					break;
			}
		}

		#region ------ Icon ------------
		private string _iconKind;
		public string IconKind
		{
			get { return _iconKind; }
			set { _iconKind = value; SendPropertyChanged("IconKind"); }
		}
		private bool _iconIcon;
		public bool IconIcon
		{
			get { return _iconIcon; }
			set { _iconIcon = value; SendPropertyChanged("IconIcon"); }
		}
		#endregion

		private string _caption;
		public string Caption
		{
			get { return _caption; }
			set { _caption = value; SendPropertyChanged("Caption"); }
		}
		private string _text;
		public string Text
		{
			get { return _text; }
			set { _text = value; SendPropertyChanged("Text"); }
		}

		#region ------ OKButton ------------
		private bool _okButton;
		public bool OkButton
		{
			get { return _okButton; }
			set { _okButton = value; SendPropertyChanged("OkButton"); }
		}
		private string _okButtonText;
		public string OkButtonText
		{
			get { return _okButtonText; }
			set { _okButtonText = value; SendPropertyChanged("OkButtonText"); }
		}
		private int _okButtonGridPosition;
		public int OkButtonGridPosition
		{
			get { return _okButtonGridPosition; }
			set { _okButtonGridPosition = value; SendPropertyChanged("OkButtonGridPosition"); }
		}

		#endregion
		#region ------ CancelButton --------
		private bool _cancelButton;
		public bool CancelButton
		{
			get { return _cancelButton; }
			set { _cancelButton = value; SendPropertyChanged("CancelButton"); }
		}
		private string _cancelButtonText;
		public string CancelButtonText
		{
			get { return _cancelButtonText; }
			set { _cancelButtonText = value; SendPropertyChanged("CancelButtonText"); }
		}
		private int _cancelButtonGridPosition;
	    private bool _isAutoCloseEnabled;

	    public int CancelButtonGridPosition
		{
			get { return _cancelButtonGridPosition; }
			set { _cancelButtonGridPosition = value; SendPropertyChanged("CancelButtonGridPosition"); }
		}
        #endregion



        public new static MessageBoxResult Show(string text)
        {
            var window = new MessageBoxExt()
            {
                Text = text,
                MessageBoxType = MessageBoxButton.OK
            };
            window.BtnOk.Focus();
            window.ShowDialog();
            return MessageBoxResult.OK;
        }
        public static MessageBoxResult Show(string text, string caption, bool autohide = false)
        {
            var window = new MessageBoxExt()
            {
                Text = text,
                Caption = caption,
                IsAutoCloseEnabled = autohide,
                MessageBoxType = MessageBoxButton.OK
            };
            window.BtnOk.Focus();
            window.ShowDialog();

            return MessageBoxResult.OK;
        }
        public new static MessageBoxResult Show(string text, string caption, MessageBoxButton buttons)
        {
            var window = new MessageBoxExt()
            {
                Text = text,
                Caption = caption,
            };
            window.BtnOk.Focus();
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    window.OkButton = true;
                    window.OkButtonGridPosition = 1;
                    window.OkButtonText = "OK";
                    window.MessageBoxType = MessageBoxButton.OK;
                    break;
                case MessageBoxButton.OKCancel:
                    window.OkButton = true;
                    window.OkButtonGridPosition = 2;
                    window.OkButtonText = "OK";
                    window.CancelButton = true;
                    window.CancelButtonGridPosition = 0;
                    window.CancelButtonText = "Cancel";
                    window.MessageBoxType = MessageBoxButton.OKCancel;
                    break;
                case MessageBoxButton.YesNo:
                    window.OkButton = true;
                    window.OkButtonGridPosition = 2;
                    window.OkButtonText = "Yes";
                    window.CancelButton = true;
                    window.CancelButtonGridPosition = 0;
                    window.CancelButtonText = "No";
                    window.MessageBoxType = MessageBoxButton.YesNo;
                    break;
            }

            window.ShowDialog();

            return window.Result;
        }
        public new static MessageBoxResult Show(string text, string caption, MessageBoxButton buttons, string[] buttonNames)
        {
            var window = new MessageBoxExt()
            {
                Text = text,
                Caption = caption,
            };
            window.BtnOk.Focus();
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    window.OkButton = true;
                    window.OkButtonGridPosition = 1;
                    window.OkButtonText = buttonNames.Length > 0 ? buttonNames[0] : "OK";
                    window.MessageBoxType = MessageBoxButton.OK;
                    break;
                case MessageBoxButton.OKCancel:
                    window.OkButton = true;
                    window.OkButtonGridPosition = 2;
                    window.OkButtonText = buttonNames.Length > 0 ? buttonNames[0] : "OK";
                    window.CancelButton = true;
                    window.CancelButtonGridPosition = 0;
                    window.CancelButtonText = buttonNames.Length > 1 ? buttonNames[1] : "Cancel";
                    window.MessageBoxType = MessageBoxButton.OKCancel;
                    break;
                case MessageBoxButton.YesNo:
                    window.OkButton = true;
                    window.OkButtonGridPosition = 2;
                    window.OkButtonText = buttonNames.Length > 0 ? buttonNames[0] : "Yes";
                    window.CancelButton = true;
                    window.CancelButtonGridPosition = 0;
                    window.CancelButtonText = buttonNames.Length > 1 ? buttonNames[1] : "No";
                    window.MessageBoxType = MessageBoxButton.YesNo;
                    break;
            }

            window.ShowDialog();

            return window.Result;
        }

        #region --------------------- Commands ---------------------
        private void OkCommand_OnClick(object sender, RoutedEventArgs e)
		{
            if (MessageBoxType == MessageBoxButton.OK || MessageBoxType == MessageBoxButton.OKCancel)
                Result =  MessageBoxResult.OK;
		    if (MessageBoxType == MessageBoxButton.YesNo || MessageBoxType == MessageBoxButton.YesNoCancel)
		        Result = MessageBoxResult.Yes;
			this.Close();
		}

		private void CancelCommand_OnClick(object sender, RoutedEventArgs e)
		{
		    if (MessageBoxType == MessageBoxButton.OK || MessageBoxType == MessageBoxButton.OKCancel)
		        Result = MessageBoxResult.Cancel;
		    if (MessageBoxType == MessageBoxButton.YesNo || MessageBoxType == MessageBoxButton.YesNoCancel)
		        Result = MessageBoxResult.No;
			this.Close();
		}
		#endregion

		#region ------------------ Notification ------------------
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

	    private void MessageBoxExt_OnPreviewKeyDown(object sender, KeyEventArgs e)
	    {
	        if (e.Key == Key.Enter)
	            OkCommand_OnClick(this, new RoutedEventArgs());
	        if (e.Key == Key.Escape)
	            CancelCommand_OnClick(this, new RoutedEventArgs());
        }
    }
}