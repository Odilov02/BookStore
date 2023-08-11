namespace Application.UseCases.Users.Command.CreateUser
{
    public class CreateUserCommand
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
