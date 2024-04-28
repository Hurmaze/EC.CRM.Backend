using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record StudentResponse : UserInfoResponse
    {
        public required State State { get; set; }
    }
}
