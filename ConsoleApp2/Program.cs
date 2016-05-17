using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp2
{
    [Table("role", Schema = "public")]
    public class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
    public class MoviesAppContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseNpgsql(@"Username=postgres;Password=postgres;Host=localhost;Port=5432;Database=test;");
        }
    }
    public class Program
    {
        public static void Main(string[] args) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            new MoviesAppContext();
            stopWatch.Stop();
            var ms = stopWatch.ElapsedMilliseconds;

            // Format and display the TimeSpan value.
            Console.WriteLine("milliseconds " + ms);
            //     var q1 = GetAllRoles();
            //  var q2 = GetRoleById(1);
            var q3 = AddRole(new Role { Name = "33333"});
          //  var q4 = DeleteRoleById(1);
            var q = 1;
        }

        public static List<Role> GetAllRoles() {
            using (var context = new MoviesAppContext()) {
                return context.Roles.ToList();
            }
        }
        public static Role GetRoleById(int id) {
            using (var context = new MoviesAppContext()) {
                return context.Roles.Single(r => r.Id == id);
            }
        }
        public static int AddRole(Role role) {
            var newRole = new Role {
                Name = role.Name
            };
            using (var context = new MoviesAppContext()) {
                context.Roles.Add(newRole);
                context.SaveChanges();
                return newRole.Id;
            }
        }
        public static bool DeleteRoleById(int id) {
            var role = new Role {
                Id = id
            };
            using (var context = new MoviesAppContext()) {
                context.Roles.Attach(role);
                context.Roles.Remove(role);
                return context.SaveChanges() != 0;
            }
        }
    }
}