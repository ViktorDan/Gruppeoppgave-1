﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppsMedGithub.Models;

// Her finnes alt som har med oppretting av database å gjøre. DB metoder finner man i DBFunksjonalitet
// Public Virtual lager connection mellom Kunder og Poststeder

namespace WebAppsMedGithub.Models
{
    public class dbKunder
    {
        [Key]
        public string Brukernavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Tlf { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
        public virtual Poststeder Poststeder { get; set; }
        public virtual Bestillinger Bestillinger { get; set; }
    }
    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public virtual List<dbKunder> Kunder { get; set; }
    }
    public class Filmer
    {
        [Key]
        public int FId { get; set; }
        public string Navn { get; set; }
        public int Aar { get; set; }

        public int Lengde { get; set; }
        public int Storrelse { get; set; }
        public int Pris { get; set; }
        public string Sjanger { get; set; }
        public string Bilde { get; set; }
        public virtual Bestillinger Bestillinger { get; set; }
    }

    public class Bestillinger
    {
        [Key]
        public int BId { get; set; }
        public string Brukernavn { get; set; }
        public int FId { get; set; }
        public virtual List<dbKunder> Kunder { get; set; }
        public virtual List<Filmer> Filmer { get; set; }
    }

    public class DBContext : DbContext
    {
        // Oppretter database databasen.
        public DBContext()
            : base("name=WebAppsMedGithub") {}

        // Oppretter tabellene Kunder, Poststeder og Filmer i databasen.
        public DbSet<dbKunder> Kunder { get; set; }
        public DbSet<Filmer> Filmer { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Bestillinger> Bestillinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


       
    }
}