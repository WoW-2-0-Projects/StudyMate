using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyMate.Application.MultipleOptionAnswers.Queries;
using StudyMate.Application.MultipleOptionAnswers.Service;

namespace StudyMate.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class MultipleOptionAnswerController(
    IMediator mediator,
    IMapper mapper,
    IMultipleOptionAnswerService multipleOptionAnswerService) : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> Get([FromQuery] GetMultipleOptionAnswerQuery query,
                                              CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }
}