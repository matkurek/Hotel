using Hotel.Models;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Funkcje
{
    public class PobierzDane
    {
        public static Pokoj PobierzPokoj(int numer)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=DESKTOP-8KLJPV0\MSSQLSERVER01;" +
            "Initial Catalog=Hotel;" +
            "Integrated Security=SSPI;" + "Connection Timeout=1;"; ;
            conn.Open();

            var pokoje = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM Pokoj where numer = " + numer.ToString(), conn))
            {
                da.SelectCommand.CommandTimeout = 5;
                da.Fill(pokoje);
            }

            int pokojNumer = -1;
            string rodzaj = "";
            int cena = 0;
            string dodatkoweInformacje = "";

            foreach (DataRow row in pokoje.Rows)
            {
                pokojNumer = Convert.ToInt32(row["numer"]);
                rodzaj = row["rodzaj"].ToString();
                cena = Convert.ToInt32(row["cenaZaNoc"]);
                dodatkoweInformacje = row["opis"].ToString();
            }
            Pokoj pokoj;
            if (pokojNumer == -1)
                 return null; 
            else
                pokoj = new Models.Pokoj() { Numer = pokojNumer, Rodzaj = rodzaj, Cena = cena, DodatkoweInformacje = dodatkoweInformacje };

            return pokoj;
        }

        public static List<Models.Pokoj> PobierzListe()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=DESKTOP-8KLJPV0\MSSQLSERVER01;" +
            "Initial Catalog=Hotel;" +
            "Integrated Security=SSPI;" + "Connection Timeout=1;";
            conn.Open();

            var pokoje = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM Pokoj", conn))
            {
                da.SelectCommand.CommandTimeout = 5;
                da.Fill(pokoje);
            }

            List<Models.Pokoj> pokojeObiekty = new List<Models.Pokoj>();
            foreach (DataRow row in pokoje.Rows)
            {
                var pokoj = new Models.Pokoj()
                {
                    Numer = Convert.ToInt32(row["numer"])
                    ,
                    Rodzaj = row["rodzaj"].ToString()
                    ,
                    Cena = Convert.ToInt32(row["cenaZaNoc"])
                    ,
                    DodatkoweInformacje = row["opis"].ToString()
                };
                pokojeObiekty.Add(pokoj);
            }

            return pokojeObiekty;
        }

        public static List<Models.Rezerwacja> PobierzListeRezerwacji(string zapytanieSql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            @"Data Source=DESKTOP-8KLJPV0\MSSQLSERVER01;" +
            "Initial Catalog=Hotel;" +
            "Integrated Security=SSPI;";
            conn.Open();

            var pokoje = new DataTable();
            using (var da = new SqlDataAdapter(zapytanieSql, conn))
            {
                da.SelectCommand.CommandTimeout = 5;
                da.Fill(pokoje);
            }

            List<Models.Rezerwacja> rezerwacjeObiekty = new List<Models.Rezerwacja>();
            foreach (DataRow row in pokoje.Rows)
            {
                var rezerwacja = new Models.Rezerwacja()
                {
                    id = Convert.ToInt32(row["id"])
                    ,
                    dataOd = Convert.ToDateTime( row["dataOd"] )
                    ,
                    dataDo = Convert.ToDateTime(row["dataDo"])
                    ,
                    pokojNumer = Convert.ToInt32(row["pokojNumer"])
                    ,
                    ileDni = Convert.ToInt32(row["ileDni"])
                    ,
                    przychod = Convert.ToInt32(row["przychod"])

                };
                rezerwacjeObiekty.Add(rezerwacja);
            }

            return rezerwacjeObiekty;
        }
    }
}
