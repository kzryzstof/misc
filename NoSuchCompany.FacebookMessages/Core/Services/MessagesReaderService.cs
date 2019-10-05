// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 10:11 AM
// Last author: 
// ==========================================================================

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NoSuchCompany.Diagnostics;
using NoSuchCompany.FacebookMessages.Core.Data;

namespace NoSuchCompany.FacebookMessages.Core.Services
{
    #region Class

    public sealed class MessagesReaderService
    {
        #region Public Methods

        public static List<ConversationDto> LoadConversations(string path)
        {
            Argument.ThrowIfIsNullOrWhiteSpace(path, nameof(path));
            
            const string SearchPattern = "*.json";

            return Directory.GetFiles(path, SearchPattern, SearchOption.AllDirectories)
                .Select(file =>
                {
                    return JsonConvert.DeserializeObject<ConversationDto>(File.ReadAllText(file));
                })
                .ToList();
        }

        #endregion
    }

    #endregion
}