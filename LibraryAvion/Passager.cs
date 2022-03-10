using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
	public class Passager  
	{
	    #region Attributs
	    private int id;
	    private string nom;
	    private DateTime dateNaissance;
	    private int pointFidelite;
        #endregion

 
        #region Constructeurs
        public Passager(int id, string nom, DateTime dateNaissance, int pointFidelite)
        {
			Id = id;
			Nom = nom;
			DateNaissance = dateNaissance;
			PointFidelite = pointFidelite;
        }

		public Passager(int id, string nom, DateTime dateNaissance)
		{
			Id = id;
			Nom = nom;
			DateNaissance = dateNaissance;
		}
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

		public string Nom
        {
			get
            {
				return nom;
            }
			set
            {
				nom = value;
            }
        }

		public DateTime DateNaissance
        {
			get
            {
				return dateNaissance;
            }
			set
            {
				dateNaissance = value;
            }
        }

		public int PointFidelite
        {
			get
            {
				return pointFidelite;
            }
			set
            {
				pointFidelite = value;
            }
        }

		
        #endregion
    }
}
