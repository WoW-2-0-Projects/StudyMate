using AutoMapper;
using StudyMate.Application.MultipleOptionAnswers.Models;
using StudyMate.Domain.Entities;

namespace StudyMate.Infrastructure.MultipleOptionAnswers.Mappers;

public class MultipleOptionAnswerMapper:Profile
{
    public MultipleOptionAnswerMapper()
    {
        CreateMap<MultipleOptionAnswer, MultipleOptionAnswerDto>().ReverseMap();
    }
}