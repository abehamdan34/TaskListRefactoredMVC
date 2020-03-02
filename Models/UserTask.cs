using System;
using System.Collections.Generic;

namespace TaskListRefactored.Models
{
    public partial class UserTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public string UserId { get; set; }
    }
}
