using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelectNationality.Application.Contracts;
using SelectNationality.Automapper;
using SelectNationality.Domain.Entities;
using SelectNationality.ViewModels;


namespace SelectNationality.Controllers
{
    public class GameController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper<Person, Models.Person> _personViewModelMapper;

        public GameController(IPersonService personService,IMapper<Person,Models.Person> personViewModelMapper)
        {
            _personService = personService;
            _personViewModelMapper = personViewModelMapper;
        }
        // GET: SelectNationality
        public ActionResult Index()
        {
            var persons = _personService.GetAll();
            var viewPersons = new List<Models.Person>();
            foreach(var person in persons)
                viewPersons.Add(_personViewModelMapper.Map(person));
            ViewData["people"] = JsonConvert.SerializeObject(viewPersons);
            return View();
        }

        // GET: SelectNationality/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelectNationality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelectNationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SelectNationality/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SelectNationality/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SelectNationality/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectNationality/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}