using Microsoft.AspNetCore.Mvc;
using MVCtest.Application;
using MVCtest.Domain;
using MVCtest.Mapping;
using MVCtest.ViewModels;
using System.Collections.Generic;

namespace MVCtest.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View((await _itemService.GetAllItemsinPage(30, 1, null)).Select(x => Mapper.ItemToVM(x)));
        }

        [HttpGet]
        public async Task<IActionResult> Details(ulong itemId)
        {
            try
            {
                ItemViewModel items = Mapper.ItemToVM(await _itemService.GetItem(itemId));
                return View(items);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //TODO: sample task
        [HttpPost]
        public async Task<IActionResult> Create(ItemViewModel itemModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = await _itemService.CreateItem(Mapper.VMtoItem(itemModel), itemModel.Image);
                    if (res)
                        return RedirectToAction(nameof(Index));

                    ModelState.AddModelError("error", "Failed to create item.");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return View(itemModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(ulong itemId)
        {
            return View(Mapper.ItemToVM(await _itemService.GetItem(itemId)));
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdatePost(ItemViewModel itemModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = await _itemService.updateItem(Mapper.VMtoItem(itemModel),itemModel.Image);
                    if (res)
                        return RedirectToAction(nameof(Index));

                    ModelState.AddModelError("error", "Failed to update item.");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return View(itemModel);
        }

        public IActionResult Delete(ulong itemId)
        {
            return View(itemId);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeletePost(ulong itemId)
        {
            try
            {
                bool res = await _itemService.deleteItem(itemId);
                if (res)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("error", "Failed to delete item.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return View(itemId);
        }

        [HttpGet]
        public async Task<IActionResult> UseItem(ulong itemId)
        {
            try
            {
                ItemViewModel items = Mapper.ItemToVM(await _itemService.GetItem(itemId));
                return View(items);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ActionName(nameof(UseItem))]
        public async Task<IActionResult> UseItemPost(ulong itemId)
        {
            try
            {
                bool res = await _itemService.useItem(itemId, "B37C0271-DDD7-4124-AD52-69360F5A219F");
                if (res)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("error", "Failed to use item.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return View(itemId);
        }
    }
}
