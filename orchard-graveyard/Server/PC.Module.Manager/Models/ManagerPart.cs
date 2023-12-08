using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace PC.Module.Manager.Models
{
    public class ManagerPart : ContentPart
    {
        // [OrchardCore.Email.EmailAddress]
        public TextField Email { get; set; }
    }
}
