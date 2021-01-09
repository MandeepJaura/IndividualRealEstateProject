using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GropProject3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GropProject3.Controllers
{
    public class HomeListingController : Controller
    {
        private readonly IHomeListingRepository homeListingRepository;
        private readonly IUserRepository userRepository;
        
        public HomeListingController(IHomeListingRepository homeListingRepository, IUserRepository userRepository) {
            this.homeListingRepository = homeListingRepository;
            this.userRepository = userRepository;
        }
        
        public IActionResult UserViewPropertyList()
        {
            
            return View(homeListingRepository.GetHomeListings());
        }

        public IActionResult Details(int id) {
            HomeListing hlDetails = homeListingRepository.GetAHomeListing(id);
            int AgentId = hlDetails.AgentId;
            User userDetails = userRepository.GetUserById(AgentId);
            ViewBag.userData = userDetails;
            return View(homeListingRepository.GetAHomeListing(id));
        }

        public IActionResult AgentHomeListingView() {
            User activeUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "userObject");
            if (activeUser != null) {

                return View(homeListingRepository.GetHomeListingsByAgentBy(activeUser.Id));
            }
            return View("Invalid User");
        }

        public IActionResult CreateHomeListing() {
            User activeUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "userObject");
            ViewBag.userId = activeUser.Id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateHomeListing(HomeListing homeListing)
        {

            if (ModelState.IsValid)
            {
                homeListingRepository.Add(homeListing);
                return RedirectToAction("AgentHomeListingView");
            }
            return View();
        }

        public IActionResult EditHomeListing(int id) {
            User activeUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "userObject");
            ViewBag.userId = activeUser.Id;
            return View(homeListingRepository.GetAHomeListing(id));
        }

        [HttpPost]
        public IActionResult EditHomeListing(HomeListing changeedHome)
        {

            if (ModelState.IsValid)
            {
                homeListingRepository.Update(changeedHome);
                return RedirectToAction("AgentHomeListingView");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(homeListingRepository.GetAHomeListing(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HomeListing deleteItem)
        {
            homeListingRepository.Delete(deleteItem);
            return RedirectToAction("AgentHomeListingView");
           
        }
    }
}

