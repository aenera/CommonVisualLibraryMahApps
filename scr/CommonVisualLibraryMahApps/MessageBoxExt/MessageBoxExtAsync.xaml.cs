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
		public partial class MessageBoxExtAsync : ChildWindow, INotifyPropertyChanged
		{
			public MessageBoxExtAsync()
			{
				this.InitializeComponent();
				DataContext = this;

				IconIcon = false;
				Text = "Notification";
				IsAutoCloseEnabled = true;
				AutoCloseInterval = 5000;
			}
			public MessageBoxExtAsync(string caption, string text, MessageExtType type, bool isAutohide = false, long autoHideInterval = 5000, string[] buttonNames = null)
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
		public int CancelButtonGridPosition
		{
			get { return _cancelButtonGridPosition; }
			set { _cancelButtonGridPosition = value; SendPropertyChanged("CancelButtonGridPosition"); }
		}
        #endregion


        #region --------------------- Commands ---------------------
        private void OkCommand_OnClick(object sender, RoutedEventArgs e)
		{
			this.Close(true);
		}

		private void CancelCommand_OnClick(object sender, RoutedEventArgs e)
		{
			this.Close(false);
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

	}

}