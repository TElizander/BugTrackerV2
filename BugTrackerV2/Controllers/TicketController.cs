using BugTrackerV2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerV2.Controllers
{
    public class TicketController : Controller
    {
        private  ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Get the  data from the ticket table
            Ticket ticket = db.Tickets
                //.Include(c => c.TicketComments)
                .FirstOrDefault(i => i.TicketID == id);

            //Map to TicketDetailViewModel

            TicketDetailViewModel ticketDetailViewModel = new TicketDetailViewModel();

            ticketDetailViewModel.TicketID = ticket.TicketID;
            ticketDetailViewModel.SubmitterID = ticket.SubmitterID;
            ticketDetailViewModel.OwnerID = ticket.OwnerID;
            ticketDetailViewModel.Subject = ticket.Subject;
            ticketDetailViewModel.Description = ticket.Description;
            ticketDetailViewModel.Environment = ticket.Environment;
            ticketDetailViewModel.Priority = ticket.Priority;
            ticketDetailViewModel.Status = ticket.Status;
            ticketDetailViewModel.SubmitDate = ticket.SubmitDate;

            
            return View(ticketDetailViewModel);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subject,Description,Environment,Priority")] Ticket ticket, HttpPostedFileBase file)
        {
            ticket.SubmitterID = User.Identity.GetUserId();
            ticket.SubmitDate = System.DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();

                try
                {
                    if (file.ContentLength > 0)
                    {
                        TicketAttachment ticketAttachment = new TicketAttachment();

                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);

                        ticketAttachment.TicketID = ticket.TicketID;
                        ticketAttachment.UserID = User.Identity.GetUserId();
                        ticketAttachment.FileName = file.FileName;
                        ticketAttachment.AttachedDate = System.DateTime.Now;

                        db.TicketAttachments.Add(ticketAttachment);
                        db.SaveChanges();
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "File Uploaded Successfully";
                }
                catch
                {
                    ViewBag.Message = "File upload failed";
                }

                return RedirectToAction("Details", new { id = ticket.TicketID });
            }
            return View(ticket); 
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
