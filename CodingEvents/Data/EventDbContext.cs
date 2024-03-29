﻿using System;
using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CodingEvents.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<EventCategory> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasOne(p => p.Category)
                .WithMany(b => b.events);

            modelBuilder.Entity<Event>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Events)
                .UsingEntity(j => j.ToTable("EventTags"));
        }
    }
}

