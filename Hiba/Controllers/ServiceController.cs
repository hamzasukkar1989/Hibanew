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
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Coaching");
            return View("~/Views/Service/Coaching/Index.cshtml",data);
        }
        public IActionResult NutritionAndHealthConsultations()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Nutrition And Health Consultations");
            return View("~/Views/Service/NutritionAndHealthConsultations/Index.cshtml",data);
        }
        public IActionResult FinancialConsults()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Financial Consults");
            return View("~/Views/Service/EconomicConsultations/FinancialConsults.cshtml", data);
        }
        public IActionResult EconomicConsults()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Economic Consults");
            return View("~/Views/Service/EconomicConsultations/EconomicConsults.cshtml",data);
        }
        public IActionResult ManagementConsults()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Management Consults");
            return View("~/Views/Service/EconomicConsultations/ManagementConsults.cshtml", data);
        }
        public IActionResult EconomicConsultations()
        {
            return View("~/Views/Service/EconomicConsultations/Index.cshtml");
        }
        public IActionResult FamilyConsultations()
        {
            ViewBag.Title1 = "Family";
            ViewBag.Title2 = "Counseling";
            ViewBag.AdolescentCounseling = "Adolescent Counseling";
            ViewBag.MaritalConsultations = "Marital Consultations";
            ViewBag.RaisingChildrenConsultations = "Raising Children Consultations";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "استشارات";
                ViewBag.Title2 = "أسرية";
                ViewBag.AdolescentCounseling = "استشارات في تربية الأبناء";
                ViewBag.MaritalConsultations = "استشارات زوجية";
                ViewBag.RaisingChildrenConsultations = "استشارات للمراهقين";
            }
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/Index.cshtml");
        }
        public IActionResult RaisingChildrenConsultations()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Raising Children Consultations");
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/RaisingChildrenConsultations.cshtml",data);
        }

        public IActionResult MaritalConsultations()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Marital Consultations");
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/MaritalConsultations.cshtml",data);
        }
        public IActionResult AdolescentCounseling()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Adolescent Counseling");
            return View("~/Views/Service/SocialAndImprovementConsultations/FamilyConsultations/AdolescentCounseling.cshtml",data);
        }

        public IActionResult PsychologicalCounseling()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Psychological Counseling");
            return View("~/Views/Service/SocialAndImprovementConsultations/PsychologicalCounseling/Index.cshtml",data);
        }

        public IActionResult SocialAndImprovementConsultations()
        {
            ViewBag.FamilyConsultations = "Family Consultations";
            ViewBag.PsychologicalCounseling = "Psychological Counseling";
            ViewBag.SelfImprovementConsultations = "Self Improvement Consultations";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.FamilyConsultations = "استشارات أسرية";
                ViewBag.PsychologicalCounseling = "استشارات نفسية";
                ViewBag.SelfImprovementConsultations = "تنمية وتطوير ذاتي";
            }
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Social And Improvement Consultations" && p.Lang == cultureInfo.ToString());
            return View("~/Views/Service/SocialAndImprovementConsultations/Index.cshtml",data);
        }

        public IActionResult SelfImprovementConsultations()
        {
           
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
            var data = _context.TrainingProgram.SingleOrDefault(tp => tp.ID == id);
            return View("~/Views/Service/Training/Course.cshtml",data);
        }
        public IActionResult Training()
        {
            ViewBag.Title1 = "Training";
            ViewBag.Title2 = "courses";
            ViewBag.OnlineCourses = "Online Courses";
            ViewBag.TrainingPrograms = "Training Programs";
            ViewBag.CurrentTrainingCourses = "Current Training Courses";
            if (cultureInfo.ToString() == "ar")
            {
                ViewBag.Title1 = "البرامج";
                ViewBag.Title2 = "التدربية";
                ViewBag.OnlineCourses = "الدورات النشطة";
                ViewBag.TrainingPrograms = "البرامج التدريبية";
                ViewBag.CurrentTrainingCourses = "الدورات الحالية";
            }
            return View("~/Views/Service/Training/Index.cshtml");
        }


        public IActionResult YouthProblems()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Youth Problems");
            return View("~/Views/Service/SocialAndImprovementConsultations/SelfImprovementConsultations/YouthProblems.cshtml",data);
        }

        public IActionResult CareerProblem()
        {
            var data = _context.Pages.SingleOrDefault(p => p.Name == "Career Problem");
            return View("~/Views/Service/SocialAndImprovementConsultations/SelfImprovementConsultations/CareerProblem.cshtml",data);
        }

        public IActionResult LecturesWorkshops()
        {
            var data = _context.LectureWorkshops.ToList();
            return View("~/Views/Service/LecturesWorkshops/Index.cshtml",data);
        }

    }
}
