#region Information

// RandomRedditReviewer: SubRedditViewModel
// Created: 2016-07-31
// Modified: 2016-08-06 9:29 PM
#endregion

#region Using Directives
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SubRedditViewModel.Annotations;

#endregion

namespace Wcj
{
    public partial class SubRedditViewModel : INotifyPropertyChanged
    {
        #region Constructors
        /// <summary>
        ///     Default constructor - set number of subreddits to 10
        /// </summary>
        public SubRedditViewModel() : this(10) {}

        /// <summary>
        ///     Specify the number of subreddits to retrieve.
        /// </summary>
        /// <param name="subs">Number of subreddits to retrieve.</param>
        public SubRedditViewModel(int subs)
        {
            SubRedditsToGet = subs;
            SubReddits = new ObservableCollection<SubReddit>();
            Status = "Ready";
            NsfwPreference = NsfwPreference.No;
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}