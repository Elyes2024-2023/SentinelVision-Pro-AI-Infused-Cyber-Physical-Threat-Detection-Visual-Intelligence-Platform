/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Threat Model
 * This file defines the Threat entity for the database
 */

using System;

namespace SentinelVisionPro.Backend.Models
{
    /// <summary>
    /// Represents a detected threat in the system
    /// </summary>
    public class Threat
    {
        /// <summary>
        /// Gets or sets the unique identifier for the threat
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of threat
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the severity level of the threat
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the threat was detected
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the location where the threat was detected
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the description of the threat
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether the threat has been resolved
        /// </summary>
        public bool IsResolved { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the threat was resolved
        /// </summary>
        public DateTime? ResolvedAt { get; set; }
    }
} 