// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 11:31 AM
// Last author: 
// ==========================================================================

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NoSuchCompany.Diagnostics;
using NoSuchCompany.FacebookMessages.Core.Annotations;
using NoSuchCompany.FacebookMessages.Core.Data;

namespace NoSuchCompany.FacebookMessages.Core.ViewModels
{
    #region Class

    public sealed class MessageViewModel : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Indicates whether the message has been written by the owner.
        /// </summary>
        public bool IsFromOwner { get; }

        public string Message { get; }

        public string BlockMessage
        {
            get => $"{Sender} ({Timestamp.ToLocalTime():t}){Environment.NewLine}{Environment.NewLine}{Message}";
        }

        
        public string Sender { get; }

        public DateTime Timestamp { get; }

        #endregion

        #region Events and Delegates

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        /// <param name="messageDto"></param>
        /// <param name="owner"></param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if:
        /// - The <paramref name="messageDto" /> instance is not specified.
        /// - The <paramref name="owner" /> instance is not specified.
        /// </exception>
        public MessageViewModel(MessageDto messageDto, string owner)
        {
            Argument.ThrowIfIsNull(messageDto, nameof(messageDto));
            Argument.ThrowIfIsNullOrWhiteSpace(owner, nameof(owner));

            Timestamp = DateTimeExtensions.FromMilliseconds(messageDto.TimestampMs);

            Sender = messageDto.SenderName.DecodeFromUtf8();
            IsFromOwner = string.Equals(Sender, owner, StringComparison.CurrentCultureIgnoreCase);

            Message = messageDto.Content.DecodeFromUtf8();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Indicates whether the specified <paramref name="text" /> is found in the message.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool Contains(string text)
        {
            return Message.Contains(text);
        }

        #endregion

        #region Private Methods

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    #endregion
}