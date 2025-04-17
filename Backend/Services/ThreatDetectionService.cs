/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Threat Detection Service
 * This file contains the business logic for threat detection
 */

using Microsoft.EntityFrameworkCore;
using SentinelVisionPro.Backend.Data;
using SentinelVisionPro.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelVisionPro.Backend.Services
{
    /// <summary>
    /// Service for handling threat detection operations
    /// </summary>
    public class ThreatDetectionService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the ThreatDetectionService
        /// </summary>
        /// <param name="context">The database context</param>
        public ThreatDetectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all threats from the database
        /// </summary>
        /// <returns>A list of all threats</returns>
        public async Task<IEnumerable<Threat>> GetAllThreatsAsync()
        {
            return await _context.Threats
                .OrderByDescending(t => t.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Gets a specific threat by ID
        /// </summary>
        /// <param name="id">The ID of the threat</param>
        /// <returns>The threat with the specified ID, or null if not found</returns>
        public async Task<Threat> GetThreatByIdAsync(int id)
        {
            return await _context.Threats.FindAsync(id);
        }

        /// <summary>
        /// Creates a new threat in the database
        /// </summary>
        /// <param name="threat">The threat to create</param>
        /// <returns>The created threat with its ID</returns>
        public async Task<Threat> CreateThreatAsync(Threat threat)
        {
            threat.Timestamp = DateTime.Now;
            _context.Threats.Add(threat);
            await _context.SaveChangesAsync();
            return threat;
        }

        /// <summary>
        /// Updates an existing threat in the database
        /// </summary>
        /// <param name="threat">The threat to update</param>
        /// <returns>The updated threat</returns>
        public async Task<Threat> UpdateThreatAsync(Threat threat)
        {
            _context.Entry(threat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return threat;
        }

        /// <summary>
        /// Marks a threat as resolved
        /// </summary>
        /// <param name="id">The ID of the threat to resolve</param>
        /// <returns>The resolved threat</returns>
        public async Task<Threat> ResolveThreatAsync(int id)
        {
            var threat = await _context.Threats.FindAsync(id);
            if (threat != null)
            {
                threat.IsResolved = true;
                threat.ResolvedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return threat;
        }

        /// <summary>
        /// Gets all unresolved threats
        /// </summary>
        /// <returns>A list of unresolved threats</returns>
        public async Task<IEnumerable<Threat>> GetUnresolvedThreatsAsync()
        {
            return await _context.Threats
                .Where(t => !t.IsResolved)
                .OrderByDescending(t => t.Timestamp)
                .ToListAsync();
        }
    }
} 