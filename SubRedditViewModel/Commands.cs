#region Information

// RandomRedditReviewer: SubRedditViewModel
// Created: 2016-07-31
// Modified: 2016-08-12 9:25 PM
#endregion

#region Using Directives
using GalaSoft.MvvmLight.CommandWpf;

#endregion

namespace Wcj
{
    public partial class SubRedditViewModel
    {
        #region  Fields
        private RelayCommand _getSubRedditsCommand;
        private RelayCommand _showInstructionsCommand;
        #endregion

        #region Properties
        /// <summary>
        ///     Get random Subreddits
        /// </summary>
        public RelayCommand GetSubRedditsCommand
            =>
                _getSubRedditsCommand ??
                (_getSubRedditsCommand =
                 new RelayCommand(async () => await GetSubRedditsAsync(), () => SubRedditsToGet > 0));

        /// <summary>
        ///     Launch instructions and credits
        /// </summary>
        public RelayCommand ShowInstructionsCommand
            =>
                _showInstructionsCommand ??
                (_showInstructionsCommand =
                 new RelayCommand(ShowInstructions));
        #endregion
    }
}