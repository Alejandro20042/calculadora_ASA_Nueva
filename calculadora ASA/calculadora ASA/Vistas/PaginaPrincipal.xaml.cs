using calculadora_ASA.VIstaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calculadora_ASA.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        
        public PaginaPrincipal()
        {
            InitializeComponent();
            BindingContext = new VMpatron(Navigation);
        }


    }
}