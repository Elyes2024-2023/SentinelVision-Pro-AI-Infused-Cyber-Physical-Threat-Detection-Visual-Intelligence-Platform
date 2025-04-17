/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Threat Detection Controller
 * This controller handles API endpoints for threat detection
 */

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentinelVisionPro.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreatDetectionController : ControllerBase
    {
        /// <summary>
        /// Get all detected threats
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreatInfo>>> GetThreats()
        {
            // This would normally fetch from a database
            var threats = new List<ThreatInfo>
            {
                new ThreatInfo { Id = 1, Type = "Suspicious Activity", Severity = "High", Timestamp = DateTime.Now },
                new ThreatInfo { Id = 2, Type = "Unauthorized Access", Severity = "Medium", Timestamp = DateTime.Now.AddHours(-1) }
            };
            
            return Ok(threats);
        }

        /// <summary>
        /// Get a specific threat by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreatInfo>> GetThreat(int id)
        {
            // This would normally fetch from a database
            var threat = new ThreatInfo { Id = id, Type = "Suspicious Activity", Severity = "High", Timestamp = DateTime.Now };
            
            if (threat == null)
            {
                return NotFound();
            }
            
            return Ok(threat);
        }

        /// <summary>
        /// Create a new threat detection
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ThreatInfo>> CreateThreat(ThreatInfo threat)
        {
            // This would normally save to a database
            threat.Id = 3; // Simulated ID assignment
            threat.Timestamp = DateTime.Now;
            
            return CreatedAtAction(nameof(GetThreat), new { id = threat.Id }, threat);
        }
    }

    /// <summary>
    /// Represents a detected threat
    /// </summary>
    public class ThreatInfo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public DateTime Timestamp { get; set; }
    }
} 