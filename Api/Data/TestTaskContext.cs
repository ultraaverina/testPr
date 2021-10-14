using Logic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class TestTaskContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TestTaskContext(DbContextOptions<TestTaskContext> options)
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
