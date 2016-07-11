CREATE DATABASE CartOrder

USE CartOrder

CREATE TABLE [dbo].[Cart] (
    [Id]                            INT					IDENTITY (1, 1)				NOT NULL,
    [description]                   NVARCHAR (120)		DEFAULT ('')				NOT NULL,
	[creation]						smalldatetime		DEFAULT (SYSDATETIME ()) 	NOT NULL,

    CONSTRAINT [PK_Cart_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Order] (
    [Id]                            INT             IDENTITY (1, 1)			NOT NULL,
	[CartId]                        INT										NOT NULL,
    [OrderName]                     NVARCHAR (120)  DEFAULT ('')			NOT NULL,
    [IsDeleted]                     BIT             DEFAULT (0)				NOT NULL,
	
    CONSTRAINT [PK_Order_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Order_CartId] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Cart] ([Id])
);

CREATE TABLE [dbo].[OrderItem] (
    [Id]                        INT             IDENTITY (1, 1)			NOT NULL,
    [OrderId]					INT										NOT NULL,
    [UnitPrice]                 MONEY           DEFAULT (0)				NOT NULL,
    [IsDeleted]                 BIT             DEFAULT (0)				NOT NULL,

    CONSTRAINT [PK_OrderItem_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItem_OrderId_Order_Id] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);