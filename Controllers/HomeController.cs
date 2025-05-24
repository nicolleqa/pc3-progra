using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pc3_progra.Models;
using pc3_progra.Services;

namespace pc3_progra.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INewsService _newsService;

    public HomeController(ILogger<HomeController> logger, INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var posts = await _newsService.GetPostsAsync();
            return View(posts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener los posts");
            return RedirectToAction(nameof(Error));
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var post = await _newsService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.Author = await _newsService.GetUserByIdAsync(post.UserId);
            post.Comments = await _newsService.GetCommentsByPostIdAsync(id);
            
            return View(post);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener el detalle del post {id}");
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}