using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace calculadora_ASA.VIstaModelo
{
    public class VMpatron : BaseViewModel
    {
        #region VARIABLES
        private string _resultadoText;
        private string _operador;
        private double _primerNumero, _segundoNumero, _resultado;

        private bool _sumaSeleccionada;
        private bool _restaSeleccionada;
        private bool _multiplicacionSeleccionada;
        private bool _divisionSeleccionada;
        #endregion
        #region OBJETOS
        public bool SumaSeleccionada
        {
            get { return _sumaSeleccionada; }
            set { SetValue(ref _sumaSeleccionada, value); }
        }

        public bool RestaSeleccionada
        {
            get { return _restaSeleccionada; }
            set { SetValue(ref _restaSeleccionada, value); }
        }

        public bool MultiplicacionSeleccionada
        {
            get { return _multiplicacionSeleccionada; }
            set { SetValue(ref _multiplicacionSeleccionada, value); }
        }

        public bool DivisionSeleccionada
        {
            get { return _divisionSeleccionada; }
            set { SetValue(ref _divisionSeleccionada, value); }
        }

        public string ResultadoText 
        {
            get { return _resultadoText; }
            set { SetValue(ref _resultadoText, value); }
        }
        #endregion
        #region CONSTRUCTOR
        public VMpatron(INavigation navigation)
        {
            _resultadoText = string.Empty;


        }
        #endregion
        #region COMANDOS
        public ICommand ACCommand => new Command(BorrarACCommand);
        public ICommand OperatorCommand => new Command<string>(OperadorCommand);
        public ICommand ResultCommand => new Command(ResultadoCommand);
        //public ICommand DotCommand => new Command<string>(ExecutePuntoCommand);
        public ICommand UnoCommand => new Command(() => BotonCommand("1"));
        public ICommand DosCommand => new Command(() => BotonCommand("2"));
        public ICommand TresCommand => new Command(() => BotonCommand("3"));
        public ICommand CuatroCommand => new Command(() => BotonCommand("4"));
        public ICommand CincoCommand => new Command(() => BotonCommand("5"));
        public ICommand SeisCommand => new Command(() => BotonCommand("6"));
        public ICommand SieteCommand => new Command(() => BotonCommand("7"));
        public ICommand OchoCommand => new Command(() => BotonCommand("8"));
        public ICommand NueveCommand => new Command(() => BotonCommand("9"));
        public ICommand CeroCommand => new Command(() => BotonCommand("0"));

        public ICommand SumaCommand => new Command(() =>  OperadorCommand("+"));
        public ICommand RestaCommand => new Command(() => OperadorCommand("-"));
        public ICommand MultiplicacionCommand => new Command(() => OperadorCommand("*"));
        public ICommand DivisionCommand => new Command(() => OperadorCommand("/"));
        #endregion
        #region PROCESOS
        private void BotonCommand(string buttonText)
        {
            ResultadoText += buttonText;
        }

        private void BorrarACCommand()
        {
            ResultadoText = string.Empty;
            _operador = string.Empty;
            _primerNumero = 0;
            _segundoNumero = 0;
        }

        private void OperadorCommand(string operatorText )
        {
            if (!string.IsNullOrEmpty(ResultadoText) && double.TryParse(ResultadoText, out _primerNumero))
            {
                _operador = operatorText;
                ResultadoText = string.Empty;

                //si es igual se modifica el operador
                SumaSeleccionada = (_operador == "+");
                RestaSeleccionada = (_operador == "-");
                MultiplicacionSeleccionada = (_operador == "*");
                DivisionSeleccionada = (_operador == "/");
            }

        }

        private void ResultadoCommand()
        {
            if (!string.IsNullOrEmpty(ResultadoText) && double.TryParse(ResultadoText, out _segundoNumero))
            {
                switch (_operador)
                {
                    case "+":
                        _resultado = _primerNumero + _segundoNumero;
                        break;
                    case "-":
                        _resultado = _primerNumero - _segundoNumero;
                        break;
                    case "*":
                        _resultado = _primerNumero * _segundoNumero;
                        break;
                    case "/":
                        if (_segundoNumero != 0)
                        {
                            _resultado = _primerNumero / _segundoNumero;
                        }
                        else
                        {
                            ResultadoText = "Error";
                            return;
                        }
                        break;
                    default:
                        return;
                }
                ResultadoText = _resultado.ToString();
                _operador = string.Empty;
            }
            SumaSeleccionada = false;
            RestaSeleccionada = false;
            MultiplicacionSeleccionada = false;
            DivisionSeleccionada = false;
        }


        //private void ExecutePuntoCommand(string dotText)
        //{
        //    if (dotText == "." && ResultadoText.Contains("."))
        //        return;

        //    ResultadoText += dotText;
        //}
        #endregion
    }
}
