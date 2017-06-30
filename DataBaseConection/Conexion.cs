using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PrestamosBrito.Models;

namespace PrestamosBrito.DataBaseConection
{
    public class Conexion : DbContext
    {
        public Conexion() : base("DataBaseConnection")
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
    }  
}