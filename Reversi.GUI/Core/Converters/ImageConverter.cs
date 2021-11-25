using Reversi.Lib.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Reversi.GUI.Core.Converters
{
    [ValueConversion(typeof(Chip), typeof(string))]
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(Chip))
            {
                throw new Exception();
            }

            switch (value)
            {
                case Chip.Empty:
                    return (BitmapImage)Application.Current.FindResource("Empty");
                case Chip.White:
                    return (BitmapImage)Application.Current.FindResource("White");
                case Chip.Black:
                    return (BitmapImage)Application.Current.FindResource("Black");
                default:
                    return (BitmapImage)Application.Current.FindResource("Empty");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
