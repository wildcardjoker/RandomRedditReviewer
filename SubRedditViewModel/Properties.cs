#region Information

// RandomRedditReviewer: SubRedditViewModel
// Created: 2016-07-31
// Modified: 2016-08-06 9:28 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight.CommandWpf;

#endregion

namespace Wcj
{
    /// <summary>
    ///     Determines whether NSFW subreddits are included.
    /// </summary>
    public enum NsfwPreference
    {
        /// <summary>
        ///     Do not include NSFW subreddits
        /// </summary>
        [Description("No NSFW")]
        No,

        /// <summary>
        ///     Include both SFW and NSFW subreddits
        /// </summary>
        [Description("Include NSFW")]
        Include,

        /// <summary>
        ///     Only get NSFW subreddits
        /// </summary>
        [Description("NSFW Only")]
        NsfwOnly
    }

    public partial class SubRedditViewModel
    {
        #region  Fields
        private const string RandomSfw = "https://www.reddit.com/r/random";
        private const string RandomNsfw = "http://www.reddit.com/r/randnsfw";
        private static readonly Random _random = new Random();
        private RelayCommand _getSubRedditsCommand;
        private NsfwPreference _nsfwPreference;
        private string _status;
        private int _subRedditCount;
        private ObservableCollection<SubReddit> _subReddits;
        private int _subRedditsToGet;
        #endregion

        #region Properties
        /// <summary>
        ///     Maximum number of subreddits to retrieve per run. We don't want to overwhelm Reddit!
        /// </summary>
        public int MaxSubReddits { get; } = 50;

        /// <summary>
        ///     NSFW options
        /// </summary>
        public List<string> NsfwOptions
            => Enum.GetNames(typeof (NsfwPreference)).ToList();

        /// <summary>
        ///     Indicates whether NSFW subreddits should be included, and whether they should be mixed with standard subreddits.
        /// </summary>
        public NsfwPreference NsfwPreference
        {
            get { return _nsfwPreference; }
            set
            {
                if (value == _nsfwPreference)
                {
                    return;
                }
                _nsfwPreference = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Status message.
        /// </summary>
        public string Status
        {
            get { return _status; }
            set
            {
                if (value == _status)
                {
                    return;
                }
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        /// <summary>
        ///     Number of Subreddits collected.
        /// </summary>
        public int SubRedditCount
        {
            get { return _subRedditCount; }
            set
            {
                if (value == _subRedditCount)
                {
                    return;
                }
                _subRedditCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Collection of Subreddits.
        /// </summary>
        public ObservableCollection<SubReddit> SubReddits
        {
            get { return _subReddits; }
            set
            {
                if (Equals(value, _subReddits))
                {
                    return;
                }
                _subReddits = value;
                OnPropertyChanged(nameof(SubReddits));
            }
        }

        /// <summary>
        ///     Number of subreddits to retrieve.
        /// </summary>
        public int SubRedditsToGet
        {
            get { return _subRedditsToGet; }
            set
            {
                _subRedditsToGet = value;
                OnPropertyChanged(nameof(SubRedditsToGet));
            }
        }
        #endregion
    }
}