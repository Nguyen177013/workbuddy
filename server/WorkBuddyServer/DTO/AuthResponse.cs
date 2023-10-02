namespace WorkBuddyServer.DTO
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpireDate { get; set; }
    }
}
