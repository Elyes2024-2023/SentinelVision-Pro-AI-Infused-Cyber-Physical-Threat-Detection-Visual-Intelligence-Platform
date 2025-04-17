/*
 * Copyright (c) 2024-2025 ELYES
 * All rights reserved.
 * Developed by ELYES
 * 
 * SentinelVision Pro Database Context
 * This file defines the Entity Framework database context
 */

using Microsoft.EntityFrameworkCore;
using SentinelVisionPro.Backend.Models;

namespace SentinelVisionPro.Backend.Data
{
    /// <summary>
    /// Database context for the SentinelVision Pro application
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationDbContext
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the threats database set
        /// </summary>
        public DbSet<Threat> Threats { get; set; }

        /// <summary>
        /// Gets or sets the system events database set
        /// </summary>
        public DbSet<SystemEvent> SystemEvents { get; set; }

        /// <summary>
        /// Configures the model for the database context
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Threat entity
            modelBuilder.Entity<Threat>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Threat>()
                .Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Threat>()
                .Property(t => t.Severity)
                .IsRequired()
                .HasMaxLength(50);

            // Configure the SystemEvent entity
            modelBuilder.Entity<SystemEvent>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<SystemEvent>()
                .Property(e => e.EventType)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<SystemEvent>()
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
} 