 using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
    public class Avion :Aeroport
    {
        static double PRIX_BUSINESS = 300;
        static double PRIX_PREMIER = 210;
        static double PRIX_ECO = 90;
		
        #region Attributs
        private int id;
        private int nbPlace;

        private int maxPlaceBusiness;
        private int maxPlacePremier;
        private int maxPlaceEco;
        private List<AvionPassager> listeAvionPassagers;
        #endregion

        #region Propriétés
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int NbPlace
        {
            get
            {
                return nbPlace;
            }
            set
            {
                nbPlace = value;
            }
        }

        public double TauxRemplissage
        {
            get
            {
                return listeAvionPassagers.Count / NbPlace;
            }
        }
        public List<AvionPassager> ListPassager
        {
            get
            {
                return listeAvionPassagers;
            }
        }
        
        
        public string FicheDescriptive
        {
            get
            {
                string result = $"Taux de remplissage: {TauxRemplissage}";

                return ($"{result} Total des billets Business: {TotalBilletsBusiness()}€, Total des billets Premier: {TotalBilletsPremier()}€, Total des billets Eco: {TotalBilletsEco()}€");
            }
        }
        #endregion

        #region Constructeur
        public Avion(int id, int nbPlace)
        {
            Id = id;
            NbPlace = nbPlace;
        }
        #endregion
		

        public int GetMaxPlaces(AvionPassager.TypePlace typePlacePassager)
        {
            int places = maxPlaceEco; // Par défaut

            switch (typePlacePassager)
            {
                case AvionPassager.TypePlace.Business:
                    places = maxPlaceBusiness;
                    break;
                case AvionPassager.TypePlace.Premier:
                    places = maxPlacePremier;
                    break;
            }

            return places;
        }

        #region CRUD
        // Ajouter un avionPassager : le C dans CRUD
        public bool AjouterAvionPassager(AvionPassager avionPassager)
        {
            if (avionPassager == null)
                throw new Exception("l'argument est null");

            AvionPassager p = RechercherAvionPassager(avionPassager.Passager.Id);
            if (p != null)
                return false; 


            if (listeAvionPassagers.Count < nbPlace)
            {

                listeAvionPassagers.Add(avionPassager);
                avionPassager.Passager.PointFidelite += 2; 
                return true;
            }
            else
            {
                return false;
            }
        }

        // Supprimer un avionPassager : le D dans CRUD
        public bool SupprimerAvionPassager(AvionPassager avionPassager)
        {
            return SupprimerAvionPassager(avionPassager.Passager.Id);
        }
        public bool SupprimerAvionPassager(int id)
        {
            AvionPassager ap = RechercherAvionPassager(id); /* TODO: indiquer le passager recherché*/
            if (ap == null)
                return false; 

            listeAvionPassagers.Remove(ap);
            ap.Passager.PointFidelite += -2;
            return true;
        }
        #endregion

        #region Méthodes de recherche
        public AvionPassager RechercherAvionPassager(int id)
        {
            return listeAvionPassagers.Find(delegate (AvionPassager AvionPassager)
            {
                return AvionPassager.Passager.Id == id;
            });
        }
        public List<AvionPassager> RechercherAvionPassagerTypePlace(AvionPassager.TypePlace typePlace)
        {
            return listeAvionPassagers.FindAll(delegate (AvionPassager avionPassager)
            {
                return avionPassager.TypePlacePassager == typePlace;
            }); 
        } 
        #endregion

        //Méthodes rajoutées pour afficher la fiche Descriptive
        public double TotalBilletsBusiness()
        {
            double total = 0;
            total += PRIX_BUSINESS * (0.1 * nbPlace);
            return total;
        }

        public double TotalBilletsPremier()
        {
            double total = 0;
            total += PRIX_PREMIER * (0.2 * nbPlace);
            return total;
        }

        public double TotalBilletsEco()
        {
            double total = 0;
            total += PRIX_ECO * (nbPlace * (1 - 0.2 - 0.1));
            return total;
        }
    }
}
