using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackQueueDictionary.Controllers
{
    public class StackController : Controller
    {
        public static Stack<string> PanStack = new Stack<string>(); //static means it lives until the program dies
        
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.PanStack = PanStack; //Allows stack to exist before running other items
            return View();
        }

        public ActionResult AddOne()
        {
            //Adds (pushes) a single item to the stack
            PanStack.Push("New Entry " + (PanStack.Count + 1));
            ViewBag.PanStack = PanStack;
            return View("Index");
        }

        public ActionResult AddHuge()
        {
            //Clear data structure
            PanStack.Clear();
            //Adds 2,000 items to the data structure
            for (int i = 0; i < 2000; i++)
            {
                PanStack.Push("New Entry " + (PanStack.Count + 1));
            }
            ViewBag.PanStack = PanStack;
            return View("Index");
        }

        public ActionResult DisplayEntries()
        {
            //Displays all items in the stack. If the stack is empty, a message will inform the user.
            if (PanStack.Count == 0)
            {
                ViewBag.Comments = "No values found in pancake stack";
            }
            else
            {
                ViewBag.PanStack = PanStack;
            }
            return View("Index");
        }

        public ActionResult DeleteOne()
        {
            //Deletes (pops) one item from the stack
            if (PanStack.Count != 0)
            {
                PanStack.Pop();
                ViewBag.PanStack = PanStack;
            }
            else
            {
                ViewBag.PanStack = PanStack;
                ViewBag.Comments = "Deletion action could not be completed. Stack is empty.";
            }
            return View("Index");
        }

        public ActionResult ClearEntries()
        {
            //Clears the stack
            PanStack.Clear();
            ViewBag.PanStack = PanStack;
            return View("Index");
        }

        public ActionResult Search()
        {
            //Creates random number generator, stopwatch object, timespan object, and a random variable to hold the generated number.
            Random rnd = new Random();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            int rndEntry = rnd.Next(0, 2001);

            //Searches the pancake stack to find an entry matching the randomly generated number.
            sw.Start();
            if (PanStack.Contains("New Entry " + rndEntry))
            {
                sw.Stop();
                ts = sw.Elapsed;
                ViewBag.Comments = "Entry " + rndEntry + " found. Time: " + ts;
            }
            else
            {
                sw.Stop();
                ts = sw.Elapsed;
                ViewBag.Comments = "Entry " + rndEntry + " not found. Time to search pancake stack: " + ts;
            }
            ViewBag.PanStack = PanStack; //Updates the ViewBag to display in the View 
            return View("Index");
        }
    }
}