using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ekay.Clases;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EKay.Pages
{
    public class DocumentoModel : PageModel
    {
        [BindProperty]
        public DocumentoRequestDto DocumentoRequest { get; set; }
        [BindProperty]
        public AutorRequestDto AutorRequest { get; set; }
        [BindProperty]
        public RemitenteRequestDto RemitenteRequest { get; set; }


       /* public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                return Page();
            }
        }*/
        
        public void OnGet()
        {
        }
    }
}
