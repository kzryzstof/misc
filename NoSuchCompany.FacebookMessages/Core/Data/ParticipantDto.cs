// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 24/06/2019 @ 8:45 AM
// Last author: 
// ==========================================================================

using Newtonsoft.Json;

namespace NoSuchCompany.FacebookMessages.Core.Data
{
    #region Class

    [JsonObject(MemberSerialization.OptIn)]
    public sealed class ParticipantDto
    {
        #region Properties

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }

    #endregion
}