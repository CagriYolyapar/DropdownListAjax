using MVCDropDownListAjax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropDownListAjax.ViewModels
{
    public class IndexVM
    {
        public List<State> States { get; set; }
        public List<Address> Addresses { get; set; }
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
        public State State { get; set; }
        public Address Address { get; set; }
        public City City { get; set; }
        public District District { get; set; }

    }
}