﻿using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CoinCapDesktop.Infrastructure.Converters
{
    internal abstract class Converter : MarkupExtension, IValueConverter
    {

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                 => throw new NotSupportedException("Convert back is not supported!");
    }
}
