/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Boolean to Visibility Converter
 * This file defines a value converter for converting boolean values to visibility
 */

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SentinelVisionPro.Frontend.Converters
{
    /// <summary>
    /// Converts a boolean value to a Visibility value
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a Visibility value
        /// </summary>
        /// <param name="value">The boolean value to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>Visibility.Visible if the value is true, otherwise Visibility.Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a Visibility value to a boolean value
        /// </summary>
        /// <param name="value">The Visibility value to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>True if the value is Visibility.Visible, otherwise false</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }
            
            return false;
        }
    }
} 