namespace EC.CRM.Backend.Application.DTOs.Response
{
    public record UserInfoResponse
    {
        public Guid Uid { get; set; }
        public string? Name { get; set; }
        public RoleResponse? Role { get; set; }
        public List<JobResponse>? Jobs { get; set; }
        public required List<SkillResponse> Skills { get; set; }
        public List<NonProfessionalInterestResponse>? NonProfessionalInterests { get; set; }
        public required List<LocationResponse> Locations { get; set; }
        public required List<StudyFieldResponse> StudyFields { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal? CurrentSalary { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? PaidToClub { get; set; }
    }
}
