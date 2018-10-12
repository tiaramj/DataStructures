using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackQueueDictionary.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<string> CueQueue = new Queue<string>();
        
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.CueQueue = CueQueue;
            return View();
        }

        public ActionResult AddOne()
        {
            CueQueue.Enqueue("New Entry " + (CueQueue.Count + 1));
            ViewBag.CueQueue = CueQueue;
            return View("Index");
        }

        public ActionResult AddHuge()
        {
            CueQueue.Clear();
            for (int i = 0; i < 2000; i++)
            {
                CueQueue.Enqueue("New Entry " + (CueQueue.Count + 1));
            }
            ViewBag.CueQueue = CueQueue;
            return View("Index");
        }

        public ActionResult DisplayEntries()
        {
            //Displays all items in the queue. If the queue is empty, a message will inform the user.
            if (CueQueue.Count == 0)
            {
                ViewBag.Comments = "No values found in the cue ball queue.";
            }
            else
            {
                ViewBag.CueQueue = CueQueue;
            }
            return View("Index");
        }

        public ActionResult DeleteOne()
        {
            //Deletes (dequeues) one item from the queue
            if (CueQueue.Count != 0)
            {
                CueQueue.Dequeue();
                ViewBag.CueQueue = CueQueue;
            }
            else
            {
                ViewBag.CueQueue = CueQueue;
                ViewBag.Comments = "Deletion action could not be completed. Queue is empty.";
            }
            return View("Index");
        }

        public ActionResult ClearEntries()
        {
            //Clears the queue
            CueQueue.Clear();
            ViewBag.CueQueue = CueQueue;
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
            if (CueQueue.Contains("New Entry " + rndEntry))
            {
                sw.Stop();
                ts = sw.Elapsed;
                ViewBag.Comments = "Entry " + rndEntry + " found. Time: " + ts;
            }
            else
            {
                sw.Stop();
                ts = sw.Elapsed;
                ViewBag.Comments = "Entry " + rndEntry + " not found. Time spent searching cue ball: " + ts;
            }
            ViewBag.CueQueue = CueQueue; //Updates the ViewBag to display in the View 
            return View("Index");
        }
    }
}