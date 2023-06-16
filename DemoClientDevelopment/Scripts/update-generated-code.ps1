$appName = "DemoClientDevelopment"
$appNameLower = "demoClientDevelopment"

# Entities
dotnet cluu "generate-cs-entities" "-p" "$PSScriptRoot\..\$appName\EntityModel\$appName.entities"
dotnet cluu "generate-ts-entities" "-p" "$PSScriptRoot\..\$appName.Web.UI\Scripts\src\$appNameLower.tsentities"

# Translations
#dotnet cluu "generate-cs-translations" "-p" "$PSScriptRoot\..\$appName\Globalization\$appNameLower.translations.json"
#dotnet cluu "generate-cs-translations" "-p" "$PSScriptRoot\..\$appName.Web.UI\Assets\Translations\$appNameLower.web.ui.translations.json"
#dotnet cluu "generate-dts-translations" "-p" "$PSScriptRoot\..\$appName.Web.UI\Assets\Translations\$appNameLower.web.ui.translations.json"

# AddIn
dotnet cluu "generate-addin-services" "-p" "$PSScriptRoot\..\$appName.Actions\AddInService.addinserviceproj"

# Offline-Metadata
#dotnet cluu "transfer-metadata" "-p" "$PSScriptRoot\..\$appName.Tests\Files\OfflineMetadata.metadataproj"

