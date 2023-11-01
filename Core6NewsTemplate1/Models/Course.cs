namespace WebOS.Models
{
    using System.ComponentModel.DataAnnotations;
    using static WebOS.Models.Common;

    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الدورة حقل مطلوب")]
        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 5)]
        [Display(Name = "إسم الدورة  باللغة العربية")]
        public string ArName { get; set; }


        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 5)]
        [Display(Name = "إسم الدورة  باللغة الانكليزية")]
        public string EnName { get; set; }


        [Display(Name = "الباقة")]
        public int CoursePackageId { get; set; }
        public CoursePackage CoursePackage { get; set; }

        [Display(Name = "أضيفت بواسطة")]
        [StringLength(450)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "تاريخ البدء ")]
        [DataType(DataType.DateTime)]
        public DateTime StartingDate { get; set; }

        [Display(Name = "تاريخ الإنتهاء ")]
        [DataType(DataType.DateTime)]
        public DateTime EndingDate { get; set; }

        [Display(Name = "تاريخ الاضافة")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime DateOfRecord { get; set; }


        [Display(Name = "عدد الدقائق المطلوبة")]
        public int TotalMinutes { get; set; }

        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "صورة")]
        public string Image { get; set; }

        [StringLength(50, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "رابط فيديو تعريفي")]
        public string IntroductoryVideo { get; set; }

        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "نشرة إعلانية")]
        public string Flyer { get; set; }

        [StringLength(250, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "ملف Pdf")]
        public string FilePdf { get; set; }

        [Display(Name = "الجهد المطلوب")]
        [StringLength(100, ErrorMessage = "العنوان طويل")]
        public string Effort { get; set; }

        [Display(Name = "هل برسوم؟")]
        public bool IsPaid { get; set; }

        [Display(Name = "رسوم الدورة")]
        public decimal CourseFees { get; set; }


        [Display(Name = "تمت الموافقة")]
        public bool IsAdminApproved { get; set; }


        [Display(Name = "مميزة")]
        public bool IsFeatured { get; set; }

        [StringLength(5000, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "تفاصيل الدورة")]
        public string Overview { get; set; }

        [StringLength(500, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "مقدمة")]
        public string Introduction { get; set; }

        [StringLength(5000, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "مخرجات الدورة")]
        public string LearningOutcomes { get; set; }

        [StringLength(5000, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "متطلبات دخول الدورة")]
        public string Requirements { get; set; }

        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "الكلمات المفتاحية")]
        public string Tags { get; set; }

        [Required]
        [Display(Name = "التخصص")]
        public string Speciality { get; set; }


        [StringLength(5000, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = " الفئة المستهدفة")]
        public string TargetStudents { get; set; }

        [StringLength(100, ErrorMessage = "عدد الحروف يجب أن يكون أقل من 100 حرف", MinimumLength = 0)]
        [Display(Name = " التواريخ المهمة")]
        public string ImportantDates { get; set; }

        [Required]
        [Display(Name = "اللغة")]
        public Language Language { get; set; }

        [Display(Name = "مسجلة مسبقا")]
        public bool IsPrerecorded { get; set; }

        [Display(Name = "محذوفة")]
        public bool IsDeleted { get; set; }

        [Display(Name = "مخفية")]
        public bool Ishidden { get; set; }

        [Display(Name = "مبلغ عنه")]
        public bool IsReported { get; set; }

        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        [Display(Name = "رابط البث المباشر")]
        public string LiveStreamLink { get; set; }
    }
}
