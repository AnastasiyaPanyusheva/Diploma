//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautySalon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class КатегорияУслуги
    {
        public КатегорияУслуги()
        {
            this.Услуга = new HashSet<Услуга>();
        }
    
        public int КодКатегория { get; set; }
        public string НаименованиеКатегория { get; set; }
    
        public virtual ICollection<Услуга> Услуга { get; set; }
    }
}
