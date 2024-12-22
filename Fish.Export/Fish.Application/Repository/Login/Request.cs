using MediatR;
using Fish.Application.Model;

namespace Fish.Application.Usecase;
public class UserCred : IRequest<ResponseOne<UserCredData>>
{
    public string username { get; set; }
    public string password { get; set; }
}

