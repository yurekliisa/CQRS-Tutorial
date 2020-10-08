using FluentValidation;

namespace CQRS.Application.Interfaces
{
    public interface IUserRequest
    {
        string UserId { get; set; }
    }
}
