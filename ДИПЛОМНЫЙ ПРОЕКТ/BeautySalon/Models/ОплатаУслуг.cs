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
    
    public partial class ОплатаУслуг
    {
        public int КодОплата { get; set; }
        public Nullable<int> КодЗапись { get; set; }
        public Nullable<decimal> ОплатаКлиента { get; set; }
    
        public virtual Запись Запись { get; set; }
    }
}
