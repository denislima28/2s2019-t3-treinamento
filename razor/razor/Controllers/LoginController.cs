using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor.Dominios;

namespace razor.Controllers
{
    public class LoginController : Controller
    {
        private readonly LanHouseContext _context;

        public LoginController(LanHouseContext context)
        {
            _context = context;
        }


        // GET: Login/Create
        public IActionResult Create()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Senha")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                Usuarios retorno = _context.Usuarios.FirstOrDefault(x => x.Email == usuarios.Email && x.Senha == usuarios.Senha);
                //Verifica a validade do email e senha digitados

                if(retorno == null)
                {
                    ViewBag.Mensagem = "Email ou senha inválidos";
                    //ViewBag só pode ser usada na mesma View em que está.

                    return View(usuarios);
                }

                HttpContext.Session.SetString("email", usuarios.Email);
                ViewBag.Mensagem = "Usuário válido";

                return RedirectToAction("Index", "RegistrosDefeitos"); //Faz o usuário ir para uma certa página depois de logar.
            }

            return View(usuarios);
        }

        
    }
}
