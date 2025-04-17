/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro System Event Model
 * This file defines the SystemEvent entity for the database
 */

using System;

namespace SentinelVisionPro.Backend.Models
{
    /// <summary>
    /// Represents a system event in the application
    /// </summary>
    public class SystemEvent
    {
        /// <summary>
        /// Gets or sets the unique identifier for the system event
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of system event
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the description of the system event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the event occurred
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the source of the system event
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the severity level of the system event
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Gets or sets additional data associated with the system event
        /// </summary>
        public string AdditionalData { get; set; }
    }
} 