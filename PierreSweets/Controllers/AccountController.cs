using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierreSweets.Models;
using System.Threading.Tasks;
using PierreSweets.ViewModels;

namespace PierreSweets.Controllers
{
  public class AccountController : Controller
  {
    private readonly PierreSweetsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ToDoListContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }
  }
}