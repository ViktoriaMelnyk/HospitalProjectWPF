//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalProjektWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingVisit
    {
        public int idBV { get; set; }
        public Nullable<int> idDoc { get; set; }
        public Nullable<int> idPat { get; set; }
        public Nullable<System.DateTime> dateOfReserv { get; set; }
        public Nullable<System.TimeSpan> timeOfVisit { get; set; }
    
        public virtual Doctors Doctors { get; set; }
        public virtual Patients Patients { get; set; }
    }
}