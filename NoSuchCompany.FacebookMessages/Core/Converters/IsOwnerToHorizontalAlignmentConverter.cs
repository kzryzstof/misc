// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 11:59 AM
// Last author: 
// ==========================================================================

using System;
using System.Globalization;
using NoSuchCompany.FacebookMessages.Core.ViewModels;
using Xamarin.Forms;

namespace NoSuchCompany.FacebookMessages.Core.Converters
{
    #region Class

    public class IsOwnerToHorizontalAlignmentConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var messageViewModel = value as MessageViewModel;

            if (messageViewModel is null)
                return TextAlignment.Start;

            return messageViewModel.IsFromOwner ? TextAlignment.End : TextAlignment.Start;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion
}