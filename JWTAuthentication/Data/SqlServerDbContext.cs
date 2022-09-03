using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Data
{
    public class SqlServerDbContext:ApplicationDbContext
    {
        public SqlServerDbContext(DbContextOptions options,IConfiguration configuration): base(options,configuration){

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer(_configuration.GetConnectionString("SQLServer"));
        }
    }
}