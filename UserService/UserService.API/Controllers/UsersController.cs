﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.BLL.DTO;
using UserService.BLL.Models;
using UserService.BLL.UseCases.UserUseCases.ResetPaswordUseCase;
using UserService.BLL.UseCases.UserUseCases.AskForResetPasswordUseCase;
using UserService.BLL.UseCases.UserUseCases.GetUserInfoUseCase;
using UserService.BLL.UseCases.UserUseCases.ListUsersWithPaginationUseCase;
using UserService.BLL.UseCases.UserUseCases.UpdateEmailUseCase;
using UserService.BLL.UseCases.UserUseCases.UpdatePasswordUseCase;
using UserService.BLL.UseCases.UserUseCases.UpdateUserUseCase;

namespace UserService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("update")]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromForm] UpdateUserDTO userDTO)
    {
        var userId = HttpContext.User.FindFirst("Id").Value;

        await _mediator.Send(new UpdateUserRequest(userDTO, userId));

        return Ok();
    }

    [HttpPost]
    [Route("update/email")]
    [Authorize]
    public async Task<IActionResult> UpdateEmail([FromBody] EmailDTO newEmail)
    {
        var userId = HttpContext.User.FindFirst("Id").Value;

        await _mediator.Send(new UpdateEmailRequest(newEmail.Email, userId));

        return Ok();
    }

    [HttpPost]
    [Route("update/password")]
    [Authorize]
    public async Task<ActionResult<string>> UpdatePassword([FromBody] UpdatePasswordDTO updatePasswordDTO)
    {
        var userId = HttpContext.User.FindFirst("Id").Value;

        var token = await _mediator.Send(new UpdatePasswordRequest(updatePasswordDTO, userId));

        return Ok(token);
    }

    [HttpGet]
    [Authorize(Policy = "admin")]
    public async Task<ActionResult<PaginatedListModel<UserInfoDTO>>> ListUsers([FromQuery] PaginationDTO pagination)
    {
        var users = await _mediator.Send(new ListUsersWithPaginationRequest(pagination));

        return Ok(users);
    }

    [HttpGet]
    [Route("info")]
    [Authorize]
    public async Task<ActionResult<UserInfoDTO>> GetUserInfo()
    {
        var userId = HttpContext.User.FindFirst("Id").Value;

        var user = await _mediator.Send(new GetUserInfoRequest(userId));

        return user;
    }

    [HttpGet]
    [Route("info/id")]
    [Authorize(Policy = "admin")]
    public async Task<ActionResult<UserInfoDTO>> GetUserInfo([FromQuery] string userId)
    {
        var user = await _mediator.Send(new GetUserInfoRequest(userId));

        return user;
    }

    [HttpGet]
    [Route("reset")]
    public async Task<IActionResult> AskForResetPassword([FromQuery] AskForResetPasswordRequest request)
    {
        await _mediator.Send(request);

        return Ok();
    }

    [HttpPost]
    [Route("reset")]
    public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        await _mediator.Send(request);

        return Ok();
    }
}
