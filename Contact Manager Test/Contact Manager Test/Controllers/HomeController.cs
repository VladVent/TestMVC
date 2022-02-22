using Contact_Manager_Test.Extensions;
using Contact_Manager_Test.Models;
using ContactManager.DAL.Context;
using ContactManager.DAL.Entities;
using ContactManager.DLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

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

        public IActionResult Index(string orderBy)
        {
            var persons = new List<Person>();
            switch (orderBy)
            {
                case "sortName":
                    persons = _personRepo.GetOrdered(p => p.Name).ToList();
                    break;
                case "sortDate":
                    persons = _personRepo.GetOrdered(p => p.DateOfBirth).ToList();
                    break;
                case "sortPhone":
                    persons = _personRepo.GetOrdered(p => p.Phone).ToList();
                    break;
                case "sortMarried":
                    persons = _personRepo.GetOrdered(p => p.IsMarried).ToList();
                    break;
                case "sortSalary":
                    persons = _personRepo.GetOrdered(p => p.Salary).ToList();
                    break;
                default:
                    persons = _personRepo.GetOrdered(p => p.Name).ToList();
                    break;
            }
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
        public IActionResult UploadCSV(UploadFileViewModel model)
        {
            var persons = new List<Person>();
            var streamReader = new StreamReader(model.File.OpenReadStream());

            var dataTable = streamReader.ConvertStreamToDataTable();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];

                var person = new Person();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    PropertyInfo propertyInfo = person.GetType()
                        .GetProperty(dataTable.Columns[j].ToString(), BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        propertyInfo.SetValue(person, Convert.ChangeType(row[j], propertyInfo.PropertyType), null);
                    }
                }

                persons.Add(person);
            }

            _personRepo.CreateRange(persons);
            return RedirectToAction("Index");
        }
    }
}