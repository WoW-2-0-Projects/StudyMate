using Microsoft.EntityFrameworkCore;
using StudyMate.Api.Configurations;
using StudyMate.Domain.Entities;
using StudyMate.Persistence.DataContexts;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();

var appDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

if ((await appDbContext.Database.GetPendingMigrationsAsync()).Any())
    await appDbContext.Database.MigrateAsync();

// Adding multiple choice question and answer
appDbContext.MultipleChoiceQuestions.Add(new MultipleChoiceQuestion
{
    Id = Guid.Parse("DB45E62F-A971-4C20-8064-47B0EE3EC400"),
    QuestionContent = "Which of the following are programming languages?",
});

appDbContext.MultipleChoiceAnswers.Add(new MultipleChoiceQuestionAnswer()
{
    QuestionId = Guid.Parse("DB45E62F-A971-4C20-8064-47B0EE3EC400"),
    Answers =
    [
        "Python",
        "Java",
        "English",
        "Spanish"
    ]
});

// Adding binary question and answer
appDbContext.TrueFalseQuestions.Add(new TrueFalseQuestion
{
    Id = Guid.Parse("CB3E7DEA-1153-4AE6-8C20-A699BF7FD76D"),
    QuestionContent = "Is Inheritance most important feature of OOP?"
});

appDbContext.TrueFalseAnswers.Add(new TrueFalseQuestionAnswer()
{
    QuestionId = Guid.Parse("CB3E7DEA-1153-4AE6-8C20-A699BF7FD76D"),
    Answer = true
});

await appDbContext.SaveChangesAsync();

var multipleChoiceQuestions = await appDbContext.MultipleChoiceQuestions.ToListAsync();
var trueFalseQuestions = await appDbContext.TrueFalseQuestions.ToListAsync();

await app.ConfigureAsync();
await app.RunAsync();