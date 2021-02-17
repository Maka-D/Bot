using Microsoft.AspNetCore.Mvc;
using Project_1.AppServices.UserInputAppService;
using Project_1.AppServices.UserInputAppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Contollers
{
    public class HomeController :Controller
    {
        private readonly IUsers _user;
        public HomeController(IUsers user)
        {
            _user = user;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddQA()
        {
            return View();
        }
      
        [HttpPost]
        public JsonResult UsersInputProcessing(string UsersQuestion)
        {
            UsersInput user = new UsersInput();
            user.Question = UsersQuestion;
            var message = _user.UsersInputProcessing(user);
            return Json(message);    
        }

        [HttpGet]
        public IActionResult SeeQuestions()
        {
            var result = _user.Output();
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //goes to Delete method in Users class in AppServices and deletes the data from database with this Id
            _user.Delete(Id);
            return RedirectToAction("SeeQuestions");
        }
        [HttpPost]
        public IActionResult Addition(UsersInput input)
        {
            //goes to Registration method in Users class in AppServices and adds input to database
            _user.Registration(input);
            return RedirectToAction("AddQA");
        }

        [HttpPost]
        public IActionResult Edit(int Id)
        {
            var result = _user.Edit(Id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(string answer, string question, int Id)
        {
            _user.Update(answer, question, Id);
            return RedirectToAction("SeeQuestions");
        }

    }
}
