using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toci.Call2Me.Database.Persistence.Models;

[ApiController]
[Route("api/[controller]")]
public class ConversationController : ControllerBase
{
    private readonly TociCall2MeContext _context;

    public ConversationController(TociCall2MeContext context)
    {
        _context = context;
    }

    // Endpoint do tworzenia nowej rozmowy
    [HttpPost]
    public async Task<ActionResult<ConversationDto>> StartConversation()
    {
        var conversation = new Conversation();
        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetConversation), new { id = conversation.Id }, new ConversationDto
        {
            Id = conversation.Id,
            StartTime = conversation.StartTime
        });
    }

    // Endpoint do dodawania transkrypcji do istniejącej rozmowy
    [HttpPost("{conversationId}/transcripts")]
    public async Task<ActionResult> AddTranscript(int conversationId, [FromBody] CreateTranscriptDto transcriptDto)
    {
        var conversation = await _context.Conversations.FindAsync(conversationId);
        if (conversation == null)
        {
            return NotFound("Rozmowa nie znaleziona.");
        }

        var transcript = new Transcript
        {
            ConversationId = conversationId,
            Speaker = transcriptDto.Speaker,
            Text = transcriptDto.Text,
            Timestamp = DateTime.UtcNow
        };

        _context.Transcripts.Add(transcript);
        await _context.SaveChangesAsync();

        return Ok("Transkrypcja dodana pomyślnie.");
    }

    // Endpoint do pobierania rozmowy z transkrypcją
    [HttpGet("{id}")]
    public async Task<ActionResult<ConversationDto>> GetConversation(int id)
    {
        var conversation = await _context.Conversations
            .Include(c => c.Transcripts)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (conversation == null)
        {
            return NotFound();
        }

        var conversationDto = new ConversationDto
        {
            Id = conversation.Id,
            StartTime = conversation.StartTime,
            Transcripts = conversation.Transcripts.Select(t => new TranscriptDto
            {
                Speaker = t.Speaker,
                Text = t.Text,
                Timestamp = t.Timestamp
            }).ToList()
        };

        return Ok(conversationDto);
    }
}
