using System.Collections.Generic;
namespace ShiftIQ.API.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
