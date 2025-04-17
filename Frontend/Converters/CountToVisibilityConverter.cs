/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Count to Visibility Converter
 * This file defines a value converter for converting count values to visibility
 */

using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SentinelVisionPro.Frontend.Converters
{
    /// <summary>
    /// Converts a count value to a Visibility value
    /// </summary>
    public class CountToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a count value to a Visibility value
        /// </summary>
        /// <param name="value">The count value to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>Visibility.Visible if the count is greater than 0, otherwise Visibility.Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            
            if (value is ICollection collection)
            {
                return collection.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a Visibility value to a count value
        /// </summary>
        /// <param name="value">The Visibility value to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>1 if the value is Visibility.Visible, otherwise 0</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible ? 1 : 0;
            }
            
            return 0;
        }
    }
} 