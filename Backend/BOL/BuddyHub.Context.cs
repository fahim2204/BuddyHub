﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BuddyDbContext : DbContext
    {
        public BuddyDbContext()
            : base("name=BuddyDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<OAuth> OAuths { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<RecoveryPassword> RecoveryPasswords { get; set; }
        public virtual DbSet<Save> Saves { get; set; }
        public virtual DbSet<SocialLink> SocialLinks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorksProfile> WorksProfiles { get; set; }
    }
}
