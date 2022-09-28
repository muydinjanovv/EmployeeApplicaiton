using Microsoft.AspNetCore.Mvc;
using Task.Data;
using Task.Entities;
using Task.Mappers;
using Task.Models;
using Task.Repositories;

namespace Task.Controllers;
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _repo;
    private readonly ILogger<EmployeeController> _logger;
    private readonly AppDbContext _db;

    public EmployeeController(IEmployeeRepository repository, AppDbContext context, ILogger<EmployeeController> logger)
    {
        _repo = repository;
        _logger = logger;
        _db = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAllEmployeeAsync());
    }
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeViewModel obj)
    {
        if(ModelState.IsValid)
        {
            await _repo.InsertEmployeeAsync(obj.ToEntity());
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var employee = await _repo.GetEmployeeByIdAsync(id);
        
        if (employee is null)
            return NotFound();

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Employee obj)
    {
        if(ModelState.IsValid)
        {
            await _repo.UpdateEmployeeAsync(obj);
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if(ModelState.IsValid)
        {
            await _repo.DeleteEmployeeIdAsync((await _repo.GetEmployeeByIdAsync(id)).Id);
            return RedirectToAction("Index");
        }
        return BadRequest();
    }
}