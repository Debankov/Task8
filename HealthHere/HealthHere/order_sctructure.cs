//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthHere
{
    using System;
    using System.Collections.Generic;
    
    public partial class order_sctructure
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int count { get; set; }
    
        public virtual order order { get; set; }
        public virtual product product { get; set; }
    }
}
