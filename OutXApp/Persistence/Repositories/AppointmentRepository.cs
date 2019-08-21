﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OutXApp.Core.Models;
using OutXApp.Core.Repositories;
using OutXApp.Core.ViewModel;

namespace OutXApp.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all appointments
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments
                .Include(p => p.Course)
                .Include(d => d.Doctor)
                .ToList();
        }
        /// <summary>
        /// Get appointments for single Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAppointmentWithCourse(int id)
        {
            return _context.Appointments
                .Where(p => p.CourseId == id)
                .Include(p => p.Course)
                .Include(d => d.Doctor)
                .ToList();
        }
        /// <summary>
        /// Get appointments for single doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAppointmentByDoctor(int id)
        {
            //return (from a in _context.Appointments where a.DoctorId == id select a).AsEnumerable();

            return _context.Appointments
                .Where(d => d.DoctorId == id)
                .Include(p => p.Course)
                .ToList();
        }

        /// <summary>
        /// Get upcomming appointments for doctor - Admin section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetTodaysAppointments(int id)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Appointments
                .Where(d => d.DoctorId == id && d.StartDateTime >= today)
                .Include(p => p.Course)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }
        /// <summary>
        /// Get upcomming appointments for specific doctor
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetUpcommingAppointments(string userId)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Appointments
                .Where(d => d.Doctor.PhysicianId == userId && d.StartDateTime >= today && d.Status==true)
                .Include(p => p.Course)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }

        public IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel)
        {
            var result = _context.Appointments.Include(p => p.Course).Include(d => d.Doctor).AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Name))
                    result = result.Where(a => a.Doctor.Name == searchModel.Name);
                if (!string.IsNullOrWhiteSpace(searchModel.Option))
                {
                    if (searchModel.Option == "ThisMonth")
                    {
                        result = result.Where(x => x.StartDateTime.Year == DateTime.Now.Year && x.StartDateTime.Month == DateTime.Now.Month);
                    }
                    else if (searchModel.Option == "Pending")
                    {
                        result = result.Where(x => x.Status == false);
                    }
                    else if (searchModel.Option == "Approved")
                    {
                        result = result.Where(x => x.Status);
                    }
                }
            }

            return result;

        }
        /// <summary>
        /// Get Daily appointments
        /// </summary>
        /// <param name="getDate"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate)
        {
            return _context.Appointments.Where(a => DbFunctions.DiffDays(a.StartDateTime, getDate) == 0)
                .Include(p => p.Course)
                .Include(d => d.Doctor)
                .ToList();
        }

        /// <summary>
        /// Validate appointment date and time
        /// </summary>
        /// <param name="appntDate"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ValidateAppointment(DateTime appntDate, int id)
        {
            return _context.Appointments.Any(a => a.StartDateTime == appntDate && a.DoctorId == id);
        }
        /// <summary>
        /// Get number of appointments for defined Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAppointments(int id)
        {
            return _context.Appointments.Count(a => a.CourseId == id);
        }


        /// <summary>
        /// Get single appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }

    }
}