﻿using Model;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace Databases
{
    public class DataBase : DbContext
    {
        public DataBase(DbConnection conection)
            : base(conection, true)
        {
            this.Database.CommandTimeout = Int32.MaxValue;
        }

        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<VisualRepresentation> VisualRepresentations { get; set; }
        public virtual DbSet<MultilingualString> MultilingualStrings { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
