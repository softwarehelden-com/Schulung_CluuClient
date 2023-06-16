#pragma warning disable
// Cluu Version: 6.0.8

// DataContext
namespace DataAccessDemo.EntityModel
{
    using Cluu.DataAccess;

    [System.Reflection.Obfuscation(Exclude = true)]
    internal class DataAccessDemoContext : ObjectContext
    {
        private static readonly IEntityMap entityMap;
        private static readonly StaticOptimizationStorage staticOptimizationStorage;

        static DataAccessDemoContext()
        {
            DataAccessDemoContext.staticOptimizationStorage = new StaticOptimizationStorage();

            var map = new EntityMap();
            DataAccessDemoContext.entityMap = map;

            map.Add("SwhOrgManagement.OrganizationUnit", typeof(DataAccessDemo.EntityModel.SwhOrgManagement.OrganizationUnit));
            map.Add("SwhOrgManagement.Person", typeof(DataAccessDemo.EntityModel.SwhOrgManagement.Person));
        }

        public DataAccessDemoContext(Cluu.Backbone.ICluuBackboneProvider cluuBackboneProvider)
            : base(cluuBackboneProvider, new ObjectContextBehavior(DataAccessDemoContext.EntityMap, DataAccessDemoContext.staticOptimizationStorage))
        {
        }

        [System.Obsolete("Use the constructor with the cluu backbone provider for explicit dependencies.")]
        public DataAccessDemoContext()
            : base(new ObjectContextBehavior(DataAccessDemoContext.EntityMap, DataAccessDemoContext.staticOptimizationStorage))
        {
        }
        
        internal static IEntityMap EntityMap {
            get => DataAccessDemoContext.entityMap;
        }
    }
}

// Dependency-Injection for DataAccessDemo.EntityModel
namespace DataAccessDemo.EntityModel
{
    using static Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions;
    using static Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions;

    /// <summary>
    /// Adds the cluu entities and actions to the service configuration builder.
    /// </summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal static class CluuEntitiesServiceConfigurationBuilderExtensions
    {
        public static Cluu.Hosting.ICluuServiceConfigurationBuilder TryAddEntityActions(this Cluu.Hosting.ICluuServiceConfigurationBuilder cluu)
        {
            var s = cluu.Services;
            s.TryAddTransient<DataAccessDemo.EntityModel.DemoClientDevelopment.Actions.IGetStreamInvokeAction, DataAccessDemo.EntityModel.DemoClientDevelopment.Actions.GetStreamInvokeAction>();
            s.TryAddTransient<DataAccessDemo.EntityModel.SwhOrgManagement.Actions.IExportPersonsInvokeAction, DataAccessDemo.EntityModel.SwhOrgManagement.Actions.ExportPersonsInvokeAction>();

            return cluu;
        }
    }
}

// Entities for DataAccessDemo.EntityModel.DemoClientDevelopment
namespace DataAccessDemo.EntityModel.DemoClientDevelopment
{
}

// FieldSelection for DataAccessDemo.EntityModel.DemoClientDevelopment
namespace DataAccessDemo.EntityModel.DemoClientDevelopment.CluuFieldSelection
{
}

// Actions for DataAccessDemo.EntityModel.DemoClientDevelopment
namespace DataAccessDemo.EntityModel.DemoClientDevelopment.Actions
{
    using static Cluu.IBackboneProviderInvokeExtensions;

    /// <summary>Abstraction for the GetStreamInvokeAction.</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal interface IGetStreamInvokeAction
    {
        /// <summary>Invokes the action async.</summary>
        System.Threading.Tasks.Task<System.IO.Stream> InvokeAsync(System.Threading.CancellationToken cancellationToken);
    }
   
    /// <summary>DemoClientDevelopment.AddIns.Demo.GetStream</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class GetStreamInvokeAction : IGetStreamInvokeAction
    {
        private readonly Cluu.Backbone.ICluuBackboneProvider backboneProvider;

        public const string ActionName = "DemoClientDevelopment.AddIns.Demo.GetStream";

        public GetStreamInvokeAction(Cluu.Backbone.ICluuBackboneProvider backboneProvider)
        {
            this.backboneProvider = backboneProvider;
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task<System.IO.Stream> InvokeAsync(System.Threading.CancellationToken cancellationToken)
        {
            return await this.backboneProvider.InvokeWithResponseStreamAsync(ActionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Invokes the action async. This method uses Cluu.CluuBackboneAccess.Current which is obsolete. Use dependency injection instead.</summary>
        [System.Obsolete("This method uses Cluu.CluuBackboneAccess.Current which is obsolete. Use dependency injection instead.")]
        public static async System.Threading.Tasks.Task<System.IO.Stream> StaticInvokeAsync(System.Threading.CancellationToken cancellationToken)
        {
            return await Cluu.CluuBackboneAccess.Current.InvokeWithResponseStreamAsync(ActionName, cancellationToken).ConfigureAwait(false);
        }
    }
}

// Entities for DataAccessDemo.EntityModel.SwhOrgManagement
namespace DataAccessDemo.EntityModel.SwhOrgManagement
{
    /// <summary>Organisationseinheit</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class OrganizationUnit : Cluu.DataAccess.Entity
    {
        public OrganizationUnit(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit CreateFieldSelector()
            => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Straße / Hausnummer</summary>
        public string Address
        {
            get => this.GetValueInternal<string>("Address");
            set => this.SetValueInternal("Address", value);
        }

        /// <summary>Straße / Hausnummer (Rechnung)</summary>
        public string BillingAddress
        {
            get => this.GetValueInternal<string>("BillingAddress");
            set => this.SetValueInternal("BillingAddress", value);
        }

        /// <summary>Stadt (Rechnung)</summary>
        public string BillingCity
        {
            get => this.GetValueInternal<string>("BillingCity");
            set => this.SetValueInternal("BillingCity", value);
        }

        /// <summary>Land (Rechnung)</summary>
        public string BillingCountry
        {
            get => this.GetValueInternal<string>("BillingCountry");
            set => this.SetValueInternal("BillingCountry", value);
        }

        /// <summary>PLZ (Rechnung)</summary>
        public string BillingZipCode
        {
            get => this.GetValueInternal<string>("BillingZipCode");
            set => this.SetValueInternal("BillingZipCode", value);
        }

        /// <summary>Firma ID</summary>
        public int? CalculatedCompanyId
        {
            get => this.GetValueInternal<int?>("CalculatedCompanyId");
            set => this.SetValueInternal("CalculatedCompanyId", value);
        }

        /// <summary>Bezeichnung</summary>
        public string Caption
        {
            get => this.GetValueInternal<string>("Caption");
            set => this.SetValueInternal("Caption", value);
        }

        /// <summary>Chef</summary>
        public int? ChiefId
        {
            get => this.GetValueInternal<int?>("ChiefId");
            set => this.SetValueInternal("ChiefId", value);
        }

        /// <summary>Stadt</summary>
        public string City
        {
            get => this.GetValueInternal<string>("City");
            set => this.SetValueInternal("City", value);
        }

        /// <summary>Kostenstellen-Nummer</summary>
        public string CostCenterNumber
        {
            get => this.GetValueInternal<string>("CostCenterNumber");
            set => this.SetValueInternal("CostCenterNumber", value);
        }

        /// <summary>Land</summary>
        public string Country
        {
            get => this.GetValueInternal<string>("Country");
            set => this.SetValueInternal("Country", value);
        }

        /// <summary>Erstelldatum</summary>
        public System.DateTime? CreationDate
        {
            get => this.GetValueInternal<System.DateTime?>("CreationDate");
            set => this.SetValueInternal("CreationDate", value);
        }

        /// <summary>Ersteller ID</summary>
        public string CreatorId
        {
            get => this.GetValueInternal<string>("CreatorId");
            set => this.SetValueInternal("CreatorId", value);
        }

        /// <summary>Beschreibung</summary>
        public string Description
        {
            get => this.GetValueInternal<string>("Description");
            set => this.SetValueInternal("Description", value);
        }

        /// <summary>Domänen-ID</summary>
        public int? DomainId
        {
            get => this.GetValueInternal<int?>("DomainId");
            set => this.SetValueInternal("DomainId", value);
        }

        /// <summary>Adresse anzeigen?</summary>
        public bool? HasAddress
        {
            get => this.GetValueInternal<bool?>("HasAddress");
            set => this.SetValueInternal("HasAddress", value);
        }

        /// <summary>Rechnungsadresse anzeigen?</summary>
        public bool? HasBillingAddress
        {
            get => this.GetValueInternal<bool?>("HasBillingAddress");
            set => this.SetValueInternal("HasBillingAddress", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Archiviert?</summary>
        public bool? IsArchived
        {
            get => this.GetValueInternal<bool?>("IsArchived");
            set => this.SetValueInternal("IsArchived", value);
        }

        /// <summary>Extern?</summary>
        public bool? IsExternal
        {
            get => this.GetValueInternal<bool?>("IsExternal");
            set => this.SetValueInternal("IsExternal", value);
        }

        /// <summary>Änderungsdatum</summary>
        public System.DateTime? LastModificationDate
        {
            get => this.GetValueInternal<System.DateTime?>("LastModificationDate");
            set => this.SetValueInternal("LastModificationDate", value);
        }

        /// <summary>Letzter Bearbeiter</summary>
        public string LastModifierId
        {
            get => this.GetValueInternal<string>("LastModifierId");
            set => this.SetValueInternal("LastModifierId", value);
        }

        /// <summary>Untergeordnete Organisationseinheiten verwalten?</summary>
        public bool? ManageChildOrganizationUnits
        {
            get => this.GetValueInternal<bool?>("ManageChildOrganizationUnits");
            set => this.SetValueInternal("ManageChildOrganizationUnits", value);
        }

        public string OriginationIdentifier
        {
            get => this.GetValueInternal<string>("OriginationIdentifier");
            set => this.SetValueInternal("OriginationIdentifier", value);
        }

        /// <summary>Übergeordnete OE</summary>
        public int? ParentId
        {
            get => this.GetValueInternal<int?>("ParentId");
            set => this.SetValueInternal("ParentId", value);
        }

        /// <summary>Lieferantennummer</summary>
        public string SupplierNumber
        {
            get => this.GetValueInternal<string>("SupplierNumber");
            set => this.SetValueInternal("SupplierNumber", value);
        }

        /// <summary>Typ</summary>
        public SwhOrgManagementOrganizationUnitType? Type
        {
            get => this.GetValueInternal<SwhOrgManagementOrganizationUnitType?>("Type");
            set => this.SetValueInternal("Type", value);
        }

        /// <summary>Eindeutige ID</summary>
        public System.Guid? UniqueId
        {
            get => this.GetValueInternal<System.Guid?>("UniqueId");
            set => this.SetValueInternal("UniqueId", value);
        }

        /// <summary>PLZ</summary>
        public string ZipCode
        {
            get => this.GetValueInternal<string>("ZipCode");
            set => this.SetValueInternal("ZipCode", value);
        }

        /// <summary>Accessor for the CalculatedCompany relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<OrganizationUnit> CalculatedCompanyReference
            => this.GetReferenceInternal<OrganizationUnit>("CalculatedCompany");

        public OrganizationUnit CalculatedCompany
        {
            get => this.CalculatedCompanyReference.Value;
            set => this.CalculatedCompanyReference.Value = value;
        }

        /// <summary>Accessor for the Chief relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<Person> ChiefReference
            => this.GetReferenceInternal<Person>("Chief");

        /// <summary>Chef</summary>
        public Person Chief
        {
            get => this.ChiefReference.Value;
            set => this.ChiefReference.Value = value;
        }

        /// <summary>Untergeordnete OE</summary>
        public Cluu.DataAccess.IEntityCollection<OrganizationUnit> ChildOrganizationUnits
            => this.GetCollectionInternal<OrganizationUnit>("ChildOrganizationUnits");

        /// <summary>Personen (Extern)</summary>
        public Cluu.DataAccess.IEntityCollection<Person> ExternalPersons
            => this.GetCollectionInternal<Person>("ExternalPersons");

        public Cluu.DataAccess.IEntityCollection<OrganizationUnit> OrganizationUnitsOfCompany
            => this.GetCollectionInternal<OrganizationUnit>("OrganizationUnitsOfCompany");

        /// <summary>Accessor for the ParentOrganizationUnit relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<OrganizationUnit> ParentOrganizationUnitReference
            => this.GetReferenceInternal<OrganizationUnit>("ParentOrganizationUnit");

        /// <summary>Übergeordnete OE</summary>
        public OrganizationUnit ParentOrganizationUnit
        {
            get => this.ParentOrganizationUnitReference.Value;
            set => this.ParentOrganizationUnitReference.Value = value;
        }

        public Cluu.DataAccess.IEntityCollection<Person> Persons
            => this.GetCollectionInternal<Person>("Persons");

        public Cluu.DataAccess.IEntityCollection<Person> PersonsOfCompany
            => this.GetCollectionInternal<Person>("PersonsOfCompany");
    }

    /// <summary>Person</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class Person : Cluu.DataAccess.Entity
    {
        public Person(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person CreateFieldSelector()
            => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Geburtsdatum</summary>
        public System.DateTime? BirthDate
        {
            get => this.GetValueInternal<System.DateTime?>("BirthDate");
            set => this.SetValueInternal("BirthDate", value);
        }

        /// <summary>Geburtsname</summary>
        public string BirthName
        {
            get => this.GetValueInternal<string>("BirthName");
            set => this.SetValueInternal("BirthName", value);
        }

        /// <summary>Gebäude</summary>
        public string BusinessBuilding
        {
            get => this.GetValueInternal<string>("BusinessBuilding");
            set => this.SetValueInternal("BusinessBuilding", value);
        }

        /// <summary>Stadt</summary>
        public string BusinessCity
        {
            get => this.GetValueInternal<string>("BusinessCity");
            set => this.SetValueInternal("BusinessCity", value);
        }

        /// <summary>Land</summary>
        public string BusinessCountry
        {
            get => this.GetValueInternal<string>("BusinessCountry");
            set => this.SetValueInternal("BusinessCountry", value);
        }

        /// <summary>Email</summary>
        public string BusinessEmail
        {
            get => this.GetValueInternal<string>("BusinessEmail");
            set => this.SetValueInternal("BusinessEmail", value);
        }

        /// <summary>Fax</summary>
        public string BusinessFax
        {
            get => this.GetValueInternal<string>("BusinessFax");
            set => this.SetValueInternal("BusinessFax", value);
        }

        /// <summary>Etage</summary>
        public string BusinessFloor
        {
            get => this.GetValueInternal<string>("BusinessFloor");
            set => this.SetValueInternal("BusinessFloor", value);
        }

        /// <summary>Standort</summary>
        public string BusinessLocation
        {
            get => this.GetValueInternal<string>("BusinessLocation");
            set => this.SetValueInternal("BusinessLocation", value);
        }

        /// <summary>Handy</summary>
        public string BusinessMobile
        {
            get => this.GetValueInternal<string>("BusinessMobile");
            set => this.SetValueInternal("BusinessMobile", value);
        }

        /// <summary>Raum</summary>
        public string BusinessRoom
        {
            get => this.GetValueInternal<string>("BusinessRoom");
            set => this.SetValueInternal("BusinessRoom", value);
        }

        /// <summary>Bundesland / Region</summary>
        public string BusinessState
        {
            get => this.GetValueInternal<string>("BusinessState");
            set => this.SetValueInternal("BusinessState", value);
        }

        /// <summary>Straße / Hausnummer</summary>
        public string BusinessStreetAndNumber
        {
            get => this.GetValueInternal<string>("BusinessStreetAndNumber");
            set => this.SetValueInternal("BusinessStreetAndNumber", value);
        }

        /// <summary>Telefon</summary>
        public string BusinessTelephone
        {
            get => this.GetValueInternal<string>("BusinessTelephone");
            set => this.SetValueInternal("BusinessTelephone", value);
        }

        /// <summary>PLZ</summary>
        public string BusinessZip
        {
            get => this.GetValueInternal<string>("BusinessZip");
            set => this.SetValueInternal("BusinessZip", value);
        }

        /// <summary>Bezeichnung</summary>
        public string Caption
        {
            get => this.GetValueInternal<string>("Caption");
            set => this.SetValueInternal("Caption", value);
        }

        /// <summary>Firma</summary>
        public int? CompanyId
        {
            get => this.GetValueInternal<int?>("CompanyId");
            set => this.SetValueInternal("CompanyId", value);
        }

        /// <summary>Kostenstelle</summary>
        public string CostCenter
        {
            get => this.GetValueInternal<string>("CostCenter");
            set => this.SetValueInternal("CostCenter", value);
        }

        /// <summary>Erstelldatum</summary>
        public System.DateTime? CreationDate
        {
            get => this.GetValueInternal<System.DateTime?>("CreationDate");
            set => this.SetValueInternal("CreationDate", value);
        }

        /// <summary>Ersteller ID</summary>
        public string CreatorId
        {
            get => this.GetValueInternal<string>("CreatorId");
            set => this.SetValueInternal("CreatorId", value);
        }

        /// <summary>Domänen-ID</summary>
        public int? DomainId
        {
            get => this.GetValueInternal<int?>("DomainId");
            set => this.SetValueInternal("DomainId", value);
        }

        /// <summary>Externe Organisationseinheit-ID</summary>
        public int? ExternalOrganizationUnitId
        {
            get => this.GetValueInternal<int?>("ExternalOrganizationUnitId");
            set => this.SetValueInternal("ExternalOrganizationUnitId", value);
        }

        /// <summary>Vorname</summary>
        public string FirstName
        {
            get => this.GetValueInternal<string>("FirstName");
            set => this.SetValueInternal("FirstName", value);
        }

        /// <summary>Geschlecht</summary>
        public SwhOrgManagementGenderType? Gender
        {
            get => this.GetValueInternal<SwhOrgManagementGenderType?>("Gender");
            set => this.SetValueInternal("Gender", value);
        }

        /// <summary>Private Kontaktdaten einblenden?</summary>
        public bool? HasPrivateContactInformation
        {
            get => this.GetValueInternal<bool?>("HasPrivateContactInformation");
            set => this.SetValueInternal("HasPrivateContactInformation", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Archiviert?</summary>
        public bool? IsArchived
        {
            get => this.GetValueInternal<bool?>("IsArchived");
            set => this.SetValueInternal("IsArchived", value);
        }

        /// <summary>Extern?</summary>
        public bool? IsExternal
        {
            get => this.GetValueInternal<bool?>("IsExternal");
            set => this.SetValueInternal("IsExternal", value);
        }

        /// <summary>Änderungsdatum</summary>
        public System.DateTime? LastModificationDate
        {
            get => this.GetValueInternal<System.DateTime?>("LastModificationDate");
            set => this.SetValueInternal("LastModificationDate", value);
        }

        /// <summary>Letzter Bearbeiter</summary>
        public string LastModifierId
        {
            get => this.GetValueInternal<string>("LastModifierId");
            set => this.SetValueInternal("LastModifierId", value);
        }

        /// <summary>Nachname</summary>
        public string LastName
        {
            get => this.GetValueInternal<string>("LastName");
            set => this.SetValueInternal("LastName", value);
        }

        /// <summary>Vorgesetzter-ID</summary>
        public int? ManagerId
        {
            get => this.GetValueInternal<int?>("ManagerId");
            set => this.SetValueInternal("ManagerId", value);
        }

        /// <summary>Notiz</summary>
        public string Notice
        {
            get => this.GetValueInternal<string>("Notice");
            set => this.SetValueInternal("Notice", value);
        }

        /// <summary>Organisationseinheit</summary>
        public string OrganizationUnitCaption
        {
            get => this.GetValueInternal<string>("OrganizationUnitCaption");
            set => this.SetValueInternal("OrganizationUnitCaption", value);
        }

        /// <summary>Organisationseinheit</summary>
        public string OrganizationUnitCustom
        {
            get => this.GetValueInternal<string>("OrganizationUnitCustom");
            set => this.SetValueInternal("OrganizationUnitCustom", value);
        }

        /// <summary>Organisationseinheit</summary>
        public int? OrganizationUnitId
        {
            get => this.GetValueInternal<int?>("OrganizationUnitId");
            set => this.SetValueInternal("OrganizationUnitId", value);
        }

        public string OriginationIdentifier
        {
            get => this.GetValueInternal<string>("OriginationIdentifier");
            set => this.SetValueInternal("OriginationIdentifier", value);
        }

        /// <summary>Personalnummer</summary>
        public string PersonnelNumber
        {
            get => this.GetValueInternal<string>("PersonnelNumber");
            set => this.SetValueInternal("PersonnelNumber", value);
        }

        /// <summary>Foto</summary>
        public byte[] PhotoFileContent
        {
            get => this.GetValueInternal<byte[]>("PhotoFileContent");
            set => this.SetValueInternal("PhotoFileContent", value);
        }

        public string PhotoFileContentType
        {
            get => this.GetValueInternal<string>("PhotoFileContentType");
            set => this.SetValueInternal("PhotoFileContentType", value);
        }

        public string PhotoFileName
        {
            get => this.GetValueInternal<string>("PhotoFileName");
            set => this.SetValueInternal("PhotoFileName", value);
        }

        public int? PhotoFileSizeInByte
        {
            get => this.GetValueInternal<int?>("PhotoFileSizeInByte");
            set => this.SetValueInternal("PhotoFileSizeInByte", value);
        }

        /// <summary>Position</summary>
        public string Position
        {
            get => this.GetValueInternal<string>("Position");
            set => this.SetValueInternal("Position", value);
        }

        /// <summary>Bevorzugte Kommunikationssprache (ID)</summary>
        public int? PreferedLanguageId
        {
            get => this.GetValueInternal<int?>("PreferedLanguageId");
            set => this.SetValueInternal("PreferedLanguageId", value);
        }

        /// <summary>Stadt (privat)</summary>
        public string PrivateCity
        {
            get => this.GetValueInternal<string>("PrivateCity");
            set => this.SetValueInternal("PrivateCity", value);
        }

        /// <summary>Land (privat)</summary>
        public string PrivateCountry
        {
            get => this.GetValueInternal<string>("PrivateCountry");
            set => this.SetValueInternal("PrivateCountry", value);
        }

        /// <summary>Email (privat)</summary>
        public string PrivateEmail
        {
            get => this.GetValueInternal<string>("PrivateEmail");
            set => this.SetValueInternal("PrivateEmail", value);
        }

        /// <summary>Fax (privat)</summary>
        public string PrivateFax
        {
            get => this.GetValueInternal<string>("PrivateFax");
            set => this.SetValueInternal("PrivateFax", value);
        }

        /// <summary>Handy (privat)</summary>
        public string PrivateMobile
        {
            get => this.GetValueInternal<string>("PrivateMobile");
            set => this.SetValueInternal("PrivateMobile", value);
        }

        /// <summary>Bundesland / Region</summary>
        public string PrivateState
        {
            get => this.GetValueInternal<string>("PrivateState");
            set => this.SetValueInternal("PrivateState", value);
        }

        /// <summary>Straße / Hausnummer (privat)</summary>
        public string PrivateStreetAndNumber
        {
            get => this.GetValueInternal<string>("PrivateStreetAndNumber");
            set => this.SetValueInternal("PrivateStreetAndNumber", value);
        }

        /// <summary>Telefon (privat)</summary>
        public string PrivateTelephone
        {
            get => this.GetValueInternal<string>("PrivateTelephone");
            set => this.SetValueInternal("PrivateTelephone", value);
        }

        /// <summary>PLZ (privat)</summary>
        public string PrivateZip
        {
            get => this.GetValueInternal<string>("PrivateZip");
            set => this.SetValueInternal("PrivateZip", value);
        }

        /// <summary>Titel</summary>
        public string Title
        {
            get => this.GetValueInternal<string>("Title");
            set => this.SetValueInternal("Title", value);
        }

        /// <summary>Eindeutige ID</summary>
        public System.Guid? UniqueId
        {
            get => this.GetValueInternal<System.Guid?>("UniqueId");
            set => this.SetValueInternal("UniqueId", value);
        }

        public Cluu.DataAccess.IEntityCollection<OrganizationUnit> ChiefOrganizationUnits
            => this.GetCollectionInternal<OrganizationUnit>("ChiefOrganizationUnits");

        /// <summary>Accessor for the Company relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<OrganizationUnit> CompanyReference
            => this.GetReferenceInternal<OrganizationUnit>("Company");

        /// <summary>Firma</summary>
        public OrganizationUnit Company
        {
            get => this.CompanyReference.Value;
            set => this.CompanyReference.Value = value;
        }

        /// <summary>Accessor for the ExternalOrganizationUnit relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<OrganizationUnit> ExternalOrganizationUnitReference
            => this.GetReferenceInternal<OrganizationUnit>("ExternalOrganizationUnit");

        /// <summary>Externe Organisationseinheit</summary>
        public OrganizationUnit ExternalOrganizationUnit
        {
            get => this.ExternalOrganizationUnitReference.Value;
            set => this.ExternalOrganizationUnitReference.Value = value;
        }

        public Cluu.DataAccess.IEntityCollection<Person> ManagedPersons
            => this.GetCollectionInternal<Person>("ManagedPersons");

        /// <summary>Accessor for the Manager relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<Person> ManagerReference
            => this.GetReferenceInternal<Person>("Manager");

        /// <summary>Vorgesetzter</summary>
        public Person Manager
        {
            get => this.ManagerReference.Value;
            set => this.ManagerReference.Value = value;
        }

        /// <summary>Accessor for the OrganizationUnit relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<OrganizationUnit> OrganizationUnitReference
            => this.GetReferenceInternal<OrganizationUnit>("OrganizationUnit");

        public OrganizationUnit OrganizationUnit
        {
            get => this.OrganizationUnitReference.Value;
            set => this.OrganizationUnitReference.Value = value;
        }
    }
}

// FieldSelection for DataAccessDemo.EntityModel.SwhOrgManagement
namespace DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection
{
    /// <summary>Field selector for Organisationseinheit</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class OrganizationUnit : Cluu.DataAccess.FieldSelector
    {
        internal OrganizationUnit()
        {
        }

        internal OrganizationUnit(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOrgManagement.OrganizationUnit";

        /// <summary>Creates a new field selector without any parent.</summary>
        public OrganizationUnit StartFromHere() => new OrganizationUnit();

        /// <summary>Straße / Hausnummer</summary>
        public string Address => this.GetFieldName("Address");

        /// <summary>Straße / Hausnummer (Rechnung)</summary>
        public string BillingAddress => this.GetFieldName("BillingAddress");

        /// <summary>Stadt (Rechnung)</summary>
        public string BillingCity => this.GetFieldName("BillingCity");

        /// <summary>Land (Rechnung)</summary>
        public string BillingCountry => this.GetFieldName("BillingCountry");

        /// <summary>PLZ (Rechnung)</summary>
        public string BillingZipCode => this.GetFieldName("BillingZipCode");

        /// <summary>Firma ID</summary>
        public string CalculatedCompanyId => this.GetFieldName("CalculatedCompanyId");

        /// <summary>Bezeichnung</summary>
        public string Caption => this.GetFieldName("Caption");

        /// <summary>Chef</summary>
        public string ChiefId => this.GetFieldName("ChiefId");

        /// <summary>Stadt</summary>
        public string City => this.GetFieldName("City");

        /// <summary>Kostenstellen-Nummer</summary>
        public string CostCenterNumber => this.GetFieldName("CostCenterNumber");

        /// <summary>Land</summary>
        public string Country => this.GetFieldName("Country");

        /// <summary>Erstelldatum</summary>
        public string CreationDate => this.GetFieldName("CreationDate");

        /// <summary>Ersteller ID</summary>
        public string CreatorId => this.GetFieldName("CreatorId");

        /// <summary>Beschreibung</summary>
        public string Description => this.GetFieldName("Description");

        /// <summary>Domänen-ID</summary>
        public string DomainId => this.GetFieldName("DomainId");

        /// <summary>Adresse anzeigen?</summary>
        public string HasAddress => this.GetFieldName("HasAddress");

        /// <summary>Rechnungsadresse anzeigen?</summary>
        public string HasBillingAddress => this.GetFieldName("HasBillingAddress");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Archiviert?</summary>
        public string IsArchived => this.GetFieldName("IsArchived");

        /// <summary>Extern?</summary>
        public string IsExternal => this.GetFieldName("IsExternal");

        /// <summary>Änderungsdatum</summary>
        public string LastModificationDate => this.GetFieldName("LastModificationDate");

        /// <summary>Letzter Bearbeiter</summary>
        public string LastModifierId => this.GetFieldName("LastModifierId");

        /// <summary>Untergeordnete Organisationseinheiten verwalten?</summary>
        public string ManageChildOrganizationUnits => this.GetFieldName("ManageChildOrganizationUnits");

        public string OriginationIdentifier => this.GetFieldName("OriginationIdentifier");

        /// <summary>Übergeordnete OE</summary>
        public string ParentId => this.GetFieldName("ParentId");

        /// <summary>Lieferantennummer</summary>
        public string SupplierNumber => this.GetFieldName("SupplierNumber");

        /// <summary>Typ</summary>
        public string Type => this.GetFieldName("Type");

        /// <summary>Eindeutige ID</summary>
        public string UniqueId => this.GetFieldName("UniqueId");

        /// <summary>PLZ</summary>
        public string ZipCode => this.GetFieldName("ZipCode");

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit CalculatedCompany => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("CalculatedCompany"));

        /// <summary>Chef</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person Chief => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person(this.GetFieldName("Chief"));

        /// <summary>Untergeordnete OE</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit ChildOrganizationUnits => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("ChildOrganizationUnits"));

        /// <summary>Personen (Extern)</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person ExternalPersons => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person(this.GetFieldName("ExternalPersons"));

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit OrganizationUnitsOfCompany => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("OrganizationUnitsOfCompany"));

        /// <summary>Übergeordnete OE</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit ParentOrganizationUnit => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("ParentOrganizationUnit"));

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person Persons => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person(this.GetFieldName("Persons"));

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person PersonsOfCompany => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person(this.GetFieldName("PersonsOfCompany"));
    }

    /// <summary>Field selector for Person</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class Person : Cluu.DataAccess.FieldSelector
    {
        internal Person()
        {
        }

        internal Person(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOrgManagement.Person";

        /// <summary>Creates a new field selector without any parent.</summary>
        public Person StartFromHere() => new Person();

        /// <summary>Geburtsdatum</summary>
        public string BirthDate => this.GetFieldName("BirthDate");

        /// <summary>Geburtsname</summary>
        public string BirthName => this.GetFieldName("BirthName");

        /// <summary>Gebäude</summary>
        public string BusinessBuilding => this.GetFieldName("BusinessBuilding");

        /// <summary>Stadt</summary>
        public string BusinessCity => this.GetFieldName("BusinessCity");

        /// <summary>Land</summary>
        public string BusinessCountry => this.GetFieldName("BusinessCountry");

        /// <summary>Email</summary>
        public string BusinessEmail => this.GetFieldName("BusinessEmail");

        /// <summary>Fax</summary>
        public string BusinessFax => this.GetFieldName("BusinessFax");

        /// <summary>Etage</summary>
        public string BusinessFloor => this.GetFieldName("BusinessFloor");

        /// <summary>Standort</summary>
        public string BusinessLocation => this.GetFieldName("BusinessLocation");

        /// <summary>Handy</summary>
        public string BusinessMobile => this.GetFieldName("BusinessMobile");

        /// <summary>Raum</summary>
        public string BusinessRoom => this.GetFieldName("BusinessRoom");

        /// <summary>Bundesland / Region</summary>
        public string BusinessState => this.GetFieldName("BusinessState");

        /// <summary>Straße / Hausnummer</summary>
        public string BusinessStreetAndNumber => this.GetFieldName("BusinessStreetAndNumber");

        /// <summary>Telefon</summary>
        public string BusinessTelephone => this.GetFieldName("BusinessTelephone");

        /// <summary>PLZ</summary>
        public string BusinessZip => this.GetFieldName("BusinessZip");

        /// <summary>Bezeichnung</summary>
        public string Caption => this.GetFieldName("Caption");

        /// <summary>Firma</summary>
        public string CompanyId => this.GetFieldName("CompanyId");

        /// <summary>Kostenstelle</summary>
        public string CostCenter => this.GetFieldName("CostCenter");

        /// <summary>Erstelldatum</summary>
        public string CreationDate => this.GetFieldName("CreationDate");

        /// <summary>Ersteller ID</summary>
        public string CreatorId => this.GetFieldName("CreatorId");

        /// <summary>Domänen-ID</summary>
        public string DomainId => this.GetFieldName("DomainId");

        /// <summary>Externe Organisationseinheit-ID</summary>
        public string ExternalOrganizationUnitId => this.GetFieldName("ExternalOrganizationUnitId");

        /// <summary>Vorname</summary>
        public string FirstName => this.GetFieldName("FirstName");

        /// <summary>Geschlecht</summary>
        public string Gender => this.GetFieldName("Gender");

        /// <summary>Private Kontaktdaten einblenden?</summary>
        public string HasPrivateContactInformation => this.GetFieldName("HasPrivateContactInformation");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Archiviert?</summary>
        public string IsArchived => this.GetFieldName("IsArchived");

        /// <summary>Extern?</summary>
        public string IsExternal => this.GetFieldName("IsExternal");

        /// <summary>Änderungsdatum</summary>
        public string LastModificationDate => this.GetFieldName("LastModificationDate");

        /// <summary>Letzter Bearbeiter</summary>
        public string LastModifierId => this.GetFieldName("LastModifierId");

        /// <summary>Nachname</summary>
        public string LastName => this.GetFieldName("LastName");

        /// <summary>Vorgesetzter-ID</summary>
        public string ManagerId => this.GetFieldName("ManagerId");

        /// <summary>Notiz</summary>
        public string Notice => this.GetFieldName("Notice");

        /// <summary>Organisationseinheit</summary>
        public string OrganizationUnitCaption => this.GetFieldName("OrganizationUnitCaption");

        /// <summary>Organisationseinheit</summary>
        public string OrganizationUnitCustom => this.GetFieldName("OrganizationUnitCustom");

        /// <summary>Organisationseinheit</summary>
        public string OrganizationUnitId => this.GetFieldName("OrganizationUnitId");

        public string OriginationIdentifier => this.GetFieldName("OriginationIdentifier");

        /// <summary>Personalnummer</summary>
        public string PersonnelNumber => this.GetFieldName("PersonnelNumber");

        /// <summary>Foto</summary>
        public string PhotoFileContent => this.GetFieldName("PhotoFileContent");

        public string PhotoFileContentType => this.GetFieldName("PhotoFileContentType");

        public string PhotoFileName => this.GetFieldName("PhotoFileName");

        public string PhotoFileSizeInByte => this.GetFieldName("PhotoFileSizeInByte");

        /// <summary>Position</summary>
        public string Position => this.GetFieldName("Position");

        /// <summary>Bevorzugte Kommunikationssprache (ID)</summary>
        public string PreferedLanguageId => this.GetFieldName("PreferedLanguageId");

        /// <summary>Stadt (privat)</summary>
        public string PrivateCity => this.GetFieldName("PrivateCity");

        /// <summary>Land (privat)</summary>
        public string PrivateCountry => this.GetFieldName("PrivateCountry");

        /// <summary>Email (privat)</summary>
        public string PrivateEmail => this.GetFieldName("PrivateEmail");

        /// <summary>Fax (privat)</summary>
        public string PrivateFax => this.GetFieldName("PrivateFax");

        /// <summary>Handy (privat)</summary>
        public string PrivateMobile => this.GetFieldName("PrivateMobile");

        /// <summary>Bundesland / Region</summary>
        public string PrivateState => this.GetFieldName("PrivateState");

        /// <summary>Straße / Hausnummer (privat)</summary>
        public string PrivateStreetAndNumber => this.GetFieldName("PrivateStreetAndNumber");

        /// <summary>Telefon (privat)</summary>
        public string PrivateTelephone => this.GetFieldName("PrivateTelephone");

        /// <summary>PLZ (privat)</summary>
        public string PrivateZip => this.GetFieldName("PrivateZip");

        /// <summary>Titel</summary>
        public string Title => this.GetFieldName("Title");

        /// <summary>Eindeutige ID</summary>
        public string UniqueId => this.GetFieldName("UniqueId");

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit ChiefOrganizationUnits => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("ChiefOrganizationUnits"));

        /// <summary>Firma</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit Company => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("Company"));

        /// <summary>Externe Organisationseinheit</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit ExternalOrganizationUnit => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("ExternalOrganizationUnit"));

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person ManagedPersons => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person(this.GetFieldName("ManagedPersons"));

        /// <summary>Vorgesetzter</summary>
        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person Manager => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.Person(this.GetFieldName("Manager"));

        public DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit OrganizationUnit => new DataAccessDemo.EntityModel.SwhOrgManagement.CluuFieldSelection.OrganizationUnit(this.GetFieldName("OrganizationUnit"));
    }
}

// Enums for DataAccessDemo.EntityModel.SwhOrgManagement
namespace DataAccessDemo.EntityModel.SwhOrgManagement
{
    /// <summary>Geschlecht</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal enum SwhOrgManagementGenderType : int
    {
        /// <summary>Weiblich</summary>
        Female = 0,

        /// <summary>Männlich</summary>
        Male = 1,

        /// <summary>Divers</summary>
        Undefined = 2
    }

    /// <summary>Organisationseinheit-Typ</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal enum SwhOrgManagementOrganizationUnitType : int
    {
        /// <summary>Firma</summary>
        Company = 0,

        /// <summary>Ressort</summary>
        Sphere = 1,

        /// <summary>Hauptabteilung</summary>
        MainDepartment = 2,

        /// <summary>Abteilung</summary>
        Department = 3,

        /// <summary>Fachabteilung</summary>
        OperatingDepartment = 4,

        /// <summary>Fachgebiet</summary>
        AreaOfExpertise = 5,

        /// <summary>Stab</summary>
        Staff = 6,

        /// <summary>Niederlassung / Zweigstelle</summary>
        BranchOffice = 7
    }
}

// Actions for DataAccessDemo.EntityModel.SwhOrgManagement
namespace DataAccessDemo.EntityModel.SwhOrgManagement.Actions
{
    using static Cluu.IBackboneProviderInvokeExtensions;

    /// <summary>Abstraction for the ExportPersonsInvokeAction.</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal interface IExportPersonsInvokeAction
    {
        /// <summary>Invokes the action async.</summary>
        System.Threading.Tasks.Task<ExportPersonsInvokeResponse> InvokeAsync(ExportPersonsInvokeRequest request, System.Threading.CancellationToken cancellationToken);
    }
   
    /// <summary>Personen exportieren</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class ExportPersonsInvokeAction : IExportPersonsInvokeAction
    {
        private readonly Cluu.Backbone.ICluuBackboneProvider backboneProvider;

        public const string ActionName = "SwhOrgManagement.AddIns.DefaultAddIn.ExportPersons";

        public ExportPersonsInvokeAction(Cluu.Backbone.ICluuBackboneProvider backboneProvider)
        {
            this.backboneProvider = backboneProvider;
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task<ExportPersonsInvokeResponse> InvokeAsync(ExportPersonsInvokeRequest request, System.Threading.CancellationToken cancellationToken)
        {
            return await this.backboneProvider.InvokeAsync<ExportPersonsInvokeRequest, ExportPersonsInvokeResponse>(ActionName, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Invokes the action async. This method uses Cluu.CluuBackboneAccess.Current which is obsolete. Use dependency injection instead.</summary>
        [System.Obsolete("This method uses Cluu.CluuBackboneAccess.Current which is obsolete. Use dependency injection instead.")]
        public static async System.Threading.Tasks.Task<ExportPersonsInvokeResponse> StaticInvokeAsync(ExportPersonsInvokeRequest request, System.Threading.CancellationToken cancellationToken)
        {
            return await Cluu.CluuBackboneAccess.Current.InvokeAsync<ExportPersonsInvokeRequest, ExportPersonsInvokeResponse>(ActionName, request, cancellationToken).ConfigureAwait(false);
        }
    }
}

// DTOs for DataAccessDemo.EntityModel.SwhOrgManagement
namespace DataAccessDemo.EntityModel.SwhOrgManagement.Actions
{
    [System.Reflection.Obfuscation(Exclude = true)]
    internal partial class ExportPersonsInvokeRequest
    {
        [System.Text.Json.Serialization.JsonPropertyName("personConstraint")]
        public string PersonConstraint { get; set; }
    
        [System.Text.Json.Serialization.JsonPropertyName("exportedFileType")]
        public int ExportedFileType { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    [System.Reflection.Obfuscation(Exclude = true)]
    internal partial class ExportPersonsInvokeResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("fileName")]
        public string FileName { get; set; }
    
        [System.Text.Json.Serialization.JsonPropertyName("fileContent")]
        public string FileContent { get; set; }
    
        [System.Text.Json.Serialization.JsonPropertyName("fileContentType")]
        public string FileContentType { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}

#pragma warning restore
