using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

using PC.Module.Manager.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Module.Manager.Migrations
{
    public class ManagerMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public ManagerMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(ManagerPart), part => part
                .Attachable()
                .WithField(nameof(ManagerPart.Email), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Email")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "The email of the person you're gonna add as manager"
                    })
                    .WithEditor("TextArea"))
                );

            _contentDefinitionManager.AlterTypeDefinition("Manager", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(ManagerPart))
                // .DisplayedAs("displayedasdadadasd")
                );

            return 1;
        }
    }
}