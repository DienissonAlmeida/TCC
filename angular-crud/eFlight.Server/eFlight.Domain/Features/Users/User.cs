namespace eFlight.Domain.Features.Users
{
    public class User : Entity
    {
        public User()
        {

        }
        public string Name { get; set; }

        public string Cpf { get; set; }
    }
}
