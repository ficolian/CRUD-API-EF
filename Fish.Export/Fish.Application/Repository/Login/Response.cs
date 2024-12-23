using System;
namespace Fish.Application.Usecase
{
    public class UserCredData
    {
        public string token { get; set; }
        public DateTime validTo { get; set; }
        public DateTime validFrom { get; set; }
        public string gmail { get; set; }
    }
}
