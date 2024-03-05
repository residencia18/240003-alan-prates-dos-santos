using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MvcMovie.Controllers
{
    public class UserController : Controller
    {
        private readonly MvcMovieContext _context;

        public UserController(MvcMovieContext context)
        {
            _context = context;
        }
        public IActionResult Painel()
        {
            var userName = HttpContext.Session.GetString("UserName");
            
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "User");
            }
            
            ViewBag.UserName = userName;

            return View();
        }
        public IActionResult Cadastro()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Painel", "User");
            }
            return View(user);
        }

        public IActionResult CadastroArtista()
        {
            var userName = HttpContext.Session.GetString("UserName");
            
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "User");
            }
            
            var artista = new Artista();
            ViewBag.UserName = userName;

            return View(artista);
        }
        public IActionResult ListagemArtista()
        {
            var artistas = _context.Artistas.ToList();
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            return View(artistas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastroArtista(Artista artista)
        {

            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                
                if (userId != null)
                {
                    artista.UserId = userId.Value;
                    _context.Artistas.Add(artista);
                    _context.SaveChanges();
                    
                    return RedirectToAction("ListagemArtista", "User");
                }
            }
            
            return View(artista);
        }
        public IActionResult ListagemEstudio()
        {
            var estudios = _context.Estudios.ToList();
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            return View(estudios);
        }
    

        public IActionResult CadastroEstudio()
        {
            var userName = HttpContext.Session.GetString("UserName");
            
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "User");
            }
            
            var estudio = new Estudio();
            
            ViewBag.UserName = userName;

            return View(estudio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastroEstudio(Estudio estudio)
        {

            if (ModelState.IsValid)
            {

                var userId = HttpContext.Session.GetInt32("UserId");
                
                if (userId != null)
                {

                    estudio.UserId = userId.Value;
                    _context.Estudios.Add(estudio);
                    _context.SaveChanges();
                    return RedirectToAction("ListagemEstudio", "User");
                }
            }
            return View(estudio);
        }

        public IActionResult Listagem()
        {
            var users = _context.Users.ToList();
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Listagem");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirArtista(int artistaId)
        {
            var artista = _context.Artistas.Find(artistaId);
            if (artista == null)
            {
                return NotFound();
            }
            _context.Artistas.Remove(artista);
            _context.SaveChanges();
            return RedirectToAction("ListagemArtista");
        }

// Action para excluir um estúdio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirEstudio(int estudioId)
        {
            var estudio = _context.Estudios.Find(estudioId);
            if (estudio == null)
            {
                return NotFound();
            }
            _context.Estudios.Remove(estudio);
            _context.SaveChanges();
            return RedirectToAction("ListagemEstudio");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.Name);
                    return RedirectToAction("Painel");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas. Tente novamente.");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
