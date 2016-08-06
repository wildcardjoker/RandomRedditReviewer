#region Information

// RandomRedditReviewer: RandomRedditReviewer
// Created: 2016-08-06
// Modified: 2016-08-06 9:27 PM
#endregion

#region Using Directives
using System;
using System.Globalization;
using System.Windows.Data;
using Humanizer;

#endregion

namespace Wcj.ValueConverters
{
    class NsfwOptionsToStringConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((NsfwPreference) Enum.Parse(typeof (NsfwPreference), (string) value)).Humanize();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof (NsfwPreference), ((string) value).Dehumanize());
        }
        #endregion
    }
}