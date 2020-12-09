using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ekay.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKay.Pages
{
    public class InicioModel : PageModel
    {
        [BindProperty]
        public DocumentoRequestDto DocumentoRequest { get; set; }

        public void OnGet()
        {
        }
    }
}
