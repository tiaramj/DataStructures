using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackQueueDictionary.Controllers
{
    public class DictionaryController : Controller
    {
        public static Dictionary<string, int> UrbanDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.UrbanDictionary = UrbanDictionary;
            return View();
        }

        public ActionResult AddOne()
        {
            UrbanDictionary.Add("New Entry " + (UrbanDictionary.Count + 1), (UrbanDictionary.Count));
            ViewBag.UrbanDictionary = UrbanDictionary.Keys;
            return View("Index");
        }

        public ActionResult AddHuge()
        {
            UrbanDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                UrbanDictionary.Add("New Entry " + (UrbanDictionary.Count + 1), (UrbanDictionary.Count));
            }
            ViewBag.UrbanDictionary = UrbanDictionary.Keys;
            return View("Index");
        }

        public ActionResult DisplayEntries()
        {
            //Displays all items in the queue. If the queue is empty, a message will inform the user.
            if (UrbanDictionary.Count == 0)
            {
                ViewBag.Comments = "No values found in the Urban Dictionary.";
            }
            else
            {
                ViewBag.UrbanDictionary = UrbanDictionary.Keys;
            }
            return View("Index");
        }

        public ActionResult DeleteOne()
        {
            //Deletes (dequeues) one item from the queue
            if (UrbanDictionary.Count != 0)
            {
                UrbanDictionary.Remove("New Entry " + (UrbanDictionary.Count));
                ViewBag.UrbanDictionary = UrbanDictionary.Keys;
            }
            else
            {
                ViewBag.UrbanDictionary = UrbanDictionary;
                ViewBag.Comments = "Deletion action could not be completed. Urban Dictionary is empty.";
            }
            return View("Index");
        }

        public ActionResult ClearEntries()
        {
            //Clears the dictionary
            UrbanDictionary.Clear();
            ViewBag.UrbanDictionary = UrbanDictionary.Keys;
            return View("Index");
        }

        public ActionResult Search()
        {
            //Creates random number generator, stopwatch object, timespan object, and a random variable to hold the generated number.
            Random rnd = new Random();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan ts;
            int rndEntry = rnd.Next(0, 2001);

            //Searches the cue ball queue to find an entry matching the randomly generated number.
            sw.Start();
            if (UrbanDictionary.ContainsValue(rndEntry))
            {
                sw.Stop();
                ts = sw.Elapsed;
                ViewBag.Comments = "Entry " + rndEntry + " found. Time: " + ts;
            }
            else
            {
                sw.Stop();
                ts = sw.Elapsed;
                ViewBag.Comments = "Entry " + rndEntry + " not found. Time to search Urban Dictionary: " + ts;
            }
            ViewBag.UrbanDictionary = UrbanDictionary.Keys; //Updates the ViewBag to display in the View 
            return View("Index");
        }
    }
}