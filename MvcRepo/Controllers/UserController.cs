using MvcRepo.DataContext;
using MvcRepo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRepo.Controllers
{
    public class UserController : Controller
    {

        public IRepo<user> repo;
        public UserController()
        {
             repo = new Repo<user>();
        }
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
         
          return View(from m in repo.Collection() select m);
        }

       
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(user model) 
        {
            repo.Insert(model);
            repo.Commit();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            user info=repo.Find(id);
             return View(info);

        }
        [HttpPost]
        public ActionResult Edit(int id,user info) 
        {
            repo.Update(info);
            repo.Commit();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            user info = repo.Find(id);
            return View(info);
        }



        [HttpDelete]
        [Route("/delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Commit();
            return RedirectToAction("Index");
        }
    }
}