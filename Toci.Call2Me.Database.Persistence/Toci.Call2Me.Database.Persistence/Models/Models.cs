using System;
using System.Collections.Generic;

public class Conversation
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; } = DateTime.UtcNow; // Czas rozpoczęcia rozmowy

    public ICollection<Transcript> Transcripts { get; set; } = new List<Transcript>();
}


public class Transcript
{
    public int Id { get; set; }
    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }

    public string Speaker { get; set; } // Identyfikator rozmówcy (np. numer telefonu lub inne ID)
    public string Text { get; set; } // Tekst transkrypcji
    public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Czas wypowiedzi
}