using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Hotel.Funkcje;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class PokojController : Controller
    {
        public IActionResult Losowy()
        {
            var pokoj = new Models.Pokoj() { Rodzaj = "Duży" };
            return View(pokoj);
        }

        [Route("Pokoj/Pokaz")]
        public IActionResult Pokaz(int numer)
        {
            var pokoj = PobierzDane.PobierzPokoj(numer);
            if (pokoj == null)
                return Content("Pokoj nieznaleizony");
            else
                return View(pokoj);
        }

        //[Route("Pokoj/wynajete/{{dataOd:regex(\\d{4}-\\d{2}-\\d{2})}}/{{dataDo}}")]
        [Route("Pokoj/wynajete/{dataOd?}/{dataDo?}")]
        public IActionResult wynajete(string dataOd, string dataDo)
        {
            return Content("Wypozyczone od " + dataOd + " do " + dataDo);
            //return View();
        }

        [Route("Pokoj/lista")]
        public IActionResult Lista()
        {

            var viewModel = new PokojeListaViewModel
            {
                Pokoje = PobierzDane.PobierzListe()
            };

            return View(viewModel);
        }

        [Route("Pokoj/zmien")]
        public IActionResult Zmien(int numer)
        {
            Pokoj pokoj;
            try
            {
                pokoj = PobierzDane.PobierzPokoj(numer);
            }
            catch (SqlException e)
            {
                return Content("Próba wyświetlenia zajmuje za długo, więc ją zakończono - prośzę spróbować później \n" + e.ToString());
            }
            

            return View(pokoj);
        }

        [HttpPost]
        [Route("Pokoj/zmien")]
        public IActionResult Zmien(int numer, string DodatkoweInformacje)
        {
            //return Content(DodatkoweInformacje);
            string connectionString = @"Data Source=DESKTOP-8KLJPV0\MSSQLSERVER01;" +
            "Initial Catalog=Hotel;" +
            "Integrated Security=SSPI;" + "Connection Timeout=1;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string update = "update Hotel.dbo.Pokoj set opis = '" + DodatkoweInformacje + "' where numer = " + numer.ToString();
                connection.Open();
                SqlCommand command = new SqlCommand(update, connection);
                // Setting command timeout in seconds:
                command.CommandTimeout = 2;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    return Content("Próba updatu zajmuje za długo, więc ją zakończono - prośzę spróbować późxniej \n" + e.ToString());
                }
            }

            return RedirectToAction("Pokaz", "Pokoj", new { numer = numer });
            //var viewModel = new PokojeListaViewModel
            //{
            //    Pokoje = PobierzDane.PobierzListe()
            //};

            //return View(viewModel);
        }
    }
}