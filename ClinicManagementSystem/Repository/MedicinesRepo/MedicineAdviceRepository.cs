using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class MedicineAdviceRepository :IMedicineAdviceRepository
    {
        private readonly ClinicManagementSystemDBContext _context;

        //constructor based dependency injection
        public MedicineAdviceRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        #region Get all medicine advices
        public async Task<List<MedicineAdviceView>> GetAllMedicineAdvicess()
        {
            if (_context != null)
            {
                return await (from s in _context.Staff
                              join
     p in _context.Appointment on s.StaffId equals p.DoctorId
                              join a in _context.Patient on p.PatientId equals a.PatientId
                              join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                              join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                              join md in _context.Medicines on ml.MedicineId equals md.MedicineId
                              select new MedicineAdviceView
                              {
                                  AppointmentId = p.AppointmentId,
                                  PatientId = p.PatientId,
                                  Patient = a.PatientName,
                                  medicineList = (from s in _context.Staff
                                                  join p in _context.Appointment on s.StaffId equals p.DoctorId
                                                  join a in _context.Patient on p.PatientId equals a.PatientId
                                                  join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                                                  join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                                                  join mde in _context.Medicines on ml.MedicineId equals mde.MedicineId
                                                  where p.AppointmentId == m.AppointmentId
                                                  select new MedicineView
                                                  {
                                                      Medicine = mde.MedicineName,
                                                      MedicineDescription = mde.MedicineDescription,
                                                      MedicinePrice = mde.MedicinePrice


                                                  }


                                  ).ToList()

                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

    }
}
