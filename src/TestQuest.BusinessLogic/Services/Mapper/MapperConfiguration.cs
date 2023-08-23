using AutoMapper;
using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;
public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<DbTest, TestDto>()
            .ForMember(dest => 
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => 
                dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => 
                dest.TimeLimit,
                opt => opt.MapFrom(src => src.TimeLimit))
            .ForMember(dest => 
                dest.Difficulty,
                opt => opt.MapFrom(src => src.Difficulty))
            .ForMember(dest => 
                dest.Status,
                opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => 
                dest.TotalQuestions,
                opt => opt.MapFrom(src => src.TotalQuestions))
            .ForMember(dest => 
                dest.AuthorId,
                opt => opt.MapFrom(src => src.AuthorId))
            .ForMember(dest => 
                dest.AgeLimit,
                opt => opt.MapFrom(src => src.AgeLimit))
            .ForMember(dest => 
                dest.CreatedAt,
                opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => 
                dest.Category,
                opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => 
                dest.Questions,
                opt => opt.MapFrom(src => src.Questions))
            .ForMember(dest => 
                dest.Description,
                opt => opt.MapFrom(src => src.Description)).ReverseMap();
        

        CreateMap<DbCategory, CategoryDto>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.Category,
                opt => opt.MapFrom(src => src.Category))
            .ForMember(dest =>
                dest.Test,
                opt => opt.MapFrom(src => src.Test)).ReverseMap();
            
            
        CreateMap<DbOption, OptionDto>()
            .ForMember(dest =>
                dest.Option,
                opt => opt.MapFrom(src => src.Option))
            .ForMember(dest =>
                dest.Question,
                opt => opt.MapFrom(src => src.Question)).ReverseMap();
            

        CreateMap<DbQuestion, QuestionDto>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.Question,
                opt => opt.MapFrom(src => src.Question))
            .ForMember(dest =>
                dest.Answer,
                opt => opt.MapFrom(src => src.Answer))
            .ForMember(dest =>
                dest.Options,
                opt => opt.MapFrom(src => src.Options)).ReverseMap();


        CreateMap<DbResultTest, ResultTestDto>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.UserId,
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest =>
                dest.CorrectAnswers,
                opt => opt.MapFrom(src => src.CorrectAnswers))
            .ForMember(dest =>
                dest.ResultPoints,
                opt => opt.MapFrom(src => src.ResultPoints))
            .ForMember(dest =>
                dest.CompletedAt,
                opt => opt.MapFrom(src => src.CompletedAt)).ReverseMap();

        
        CreateMap<DbUser, UserDto>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest =>
                dest.Password,
                opt => opt.MapFrom(src => src.Password))
            .ForMember(dest =>
                dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest =>
                dest.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest =>
                dest.AccessLevel,
                opt => opt.MapFrom(src => src.AccessLevel))
            .ForMember(dest =>
                dest.Age,
                opt => opt.MapFrom(src => src.Age))
            .ForMember(dest =>
                dest.RatingPoints,
                opt => opt.MapFrom(src => src.RatingPoints))
            .ForMember(dest =>
                dest.Achievements,
                opt => opt.MapFrom(src => src.Achievements))
            .ForMember(dest =>
                dest.Role,
                opt => opt.MapFrom(src => src.Role)).ReverseMap();
            


        CreateMap<DbQuestionAnswer, QuestionAnswerDto>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id)).ReverseMap()
            .ForMember(dest =>
                dest.Answer,
                opt => opt.MapFrom(src => src.Answer))
            .ForMember(dest =>
                dest.QuestionText,
                opt => opt.MapFrom(src => src.QuestionText))
            .ForMember(dest =>
                dest.Status,
                opt => opt.MapFrom(src => src.Status)).ReverseMap();

        CreateMap<CommentAndTestScoreDto, DbCommentAndTestScore>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.UserId,
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest =>
                dest.TestId,
                opt => opt.MapFrom(src => src.TestId))
            .ForMember(dest =>
                dest.CommentText,
                opt => opt.MapFrom(src => src.CommentText))
            .ForMember(dest =>
                dest.Score,
                opt => opt.MapFrom(src => src.Score)).ReverseMap();
    }
}