using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Shared
{
    public class LoanPeriod : INotifyPropertyChanged
    {
        public LoanPeriod(int _index, int _period)
        {
            Index = _index;
            Period = _period;
        }

        private int index;
        private int period;



        public int Index
        {
            get { return index; }
            set { SetField(ref index, value); }
        }
        public int Period
        {
            get { return period; }
            set { SetField(ref period, value); }
        }



        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
