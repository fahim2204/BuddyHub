//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class EmailLog
    {
        public int Id { get; set; }
        public int Fk_User_Id { get; set; }
        public string EmailToken { get; set; }
        public System.DateTime Created_At { get; set; }
        public int Status { get; set; }
    
        public virtual User User { get; set; }
    }
}
