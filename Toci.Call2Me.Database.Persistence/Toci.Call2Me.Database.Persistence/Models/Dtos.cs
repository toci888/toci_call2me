using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Call2Me.Database.Persistence.Models
{
    public class ConversationDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public List<TranscriptDto> Transcripts { get; set; } = new List<TranscriptDto>();
    }
    public class TranscriptDto
    {
        public string Speaker { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
    public class CreateTranscriptDto
    {
        public string Speaker { get; set; }
        public string Text { get; set; }
    }
}
