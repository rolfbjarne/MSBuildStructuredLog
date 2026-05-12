using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace StructuredLogViewer.Avalonia.Controls
{
    public class NodeIsSelectedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isSelected && isSelected)
            {
                // When selected, use the default foreground (theme-aware)
                return null;
            }

            return parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotSupportedException();
    }
}
