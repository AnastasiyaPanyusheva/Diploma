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
    
    public partial class Материал
    {
        public Материал()
        {
            this.Расход = new HashSet<Расход>();
            this.СоставПрихода = new HashSet<СоставПрихода>();
        }
    
        public int КодМатериал { get; set; }
        public string НаименованиеМатериал { get; set; }
        public Nullable<int> КодГруппа { get; set; }
    
        public virtual ГруппаМатериалов ГруппаМатериалов { get; set; }
        public virtual ICollection<Расход> Расход { get; set; }
        public virtual ICollection<СоставПрихода> СоставПрихода { get; set; }
    }
}
