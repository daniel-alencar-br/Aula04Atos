using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula04Atos.Models;
using System.Data;

namespace Aula04Atos.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            Repositorio Pesq = new Repositorio();
            DataSet Tabelas;
            // 1..N : DataTable  1..N : DataRow

            Tabelas = Pesq.VoltaClientes();

            IEnumerable<DataRow> Clientes =
                from Cli in Tabelas.Tables[0].AsEnumerable()
                  orderby Cli.Field<int>("Idade") descending
                    select Cli;

            IEnumerable<DataRow> ClientesMais40 =
                 Clientes.Where(p => p.Field<int>("Idade") > 40);

            int iTotal = Clientes.Sum(p => p.Field<int>("Idade"));

            ViewBag.Dados = "";
            foreach (DataRow Linha in Clientes)
            {
                ViewBag.Dados += Linha["Nome"].ToString() + " - ";
            }

            // Varredura Total
            /*ViewBag.Dados = "";
            foreach (DataRow Linha in Tabelas.Tables[0].Rows)
            {
                ViewBag.Dados += Linha["Nome"].ToString() + " - ";
            }*/

            return View();
        }
    }
}

