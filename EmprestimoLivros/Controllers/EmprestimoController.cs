    using EmprestimoLivros.Data;
    using EmprestimoLivros.Models;
    using Microsoft.AspNetCore.Mvc;

    namespace EmprestimoLivros.Controllers
    { 
        public class EmprestimoController : Controller
        {
            private readonly ApplicationDbContext _context;

            public EmprestimoController(ApplicationDbContext context)
            {
                _context = context;
            }

            public ActionResult Index()
            {
                var contacts = _context.Emprestimos;
            
                return View(contacts);
            }
          

            [HttpGet]
            public IActionResult Cadastrar()  //Qual a difeenca entra IActionResult E ActionResult???????????
            {

              return View();
            }


            [HttpGet]
            public ActionResult Editar(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
            }


            [HttpGet]
            public ActionResult Excluir(int? id)
            {

            if (id == null)
            {
                return NotFound();
            }

            EmprestimosModel dbBook = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (dbBook == null)
            {
                return NotFound();
            }


                return View(dbBook);

            }


            [HttpPost]
            public ActionResult Cadastrar(EmprestimosModel emprestimo)
            {

            if (ModelState.IsValid)
            {
                emprestimo.dataUltimaAtualizacao = DateTime.Now;

                _context.Emprestimos.Add(emprestimo);
                _context.SaveChanges();
                TempData["MensagemSucesso"] = "Book save succesfully !";

                return RedirectToAction("Index");
            }

            return View("Cadastrar", emprestimo);
        }

     

            [HttpPost]
            public IActionResult Editar(EmprestimosModel emprestimo)
            {
                    if (ModelState.IsValid)
             {
                var emprestimoDB = _context.Emprestimos.Find(emprestimo.Id);


                emprestimoDB.LivroEmprestado = emprestimo.LivroEmprestado;
                emprestimoDB.Recebedor = emprestimo.Recebedor;
                emprestimoDB.Fornecedor = emprestimo.Fornecedor;


                _context.Emprestimos.Update(emprestimoDB);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Edição succesfully Edited!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Error while trying to save book!";
            return View(emprestimo);
            }

            [HttpPost]
            public ActionResult Excluir(EmprestimosModel emprestimoToDelete)
            {
            if (emprestimoToDelete == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimoToDelete);
            _context.SaveChanges();
            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
            return RedirectToAction("Index");
        }


        }
    }
