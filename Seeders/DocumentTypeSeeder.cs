using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Seeders
{
    public class DocumentTypeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType { Id = 1, Name = "Cédula de Ciudadanía"},
                new DocumentType { Id = 2, Name = "Tarjeta de Identidad"},
                new DocumentType { Id = 3, Name = "Pasaporte"},
                new DocumentType { Id = 4, Name = "Número de Identificación Tributaria" },
                new DocumentType { Id = 5, Name = "Cédula de Extranjería"},
                new DocumentType { Id = 6, Name = "Registro Civil"},
                new DocumentType { Id = 7, Name = "Permiso Especial de Permanencia" }
            );
        }
    }
}    