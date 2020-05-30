﻿using System;
using System.Collections.Generic;
using System.Text;
using BlogApplication.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // mapeamos los modelos
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}