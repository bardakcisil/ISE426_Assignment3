namespace Assignment3
{
    public class User
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
