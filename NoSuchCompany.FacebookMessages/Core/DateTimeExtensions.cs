// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 10:31 AM
// Last author: 
// ==========================================================================

using System;

namespace NoSuchCompany.FacebookMessages.Core
{
    #region Class

    public static class DateTimeExtensions
    {
        #region Fields

        private static readonly DateTime FacebookMinDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds a new instance of <see cref="DateTime" /> by adding the specified number of milliseconds
        /// elapsed since January the 1st of 1970 (UTC).
        /// </summary>
        /// <param name="timestampMs"></param>
        /// <returns></returns>
        public static DateTime FromMilliseconds(ulong timestampMs)
        {
            TimeSpan elapsedTimeSince1970 = TimeSpan.FromMilliseconds(timestampMs);
            return FacebookMinDateUtc.Add(elapsedTimeSince1970);
        }

        #endregion
    }

    #endregion
}