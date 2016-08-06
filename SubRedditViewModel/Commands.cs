#region Information

// RandomRedditReviewer: SubRedditViewModel
// Created: 2016-07-31
// Modified: 2016-08-06 9:28 PM
#endregion

#region Using Directives
using GalaSoft.MvvmLight.CommandWpf;

#endregion

namespace Wcj
{
    public partial class SubRedditViewModel
    {
        #region Properties
        /// <summary>
        ///     Get random Subreddits
        /// </summary>
        public RelayCommand GetSubRedditsCommand
            =>
                _getSubRedditsCommand ??
                (_getSubRedditsCommand =
                 new RelayCommand(async () => await GetSubRedditsAsync(), () => SubRedditsToGet > 0));
        #endregion
    }
}