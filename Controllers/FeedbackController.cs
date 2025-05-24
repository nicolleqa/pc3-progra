using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc3_progra.Data;
using pc3_progra.Models;

namespace pc3_progra.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FeedbackController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
    {
        return await _context.Feedbacks.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
    {
        var existingFeedback = await _context.Feedbacks
            .FirstOrDefaultAsync(f => f.PostId == feedback.PostId);

        if (existingFeedback != null)
        {
            return BadRequest("Ya existe una reaccion para este post");
        }

        feedback.Fecha = DateTime.Now;
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFeedbacks), new { id = feedback.Id }, feedback);
    }
}