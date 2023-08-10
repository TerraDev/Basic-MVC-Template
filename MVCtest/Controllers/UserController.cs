using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCtest.Application;
using MVCtest.Domain;
using MVCtest.Mapping;
using MVCtest.ViewModels;

namespace MVCtest.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View((await _userService.GetAllUsers()).Select(x => Mapper.UsertoVM(x)));
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel userModel)
        {
            try
            {
                //userModel.Roles = new List<string>();
                if(ModelState.IsValid)
                {
                    var res = await _userService.Register(Mapper.VMtoUser(userModel));
                    if(res.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return View(userModel);
        }

        //set user password controller

        [HttpGet]
        public async Task<IActionResult> UserDetails(string userId)
        {
            AppUser user = await _userService.GetUserById(userId);
            return View(Mapper.UsertoVM(user));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string userId)
        {
            AppUser user = await _userService.GetUserById(userId);
            return View(Mapper.UsertoVM(user));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserViewModel viewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var res = await _userService.EditUser(Mapper.VMtoUser(viewModel));
                    if(res.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
            return View(viewModel);
        }

        [HttpGet]
        [ActionName("changePassword")]
        public IActionResult SetUserPassword(string userId)
        {
            //check if user with this id exists
            return View(
                new PasswordViewModel()
                {
                    userId = userId
                });
        }

        [HttpPost]
        [ActionName("changePassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetUserPassword(PasswordViewModel pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _userService.setUserPassword(pModel.userId, pModel.Password);
                    if (res.Succeeded)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return View(pModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                return View(Mapper.UsertoVM(await _userService.GetUserById(userId)));
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        [ActionName(nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUserPost(string userId)
        {
            try
            {
                await _userService.DeleteUser(await _userService.GetUserById(userId));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _userService.Register(
                        new AppUser{
                        Email = model.Email,
                        UserName = model.Username
                    },  model.Password);

                    return RedirectToAction(nameof(ItemController.Index), "Item");
                }
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
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
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _userService.Login(model.userName, model.Password, false);

                    if(res.Succeeded)
                        return RedirectToAction(nameof(ItemController.Index), "Item");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _userService.Logout();
                return RedirectToAction(nameof(ItemController.Index), "Item");
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
