using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace YemekhaneStokTakipV2.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
            public string UserName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Şifre zorunludur.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public bool RememberMe { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Giriş işlemini biraz sonra ekleyeceğiz.
            return RedirectToPage("/Index");
        }
    }
}