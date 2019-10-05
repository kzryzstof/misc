// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 12:10 PM
// Last author: 
// ==========================================================================

using System;
using System.Collections.ObjectModel;

namespace NoSuchCompany.FacebookMessages.Core.ViewModels
{
    #region Class

    public sealed class DailyMessageViewModel : ObservableCollection<MessageViewModel>
    {
        #region Properties

        public DateTime Date { get; set; }

        public ObservableCollection<MessageViewModel> Messages => this;

        #endregion
    }

    #endregion
}