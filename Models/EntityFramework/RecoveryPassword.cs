//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuddyHub.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecoveryPassword
    {
        public int Id { get; set; }
        public string QuestionOne { get; set; }
        public string QuestionOneAnswer { get; set; }
        public string QuestionTwo { get; set; }
        public string QuestionTwoAnswer { get; set; }
        public Nullable<int> FK_Users_Id { get; set; }
    
        public virtual User User { get; set; }
    }
}
