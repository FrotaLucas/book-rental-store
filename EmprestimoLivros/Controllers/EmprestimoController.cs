using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{ 
    public class EmprestimoController : Controller
    {
        private static List<EmprestimosModel> contacts = new List<EmprestimosModel>();

        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
            //contacts.Add(new EmprestimosModel { Recebedor = "Lucas Doe", Fornecedor = "Lola", LivroEmprestado = "A Revoada", dataUltimaAtualizacao = DateTime.Now }); ;

        }

        public ActionResult Index()
        {
            // Adding some sample contacts

            return View(contacts);
        }
        //public IActionResult Index()
        //{
        //    IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
        //    return View(emprestimos);
        //}

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0) {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x=> x.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id) {
            
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x=> x.Id == id);
            
            if(emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        
        }

        [HttpPost]
        public ActionResult AddContact(EmprestimosModel emprestimo)
        {
            string a;
            if (ModelState.IsValid)
            {
                emprestimo.dataUltimaAtualizacao = DateTime.Now;
                a = emprestimo.Fornecedor;
                contacts.Add(emprestimo);
                return RedirectToAction("Index");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine($"Validation Error: {error.ErrorMessage}");
            }
            // If ModelState is not valid, return to the view with the current model for correction.
            return View("Cadastrar", emprestimo);
        }

        [HttpPost]

        public IActionResult Cadastrar(EmprestimosModel emprestimo)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";
                return RedirectToAction("Index");   
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizada com sucesso";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteContact(EmprestimosModel emprestimoToDelete)
        {
           if (ModelState.IsValid)
            {
                var contactToRemove = contacts.FirstOrDefault(c =>
                    c.Recebedor == emprestimoToDelete.Recebedor &&
                    c.Fornecedor == emprestimoToDelete.Fornecedor &&
                    c.LivroEmprestado == emprestimoToDelete.LivroEmprestado);

                if (contactToRemove != null)
                {
                    // Remove the contact from the list
                    contacts.Remove(contactToRemove);
                }

                return RedirectToAction("Index");

            }

            return NotFound();
        }

        [HttpPost]

        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if( emprestimo == null)
            {
                return NotFound() ;
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Remoção realizado com sucesso";

            return RedirectToAction("Index");   
        }

    }
}
