namespace API.Dtos
{
    public class UserForListDto
    {
        public string Username { get; set; }  
        public int PaidLeave { get; set; }
        public int UnpaidLeave { get; set; }
    }
}