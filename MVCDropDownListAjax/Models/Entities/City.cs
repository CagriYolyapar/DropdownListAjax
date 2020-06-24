using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropDownListAjax.Models.Entities
{
    public class City:BaseEntity
    {
        public int StateID { get; set; }
        //Relational Properties
        public virtual State State { get; set; }

        public virtual List<District> Districts { get; set; }



    }
}