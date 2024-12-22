using System.ComponentModel.DataAnnotations;

namespace Fish.Entity.SQL
{
    public class MasterUser
    {
        [Key]
        public int userId { get; set; }
        public string username { get; set; }
        public string gmail { get; set; }
        public string password { get; set; }
    }
}
