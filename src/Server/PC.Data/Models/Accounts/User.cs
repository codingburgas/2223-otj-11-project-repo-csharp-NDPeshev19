namespace PC.Data.Models.Accounts;

public class User : BaseAzureAccount
{
    public List<Article>? ArticlesCreated { get; set; }

    public List<Article>? ArticlesEdited { get; set; }
}

