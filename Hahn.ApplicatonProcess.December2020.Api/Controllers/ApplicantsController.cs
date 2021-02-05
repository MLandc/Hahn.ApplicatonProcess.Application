using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.CreateApplicant;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.DeleteApplicant;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.UpdateApplicant;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantDetail;
using Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Queries.GetApplicantsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly LinkGenerator _linkGenerator;

        public ApplicantsController(IMediator mediator, LinkGenerator linkGenerator)
        {
            _mediator = mediator;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("all", Name = "GetAllApplicants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ApplicantsListVM>>> GetAllApplicants()
        {
            var dtos = await _mediator.Send(new GetApplicantsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetApplicantById")]
        public async Task<ActionResult<ApplicantDetailVM>> GetApplicantById(int id)
        {
            var getApplicantDetailQuery = new GetApplicantDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getApplicantDetailQuery));
        }

        [HttpPost(Name = "AddApplicant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateApplicantCommandResponse>> Create([FromBody] CreateApplicantCommand createApplicantCommand)
        {
            try
            {
                var response = await _mediator.Send(createApplicantCommand);
                if (!response.Success)
                {
                    return response;
                }

                var location = _linkGenerator.GetPathByAction("GetApplicantById", "Applicants", new { response.Applicant.Id });
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current applicant.");
                }

                return Created(location, response);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DAtabase failed to create new applicant.");
            }
        }

        [HttpPut(Name = "UpdateApplicant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateApplicantCommand updateApplicantCommand)
        {
            await _mediator.Send(updateApplicantCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteApplicant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteApplicantCommand = new DeleteApplicantCommand() { Id = id };
            await _mediator.Send(deleteApplicantCommand);
            return NoContent();
        }
    }
}
