// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 10:32 AM
// Last author: 
// ==========================================================================

using Newtonsoft.Json;

namespace NoSuchCompany.FacebookMessages.Core.Data
{
    #region Class

    [JsonObject(MemberSerialization.OptIn)]
    public sealed class MessageDto
    {
        #region Properties

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "sender_name")]
        public string SenderName { get; set; }

        [JsonProperty(PropertyName = "timestamp_ms")]
        public ulong TimestampMs { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        #endregion
    }

    #endregion
}