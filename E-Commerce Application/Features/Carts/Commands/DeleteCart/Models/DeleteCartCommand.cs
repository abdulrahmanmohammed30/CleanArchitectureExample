using MediatR;

namespace E_Commerce_Application.Services
{
        public class DeleteCartCommand: IRequest<bool>
        {
            public int Id { get; set; }
        }
}
