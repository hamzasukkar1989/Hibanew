using Hiba.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hiba.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;         
        }
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Coaching()
        {
            var pagedata = _context.Pages.SingleOrDefault(p => p.Name == "Coaching" && p.Lang == cultureInfo.ToString());
            if (pagedata!=null)
            {
                ViewBag.Title1 = pagedata.Title1;
                ViewBag.Title2 = pagedata.Title2;
                ViewBag.Image = pagedata.Image;
                ViewBag.Text = pagedata.Text;
                ViewBag.align = "left";
            }
           
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
            }
            var data = _context.Coaching.Where(c => c.Lang == cultureInfo.ToString()).ToList();
            return View("~/Views/Service/Coaching/Index.cshtml",data);
        }
        public IActionResult Coach(int id)
        {
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
            }
            var data = _context.Coaching.SingleOrDefault(c => c.ID == id && c.Lang == cultureInfo.ToString());
            return View("~/Views/Service/Coaching/Coach.cshtml", data);
        }

        public IActionResult NutritionAndHealthConsultations()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Nutrition And Health Consultations" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/NutritionAndHealthConsultations/Index.cshtml",data);
        }
        public IActionResult FinancialConsults()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Financial Consults" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/EconomicConsultations/FinancialConsults.cshtml", data);
        }
        public IActionResult EconomicConsults()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Economic Consults" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/EconomicConsultations/EconomicConsults.cshtml",data);
        }
        public IActionResult ManagementConsults()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Management Consults" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/EconomicConsultations/ManagementConsults.cshtml", data);
        }
        public IActionResult EconomicConsultations()
        {
            ViewBag.Title1 = "Economic";
            ViewBag.Title2 = "Consultations";
            ViewBag.FinancialConsults = "Financial Consults";
            ViewBag.EconomicConsults = "Economic Consults";
            ViewBag.ManagementConsults = "Management Consults";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
                ViewBag.Title1 = "استشارات";
                ViewBag.Title2 = "اقتصادية";
                ViewBag.FinancialConsults = "استشارات مالية";
                ViewBag.EconomicConsults = "استشارات اقتصادية";
                ViewBag.ManagementConsults = "استشارات إدارية";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Economic Consultations" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/EconomicConsultations/Index.cshtml",data);
        }
        public IActionResult FamilyConsultations()
        {
            ViewBag.Title1 = "Family";
            ViewBag.Title2 = "Counseling";
            ViewBag.AdolescentCounseling = "Adolescent Counseling";
            ViewBag.MaritalConsultations = "Marital Consultations";
            ViewBag.RaisingChildrenConsultations = "Raising Children Consultations";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "استشارات";
                ViewBag.Title2 = "أسرية";
                ViewBag.AdolescentCounseling = "استشارات للمراهقين";
                ViewBag.MaritalConsultations = "استشارات زوجية";
                ViewBag.RaisingChildrenConsultations = "استشارات في تربية الأبناء";
                ViewBag.align = "right";
            }
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/Index.cshtml");
        }
        public IActionResult RaisingChildrenConsultations()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Raising Children Consultations" && p.Lang == cultureInfo.ToString());
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/RaisingChildrenConsultations.cshtml",data);
        }

        public IActionResult MaritalConsultations()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Marital Consultations" && p.Lang == cultureInfo.ToString());
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/MaritalConsultations.cshtml",data);
        }
        public IActionResult AdolescentCounseling()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Adolescent Counseling" && p.Lang == cultureInfo.ToString());
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/AdolescentCounseling.cshtml",data);
        }

        public IActionResult PsychologicalCounseling()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Psychological Counseling"&& p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/SocialAndImprovementConsultations/PsychologicalCounseling/Index.cshtml",data);
        }

        public IActionResult SocialAndImprovementConsultations()
        {
            ViewBag.FamilyConsultations = "Family Consultations";
            ViewBag.PsychologicalCounseling = "Psychological Counseling";
            ViewBag.SelfImprovementConsultations = "Self Improvement Consultations";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.FamilyConsultations = "استشارات أسرية";
                ViewBag.PsychologicalCounseling = "استشارات نفسية";
                ViewBag.SelfImprovementConsultations = "تنمية وتطوير ذاتي";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Social And Improvement Consultations" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/SocialAndImprovementConsultations/Index.cshtml",data);
        }

        public IActionResult SelfImprovementConsultations()
        {

            ViewBag.Title1 = "Self And Improvement";
            ViewBag.Title2 = "Consultations";
            ViewBag.YouthProblems = "Youth Problems";
            ViewBag.CareerProblem = "Career Problem";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = " تنمية وتطوير ";
                ViewBag.Title2 = "ذاتي";
                ViewBag.YouthProblems = "مشكلات الشباب";
                ViewBag.CareerProblem = "استشارات مهنية";
                ViewBag.align = "right";
            }
                return View("~/Views/Service/SocialAndImprovementConsultations/SelfImprovementConsultations/Index.cshtml");
        }

        public IActionResult OnlineCourses()
        {
            var data = _context.TrainingProgram.Where
                (
                    t => t.TrainingType == Common.Enums.TrainingType.OnlineCourses &&
                    t.Lang == cultureInfo.ToString()
                ).ToList();
            return View("~/Views/Service/Training/OnlineCourses.cshtml", data);
        }
        public IActionResult CurrentTrainingCourses()
        {
            ViewBag.Title1 = "Current Training";
            ViewBag.Title2 = "Courses";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "البرامج";
                ViewBag.Title2 = "التدربية";
            }
            var data = _context.TrainingProgram.Where(t => t.TrainingType == Common.Enums.TrainingType.CurrentCourses && t.Lang == cultureInfo.ToString()).ToList();
            return View("~/Views/Service/Training/CurrentTrainingCourses.cshtml",data);
        }
        public IActionResult TrainingPrograms()
        {
            ViewBag.Title1 = "Training";
            ViewBag.Title2 = "Programs";
           
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "الدورات";
                ViewBag.Title2 = "التدربية";
            }
             
            var data = _context.TrainingProgram.Where(t => t.TrainingType == Common.Enums.TrainingType.TrainingPrograms && t.Lang== cultureInfo.ToString()).ToList();
            return View("~/Views/Service/Training/TrainingPrograms.cshtml", data);
        }

        public IActionResult Course(int id)
        {
            var data = _context.TrainingProgram.SingleOrDefault(tp => tp.ID == id && tp.Lang == cultureInfo.ToString());
            ViewBag.RegisterCourse = "Register A Course";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.RegisterCourse = "تسجيل دورة";
            }
            return View("~/Views/Service/Training/Course.cshtml",data);
        }
        public IActionResult Training()
        {
            ViewBag.Title1 = "Training";
            ViewBag.Title2 = "courses";
            ViewBag.OnlineCourses = "Online Courses";
            ViewBag.TrainingPrograms = "Training Programs";
            ViewBag.CurrentTrainingCourses = "Current Training Courses";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "البرامج";
                ViewBag.Title2 = "التدربية";
                ViewBag.OnlineCourses = "الدورات النشطة";
                ViewBag.TrainingPrograms = "البرامج التدريبية";
                ViewBag.CurrentTrainingCourses = "الدورات الحالية";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Training" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/Training/Index.cshtml",data);
        }


        public IActionResult YouthProblems()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Youth Problems" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/SocialAndImprovementConsultations/SelfImprovementConsultations/YouthProblems.cshtml",data);
        }

        public IActionResult CareerProblem()
        {
            ViewBag.ConsultationRequest = "Consultation Request";
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.ConsultationRequest = "طلب أستشارة";
                ViewBag.align = "right";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Career Problem" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/SocialAndImprovementConsultations/SelfImprovementConsultations/CareerProblem.cshtml",data);
        }

        public IActionResult LecturesWorkshops()
        {
            var pagedata = _context.Pages.SingleOrDefault(p => p.Name == "Lectures Workshops" && p.Lang == cultureInfo.ToString());
            ViewBag.Title1 = pagedata.Title1;
            ViewBag.Title2 = pagedata.Title2;
            ViewBag.Image = pagedata.Image;
            ViewBag.Text = pagedata.Text;
            ViewBag.align = "left";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
            }
            var data = _context.LectureWorkshops.Where(lw => lw.Lang== cultureInfo.ToString()).ToList();
            return View("~/Views/Service/LecturesWorkshops/Index.cshtml",data);
        }

        public IActionResult LectureWorkshop(int id)
        {
            ViewBag.align = "left";
            ViewBag.Title1 = "Lectures and";
            ViewBag.Title2 = "workshops";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.align = "right";
                ViewBag.Title1 = "محاضرات";
                ViewBag.Title2 = "وورشات عمل";
            }
            var data = _context.LectureWorkshops.SingleOrDefault(lw =>lw.ID==id && lw.Lang == cultureInfo.ToString());
            return View("~/Views/Service/LecturesWorkshops/LectureWorkshop.cshtml", data);
        }


    }
}
