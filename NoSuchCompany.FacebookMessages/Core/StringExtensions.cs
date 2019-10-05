// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 11:04 AM
// Last author: 
// ==========================================================================

using System.Text;

namespace NoSuchCompany.FacebookMessages.Core
{
    #region Class

    public static class StringExtensions
    {
        #region Public Methods

        public static string DecodeFromUtf8(this string utf8String)
        {
            // copy the string as UTF-8 bytes.
            var utf8Bytes = new byte[utf8String.Length];
            
            for (var i = 0; i < utf8String.Length; ++i) //Debug.Assert( 0 <= utf8String[i] && utf8String[i] <= 255, "the char must be in byte's range");
                utf8Bytes[i] = (byte) utf8String[i];

            return Encoding.UTF8.GetString(utf8Bytes, 0, utf8Bytes.Length);
        }

        #endregion
    }

    #endregion
}