using Microsoft.AspNetCore.Mvc;
using PierreSweets.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

//new using directives
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierreSweets.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierreSweetsContext _db;
    private readonly UserManager<ApplicationUser> _userManager; //new line

    public TreatsController(UserManager<ApplicationUser> userManager, PierreSweetsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

     public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id);
      return View(userTreats);
    }
  }
}