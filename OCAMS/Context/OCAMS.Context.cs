﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OCAMS.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OCAMSDBEntities : DbContext
    {
        public OCAMSDBEntities()
            : base("name=OCAMSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OCAMS_Account> OCAMS_Account { get; set; }
        public virtual DbSet<OCAMS_Person> OCAMS_Person { get; set; }
        public virtual DbSet<OCAMS_User> OCAMS_User { get; set; }
        public virtual DbSet<OCAMS_AccountLevel> OCAMS_AccountLevel { get; set; }
        public virtual DbSet<OCAMS_AccountType> OCAMS_AccountType { get; set; }
        public virtual DbSet<OCAMS_CasinoBalance> OCAMS_CasinoBalance { get; set; }
        public virtual DbSet<OCAMS_Commission> OCAMS_Commission { get; set; }
        public virtual DbSet<OCAMS_Currency> OCAMS_Currency { get; set; }
        public virtual DbSet<OCAMS_Deposit> OCAMS_Deposit { get; set; }
        public virtual DbSet<OCAMS_GeneralSettings> OCAMS_GeneralSettings { get; set; }
        public virtual DbSet<OCAMS_UserSettingsCasino> OCAMS_UserSettingsCasino { get; set; }
        public virtual DbSet<OCAMS_UserType> OCAMS_UserType { get; set; }
        public virtual DbSet<OCAMS_Withdraw> OCAMS_Withdraw { get; set; }
        public virtual DbSet<OCAMS_AccountParentChild> OCAMS_AccountParentChild { get; set; }
    }
}
