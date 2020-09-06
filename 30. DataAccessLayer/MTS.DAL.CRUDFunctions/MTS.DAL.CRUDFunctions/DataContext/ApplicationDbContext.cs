﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.DAL.Entities.Core;
using MTS.DAL.Entities.Core.Credit;
using MTS.DAL.Entities.Core.EditPageContent;
using MTS.DAL.Interfaces.Standard;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    public sealed class ApplicationDbContext : IdentityDbContext<DALUserAccount>
    {
        private readonly ISeedData _seedData;

        public DbSet<DALPageSection> PageSections { get; set; }
        public DbSet<DALSectionPart> SectionParts { get; set; }
        public DbSet<DALUserAccount> UserAccounts { get; set; }
        public DbSet<DALCreditCategory> CreditCategories { get; set; }
        public DbSet<DALCredit> Credits { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ISeedData seedData)
            : base(options)
        {
            _seedData = seedData;
        }

        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            await _seedData.SeedPageSectionsAsync(builder);

            await _seedData.SeedAccountsAsync(builder);

            await _seedData.SeedCredits(builder);
        }
    }
}
