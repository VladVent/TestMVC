using Contact_Manager_Test.Models;
using ContactManager.DAL.Entities;
using ContactManager.DLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;

namespace Contact_Manager_Test.Controllers
{
    public class UploadCSVController : Controller
    {
        private readonly IGenericRepository<Person> _personRepo;
        public IActionResult UploadCSV(UploadFileViewModel model)
        {
            try
            {
                var csvTable = new DataTable();
                var persons = new List<Person>();
                using (var reader = new StreamReader(model.File.OpenReadStream()))
                {
                    for (int i = 0; i < new DataTable().Columns.Count; i++)
                    {
                        var name = new DataTable().Rows[i][0].ToString();
                        var birth = new DataTable().Rows[i][1].ToString();
                        var maried = new DataTable().Rows[i][2].ToString();
                        var phone = new DataTable().Rows[i][3].ToString();
                        var salary = new DataTable().Rows[i][4].ToString();
                    }
                }
                _personRepo.CreateRange(persons);
                return Ok();
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }
    }
}
