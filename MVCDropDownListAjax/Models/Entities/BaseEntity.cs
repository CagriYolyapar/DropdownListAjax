using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropDownListAjax.Models.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}