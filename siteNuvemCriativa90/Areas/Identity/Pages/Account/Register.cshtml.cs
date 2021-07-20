using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using siteNuvemCriativa90.Controllers;
using siteNuvemCriativa90.Data;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ident<IdentityUser> userr;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly siteNuvemCriativa90DBContext _context;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            siteNuvemCriativa90DBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(50)]
            [Display(Name = "Nome")]
            public string Nome { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "Grupo Usuário")]
            public int IDGrupoUsuario { get; set; }
            [ForeignKey("IDGrupoUsuario")]
            [Display(Name = "Grupo Usuário")]
            public GrupoUsuario GrupoUsuario { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {

            ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario");
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            try
            {
                var user = new IdentityUser { UserName = Input.Nome, Email = Input.Email,   };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Confirme sua conta em nosso site <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clicando aqui</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("/Central");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario");
                }

            }
            catch (Exception e)
            {
                return NotFound(e);
            }

            return Page();
        }
    }
}
