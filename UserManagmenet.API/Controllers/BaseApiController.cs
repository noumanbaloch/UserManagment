using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserManagmenet.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public class BaseApiController : ControllerBase
{
}
