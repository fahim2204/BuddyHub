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
    
    public partial class Save
    {
        public int Id { get; set; }
        public int FK_Posts_Id { get; set; }
        public int FK_Users_Id { get; set; }
    
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}