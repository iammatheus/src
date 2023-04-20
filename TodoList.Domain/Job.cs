using System;

using TodoList.Domain.Identity;

namespace TodoList.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
