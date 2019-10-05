// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 23/06/2019 @ 9:21 AM
// Last author: 
// ==========================================================================

using Xamarin.Forms;

namespace NoSuchCompany.FacebookMessages.Core
{
    #region Class

    public class App : Application
    {
        public App()
        {
            InitializeComponent();
 
            MainPage = new AppShell();
        }
    }

    #endregion
}