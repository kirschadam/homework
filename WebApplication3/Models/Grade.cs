using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int Grade1 { get; set; }
        public string SubjectName { get; set; }
        public int StudentId { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
