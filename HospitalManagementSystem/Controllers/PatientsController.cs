using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.Controllers
{
    public class PatientsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View(new PatientVM());
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,LastName,DateOfBirth,Gender,PhoneNumber,Address,Appointments,Operation")] PatientVM patient)
        {
            if (patient.Operation == "Add")
            {
                if (patient.Appointments == null)
                {
                    patient.Appointments = new List<Appointment>();
                }
                patient.Appointments.Add(new Appointment());
                return View(patient);
            }
            if (patient.Operation != null && patient.Operation.StartsWith("Delete"))
            {
                int.TryParse(patient.Operation.Replace("Delete-", ""), out int index);
                patient.Appointments.RemoveAt(index);
                return View(patient);
            }


            if (ModelState.IsValid)
            {
                var pat = patient.ToPatient();
                db.Patients.Add(pat);
                db.SaveChanges();                
               
              return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            var data = new PatientVM(patient);
            return View(data);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( PatientVM patient)
        {
            if (patient.Operation == "Add")
            {              
                patient.Appointments.Add(new Appointment());
                return View(patient);
            }
            if (patient.Operation != null && patient.Operation.StartsWith("Delete"))
            {
                int.TryParse(patient.Operation.Replace("Delete-", ""), out int index);
                patient.Appointments.RemoveAt(index);
                return View(patient);
            }

            if (ModelState.IsValid)
            {
                Patient del = db.Patients.Find(patient.PatientID);
                db.Appointments.RemoveRange(del.Appointments);
                db.Patients.Remove(del);
                db.SaveChanges();

                var pat = patient.ToPatient();
                db.Patients.Add(pat);
                db.SaveChanges();              
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Patient patient = db.Patients.Find(id);
            db.Appointments.RemoveRange(patient.Appointments);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
