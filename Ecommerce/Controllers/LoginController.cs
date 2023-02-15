using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {

        //***************************CADASTRO DE USUÁRIOS***************************
        public IActionResult cadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult cadastroUsuario(Usuario user)
        {

            Usuario ur = new Usuario();
            ur.Inserir(user);
            ViewBag.Sucesso = "Usuário cadastrado com sucesso!";
            return View();
        }

        //***************************LOGIN DE USUÁRIOS***************************
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            Usuario ur = new Usuario();
            Usuario usuario = ur.Login(user);

            try
            {
                if (user.email == "admin@admin.com" && user.senha == "1234")
                {
                    HttpContext.Session.SetInt32("id_usuarios", usuario.id);
                    HttpContext.Session.SetString("nome_usuario", usuario.nome_usuario);
                    return RedirectToAction("Listar_Usuarios");
                }
                if (usuario != null)
                {
                    HttpContext.Session.SetInt32("id_usuarios", usuario.id);
                    HttpContext.Session.SetString("nome_usuario", usuario.nome_usuario);
                    ViewBag.Sucesso = "LOGIN REALIZADO COM SUCESSO!";

                }
                else
                {
                    ViewBag.Falha = "ERRO, VERIFIQUE SEU EMAIL E SENHA";
                }
                return View();

            }
            catch (Exception e)
            {
                TempData["msg"] = "ERRO: " + e.Message;
            }
            return View();
        }

        //*************************** LOGOUT ***************************
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("HomePage", "Home");
        }

        //*************************** LISTAR USUÁRIOS - ADMIN ***************************
        public IActionResult Listar_Usuarios()
        {
            if (HttpContext.Session.GetInt32("id_usuarios") == null)
                return RedirectToAction("Login");

            Usuario ur = new Usuario();
            List<Usuario> listagem = ur.Listar_Usuarios();
            return View(listagem);
        }

        //*************************** ALTERAÇÃO DE USUÁRIOS - ADMIN ***************************
        [HttpGet]
        public IActionResult Alterar_Usuario(int id)
        {
            if (HttpContext.Session.GetInt32("id_usuarios") == null)
                return RedirectToAction("Login");

            Usuario ur = new Usuario();
            Usuario user = ur.ExibirUsuario(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Alterar_Usuario(Usuario usuario)
        {
            Usuario ur = new Usuario();
            ur.Alterar(usuario);
            return RedirectToAction("Listar_Usuarios");
        }


        //*************************** EXCLUSÃO DE USUÁRIOS - ADMIN ***************************
        [HttpGet]
        public IActionResult Excluir_Usuario(int id)
        {
            if (HttpContext.Session.GetInt32("id_usuarios") == null)
                return RedirectToAction("Login");

            Usuario ur = new Usuario();
            ur.Excluir(id);
            return RedirectToAction("Listar_Usuarios");
        }

      




    }
}
