// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 24/06/2019 @ 9:25 AM
// Last author: 
// ==========================================================================

using NoSuchCompany.FacebookMessages.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoSuchCompany.FacebookMessages.Core
{
    #region Class

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainWindow
    {
        #region Properties

        public MainWindowViewModel ViewModel { get; }

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            BindingContext = ViewModel = new MainWindowViewModel();
            
            const string Path = "/Users/christophe/nosuch-company/NoSuchCompany.FacebookMessages/Data/facebook-christophecommeyne_1/messages/inbox";
            ViewModel.LoadConversations(Path, "Christophe Commeyne");
        }

        #endregion

        
    }

    #endregion
}