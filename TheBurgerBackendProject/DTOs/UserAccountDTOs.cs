namespace TheBurgerBackendProject.DTOs
{
    public class UserAccountDTOs
    {
    }

    public class UserLoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserNewDTO : UserLoginDTO
    {
        public string UserName { get; set; } = string.Empty;
    }
}
