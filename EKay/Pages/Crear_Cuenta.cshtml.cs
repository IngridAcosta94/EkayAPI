using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ekay.Clases;
using Newtonsoft.Json;
using System.Net.Http;
using Ekay.Response;

namespace EKay.Pages
{
    public class Crear_CuentaModel : PageModel
    {
        [BindProperty]
        public EmpresaRequestDto EmpresaRequest { get; set; }
        
        [BindProperty]
        public CuentaRequestDto CuentaRequest { get; set; }

        public void OnGet()
        {
            EmpresaRequest = new EmpresaRequestDto();
            CuentaRequest = new CuentaRequestDto();
        }
       

        public async Task<IActionResult> OnPost()
        {
           
            var httpClient = new HttpClient();
            CuentaRequest.PerfilId = 2;
            CuentaRequest.Usuario = EmpresaRequest.Correo;
            var Json = await httpClient.PostAsJsonAsync("https://localhost:44321/api/empresa/", EmpresaRequest);
            var user = await httpClient.GetStringAsync("https://localhost:44321/api/empresa");
            var users = JsonConvert.DeserializeObject<ApiResponse<List<EmpresaResponseDto>>>(user); //modficar
            CuentaRequest.EmpresaId = users.Data.Last().Id; //modificar
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                 
                await httpClient.PostAsJsonAsync("https://localhost:44321/api/cuenta/", CuentaRequest);

                return Redirect("Index");
            }
            
           
        }
    }
}
