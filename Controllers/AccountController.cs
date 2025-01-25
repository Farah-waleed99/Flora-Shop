using Microsoft.AspNetCore.Mvc;
using Master.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Master.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> _signInManager,
             RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            signInManager = _signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            ApplicationUser user = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };

            var r = await userManager.CreateAsync(user, model.Password);
            if (r.Succeeded)

            {
                var roleResult = await userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Login");
            }
            foreach (var err in r.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View(model);



        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Dashboard" });

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "default" });
                    }
                }
                ModelState.AddModelError("", "Invalid User or password");
                return View(model);

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]

        public async Task<IActionResult> RolesList()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> CreateRole(CreateRoleViewModel model)

        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName,
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RolesList));
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);

        }


        public async Task<IActionResult> EditRole(string id)
        {

            if (id == null)
            {
                return NotFound();
            }


            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            EditViewModel model = new EditViewModel
            {
                RoleName = role.Name!,
                RoleId = role.Id


            };
            return View(model);
        }


        [HttpPost]

        public async Task<IActionResult> EditRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var x = await _roleManager.FindByIdAsync(model.RoleId);
                if (x == null) { return NotFound(); };
                x.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(x);
                if (result.Succeeded)
                { return RedirectToAction(nameof(RolesList)); }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(string? id)
        {

            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList");

                }
                return NotFound();
            }



            return RedirectToAction("RolesList");
        }
    }
}

