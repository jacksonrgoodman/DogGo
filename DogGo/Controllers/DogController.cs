using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DogGo.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepo;

        //TODO ASP.NET will give us an instance of our Dog Repository. This is called "Dependency Injection"
        public DogController(IDogRepository dogRepository)
        {
            _dogRepo = dogRepository;
        }
        //TODO GET: Dogs
        public ActionResult Index()
        {
            List<Dog> dogs = _dogRepo.GetAllDogs();

            return View(dogs);
        }
        //TODO GET: Walkers/Details/*example ID*
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }
        //TODO GET: Dogs/Create
        public IActionResult Create()
        {
            return View();
        }
        //TODO POST: Dogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                _dogRepo.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            return View(dog);
        }
        //TODO POST: Owners/Delete/*EXAMPLE ID*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.DeleteDog(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
        //TODO GET: Dogs/Edit/*EXAMPLE ID*
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }
        //TODO POST: Dogs/Edit/*EXAMPLE ID*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                _dogRepo.UpdateDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
    }
}
