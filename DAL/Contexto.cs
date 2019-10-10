﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace DAL
{
    public class Contexto : DbContext

    {

        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }

        public Contexto() : base("ConStr") { }
    }
}
