using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerMVVM.ViewModels
{
    public class CambioDivisasViewModel : INotifyPropertyChanged
    {
        private string _valorDolares;
        private string _valorEuros;

        public string ValorDolares
        {
            get => _valorDolares;
            set{ 
                if (value != _valorDolares)
                {
                    _valorDolares = value;
                    OnPropertyChanged();
                    ConvierteDeDolaresAEuros();
                }
            }
        }

        public string ValorEuros
        {
            get => _valorEuros;
            set
            {
                if (value != _valorEuros)
                {
                    _valorEuros = value;
                    OnPropertyChanged();
                }
            }
        }
        public void ConvierteDeDolaresAEuros()
        {
            try
            {
                double cambio = Double.Parse(ValorDolares) * 0.93;
                ValorEuros = $"{cambio:F2}";
            }
            catch (Exception) 
            {
                ValorEuros = "Valor Incorrecto";  
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
