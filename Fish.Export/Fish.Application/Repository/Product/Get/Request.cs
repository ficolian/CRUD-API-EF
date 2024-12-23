using MediatR;
using Fish.Application.Model;

namespace Fish.Application.Usecase
{
    public class GetProductRequest : IRequest<ResponseOne<GetProductData>>
    {
        public int productId { get; set; }  
    }
}
