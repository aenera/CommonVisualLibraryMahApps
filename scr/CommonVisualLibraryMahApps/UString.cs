using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommonVisualLibraryMahApps.Annotations;

namespace CommonVisualLibraryMahApps
{
    public class UString : INotifyPropertyChanged
    {
        private Guid _id;
        private Guid ID 
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }

        private string _str;
        public string Str
        {
            get => _str;
            set { _str = value; OnPropertyChanged(nameof(Str)); }
        }

        public override string ToString()
        {
            return Str;
        }

        public UString(string s)
        {
            Str = s;
            ID = Guid.NewGuid();
        }

        #region --------------------- Notification -----------------
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
