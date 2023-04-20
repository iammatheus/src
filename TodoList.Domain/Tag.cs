using System.Collections.Generic;
using TodoList.Domain.Identity;

namespace TodoList.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
    }
}
