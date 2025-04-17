/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro String to Visibility Converter
 * This file defines a value converter for converting string values to visibility
 */

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SentinelVisionPro.Frontend.Converters
{
    /// <summary>
    /// Converts a string value to a Visibility value
    /// </summary>
    public class StringToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string value to a Visibility value
        /// </summary>
        /// <param name="value">The string value to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>Visibility.Visible if the string is not null or empty, otherwise Visibility.Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return !string.IsNullOrEmpty(stringValue) ? Visibility.Visible : Visibility.Collapsed;
            }
            
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a Visibility value to a string value
        /// </summary>
        /// <param name="value">The Visibility value to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>An empty string</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
} 