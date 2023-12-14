namespace PC.Data.Models.Accounts;

public class Student : BaseAzureAccount
{
    public List<ArticlePlacementStudent>? ArticlePlacementStudents { get; set; }
}
