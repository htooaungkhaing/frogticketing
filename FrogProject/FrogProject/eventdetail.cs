//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrogProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class eventdetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eventdetail()
        {
            this.orderdetails = new HashSet<orderdetail>();
        }
    
        public System.Guid EventID { get; set; }
        public string EventName { get; set; }
        public string Type { get; set; }
        public string Venue { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string GateOpen { get; set; }
        public string PublicSale { get; set; }
        public int valiabeTicet { get; set; }
        public string Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderdetail> orderdetails { get; set; }
    }
}
