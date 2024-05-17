using AutoMapper;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Models;

namespace E_Learning_Management_System
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>();

            CreateMap<InstructorDTO, Instructor>();
            CreateMap<Instructor, InstructorDTO>();


            CreateMap<QuizDTO, Quiz>();
            CreateMap<Quiz, QuizDTO>();

            CreateMap<LearnerDTO, Learner>();
            CreateMap<Learner, LearnerDTO>();

            CreateMap<AdminstratorDTO, Adminstrator>();
            CreateMap<Adminstrator, AdminstratorDTO > ();





















            CreateMap<CertificateDTO, Certificate>();   
            CreateMap<Certificate, CertificateDTO>();

            CreateMap<TheQuizzes, TheQuizzesDTO>();
            CreateMap<TheQuizzesDTO, TheQuizzes>();

            CreateMap<ContentDTO, Content>();
            CreateMap<Content, ContentDTO>();


        }
    }
}
