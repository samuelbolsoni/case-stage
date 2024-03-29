﻿using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Context
{
    public interface IApplicationContext
    {
        DbSet<Area> Areas { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<SystemApp> SystemApps { get; set; }
        DbSet<Proccess> Proccess { get; set; }
        DbSet<ProccessFile> ProccessFiles { get; set; }
        DbSet<ProccessPerson> ProccessPerson { get; set; }
        DbSet<ProccessSystem> ProccessSystems { get; set; }
        Task<int> SaveChanges();
    }
}
