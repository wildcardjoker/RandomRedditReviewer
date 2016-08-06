#region Information

// RandomRedditReviewer: SubReddit
// Created: 2016-07-31
// Modified: 2016-08-06 8:57 PM
#endregion

#region Using Directives
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.CommandWpf;
using Wcj.Annotations;

#endregion

namespace Wcj
{
    /// <summary>
    ///     Describes Name and address of a Subreddit
    /// </summary>
    public class SubReddit : INotifyPropertyChanged
    {
        #region  Fields
        private string _hyperlink;
        private string _name;
        private RelayCommand _navigateToSubRedditCommand;
        #endregion

        #region Constructors
        /// <summary>
        ///     Generate a new Subreddit
        /// </summary>
        /// <param name="name">The title of the Subreddit</param>
        /// <param name="link">The address of the Subreddit</param>
        public SubReddit(string name, string link)
        {
            Name = name;
            Hyperlink = link;
        }

        /// <summary>
        ///     Generate a new Subreddit
        /// </summary>
        /// <param name="address">The Uri of the Subreddit</param>
        public SubReddit(Uri address)
        {
            Name = address.AbsolutePath;
            Hyperlink = address.AbsoluteUri;
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void NavigateToSubReddit()
        {
            if (Hyperlink != null)
            {
                Process.Start(Hyperlink);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     the web site address of the Subreddit
        /// </summary>

        #region Properties
        public string Hyperlink
        {
            get { return _hyperlink; }
            set
            {
                if (Equals(value, _hyperlink))
                {
                    return;
                }
                _hyperlink = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     The name of the Subreddit
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Navigate to the selected Subreddit in the user's default browser
        /// </summary>
        public RelayCommand NavigateToSubRedditCommand
            => _navigateToSubRedditCommand ?? (_navigateToSubRedditCommand = new RelayCommand(NavigateToSubReddit));
        #endregion
    }
}