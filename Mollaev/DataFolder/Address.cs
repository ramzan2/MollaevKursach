//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mollaev.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.StorageRooms = new HashSet<StorageRooms>();
        }
    
        public int IdAddress { get; set; }
        public int IdStreet { get; set; }
        public int HouseAddress { get; set; }
        public Nullable<int> FlatAddress { get; set; }
        public Nullable<int> HousingAddress { get; set; }
        public int IdCity { get; set; }
        public int IdRegion { get; set; }
    
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual Street Street { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StorageRooms> StorageRooms { get; set; }
    }
}