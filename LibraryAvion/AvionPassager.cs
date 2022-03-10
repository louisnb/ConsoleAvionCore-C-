using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
    public class AvionPassager 
    {
        public enum TypePlace { Business, Premier, Eco };

        public TypePlace TypePlacePassager { get; set; }
        public Passager Passager { get; set; }

        public string Identite()
        {  
           return $"Nom: {Passager.Nom}, date: { Passager.DateNaissance} point de fidelité: { Passager.PointFidelite}"; 
        }

        public AvionPassager(Passager passager, TypePlace place)
        {
            Passager = passager;
            this.TypePlacePassager = place;
        }
    }
}
