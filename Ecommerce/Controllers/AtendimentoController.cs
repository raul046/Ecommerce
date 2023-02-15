using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class AtendimentoController : Controller
    {
        public IActionResult Atendimento()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Atendimento(AtendimentoModel a)
        {
            if (HttpContext.Session.GetInt32("id_usuarios") == null)
                return RedirectToAction("Login","Login");
            AtendimentoModel ur = new AtendimentoModel();
            ur.Enviar_Atendimento(a);
            ViewBag.Registro = "Obrigado, sua mensagem foi enviada com sucesso!";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("HomePage", "Home");
        }
    }
}
