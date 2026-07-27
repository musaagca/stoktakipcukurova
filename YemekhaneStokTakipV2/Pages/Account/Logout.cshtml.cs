using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LogoutModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _signInManager.SignOutAsync();

        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

        Response.Cookies.Delete(".AspNetCore.Identity.Application");

        return RedirectToPage("/Account/Login");
    }
}