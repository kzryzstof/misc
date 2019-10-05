// ==========================================================================
// Copyright (C) 2019 by NoSuch Company.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// 
// Last change: 18/08/2019 @ 4:59 PM
// Last author: 
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using NoSuchCompany.Diagnostics;
using NoSuchCompany.FacebookMessages.Core.Annotations;
using NoSuchCompany.FacebookMessages.Core.Data;
using NoSuchCompany.FacebookMessages.Core.Services;
using Xamarin.Forms.Internals;

namespace NoSuchCompany.FacebookMessages.Core.ViewModels
{
    #region Class

    /// <summary>
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private List<ConversationDto> _conversations;

        #endregion

        #region Properties

        public ObservableCollection<ConversationViewModel> Conversations { get; }

        private ConversationViewModel _selectedConversation;
        
        public ConversationViewModel SelectedConversation
        {
            get => _selectedConversation;
            set
            {
                if (ReferenceEquals(_selectedConversation, value))
                    return;

                _selectedConversation = value;
                OnPropertyChanged();
            }
        } 
        #endregion

        #region Events and Delegates

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            Conversations = new ObservableCollection<ConversationViewModel>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads all the conversations found in the given <paramref name="path" />.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="owner"></param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if:
        /// - The <paramref name="path"/> is not specified.
        /// - The <paramref name="owner"/> is not specified.
        /// </exception>
        public void LoadConversations(string path, string owner)
        {
            Argument.ThrowIfIsNullOrWhiteSpace(path, nameof(path));
            Argument.ThrowIfIsNullOrWhiteSpace(owner, nameof(owner));
            
            _conversations = MessagesReaderService.LoadConversations(path);

            //  Builds and sorts the view-models.
            var conversationId = 0;
            var conversationViewModels = new List<ConversationViewModel>();
            
            _conversations.ForEach(c =>
            {
                conversationId++;
                conversationViewModels.Add(new ConversationViewModel(conversationId, c, owner));
            });
            
            //  Fills the list.
            Conversations.Clear();
            conversationViewModels.Where(c => c.Messages.Any()).OrderByDescending(c => c.MostRecentMessage.Timestamp).ForEach(Conversations.Add);
        }

        #endregion

        #region Protected Methods

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    #endregion
}