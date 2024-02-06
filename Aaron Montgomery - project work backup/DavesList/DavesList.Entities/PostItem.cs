using System;
using System.Collections.Generic;

namespace DavesList.Entities
{
    public partial class PostItem
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Post { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
