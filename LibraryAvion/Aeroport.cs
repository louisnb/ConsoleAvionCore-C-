using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
    public class Aeroport
    {
        #region Attributs
        private List<Avion> listeAvions = new List<Avion>();
        public Avion Avion; //ajouter pour pouvoir retourner la liste des passagers ayant pris l'avion
        #endregion

        #region CRUD
        // Ajouter un avion : le C dans CRUD
        public bool AjouterAvion(Avion avion)
        {
            if (avion == null)
                throw new Exception();

            Avion p = RechercherAvion(avion.Id);
            if (p != null)
                return false; 

            listeAvions.Add(avion);
            return true;
        }

        // Supprimer un avion : le D dans CRUD
        public bool SupprimerAvion(Avion avion)
        {
            return SupprimerAvion(avion.Id);
        }
        public bool SupprimerAvion(int id)
        {
            Avion p = RechercherAvion(id);
            if (p == null)
                return false; 

            listeAvions.Remove(p);
            return true;
        }
        #endregion

        #region Méthodes de recherche
        public Avion RechercherAvion(int id)
        {
            return listeAvions.Find(delegate (Avion Avion)
            {
                return Avion.Id == id;
            });
        }


        public List<Avion> RechercherAvionsRemplissage(double tauxRemplissage)
        {
            return listeAvions.FindAll(delegate (Avion avion)
            {
                return avion.TauxRemplissage <= tauxRemplissage;
            });
        }
        #endregion


        public void AfficherAvions()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("AfficherAvions");

            foreach (Avion avion in listeAvions)
            {
                Console.WriteLine(avion.FicheDescriptive);
            }
        }

        public List<AvionPassager> PassagersAvions(int id)
        {
            /* TODO : retourne la liste des passagers ayant pris l'avion
             * 
             * ATTENTION : un passager ayant prix 2 avions différents ne doit apparaitre qu'une seule fois !!
             * 
             */
            return Avion.ListPassager.FindAll(delegate (AvionPassager avionPassager)
            {
                return avionPassager.Passager.Id == id;
            });
        }


        public List<Avion> AvionsPassager(Passager passager)
        {
            return AvionsPassager(passager.Id);
        }
        public List<Avion> AvionsPassager(int id)
        {
            return listeAvions.FindAll(delegate (Avion avion)
            {
                return avion.Id == id;
            });
        }
    }
}
