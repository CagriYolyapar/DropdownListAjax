using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropDownListAjax.Models.Entities
{
    public class State:BaseEntity
    {
        //Relational Properties
        public virtual List<City> Cities { get; set; }

    }
}