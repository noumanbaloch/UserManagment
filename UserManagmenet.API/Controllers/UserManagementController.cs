using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Abstractions.Application;
using UserManagement.Domain.Dtos.UserManagement;

namespace UserManagmenet.API.Controllers;
public class UserManagementController : BaseApiController
{
    private readonly IUserManagmenetService _userManagementService;

    public UserManagementController(IUserManagmenetService userManagementService)
    {
        _userManagementService = userManagementService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetUsers()
        => Ok(await _userManagementService.GetUsersAsync());

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequestDto requestDto)
        => Ok(await _userManagementService.AddUserAsync(requestDto));


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDto requestDto)
        => Ok(await _userManagementService.UpdateUserAsync(requestDto));


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDto requestDto)
        => Ok(await _userManagementService.DeleteUserAsync(requestDto));

}
