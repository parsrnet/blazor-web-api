namespace bookstoreapp.api.Models.Author;

public class AuthorReadOnlyDto : BaseDto // int Id
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
}
