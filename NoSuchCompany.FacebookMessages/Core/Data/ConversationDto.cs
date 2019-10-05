// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 10:32 AM
// Last author: 
// ==========================================================================

using System.Collections.Generic;
using Newtonsoft.Json;

namespace NoSuchCompany.FacebookMessages.Core.Data
{
    #region Class

    [JsonObject(MemberSerialization.OptIn)]
    public sealed class ConversationDto
    {
        #region Properties

        [JsonProperty(PropertyName = "is_still_participant")]
        public bool IsStillParticipant { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<MessageDto> Messages { get; set; }

        [JsonProperty(PropertyName = "participants")]
        public List<ParticipantDto> Participants { get; set; }

        [JsonProperty(PropertyName = "thread_path")]
        public string ThreadPath { get; set; }

        [JsonProperty(PropertyName = "thread_type")]
        public string ThreadType { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        #endregion
    }

    #endregion
}