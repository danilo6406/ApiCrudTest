CREATE DATABASE ApiTestDb;
GO

USE ApiTestDb;
GO

CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
 CONSTRAINT [PK__Product__B40CC6EDDAF28AED] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Product Identificator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'ProductID'
GO

CREATE TABLE [dbo].[Stores](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[StoreName] [varchar](50) NULL,
 CONSTRAINT [PK__Store__3B82F0E15E43CFE6] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Store identificator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stores', @level2type=N'COLUMN',@level2name=N'StoreID'
GO

CREATE TABLE [dbo].[StoreProductMappings](
	[MappingID] [int] IDENTITY(1,1) NOT NULL,
	[StoreID] [int] NULL,
	[ProductID] [int] NULL,
	[Stock] [int] NULL,
 CONSTRAINT [PK__StorePro__8B5781BD48F098BD] PRIMARY KEY CLUSTERED 
(
	[MappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StoreProductMappings]  WITH CHECK ADD  CONSTRAINT [FK__StoreProd__Produ__3C69FB99] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO

ALTER TABLE [dbo].[StoreProductMappings] CHECK CONSTRAINT [FK__StoreProd__Produ__3C69FB99]
GO

ALTER TABLE [dbo].[StoreProductMappings]  WITH CHECK ADD  CONSTRAINT [FK__StoreProd__Store__3B75D760] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Stores] ([StoreID])
GO

ALTER TABLE [dbo].[StoreProductMappings] CHECK CONSTRAINT [FK__StoreProd__Store__3B75D760]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mapping Identificator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StoreProductMappings', @level2type=N'COLUMN',@level2name=N'MappingID'
GO