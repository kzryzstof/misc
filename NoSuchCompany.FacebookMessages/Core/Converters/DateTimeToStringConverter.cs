// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 12:28 PM
// Last author: 
// ==========================================================================

using System;
using System.Globalization;
using Xamarin.Forms;

namespace NoSuchCompany.FacebookMessages.Core.Converters
{
    #region Class

    public sealed class DateTimeToStringConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime) value;

            return dateTime.ToLocalTime().ToString("D");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion
}