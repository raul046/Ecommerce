using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class CardapioController : Controller
    {
        public IActionResult Cardapio()
        {
            CardapioModel ur = new CardapioModel();
            List<Produtos> produtos = ur.Listar_Cardapio();
            return View(produtos);
        }

        /*=========================CADASTRO DE PRODUTOS-LANCHES=========================*/
        public IActionResult Registro_Cardapio()
        {
            if (HttpContext.Session.GetInt32("id_usuarios") == null)
                return RedirectToAction("Login", "Login");

            return View();
        }

        [HttpPost]
        public IActionResult Registro_Cardapio(Produtos produtos)
        {
            CardapioModel ur = new CardapioModel();
            ur.Inserir_Produtos(produtos);
            ViewBag.Registro = "Registrado com sucesso !";
            return View();
        }

        /*=========================LISTAGEM DE PRODUTOS-LANCHES=========================*/
        public IActionResult Listar_Cardapio()
        {
            if (HttpContext.Session.GetInt32("id_usuarios") == null)
                return RedirectToAction("Login", "Login");

            CardapioModel ur = new CardapioModel();
            List<Produtos> listagem = ur.Listar_Cardapio();
            return View(listagem);
        }

        /*=========================ALTERAÇÃO DE PRODUTOS-LANCHES=========================*/
        [HttpGet]
        public IActionResult Alterar_Cardapio(int id)
        {
            CardapioModel ur = new CardapioModel();
            Produtos p = ur.ExibirProduto(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Alterar_Cardapio(Produtos produtos)
        {
            CardapioModel ur = new CardapioModel();
            ur.Alterar_P(produtos);
            return RedirectToAction("Listar_Cardapio");
        }

        /*=========================EXCLUSÃO DE PRODUTOS-LANCHES=========================*/
        [HttpGet]
        public IActionResult Excluir_Produtos(int id)
        {
            CardapioModel ur = new CardapioModel();
            ur.Excluir_P(id);
            return RedirectToAction("Cardapio");
        }
        [HttpGet]
        public IActionResult Excluir_Produto(int id)
        {
            CardapioModel ur = new CardapioModel();
            ur.Excluir_P(id);
            return RedirectToAction("Listar_Cardapio");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("HomePage", "Home");
        }

      
    }
}


