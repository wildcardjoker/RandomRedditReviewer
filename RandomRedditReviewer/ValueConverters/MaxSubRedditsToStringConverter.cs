#region Information

// RandomRedditReviewer: RandomRedditReviewer
// Created: 2016-08-06
// Modified: 2016-08-06 8:58 PM
#endregion

#region Using Directives
using System;
using System.Globalization;
using System.Windows.Data;

#endregion

namespace Wcj.ValueConverters
{
    internal class MaxSubRedditsToStringConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => $"Number of subReddits to retrieve (maximum {value}):";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}