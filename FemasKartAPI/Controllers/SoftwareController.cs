using Business.Requests;
using Business.Softwares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly ISoftwareService _softwareService;

        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        // GET: /Software
        public async Task<IActionResult> Index()
        {
            var result = await _softwareService.GetAllAsync();
            if (!result.IsSuccess) return View("Error", result.ErrorMessage);

            return View(result.Data);
        }

        // GET: /Software/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Software/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateSoftwareRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _softwareService.CreateAsync(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Software/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _softwareService.GetByIdAsync(id);
            if (!result.IsSuccess) return NotFound();

            var model = result.Data;
            return View(model);
        }

        // POST: /Software/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateSoftwareRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _softwareService.UpdateAsync(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: /Software/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _softwareService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Software/AddRevision/5
        //    public async Task<IActionResult> AddRevision(int softwareId)
        //    {
        //        var result = await _softwareService.GetByIdAsync(softwareId);
        //        if (!result.IsSuccess) return NotFound();

        //        //var model = new AddSoftwareRevisionViewModel
        //        //{
        //        //    SoftwareId = result.Data.Id,
        //        //    SoftwareName = result.Data.Name
        //        //};

        //    //    return View(model);
        //    //}

        //    // POST: /Software/AddRevision
        //    [HttpPost]
        //    public async Task<IActionResult> AddRevision(AddSoftwareRevisionViewModel model)
        //    {
        //        if (!ModelState.IsValid) return View(model);

        //        var request = new AddSoftwareRevisionRequest
        //        {
        //            SoftwareId = model.SoftwareId,
        //            ApprovalCode = "REV-" + model.RevisionNo,
        //            Notes = model.Notes,
        //            File = model.File
        //        };

        //        var result = await _softwareService.AddRevisionAsync(request);
        //        if (!result.IsSuccess)
        //        {
        //            //ModelState.AddModelError("", result.Message);
        //            return View(model);
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }
        //}
    }
}