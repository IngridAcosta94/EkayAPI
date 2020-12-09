using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ekay.Clases;
using Ekay.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EKay.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CuentaRequestDto CuentaRequest { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> OnPost()
        {
            var httpClient = new HttpClient();
            var user = await httpClient.GetStringAsync("https://localhost:44321/api/cuenta");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else if (user.Contains(CuentaRequest.Usuario) && user.Contains(CuentaRequest.Contrasenia))
            {
               
                return Redirect("Inicio");
            }
            return Page();
        }

        public void OnGet()
        {


        }
    }
}
