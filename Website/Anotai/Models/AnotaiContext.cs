﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class AnotaiContext : DbContext
    {
        public AnotaiContext() : base()
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}