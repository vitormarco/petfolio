using Microsoft.AspNetCore.Mvc;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class PetfolioApiBaseController : ControllerBase
{
}
