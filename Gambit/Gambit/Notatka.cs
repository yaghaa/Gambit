//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gambit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notatka
    {
        public string tytul { get; set; }
        public string opis { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int notatkaId { get; set; }
        public Nullable<int> wydarzenieId { get; set; }
        public string Id { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Wydarzenie Wydarzenie { get; set; }
    }
}