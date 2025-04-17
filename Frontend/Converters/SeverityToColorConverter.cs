/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Severity to Color Converter
 * This file defines a value converter for converting threat severity levels to colors
 */

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SentinelVisionPro.Frontend.Converters
{
    /// <summary>
    /// Converts a threat severity level to a color value
    /// </summary>
    public class SeverityToColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a severity level to a color
        /// </summary>
        /// <param name="value">The severity level to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>A SolidColorBrush representing the severity level</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string severity)
            {
                return severity.ToLower() switch
                {
                    "critical" => new SolidColorBrush(Colors.Red),
                    "high" => new SolidColorBrush(Colors.OrangeRed),
                    "medium" => new SolidColorBrush(Colors.Orange),
                    "low" => new SolidColorBrush(Colors.Yellow),
                    _ => new SolidColorBrush(Colors.Gray)
                };
            }
            
            return new SolidColorBrush(Colors.Gray);
        }

        /// <summary>
        /// Converts a color back to a severity level
        /// </summary>
        /// <param name="value">The color to convert</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The converter parameter</param>
        /// <param name="culture">The culture to use for the conversion</param>
        /// <returns>The severity level string</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return brush.Color switch
                {
                    { R: 255, G: 0, B: 0 } => "Critical",
                    { R: 255, G: 69, B: 0 } => "High",
                    { R: 255, G: 165, B: 0 } => "Medium",
                    { R: 255, G: 255, B: 0 } => "Low",
                    _ => "Unknown"
                };
            }
            
            return "Unknown";
        }
    }
} 