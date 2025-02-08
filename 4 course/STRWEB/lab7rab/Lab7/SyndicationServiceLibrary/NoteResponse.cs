using Newtonsoft.Json;
using System.Collections.Generic;

namespace SyndicationServiceLibrary
{
    public class NoteResponse
    {
        [JsonProperty("value")]
        public List<Note> Value { get; set; }
    }

    public class Note
    {
        [JsonProperty("subject")]
        public string Subj { get; set; }

        [JsonProperty("note1")]
        public string Note1 { get; set; }
    }
}
