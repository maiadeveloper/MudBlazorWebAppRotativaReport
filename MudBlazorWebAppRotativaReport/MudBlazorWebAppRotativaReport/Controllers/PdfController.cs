using Microsoft.AspNetCore.Mvc;
using MudBlazorWebAppRotativaReport.Models;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace MudBlazorWebAppRotativaReport.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult GerarRelatorio()
        {
            var pessoa = new Pessoa();

            pessoa.Id = 1;
            pessoa.Nome = "Luís Antônio O Maia";
            pessoa.Email = "luisaom@teste.com";

            string customSwitches = string.Format(
                   "--footer-left \"Data e hora impressão:" + @DateTime.Now + " | TI - Tecnologia da Informação\" " +
                    "--footer-font-name \"Open Sans\" " +
                    " --footer-line --footer-font-size \"8\" " +
                    "--footer-right \"Página [page] de [toPage]\"");

            var pdf = new ViewAsPdf(pessoa)
            {
                CustomSwitches = customSwitches,

                PageMargins = new Margins { Bottom = 20, Left = 15, Right = 15, Top = 20 },
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                ViewName = "Relatorio"
            };

            return pdf;
        }
    }
}
