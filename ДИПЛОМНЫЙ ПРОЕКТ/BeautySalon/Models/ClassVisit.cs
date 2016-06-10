using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeautySalon.Models;

namespace BeautySalon.Models
{
    public class ClassVisit
    {
        public List<Заявка> заявка { get; set; }
        public List<ЗаписьЗапрос> запись { get; set; }
      
       // public System.Collections.Generic.List<Заявка> Заявка { set; get; }
       // public System.Collections.Generic.List<ЗаписьЗапрос> ЗаписьЗапрос { set; get; }
       //public System.Collections.Generic.List<Заявка> viewRasp { set; get; }
       // public string SelectGroup { set; get; }
       // public ClassVisit()
       // {
       // }
       // public ClassVisit(System.Collections.Generic.List<Заявка> r, System.Collections.Generic.List<ЗаписьЗапрос> g)
       // {
       //     Заявка = r;
       //     ЗаписьЗапрос = g;
       //     SelectGroup = " ";
       // }

    }
}