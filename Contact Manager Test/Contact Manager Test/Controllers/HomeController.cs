using Contact_Manager_Test.Models;
using ContactManager.DAL.Entities;
using ContactManager.DLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contact_Manager_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Person> _personRepo;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Person> personRepo)
        {
            _logger = logger;
            _personRepo = personRepo;
        }

        public IActionResult Index()
        {
            var persons = _personRepo.Get();
            return View(persons);
        }

        [HttpPut]
        public IActionResult UpdatePerson(Person person)
        {
            _personRepo.Update(person);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletePerson(int Id)
        {
            _personRepo.Remove(Id);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}