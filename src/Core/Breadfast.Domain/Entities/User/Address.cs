namespace Breadfast.Domain.Entities.User
{
    public class Address :BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        
        public string Country { get; set; } = default!;
        public string UserId { get; set; }
        public ApplcationUser User { get; set; }
    }
}