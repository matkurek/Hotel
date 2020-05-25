using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Funkcje;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Hotel.Controllers
{
    public class RezerwacjaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Rezerwacja/lista")]
        public IActionResult Lista(int ?numerPokoju)
        {
            RezerwacjeListaViewModel viewModel;
            try
            {
                if (numerPokoju.HasValue)
                {
                    viewModel = new RezerwacjeListaViewModel
                    {
                        Rezerwacje = PobierzDane.PobierzListeRezerwacji(@"SELECT [id]
                                                                      ,[dataOd]
                                                                      ,[dataDo]
                                                                      ,[pokojNumer]
                                                                      ,DATEDIFF(day, dataOd, dataDo) as ileDni
                                                                      ,DATEDIFF(day, dataOd, dataDo) * p.cenaZaNoc as Przychod
                                                                  FROM [Hotel].[dbo].[Rezerwacje] r
                                                                  join Hotel.dbo.Pokoj p on r.pokojNumer = p.numer
                                                                  where p.numer = " + numerPokoju.ToString())
                    };
                }
                else
                {
                    {
                        viewModel = new RezerwacjeListaViewModel
                        {
                            Rezerwacje = PobierzDane.PobierzListeRezerwacji(@"SELECT [id]
                                                                      ,[dataOd]
                                                                      ,[dataDo]
                                                                      ,[pokojNumer]
                                                                      ,DATEDIFF(day, dataOd, dataDo) as ileDni
                                                                      ,DATEDIFF(day, dataOd, dataDo) * p.cenaZaNoc as Przychod
                                                                  FROM [Hotel].[dbo].[Rezerwacje] r
                                                                  join Hotel.dbo.Pokoj p on r.pokojNumer = p.numer")
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return Content("Fast Fail - za długie oczekiwanie \n"+ e.ToString());
            }
            return View(viewModel);
        }

        [Route("Rezerwacja/dodaj")]
        public IActionResult dodaj()
        {
            return View();
        }

        [HttpPost]
        [Route("Rezerwacja/dodaj")]
        public IActionResult dodaj(int numerPokoju, DateTime dataOd, DateTime dataDo)
        {

            var Rezerwacje = PobierzDane.PobierzListeRezerwacji(@"SELECT [id]
                                                                      ,[dataOd]
                                                                      ,[dataDo]
                                                                      ,[pokojNumer]
                                                                      ,DATEDIFF(day, dataOd, dataDo) as ileDni
                                                                      ,DATEDIFF(day, dataOd, dataDo) * p.cenaZaNoc as Przychod
                                                                  FROM [Hotel].[dbo].[Rezerwacje] r
                                                                  join Hotel.dbo.Pokoj p on r.pokojNumer = p.numer
                                                                  where p.numer = " + numerPokoju.ToString() +
                " and ((dataOd between '" + dataOd.ToString("yyyy-MM-dd") + "' and '" + dataDo.ToString("yyyy-MM-dd") + "') or" +
                " (dataDo between '" + dataOd.ToString("yyyy-MM-dd") + "' and '" + dataDo.ToString("yyyy-MM-dd") + "') ) ");
            if (Rezerwacje.Count > 0)
            {
                return Content("Nie można wprowadzić tej rezerwacji bo dla tego przedziału dat pokój jest zarezerwowany");
            }
            else
            {
                //return Content(DodatkoweInformacje);
                string insert = @"insert into Hotel.dbo.Rezerwacje (pokojNumer,dataOd,dataDo) values 
(" + numerPokoju.ToString() + ",'" + dataOd.ToString("yyyy-MM-dd") + "','" + dataDo.ToString("yyyy-MM-dd") + "')";

                var factory = new ConnectionFactory()
                {
                    UserName = "nbmnpwjs",
                    Password = "Nij0m4Mdxj4Zxp8F2h1eHZji_VjLoj2a",
                    HostName = "bulldog.rmq.cloudamqp.com",
                    VirtualHost = "nbmnpwjs"
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("message_queue", false, false, false, null);


                    // consume response from consumer
                    string replyQueueName = channel.QueueDeclare().QueueName;

                    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);

                    // send/receive message
                    //string message = "my message XYZ 9:44 - KSR";
                    var body = System.Text.Encoding.UTF8.GetBytes(insert);

                    var properties = channel.CreateBasicProperties();
                    properties.ReplyTo = replyQueueName;
                    var corrId = Guid.NewGuid().ToString();
                    properties.CorrelationId = corrId;

                    channel.BasicPublish("", "message_queue", properties, body);

                }

                return RedirectToAction("lista", "Rezerwacja");
            }
        }
    } 
}