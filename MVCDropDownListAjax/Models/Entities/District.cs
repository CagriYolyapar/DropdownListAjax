using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropDownListAjax.Models.Entities
{
    public class District:BaseEntity
    {
        public int CityID { get; set; }

        //Relational Properties
        public virtual City City { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}