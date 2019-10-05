// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 05/10/2019 @ 11:29 AM
// Last author: 
// ==========================================================================

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using NoSuchCompany.Diagnostics;
using NoSuchCompany.FacebookMessages.Core.Annotations;
using NoSuchCompany.FacebookMessages.Core.Data;
using Xamarin.Forms.Internals;

namespace NoSuchCompany.FacebookMessages.Core.ViewModels
{
    #region Class

    public sealed class ConversationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _summary;

        #endregion

        #region Properties

        public int Id { get; }

        /// <summary>
        /// Gets all the messages from the oldest one to the most recent.
        /// </summary>
        public ObservableCollection<MessageViewModel> Messages { get; }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<DailyMessageViewModel> GroupedMessages { get; }
        
        /// <summary>
        /// Gets the most recent message found in the conversation.
        /// </summary>
        public MessageViewModel MostRecentMessage => Messages.LastOrDefault();

        /// <summary>
        /// Gets the oldest message found in the conversation.
        /// </summary>
        public MessageViewModel OldestMessage => Messages.FirstOrDefault();

        /// <summary>
        /// Gets a summary of the conversation.
        /// </summary>
        public string Summary
        {
            get => _summary;
            set
            {
                if (_summary == value)
                    return;

                _summary = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Events and Delegates

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conversationDto"></param>
        /// <param name="owner"></param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if:
        /// - The <paramref name="conversationDto" /> instance is not specified.
        /// - The <paramref name="owner" /> instance is not specified.
        /// </exception>
        public ConversationViewModel(int id, ConversationDto conversationDto, string owner)
        {
            Argument.ThrowIfIsNull(conversationDto, nameof(conversationDto));
            Argument.ThrowIfIsNullOrWhiteSpace(owner, nameof(owner));

            Id = id;
            ConversationDto conversationDto1 = conversationDto;

            Messages = new ObservableCollection<MessageViewModel>();

            conversationDto.Messages
                .Where(m => false == string.IsNullOrWhiteSpace(m.Content))
                .OrderBy(m => m.TimestampMs)
                .ToList()
                .ForEach(m => Messages.Add(new MessageViewModel(m, owner)));

            if (Messages.Any())
                Summary = $"[{id:##0}] {conversationDto1.Title} - {OldestMessage.Timestamp.ToLocalTime():f} - {MostRecentMessage.Timestamp.ToLocalTime():f}";
            else
                Summary = $"[{id:##0}] {conversationDto1.Title} - No messages";
            
            //    Builds the list of grouped messages.
            GroupedMessages = new ObservableCollection<DailyMessageViewModel>(Messages.GroupBy(
                                                                                  p => p.Timestamp.Date,
                                                                                  p => p,
                                                                                  (key, g) =>
                                                                                  {
                                                                                      var dailyMessageViewModel = new DailyMessageViewModel {Date = key};
                                                                                      g.ForEach(dailyMessageViewModel.Add);
                                                                                      return dailyMessageViewModel;
                                                                                  }));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Indicates whether the specified <paramref name="text" /> is found in the conversation.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool Contains(string text)
        {
            return Messages.Any(messageViewModel => messageViewModel.Contains(text));
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