using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace CommonVisualLibraryMahApps.Window
{
    /// <summary>
    /// Логика взаимодействия для SelectTablesWindow.xaml
    /// </summary>
    public partial class ItemEditWindow : MetroWindow, INotifyPropertyChanged
    {
        public Boolean IsOK = false;

        private string _windowTitle;
        public String WindowTitle
        {
            get { return _windowTitle; }
            set { _windowTitle = value; SendPropertyChanged("WindowTitle"); }
        }

        private string _paramLabel;
        public String ParamLabel
        {
            get { return _paramLabel; }
            set { _paramLabel = value; SendPropertyChanged("ParamLabel"); }
        }
        private string _paramText;
        public String ParamText
        {
            get { return _paramText; }
            set { _paramText = value; SendPropertyChanged("ParamText"); }
        }

        private string _paramLabel2;
        public String ParamLabel2
        {
            get { return _paramLabel2; }
            set { _paramLabel2 = value; SendPropertyChanged("ParamLabel2"); }
        }
        private string _paramText2;
        public String ParamText2
        {
            get { return _paramText2; }
            set { _paramText2= value; SendPropertyChanged("ParamText2"); }
        }

        private bool _param2IsEnabled;
        public bool Param2IsEnabled
        {
            get { return _param2IsEnabled; }
            set { _param2IsEnabled = value; SendPropertyChanged("Param2IsEnabled"); }
        }
       

        public ItemEditWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            Edit1.Focus();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            IsOK = false;
            this.Close();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            IsOK = true;
            this.Close();
        }

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
