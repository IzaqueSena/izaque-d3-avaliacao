namespace izaque_d3_avaliacao.Models
{
    internal class User
    {
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }
        public DateTime LogInInstant { get; set; }
        public DateTime LogOutInstant { get; set; }

    }
}
