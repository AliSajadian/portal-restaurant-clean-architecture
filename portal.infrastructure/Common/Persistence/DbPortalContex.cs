// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
// using portal.infrastructure.Models;

// namespace portal.infrastructure.Data
// {
//     public partial class DbPortalContext : DbContext
//     {
//         public DbPortalContext()
//         {
//         }

//         public DbPortalContext(DbContextOptions<DbPortalContext> options)
//             : base(options)
//         {
//         }

//         public virtual DbSet<AuthUser> AuthUsers { get; set; } = null!;
//         public virtual DbSet<TblBaseCompany> TblBaseCompanies { get; set; } = null!;
//         public virtual DbSet<TblBaseDepartment> TblBaseDepartments { get; set; } = null!;
//         public virtual DbSet<TblBaseEmployee> TblBaseEmployees { get; set; } = null!;
//         public virtual DbSet<TblBaseJobPosition> TblBaseJobPositions { get; set; } = null!;
//         public virtual DbSet<TblBaseNotification> TblBaseNotifications { get; set; } = null!;
//         public virtual DbSet<TblBaseProject> TblBaseProjects { get; set; } = null!;
//         public virtual DbSet<TblRestaurantDayMeal> TblRestaurantDayMeals { get; set; } = null!;
//         public virtual DbSet<TblRestaurantEmployeeDayMeal> TblRestaurantEmployeeDayMeals { get; set; } = null!;
//         public virtual DbSet<TblRestaurantGuestDayMeal> TblRestaurantGuestDayMeals { get; set; } = null!;
//         public virtual DbSet<TblRestaurantGuestDayMealJunction> TblRestaurantGuestDayMealJunctions { get; set; } = null!;
//         public virtual DbSet<TblRestaurantMeal> TblRestaurantMeals { get; set; } = null!;

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
// //             if (!optionsBuilder.IsConfigured)
// //             {
// // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
// //                 optionsBuilder.UseSqlServer("Server=SAJADIAN-PC;Database=DbPortal_v2;Trusted_Connection=True;MultipleActiveResultSets=True");
// //             }
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.UseCollation("Arabic_CI_AS");

//             modelBuilder.Entity<TblBaseDepartment>(entity =>
//             {
//                 entity.HasOne(d => d.Company)
//                     .WithMany(p => p.TblBaseDepartments)
//                     .HasForeignKey(d => d.CompanyId)
//                     .HasConstraintName("tbl_base_department_company_id_a1233324_fk_tbl_base_company_id");
//             });

//             modelBuilder.Entity<TblBaseEmployee>(entity =>
//             {
//                 entity.HasIndex(e => e.PersonelCode, "tbl_base_employee_personel_code_27988cef_uniq")
//                     .IsUnique()
//                     .HasFilter("([personel_code] IS NOT NULL)");

//                 entity.HasIndex(e => e.UserId, "tbl_base_employee_user_id_13c118bc_uniq")
//                     .IsUnique()
//                     .HasFilter("([user_id] IS NOT NULL)");

//                 entity.HasOne(d => d.Department)
//                     .WithMany(p => p.TblBaseEmployees)
//                     .HasForeignKey(d => d.DepartmentId)
//                     .HasConstraintName("tbl_base_employee_department_id_971fa997_fk_tbl_base_department_id");

//                 entity.HasOne(d => d.JobPosition)
//                     .WithMany(p => p.TblBaseEmployees)
//                     .HasForeignKey(d => d.JobPositionId)
//                     .HasConstraintName("tbl_base_employee_jobPosition_id_7013544e_fk_tbl_base_jobPosition_id");

//                 entity.HasOne(d => d.Project)
//                     .WithMany(p => p.TblBaseEmployees)
//                     .HasForeignKey(d => d.ProjectId)
//                     .HasConstraintName("tbl_base_employee_project_id_3281731a_fk_tbl_base_project_id");

//                 entity.HasOne(d => d.User)
//                     .WithOne(p => p.TblBaseEmployee)
//                     .HasForeignKey<TblBaseEmployee>(d => d.UserId)
//                     .HasConstraintName("tbl_base_employee_user_id_13c118bc_fk_auth_user_id");
//             });

//             modelBuilder.Entity<TblBaseNotification>(entity =>
//             {
//                 entity.HasOne(d => d.NotifierUser)
//                     .WithMany(p => p.TblBaseNotifications)
//                     .HasForeignKey(d => d.NotifierUserId)
//                     .HasConstraintName("tbl_base_notification_notifier_user_id_3230b9b6_fk_auth_user_id");
//             });

//             modelBuilder.Entity<TblBaseProject>(entity =>
//             {
//                 entity.HasOne(d => d.Company)
//                     .WithMany(p => p.TblBaseProjects)
//                     .HasForeignKey(d => d.CompanyId)
//                     .HasConstraintName("tbl_base_project_company_id_8586f4b3_fk_tbl_base_company_id");
//             });

//             modelBuilder.Entity<TblRestaurantDayMeal>(entity =>
//             {
//                 entity.HasOne(d => d.ResturauntMeal)
//                     .WithMany(p => p.TblRestaurantDayMeals)
//                     .HasForeignKey(d => d.ResturauntMealId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("FK_tbl_restaurant_meal_tbl_restaurant_day_meal");
//             });

//             modelBuilder.Entity<TblRestaurantEmployeeDayMeal>(entity =>
//             {
//                 entity.HasOne(d => d.Employee)
//                     .WithMany(p => p.TblRestaurantEmployeeDayMeals)
//                     .HasForeignKey(d => d.EmployeeId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("FK_tbl_base_employee_tbl_restaurant_employee_day_meal");
//             });

//             modelBuilder.Entity<TblRestaurantGuestDayMealJunction>(entity =>
//             {
//                 entity.HasOne(d => d.RestaurantDayMeal)
//                     .WithMany(p => p.TblRestaurantGuestDayMealJunctions)
//                     .HasForeignKey(d => d.RestaurantDayMealId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("FK_tbl_restaurant_day_meal_tbl_restaurant_guest_day_meal_junction");

//                 entity.HasOne(d => d.RestaurantGuestDayMeal)
//                     .WithMany(p => p.TblRestaurantGuestDayMealJunctions)
//                     .HasForeignKey(d => d.RestaurantGuestDayMealId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("FK_tbl_restaurant_guest_day_meal_tbl_restaurant_guest_day_meal_junction");
//             });

//             OnModelCreatingPartial(modelBuilder);
//         }

//         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//     }
// }
