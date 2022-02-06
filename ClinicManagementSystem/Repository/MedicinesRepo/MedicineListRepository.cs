//using ClinicManagementSystem.Models;
//using ClinicManagementSystem.View_Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ClinicManagementSystem.Repository
//{
   
//    public class MedicineListRepository: IMedicineListRepository
//    {
//        //data fields
//        private readonly ClinicManagementSystemDBContext _context;

//        public MedicineListRepository(ClinicManagementSystemDBContext context)
//        {
//            _context = context;
//        }

//        #region get medicine details
//        public async Task<List<MedicineListView>> GetPrescriptionDetails()
//        {
//            if (_context != null)
//            {
//                return await _context.MedicineAdvice.ToListAsync() ;
//            }
//                //{
//                //    return await (
//                //        from
//                //        p in _context.Patient
//                //        join
//                //        a in _context.Appointment
//                //        on p.PatientId equals a.PatientId
//                //        join
//                //        m in _context.MedicineAdvice
//                //        on a.AppointmentId equals m.AppointmentId
//                //        join
//                //        md in _context.MedicineDetails
//                //        on m.MedicineAdviceId equals md.MedicineAdviceId
//                //        join
//                //        ml in _context.Medicines
//                //        on md.MedicineId equals ml.MedicineId
//                //        select new MedicineListView
//                //        {
//                //            PatientId = p.PatientId,
//                //            PatientName = p.PatientName,
//                //            DoctorsName = "" + (from a in _context.Appointment
//                //                                join s in _context.Staff
//                //                                on
//                //                                a.DoctorId equals s.StaffId
//                //                                select s.FirstName
//                //                              ).FirstOrDefault(),
//                //            DateOfPrescription = a.AppointmentDate,
//                //            DoctorsId = a.DoctorId,
//                //            Medicines = "" + (from md in _context.MedicineAdvice
//                //                              join m in _context.MedicineDetails
//                //                              on md.MedicineAdviceId equals m.MedicineAdviceId
//                //                              join mli in _context.Medicines
//                //                              on m.MedicineId equals mli.MedicineId
//                //                              where md.MedicineAdviceId == m.MedicineAdviceId
//                //                              select new MedicineView
//                //                              {
//                //                                  Medicine = mli.MedicineName,
//                //                                  Quantity = m.Quantity
//                //                              }.ToList()
//                //                              ).ToList()


//                //        }
//                //        );.ToListAsync();



//                //}
//                return null;
//        }

//        #endregion

//    }
//}
