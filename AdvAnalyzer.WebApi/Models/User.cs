using System.Collections.Generic;

namespace AdvAnalyzer.WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public virtual ICollection<SearchQuery> SearchQueries { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
