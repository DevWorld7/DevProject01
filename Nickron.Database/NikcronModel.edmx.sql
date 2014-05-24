
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/24/2014 17:18:03
-- Generated from EDMX file: D:\Accomplishments\DevProject01\Nickron.Database\NikcronModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductModelManufacture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModels] DROP CONSTRAINT [FK_ProductModelManufacture];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductModelProductType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModels] DROP CONSTRAINT [FK_ProductModelProductType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemProductModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItemProductModel];
GO
IF OBJECT_ID(N'[dbo].[FK_StockhouseZone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Stockhouse] DROP CONSTRAINT [FK_StockhouseZone];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItemWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemStockhouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItemStockhouse];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemDistributor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItemDistributor];
GO
IF OBJECT_ID(N'[dbo].[FK_DealersProductItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_DealersProductItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemRetailer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItemRetailer];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductModelProductWarranty_ProductModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModelProductWarranty] DROP CONSTRAINT [FK_ProductModelProductWarranty_ProductModel];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductModelProductWarranty_ProductWarranty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModelProductWarranty] DROP CONSTRAINT [FK_ProductModelProductWarranty_ProductWarranty];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Warehouse] DROP CONSTRAINT [FK_CompanyWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_WarehouseStockhouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Stockhouse] DROP CONSTRAINT [FK_WarehouseStockhouse];
GO
IF OBJECT_ID(N'[dbo].[FK_DealersRetailer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Retailer] DROP CONSTRAINT [FK_DealersRetailer];
GO
IF OBJECT_ID(N'[dbo].[FK_StockhouseDistributor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Distributor] DROP CONSTRAINT [FK_StockhouseDistributor];
GO
IF OBJECT_ID(N'[dbo].[FK_DistributorDealers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Dealers] DROP CONSTRAINT [FK_DistributorDealers];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_User] DROP CONSTRAINT [FK_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOffice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_User] DROP CONSTRAINT [FK_UserOffice];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductHistoryProductItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductHistories] DROP CONSTRAINT [FK_ProductHistoryProductItem];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesProductItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_SalesProductItem];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_SalesUser];
GO
IF OBJECT_ID(N'[dbo].[FK_SaleProductWarranty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductWarranties] DROP CONSTRAINT [FK_SaleProductWarranty];
GO
IF OBJECT_ID(N'[dbo].[FK_SaleCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_SaleCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemProductColors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItemProductColors];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductModelProductColors_ProductModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModelProductColors] DROP CONSTRAINT [FK_ProductModelProductColors_ProductModel];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductModelProductColors_ProductColors]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModelProductColors] DROP CONSTRAINT [FK_ProductModelProductColors_ProductColors];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductModelProductImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductImages] DROP CONSTRAINT [FK_ProductModelProductImage];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_ServiceSale];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesReturnSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_SalesReturnSale];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesReturnUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesReturns] DROP CONSTRAINT [FK_SalesReturnUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_ServiceUser];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesReturnReturnType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesReturns] DROP CONSTRAINT [FK_SalesReturnReturnType];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceServiceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_ServiceServiceType];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceServiceCentre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_ServiceServiceCentre];
GO
IF OBJECT_ID(N'[dbo].[FK_StateCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[States] DROP CONSTRAINT [FK_StateCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_StateCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_StateCity];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessOffice_inherits_Office]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_BusinessOffice] DROP CONSTRAINT [FK_BusinessOffice_inherits_Office];
GO
IF OBJECT_ID(N'[dbo].[FK_Stockhouse_inherits_BusinessOffice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Stockhouse] DROP CONSTRAINT [FK_Stockhouse_inherits_BusinessOffice];
GO
IF OBJECT_ID(N'[dbo].[FK_Warehouse_inherits_Office]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Warehouse] DROP CONSTRAINT [FK_Warehouse_inherits_Office];
GO
IF OBJECT_ID(N'[dbo].[FK_Distributor_inherits_BusinessOffice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Distributor] DROP CONSTRAINT [FK_Distributor_inherits_BusinessOffice];
GO
IF OBJECT_ID(N'[dbo].[FK_Dealers_inherits_BusinessOffice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Dealers] DROP CONSTRAINT [FK_Dealers_inherits_BusinessOffice];
GO
IF OBJECT_ID(N'[dbo].[FK_Retailer_inherits_BusinessOffice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Retailer] DROP CONSTRAINT [FK_Retailer_inherits_BusinessOffice];
GO
IF OBJECT_ID(N'[dbo].[FK_Company_inherits_Office]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_Company] DROP CONSTRAINT [FK_Company_inherits_Office];
GO
IF OBJECT_ID(N'[dbo].[FK_User_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_User] DROP CONSTRAINT [FK_User_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Customer_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Customer] DROP CONSTRAINT [FK_Customer_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceCentre_inherits_Office]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offices_ServiceCentre] DROP CONSTRAINT [FK_ServiceCentre_inherits_Office];
GO
IF OBJECT_ID(N'[dbo].[FK_Mobile_inherits_ProductModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModels_Mobile] DROP CONSTRAINT [FK_Mobile_inherits_ProductModel];
GO
IF OBJECT_ID(N'[dbo].[FK_Tablet_inherits_ProductModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModels_Tablet] DROP CONSTRAINT [FK_Tablet_inherits_ProductModel];
GO
IF OBJECT_ID(N'[dbo].[FK_Laptop_inherits_ProductModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductModels_Laptop] DROP CONSTRAINT [FK_Laptop_inherits_ProductModel];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Offices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices];
GO
IF OBJECT_ID(N'[dbo].[Zones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zones];
GO
IF OBJECT_ID(N'[dbo].[ProductTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductTypes];
GO
IF OBJECT_ID(N'[dbo].[Manufactures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manufactures];
GO
IF OBJECT_ID(N'[dbo].[ProductModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModels];
GO
IF OBJECT_ID(N'[dbo].[ProductWarranties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductWarranties];
GO
IF OBJECT_ID(N'[dbo].[ProductItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductItems];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[ProductColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductColor];
GO
IF OBJECT_ID(N'[dbo].[ProductHistories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductHistories];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO
IF OBJECT_ID(N'[dbo].[ProductImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductImages];
GO
IF OBJECT_ID(N'[dbo].[SalesReturns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesReturns];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[ReturnTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReturnTypes];
GO
IF OBJECT_ID(N'[dbo].[ServiceTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceTypes];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Offices_BusinessOffice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_BusinessOffice];
GO
IF OBJECT_ID(N'[dbo].[Offices_Stockhouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_Stockhouse];
GO
IF OBJECT_ID(N'[dbo].[Offices_Warehouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_Warehouse];
GO
IF OBJECT_ID(N'[dbo].[Offices_Distributor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_Distributor];
GO
IF OBJECT_ID(N'[dbo].[Offices_Dealers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_Dealers];
GO
IF OBJECT_ID(N'[dbo].[Offices_Retailer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_Retailer];
GO
IF OBJECT_ID(N'[dbo].[Offices_Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_Company];
GO
IF OBJECT_ID(N'[dbo].[People_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_User];
GO
IF OBJECT_ID(N'[dbo].[People_Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Customer];
GO
IF OBJECT_ID(N'[dbo].[Offices_ServiceCentre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices_ServiceCentre];
GO
IF OBJECT_ID(N'[dbo].[ProductModels_Mobile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModels_Mobile];
GO
IF OBJECT_ID(N'[dbo].[ProductModels_Tablet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModels_Tablet];
GO
IF OBJECT_ID(N'[dbo].[ProductModels_Laptop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModels_Laptop];
GO
IF OBJECT_ID(N'[dbo].[ProductModelProductWarranty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModelProductWarranty];
GO
IF OBJECT_ID(N'[dbo].[ProductModelProductColors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductModelProductColors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(250)  NULL,
    [LastName] nvarchar(250)  NULL,
    [Gender] nvarchar(10)  NULL,
    [DataOfBirth] nvarchar(max)  NULL,
    [BloodGroup] nvarchar(10)  NULL,
    [PresentAddress_Address1] nvarchar(250)  NULL,
    [PresentAddress_Address2] nvarchar(250)  NULL,
    [PresentAddress_City] nvarchar(250)  NULL,
    [PresentAddress_State] nvarchar(100)  NULL,
    [PresentAddress_Country] nvarchar(100)  NULL,
    [PresentAddress_Zip] nvarchar(10)  NULL,
    [PermanentAddress_Address1] nvarchar(250)  NULL,
    [PermanentAddress_Address2] nvarchar(250)  NULL,
    [PermanentAddress_City] nvarchar(250)  NULL,
    [PermanentAddress_State] nvarchar(100)  NULL,
    [PermanentAddress_Country] nvarchar(100)  NULL,
    [PermanentAddress_Zip] nvarchar(10)  NULL,
    [Contact_Mobile] nvarchar(20)  NULL,
    [Contact_Phone] nvarchar(20)  NULL,
    [Contact_Email] nvarchar(250)  NULL,
    [Contact_Website] nvarchar(250)  NULL,
    [Contact_Fax] nvarchar(20)  NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'Offices'
CREATE TABLE [dbo].[Offices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Address_Address1] nvarchar(250)  NULL,
    [Address_Address2] nvarchar(250)  NULL,
    [Address_City] nvarchar(250)  NULL,
    [Address_State] nvarchar(100)  NULL,
    [Address_Country] nvarchar(100)  NULL,
    [Address_Zip] nvarchar(10)  NULL,
    [Contact1_Mobile] nvarchar(20)  NULL,
    [Contact1_Phone] nvarchar(20)  NULL,
    [Contact1_Email] nvarchar(250)  NULL,
    [Contact1_Website] nvarchar(250)  NULL,
    [Contact1_Fax] nvarchar(20)  NULL,
    [Contact2_Mobile] nvarchar(20)  NULL,
    [Contact2_Phone] nvarchar(20)  NULL,
    [Contact2_Email] nvarchar(250)  NULL,
    [Contact2_Website] nvarchar(250)  NULL,
    [Contact2_Fax] nvarchar(20)  NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL,
    [ContactPerson] nvarchar(250)  NULL
);
GO

-- Creating table 'Zones'
CREATE TABLE [dbo].[Zones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'ProductTypes'
CREATE TABLE [dbo].[ProductTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'Manufactures'
CREATE TABLE [dbo].[Manufactures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'ProductModels'
CREATE TABLE [dbo].[ProductModels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ModelNumber] nvarchar(100)  NULL,
    [ModelName] nvarchar(250)  NULL,
    [ManufactureId] int  NOT NULL,
    [ProductTypeId] int  NOT NULL,
    [Processor] nvarchar(50)  NULL,
    [Memory] nvarchar(50)  NULL,
    [OperatingSystem] nvarchar(50)  NULL,
    [OSVersion] nvarchar(50)  NULL,
    [InternalStorage] nvarchar(50)  NULL,
    [ExternalStorage] nvarchar(50)  NULL,
    [DisplayType] nvarchar(50)  NULL,
    [DisplaySize] nvarchar(50)  NULL,
    [DisplayResolution] nvarchar(50)  NULL,
    [Dimension] nvarchar(50)  NULL,
    [Weight] nvarchar(50)  NULL,
    [BatteryType] nvarchar(50)  NULL,
    [BatteryStandBy] float  NULL,
    [PrimaryCamera] nvarchar(20)  NULL,
    [SecondryCamera] nvarchar(20)  NULL,
    [VideoRecording] nvarchar(20)  NULL,
    [WiFi] nvarchar(20)  NULL
);
GO

-- Creating table 'ProductWarranties'
CREATE TABLE [dbo].[ProductWarranties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WarrantyNumber] nvarchar(30)  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [Period] int  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL,
    [SaleProductWarranty_ProductWarranty_Id] int  NOT NULL
);
GO

-- Creating table 'ProductItems'
CREATE TABLE [dbo].[ProductItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductModelId] int  NOT NULL,
    [WarehouseId] int  NULL,
    [StockhouseId] int  NULL,
    [DistributorId] int  NULL,
    [DealersId] int  NULL,
    [RetailerId] int  NULL,
    [SerialNumber] nvarchar(40)  NULL,
    [IMEI1] nvarchar(40)  NULL,
    [IMEI2] nvarchar(40)  NULL,
    [PartNumber] nvarchar(40)  NULL,
    [ProductColorsId] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [ModuleAccess] nvarchar(500)  NOT NULL,
    [ReadAccess] nvarchar(500)  NOT NULL,
    [WriteAccess] nvarchar(500)  NOT NULL,
    [DeleteAccess] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'ProductColor'
CREATE TABLE [dbo].[ProductColor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [HexCode] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'ProductHistories'
CREATE TABLE [dbo].[ProductHistories] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ProductItemId] int  NOT NULL,
    [Comments] nvarchar(250)  NOT NULL,
    [LogTime] datetime  NOT NULL,
    [LogUsername] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InvoiceNumber] nvarchar(50)  NOT NULL,
    [InvoicedDate] datetime  NOT NULL,
    [Amount] float  NULL,
    [Discount] float  NULL,
    [Payment] float  NULL,
    [UserId] int  NULL,
    [CustomerId] int  NULL,
    [WarrantyStart] datetime  NULL,
    [WarrantyEnd] datetime  NULL,
    [ProductItem_Id] int  NOT NULL,
    [SalesReturnSale_Sale_Id] int  NOT NULL
);
GO

-- Creating table 'ProductImages'
CREATE TABLE [dbo].[ProductImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [FileName] nvarchar(500)  NOT NULL,
    [ProductModelId] int  NOT NULL
);
GO

-- Creating table 'SalesReturns'
CREATE TABLE [dbo].[SalesReturns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Commands] nvarchar(250)  NULL,
    [UserId] int  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL,
    [ReturnTypeId] int  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Commands] nvarchar(500)  NOT NULL,
    [SaleId] int  NULL,
    [UserId] int  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL,
    [ServiceTypeId] int  NOT NULL,
    [ServiceCentreId] int  NOT NULL
);
GO

-- Creating table 'ReturnTypes'
CREATE TABLE [dbo].[ReturnTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'ServiceTypes'
CREATE TABLE [dbo].[ServiceTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL,
    [CountryId] smallint  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Status_IsActive] bit  NULL,
    [Status_IsDeleted] bit  NULL,
    [Status_IsHidden] bit  NULL,
    [Status_IsReadOnly] bit  NULL,
    [AuditLog_CreatedBy] int  NOT NULL,
    [AuditLog_CreatedOn] datetime  NOT NULL,
    [AuditLog_ModifiedBy] int  NULL,
    [AuditLog_ModifiedOn] datetime  NULL,
    [StateId] int  NOT NULL
);
GO

-- Creating table 'Offices_BusinessOffice'
CREATE TABLE [dbo].[Offices_BusinessOffice] (
    [EvaluationType] nvarchar(50)  NULL,
    [JoiningDate] datetime  NULL,
    [RecommendationFrom] nvarchar(100)  NULL,
    [CorporateStatus] nvarchar(50)  NULL,
    [RegistrationNumber] nvarchar(100)  NULL,
    [FunctioningFrom] datetime  NULL,
    [IndividualHouseAddress] nvarchar(250)  NULL,
    [FirmRegistration] nvarchar(250)  NULL,
    [TIN] nvarchar(250)  NULL,
    [PAN] nvarchar(20)  NULL,
    [CST] nvarchar(20)  NULL,
    [BusinessPresentAddress] nvarchar(250)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BankAccountNumber] nvarchar(30)  NULL,
    [BankIFSC] nvarchar(30)  NULL,
    [Location] nvarchar(50)  NULL,
    [Coverages] nvarchar(100)  NULL,
    [Languages] nvarchar(100)  NULL,
    [StrengthOfFieldForce] int  NULL,
    [TradeCreditFacilites] nvarchar(50)  NULL,
    [PeakSalesPeriod] nvarchar(50)  NULL,
    [ExpectedMonthlyLifting] int  NULL,
    [PopularFestivalFairs] nvarchar(100)  NULL,
    [Approver] nvarchar(250)  NULL,
    [ApprovalComments] nvarchar(250)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_Stockhouse'
CREATE TABLE [dbo].[Offices_Stockhouse] (
    [ZoneId] int  NOT NULL,
    [WarehouseId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_Warehouse'
CREATE TABLE [dbo].[Offices_Warehouse] (
    [CompanyId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_Distributor'
CREATE TABLE [dbo].[Offices_Distributor] (
    [StockhouseId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_Dealers'
CREATE TABLE [dbo].[Offices_Dealers] (
    [DistributorId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_Retailer'
CREATE TABLE [dbo].[Offices_Retailer] (
    [DealersId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_Company'
CREATE TABLE [dbo].[Offices_Company] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'People_User'
CREATE TABLE [dbo].[People_User] (
    [RoleId] smallint  NOT NULL,
    [OfficeId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'People_Customer'
CREATE TABLE [dbo].[People_Customer] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Offices_ServiceCentre'
CREATE TABLE [dbo].[Offices_ServiceCentre] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'ProductModels_Mobile'
CREATE TABLE [dbo].[ProductModels_Mobile] (
    [FormFactor] nvarchar(20)  NULL,
    [CallFeatures] nvarchar(20)  NULL,
    [SimSize] nvarchar(10)  NULL,
    [SimType] nvarchar(10)  NULL,
    [CallMemory] nvarchar(10)  NULL,
    [PhoneMemory] nvarchar(10)  NULL,
    [SMSMemory] nvarchar(10)  NULL,
    [PreinstalledBrowser] nvarchar(20)  NULL,
    [MusicPlayer] nvarchar(20)  NULL,
    [VideoPlayer] nvarchar(20)  NULL,
    [FM] nvarchar(20)  NULL,
    [SoundEnhancement] nvarchar(20)  NULL,
    [RingTone] nvarchar(20)  NULL,
    [SARValue] nvarchar(20)  NULL,
    [InternetFeatures] nvarchar(50)  NULL,
    [Connectivity_HSPA_3G] nvarchar(30)  NULL,
    [Connectivity_GPRS_2G] nvarchar(30)  NULL,
    [Connectivity_USB] nvarchar(30)  NULL,
    [Connectivity_Bluetooth] nvarchar(15)  NULL,
    [Connectivity_Hotspot] nvarchar(20)  NULL,
    [Connectivity_SupportedNetworks] nvarchar(50)  NULL,
    [Connectivity_OperatingFrequencies] nvarchar(30)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ProductModels_Tablet'
CREATE TABLE [dbo].[ProductModels_Tablet] (
    [CallFeatures] nvarchar(50)  NULL,
    [SupportedNetworks] nvarchar(30)  NULL,
    [PreinstalledBrowser] nvarchar(50)  NULL,
    [InternetFeatures] nvarchar(50)  NULL,
    [AudioJack] nvarchar(30)  NULL,
    [AudioFormat] nvarchar(30)  NULL,
    [VideoFormat] nvarchar(30)  NULL,
    [Connectivity_HSPA_3G] nvarchar(30)  NULL,
    [Connectivity_GPRS_2G] nvarchar(30)  NULL,
    [Connectivity_USB] nvarchar(30)  NULL,
    [Connectivity_Bluetooth] nvarchar(15)  NULL,
    [Connectivity_Hotspot] nvarchar(20)  NULL,
    [Connectivity_SupportedNetworks] nvarchar(50)  NULL,
    [Connectivity_OperatingFrequencies] nvarchar(30)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ProductModels_Laptop'
CREATE TABLE [dbo].[ProductModels_Laptop] (
    [Chipset] nvarchar(50)  NULL,
    [ClockSpeed] nvarchar(30)  NULL,
    [Cache] nvarchar(30)  NULL,
    [HardwareInterface] nvarchar(30)  NULL,
    [RPM] nvarchar(30)  NULL,
    [HDDCapacity] nvarchar(30)  NULL,
    [OpticalDrive] nvarchar(30)  NULL,
    [SystemArch] nvarchar(30)  NULL,
    [GraphicProcessor] nvarchar(30)  NULL,
    [Keyboard] nvarchar(30)  NULL,
    [Speakers] nvarchar(30)  NULL,
    [Sound] nvarchar(30)  NULL,
    [BatteryCell] nvarchar(50)  NULL,
    [USBPort] nvarchar(30)  NULL,
    [VGAPort] nvarchar(30)  NULL,
    [HDMIPort] nvarchar(30)  NULL,
    [RJ45LAN] nvarchar(30)  NULL,
    [MultiCardSlot] nvarchar(30)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ProductModelProductWarranty'
CREATE TABLE [dbo].[ProductModelProductWarranty] (
    [ProductModelProductWarranty_ProductWarranty_Id] int  NOT NULL,
    [ProductWarranties_Id] int  NOT NULL
);
GO

-- Creating table 'ProductModelProductColors'
CREATE TABLE [dbo].[ProductModelProductColors] (
    [ProductModelProductColors_ProductColors_Id] int  NOT NULL,
    [ProductColors_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices'
ALTER TABLE [dbo].[Offices]
ADD CONSTRAINT [PK_Offices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zones'
ALTER TABLE [dbo].[Zones]
ADD CONSTRAINT [PK_Zones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductTypes'
ALTER TABLE [dbo].[ProductTypes]
ADD CONSTRAINT [PK_ProductTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Manufactures'
ALTER TABLE [dbo].[Manufactures]
ADD CONSTRAINT [PK_Manufactures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductModels'
ALTER TABLE [dbo].[ProductModels]
ADD CONSTRAINT [PK_ProductModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductWarranties'
ALTER TABLE [dbo].[ProductWarranties]
ADD CONSTRAINT [PK_ProductWarranties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [PK_ProductItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductColor'
ALTER TABLE [dbo].[ProductColor]
ADD CONSTRAINT [PK_ProductColor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductHistories'
ALTER TABLE [dbo].[ProductHistories]
ADD CONSTRAINT [PK_ProductHistories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [PK_ProductImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SalesReturns'
ALTER TABLE [dbo].[SalesReturns]
ADD CONSTRAINT [PK_SalesReturns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReturnTypes'
ALTER TABLE [dbo].[ReturnTypes]
ADD CONSTRAINT [PK_ReturnTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceTypes'
ALTER TABLE [dbo].[ServiceTypes]
ADD CONSTRAINT [PK_ServiceTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_BusinessOffice'
ALTER TABLE [dbo].[Offices_BusinessOffice]
ADD CONSTRAINT [PK_Offices_BusinessOffice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_Stockhouse'
ALTER TABLE [dbo].[Offices_Stockhouse]
ADD CONSTRAINT [PK_Offices_Stockhouse]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_Warehouse'
ALTER TABLE [dbo].[Offices_Warehouse]
ADD CONSTRAINT [PK_Offices_Warehouse]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_Distributor'
ALTER TABLE [dbo].[Offices_Distributor]
ADD CONSTRAINT [PK_Offices_Distributor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_Dealers'
ALTER TABLE [dbo].[Offices_Dealers]
ADD CONSTRAINT [PK_Offices_Dealers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_Retailer'
ALTER TABLE [dbo].[Offices_Retailer]
ADD CONSTRAINT [PK_Offices_Retailer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_Company'
ALTER TABLE [dbo].[Offices_Company]
ADD CONSTRAINT [PK_Offices_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_User'
ALTER TABLE [dbo].[People_User]
ADD CONSTRAINT [PK_People_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Customer'
ALTER TABLE [dbo].[People_Customer]
ADD CONSTRAINT [PK_People_Customer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offices_ServiceCentre'
ALTER TABLE [dbo].[Offices_ServiceCentre]
ADD CONSTRAINT [PK_Offices_ServiceCentre]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductModels_Mobile'
ALTER TABLE [dbo].[ProductModels_Mobile]
ADD CONSTRAINT [PK_ProductModels_Mobile]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductModels_Tablet'
ALTER TABLE [dbo].[ProductModels_Tablet]
ADD CONSTRAINT [PK_ProductModels_Tablet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductModels_Laptop'
ALTER TABLE [dbo].[ProductModels_Laptop]
ADD CONSTRAINT [PK_ProductModels_Laptop]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ProductModelProductWarranty_ProductWarranty_Id], [ProductWarranties_Id] in table 'ProductModelProductWarranty'
ALTER TABLE [dbo].[ProductModelProductWarranty]
ADD CONSTRAINT [PK_ProductModelProductWarranty]
    PRIMARY KEY CLUSTERED ([ProductModelProductWarranty_ProductWarranty_Id], [ProductWarranties_Id] ASC);
GO

-- Creating primary key on [ProductModelProductColors_ProductColors_Id], [ProductColors_Id] in table 'ProductModelProductColors'
ALTER TABLE [dbo].[ProductModelProductColors]
ADD CONSTRAINT [PK_ProductModelProductColors]
    PRIMARY KEY CLUSTERED ([ProductModelProductColors_ProductColors_Id], [ProductColors_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ManufactureId] in table 'ProductModels'
ALTER TABLE [dbo].[ProductModels]
ADD CONSTRAINT [FK_ProductModelManufacture]
    FOREIGN KEY ([ManufactureId])
    REFERENCES [dbo].[Manufactures]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductModelManufacture'
CREATE INDEX [IX_FK_ProductModelManufacture]
ON [dbo].[ProductModels]
    ([ManufactureId]);
GO

-- Creating foreign key on [ProductTypeId] in table 'ProductModels'
ALTER TABLE [dbo].[ProductModels]
ADD CONSTRAINT [FK_ProductModelProductType]
    FOREIGN KEY ([ProductTypeId])
    REFERENCES [dbo].[ProductTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductModelProductType'
CREATE INDEX [IX_FK_ProductModelProductType]
ON [dbo].[ProductModels]
    ([ProductTypeId]);
GO

-- Creating foreign key on [ProductModelId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItemProductModel]
    FOREIGN KEY ([ProductModelId])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemProductModel'
CREATE INDEX [IX_FK_ProductItemProductModel]
ON [dbo].[ProductItems]
    ([ProductModelId]);
GO

-- Creating foreign key on [ZoneId] in table 'Offices_Stockhouse'
ALTER TABLE [dbo].[Offices_Stockhouse]
ADD CONSTRAINT [FK_StockhouseZone]
    FOREIGN KEY ([ZoneId])
    REFERENCES [dbo].[Zones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StockhouseZone'
CREATE INDEX [IX_FK_StockhouseZone]
ON [dbo].[Offices_Stockhouse]
    ([ZoneId]);
GO

-- Creating foreign key on [WarehouseId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItemWarehouse]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Offices_Warehouse]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemWarehouse'
CREATE INDEX [IX_FK_ProductItemWarehouse]
ON [dbo].[ProductItems]
    ([WarehouseId]);
GO

-- Creating foreign key on [StockhouseId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItemStockhouse]
    FOREIGN KEY ([StockhouseId])
    REFERENCES [dbo].[Offices_Stockhouse]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemStockhouse'
CREATE INDEX [IX_FK_ProductItemStockhouse]
ON [dbo].[ProductItems]
    ([StockhouseId]);
GO

-- Creating foreign key on [DistributorId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItemDistributor]
    FOREIGN KEY ([DistributorId])
    REFERENCES [dbo].[Offices_Distributor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemDistributor'
CREATE INDEX [IX_FK_ProductItemDistributor]
ON [dbo].[ProductItems]
    ([DistributorId]);
GO

-- Creating foreign key on [DealersId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_DealersProductItem]
    FOREIGN KEY ([DealersId])
    REFERENCES [dbo].[Offices_Dealers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DealersProductItem'
CREATE INDEX [IX_FK_DealersProductItem]
ON [dbo].[ProductItems]
    ([DealersId]);
GO

-- Creating foreign key on [RetailerId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItemRetailer]
    FOREIGN KEY ([RetailerId])
    REFERENCES [dbo].[Offices_Retailer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemRetailer'
CREATE INDEX [IX_FK_ProductItemRetailer]
ON [dbo].[ProductItems]
    ([RetailerId]);
GO

-- Creating foreign key on [ProductModelProductWarranty_ProductWarranty_Id] in table 'ProductModelProductWarranty'
ALTER TABLE [dbo].[ProductModelProductWarranty]
ADD CONSTRAINT [FK_ProductModelProductWarranty_ProductModel]
    FOREIGN KEY ([ProductModelProductWarranty_ProductWarranty_Id])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductWarranties_Id] in table 'ProductModelProductWarranty'
ALTER TABLE [dbo].[ProductModelProductWarranty]
ADD CONSTRAINT [FK_ProductModelProductWarranty_ProductWarranty]
    FOREIGN KEY ([ProductWarranties_Id])
    REFERENCES [dbo].[ProductWarranties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductModelProductWarranty_ProductWarranty'
CREATE INDEX [IX_FK_ProductModelProductWarranty_ProductWarranty]
ON [dbo].[ProductModelProductWarranty]
    ([ProductWarranties_Id]);
GO

-- Creating foreign key on [CompanyId] in table 'Offices_Warehouse'
ALTER TABLE [dbo].[Offices_Warehouse]
ADD CONSTRAINT [FK_CompanyWarehouse]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Offices_Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyWarehouse'
CREATE INDEX [IX_FK_CompanyWarehouse]
ON [dbo].[Offices_Warehouse]
    ([CompanyId]);
GO

-- Creating foreign key on [WarehouseId] in table 'Offices_Stockhouse'
ALTER TABLE [dbo].[Offices_Stockhouse]
ADD CONSTRAINT [FK_WarehouseStockhouse]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Offices_Warehouse]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WarehouseStockhouse'
CREATE INDEX [IX_FK_WarehouseStockhouse]
ON [dbo].[Offices_Stockhouse]
    ([WarehouseId]);
GO

-- Creating foreign key on [DealersId] in table 'Offices_Retailer'
ALTER TABLE [dbo].[Offices_Retailer]
ADD CONSTRAINT [FK_DealersRetailer]
    FOREIGN KEY ([DealersId])
    REFERENCES [dbo].[Offices_Dealers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DealersRetailer'
CREATE INDEX [IX_FK_DealersRetailer]
ON [dbo].[Offices_Retailer]
    ([DealersId]);
GO

-- Creating foreign key on [StockhouseId] in table 'Offices_Distributor'
ALTER TABLE [dbo].[Offices_Distributor]
ADD CONSTRAINT [FK_StockhouseDistributor]
    FOREIGN KEY ([StockhouseId])
    REFERENCES [dbo].[Offices_Stockhouse]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StockhouseDistributor'
CREATE INDEX [IX_FK_StockhouseDistributor]
ON [dbo].[Offices_Distributor]
    ([StockhouseId]);
GO

-- Creating foreign key on [DistributorId] in table 'Offices_Dealers'
ALTER TABLE [dbo].[Offices_Dealers]
ADD CONSTRAINT [FK_DistributorDealers]
    FOREIGN KEY ([DistributorId])
    REFERENCES [dbo].[Offices_Distributor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DistributorDealers'
CREATE INDEX [IX_FK_DistributorDealers]
ON [dbo].[Offices_Dealers]
    ([DistributorId]);
GO

-- Creating foreign key on [RoleId] in table 'People_User'
ALTER TABLE [dbo].[People_User]
ADD CONSTRAINT [FK_UserRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole'
CREATE INDEX [IX_FK_UserRole]
ON [dbo].[People_User]
    ([RoleId]);
GO

-- Creating foreign key on [OfficeId] in table 'People_User'
ALTER TABLE [dbo].[People_User]
ADD CONSTRAINT [FK_UserOffice]
    FOREIGN KEY ([OfficeId])
    REFERENCES [dbo].[Offices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOffice'
CREATE INDEX [IX_FK_UserOffice]
ON [dbo].[People_User]
    ([OfficeId]);
GO

-- Creating foreign key on [ProductItemId] in table 'ProductHistories'
ALTER TABLE [dbo].[ProductHistories]
ADD CONSTRAINT [FK_ProductHistoryProductItem]
    FOREIGN KEY ([ProductItemId])
    REFERENCES [dbo].[ProductItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductHistoryProductItem'
CREATE INDEX [IX_FK_ProductHistoryProductItem]
ON [dbo].[ProductHistories]
    ([ProductItemId]);
GO

-- Creating foreign key on [ProductItem_Id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_SalesProductItem]
    FOREIGN KEY ([ProductItem_Id])
    REFERENCES [dbo].[ProductItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesProductItem'
CREATE INDEX [IX_FK_SalesProductItem]
ON [dbo].[Sales]
    ([ProductItem_Id]);
GO

-- Creating foreign key on [UserId] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_SalesUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[People_User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesUser'
CREATE INDEX [IX_FK_SalesUser]
ON [dbo].[Sales]
    ([UserId]);
GO

-- Creating foreign key on [SaleProductWarranty_ProductWarranty_Id] in table 'ProductWarranties'
ALTER TABLE [dbo].[ProductWarranties]
ADD CONSTRAINT [FK_SaleProductWarranty]
    FOREIGN KEY ([SaleProductWarranty_ProductWarranty_Id])
    REFERENCES [dbo].[Sales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SaleProductWarranty'
CREATE INDEX [IX_FK_SaleProductWarranty]
ON [dbo].[ProductWarranties]
    ([SaleProductWarranty_ProductWarranty_Id]);
GO

-- Creating foreign key on [CustomerId] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_SaleCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[People_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SaleCustomer'
CREATE INDEX [IX_FK_SaleCustomer]
ON [dbo].[Sales]
    ([CustomerId]);
GO

-- Creating foreign key on [ProductColorsId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItemProductColors]
    FOREIGN KEY ([ProductColorsId])
    REFERENCES [dbo].[ProductColor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemProductColors'
CREATE INDEX [IX_FK_ProductItemProductColors]
ON [dbo].[ProductItems]
    ([ProductColorsId]);
GO

-- Creating foreign key on [ProductModelProductColors_ProductColors_Id] in table 'ProductModelProductColors'
ALTER TABLE [dbo].[ProductModelProductColors]
ADD CONSTRAINT [FK_ProductModelProductColors_ProductModel]
    FOREIGN KEY ([ProductModelProductColors_ProductColors_Id])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductColors_Id] in table 'ProductModelProductColors'
ALTER TABLE [dbo].[ProductModelProductColors]
ADD CONSTRAINT [FK_ProductModelProductColors_ProductColors]
    FOREIGN KEY ([ProductColors_Id])
    REFERENCES [dbo].[ProductColor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductModelProductColors_ProductColors'
CREATE INDEX [IX_FK_ProductModelProductColors_ProductColors]
ON [dbo].[ProductModelProductColors]
    ([ProductColors_Id]);
GO

-- Creating foreign key on [ProductModelId] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [FK_ProductModelProductImage]
    FOREIGN KEY ([ProductModelId])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductModelProductImage'
CREATE INDEX [IX_FK_ProductModelProductImage]
ON [dbo].[ProductImages]
    ([ProductModelId]);
GO

-- Creating foreign key on [SaleId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_ServiceSale]
    FOREIGN KEY ([SaleId])
    REFERENCES [dbo].[Sales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceSale'
CREATE INDEX [IX_FK_ServiceSale]
ON [dbo].[Services]
    ([SaleId]);
GO

-- Creating foreign key on [SalesReturnSale_Sale_Id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_SalesReturnSale]
    FOREIGN KEY ([SalesReturnSale_Sale_Id])
    REFERENCES [dbo].[SalesReturns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesReturnSale'
CREATE INDEX [IX_FK_SalesReturnSale]
ON [dbo].[Sales]
    ([SalesReturnSale_Sale_Id]);
GO

-- Creating foreign key on [UserId] in table 'SalesReturns'
ALTER TABLE [dbo].[SalesReturns]
ADD CONSTRAINT [FK_SalesReturnUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[People_User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesReturnUser'
CREATE INDEX [IX_FK_SalesReturnUser]
ON [dbo].[SalesReturns]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_ServiceUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[People_User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceUser'
CREATE INDEX [IX_FK_ServiceUser]
ON [dbo].[Services]
    ([UserId]);
GO

-- Creating foreign key on [ReturnTypeId] in table 'SalesReturns'
ALTER TABLE [dbo].[SalesReturns]
ADD CONSTRAINT [FK_SalesReturnReturnType]
    FOREIGN KEY ([ReturnTypeId])
    REFERENCES [dbo].[ReturnTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesReturnReturnType'
CREATE INDEX [IX_FK_SalesReturnReturnType]
ON [dbo].[SalesReturns]
    ([ReturnTypeId]);
GO

-- Creating foreign key on [ServiceTypeId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_ServiceServiceType]
    FOREIGN KEY ([ServiceTypeId])
    REFERENCES [dbo].[ServiceTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServiceType'
CREATE INDEX [IX_FK_ServiceServiceType]
ON [dbo].[Services]
    ([ServiceTypeId]);
GO

-- Creating foreign key on [ServiceCentreId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_ServiceServiceCentre]
    FOREIGN KEY ([ServiceCentreId])
    REFERENCES [dbo].[Offices_ServiceCentre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServiceCentre'
CREATE INDEX [IX_FK_ServiceServiceCentre]
ON [dbo].[Services]
    ([ServiceCentreId]);
GO

-- Creating foreign key on [CountryId] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [FK_StateCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateCountry'
CREATE INDEX [IX_FK_StateCountry]
ON [dbo].[States]
    ([CountryId]);
GO

-- Creating foreign key on [StateId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_StateCity]
    FOREIGN KEY ([StateId])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateCity'
CREATE INDEX [IX_FK_StateCity]
ON [dbo].[Cities]
    ([StateId]);
GO

-- Creating foreign key on [Id] in table 'Offices_BusinessOffice'
ALTER TABLE [dbo].[Offices_BusinessOffice]
ADD CONSTRAINT [FK_BusinessOffice_inherits_Office]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_Stockhouse'
ALTER TABLE [dbo].[Offices_Stockhouse]
ADD CONSTRAINT [FK_Stockhouse_inherits_BusinessOffice]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices_BusinessOffice]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_Warehouse'
ALTER TABLE [dbo].[Offices_Warehouse]
ADD CONSTRAINT [FK_Warehouse_inherits_Office]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_Distributor'
ALTER TABLE [dbo].[Offices_Distributor]
ADD CONSTRAINT [FK_Distributor_inherits_BusinessOffice]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices_BusinessOffice]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_Dealers'
ALTER TABLE [dbo].[Offices_Dealers]
ADD CONSTRAINT [FK_Dealers_inherits_BusinessOffice]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices_BusinessOffice]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_Retailer'
ALTER TABLE [dbo].[Offices_Retailer]
ADD CONSTRAINT [FK_Retailer_inherits_BusinessOffice]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices_BusinessOffice]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_Company'
ALTER TABLE [dbo].[Offices_Company]
ADD CONSTRAINT [FK_Company_inherits_Office]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'People_User'
ALTER TABLE [dbo].[People_User]
ADD CONSTRAINT [FK_User_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'People_Customer'
ALTER TABLE [dbo].[People_Customer]
ADD CONSTRAINT [FK_Customer_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Offices_ServiceCentre'
ALTER TABLE [dbo].[Offices_ServiceCentre]
ADD CONSTRAINT [FK_ServiceCentre_inherits_Office]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Offices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ProductModels_Mobile'
ALTER TABLE [dbo].[ProductModels_Mobile]
ADD CONSTRAINT [FK_Mobile_inherits_ProductModel]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ProductModels_Tablet'
ALTER TABLE [dbo].[ProductModels_Tablet]
ADD CONSTRAINT [FK_Tablet_inherits_ProductModel]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ProductModels_Laptop'
ALTER TABLE [dbo].[ProductModels_Laptop]
ADD CONSTRAINT [FK_Laptop_inherits_ProductModel]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ProductModels]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------