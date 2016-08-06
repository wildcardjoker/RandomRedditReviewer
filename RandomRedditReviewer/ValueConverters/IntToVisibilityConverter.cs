#region Information

// RandomRedditReviewer: RandomRedditReviewer
// Created: 2016-08-06
// Modified: 2016-08-06 8:58 PM
#endregion

#region Using Directives
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#endregion

namespace Wcj.ValueConverters
{
    /// <summary>
    ///     Set Visibility to True if value > 0
    /// </summary>
    class IntToVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (int) value == 0 ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}