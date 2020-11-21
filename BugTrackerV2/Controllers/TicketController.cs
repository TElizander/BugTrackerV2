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
using System.Data.Entity;

namespace BugTrackerV2.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private  ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ticket
        public ActionResult Index(string? SubmitterId)
        {
            //Check if a SubmitterId was passed, if not, send all tickets, if it was, send only ticketrs where the submitter id matches
            var ticketList = SubmitterId == null ? 
                db.Tickets.ToList() : 
                db.Tickets.ToList().Where(i => i.SubmitterID == SubmitterId);


            return View(ticketList);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Get the data from the ticket table and all comments associated with the ticket
            Ticket ticket = db.Tickets
                .Include(i => i.TicketComments)
                .Include(i => i.TicketAttachments)
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

            ticketDetailViewModel.TicketComments = ticket.TicketComments;
            ticketDetailViewModel.TicketAttachments = ticket.TicketAttachments;

            
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
                        string _directory = Server.MapPath("~/UploadedFiles/" + ticket.TicketID);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles/" + ticket.TicketID), _FileName);

                        ticketAttachment.TicketID = ticket.TicketID;
                        ticketAttachment.UserID = User.Identity.GetUserId();
                        ticketAttachment.FileName = Path.GetFileName(file.FileName);
                        ticketAttachment.FileLocation = _path;
                        ticketAttachment.AttachedDate = System.DateTime.Now;
                        db.TicketAttachments.Add(ticketAttachment);
                        db.SaveChanges();

                        System.IO.Directory.CreateDirectory(_directory);
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

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateComment")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "TicketID,CommentDescription")] TicketComment ticketComment)
        {
            ticketComment.PostDate = System.DateTime.Now;
            ticketComment.UserID = User.Identity.GetUserId();

                if (ModelState.IsValid)
                {
                    db.TicketComments.Add(ticketComment);
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = ticketComment.TicketID });
                }


            return RedirectToAction("Details", new { id = ticketComment.TicketID, ticketComment });
        }

        public FilePathResult DownloadTicketFile(string fileName, int ticketId)
        {
            return new FilePathResult(@"~/UploadedFiles/" + ticketId.ToString() + "/" + fileName, MimeMapping.GetMimeMapping(fileName));
        }
    }
}
