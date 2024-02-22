    using EmprestimoLivros.Data;
    using EmprestimoLivros.Models;
    using Microsoft.AspNetCore.Mvc;

    namespace EmprestimoLivros.Controllers
    { 
        public class EmprestimoController : Controller
        {
            //private static List<EmprestimosModel> contacts = new List<EmprestimosModel>();

            private static List<EmprestimosModel> contacts = new List<EmprestimosModel>
            {
                new EmprestimosModel { Id = 0, Recebedor = "John", Fornecedor = "Doe", LivroEmprestado = "The Legend", dataUltimaAtualizacao = DateTime.Now },
                new EmprestimosModel {Id = 1, Recebedor = "Teresa", Fornecedor = "Schutz", LivroEmprestado = "A New World", dataUltimaAtualizacao = DateTime.Now },
                new EmprestimosModel {Id = 2, Recebedor = "Victor", Fornecedor = "Mahls", LivroEmprestado = "Robin Hood", dataUltimaAtualizacao = DateTime.Now },
                // Add more items if needed
            };

        public EmprestimoController()
            {
                //EmprestimosModel itema = new EmprestimosModel { Recebedor = "Lucas Doe", Fornecedor = "Lola", LivroEmprestado = "A Revoada", dataUltimaAtualizacao = DateTime.Now };
                //contacts.Add(itema);

            }

            public ActionResult Index()
            {
            
                return View(contacts);
            }
            //public IActionResult Index()
            //{
            //    IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            //    return View(emprestimos);
            //}

            [HttpGet]
            public IActionResult Cadastrar()  //Qual a difeenca entra IActionResult E ActionResult???????????
            {
                Console.WriteLine("Cadastrar Get");
                foreach (EmprestimosModel exemplo in contacts)
                {
                    Console.WriteLine(exemplo.Id + exemplo.Recebedor);
                }

            return View();
            }


            [HttpGet]
            public ActionResult Editar(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                EmprestimosModel emprestimo = contacts.FirstOrDefault(x => x.Id == id); 

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
                //Console.WriteLine(id);
                EmprestimosModel chosenContact = contacts.FirstOrDefault( x => x.Id == id);
                if (chosenContact == null)
                {
                    return NotFound();
                }

                return View(chosenContact);

            }


            [HttpPost]
            public ActionResult Cadastrar(EmprestimosModel emprestimo)
            {
           
                if (ModelState.IsValid)
                {
                    emprestimo.Id = contacts.Count();
                    emprestimo.dataUltimaAtualizacao = DateTime.Now;
                
                    contacts.Add(emprestimo);
                    Console.WriteLine("Cadastrar Post");
                    foreach (EmprestimosModel exemplo in contacts)
                    {
                        Console.WriteLine(exemplo.Id + exemplo.Recebedor);
                    }
                //Console.WriteLine("Lenght:"+ contacts.Count());
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
            public IActionResult Editar(EmprestimosModel emprestimo)
            {
                if(ModelState.IsValid)
                {

                    contacts[emprestimo.Id] = emprestimo;
                    Console.WriteLine("Novo Recebedor:" + contacts[emprestimo.Id].Recebedor + "Novo Livro:" + contacts[emprestimo.Id].LivroEmprestado + "Id:" + contacts[emprestimo.Id].Id);
                    TempData["MensagemSucesso"] = "Edição realizada com sucesso";

                    return RedirectToAction("Index");
                }

                return View();
            }

            [HttpPost]
            public ActionResult Excluir(EmprestimosModel emprestimoToDelete)
            {
                Console.WriteLine(emprestimoToDelete.Id);
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


        }
    }
