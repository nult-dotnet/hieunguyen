using Backend.Application.Common.Models;
using Backend.Data.Entities;
using MediatR;

namespace Backend.Application.Brands.Models
{
    public class UpdateBrandResource : IRequest<ApiResult<Brand>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
    }
}
