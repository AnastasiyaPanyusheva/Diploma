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
    
    public partial class КлиентЗапрос
    {
        public int КодКлиент { get; set; }
        public string ФИОклиент { get; set; }
        public string Пол { get; set; }
        public Nullable<System.DateTime> ДатаРожденияКлиент { get; set; }
        public string ТелефонКлиент { get; set; }
        public string АдресКлиент { get; set; }
        public string EmailКлиент { get; set; }
        public Nullable<System.DateTime> ДатаЗаполнения { get; set; }
        public string ПримечаниеКлиент { get; set; }
    }
}
