using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropDownListAjax.Models.Entities
{
    public class Address:BaseEntity
    {
        public string LastName { get; set; }
        public string Description { get; set; }
        public int DistrictID { get; set; }
        //Relational Properties
        public virtual District District { get; set; }

    }
}