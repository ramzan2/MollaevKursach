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
    
    public partial class Payment
    {
        public int IdPayment { get; set; }
        public System.DateTime DateOfPayment { get; set; }
        public int AmountPayment { get; set; }
        public Nullable<int> IdStatusPayment { get; set; }
        public int IdContract { get; set; }
    
        public virtual Contract Contract { get; set; }
        public virtual StatusPayment StatusPayment { get; set; }
    }
}