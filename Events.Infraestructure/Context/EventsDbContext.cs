using System;
using System.Collections.Generic;
using Events.Domain.Entities;
using Events.Infraestructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Events.Infraestructure.Context;

public class EventsDbContext : DbContext
{
    public EventsDbContext()
    {
    }

    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventMap());
    }

    
}
