﻿using calculadora_ASA.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calculadora_ASA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaPrincipal();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
