// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 23/06/2019 @ 4:25 PM
// Last author: 
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoSuchCompany.FacebookMessages.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent ();
            MainPage = new MainWindow();
        }
    }
}