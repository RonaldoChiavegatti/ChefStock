Build started...
Build succeeded.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categorias] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Fornecedores] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Endereco] nvarchar(max) NULL,
    CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Funcionarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Cargo] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    CONSTRAINT [PK_Funcionarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PedidosCompra] (
    [Id] int NOT NULL IDENTITY,
    [DataPedido] datetime2 NOT NULL,
    [FornecedorId] int NOT NULL,
    [Total] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PedidosCompra] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidosCompra_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [PrecoUnitario] decimal(18,2) NOT NULL,
    [QuantidadeEmEstoque] int NOT NULL,
    [CategoriaId] int NOT NULL,
    [FornecedorId] int NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Inventarios] (
    [Id] int NOT NULL IDENTITY,
    [ProdutoId] int NOT NULL,
    [DataMovimentacao] datetime2 NOT NULL,
    [Quantidade] int NOT NULL,
    [TipoMovimentacao] int NOT NULL,
    CONSTRAINT [PK_Inventarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Inventarios_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id])
);
GO

CREATE TABLE [ItensPedidoCompra] (
    [Id] int NOT NULL IDENTITY,
    [PedidoCompraId] int NOT NULL,
    [ProdutoId] int NOT NULL,
    [Quantidade] int NOT NULL,
    [PrecoUnitario] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ItensPedidoCompra] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ItensPedidoCompra_PedidosCompra_PedidoCompraId] FOREIGN KEY ([PedidoCompraId]) REFERENCES [PedidosCompra] ([Id]),
    CONSTRAINT [FK_ItensPedidoCompra_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id])
);
GO

CREATE INDEX [IX_Inventarios_ProdutoId] ON [Inventarios] ([ProdutoId]);
GO

CREATE INDEX [IX_ItensPedidoCompra_PedidoCompraId] ON [ItensPedidoCompra] ([PedidoCompraId]);
GO

CREATE INDEX [IX_ItensPedidoCompra_ProdutoId] ON [ItensPedidoCompra] ([ProdutoId]);
GO

CREATE INDEX [IX_PedidosCompra_FornecedorId] ON [PedidosCompra] ([FornecedorId]);
GO

CREATE INDEX [IX_Produtos_CategoriaId] ON [Produtos] ([CategoriaId]);
GO

CREATE INDEX [IX_Produtos_FornecedorId] ON [Produtos] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241111010537_InitialCreate', N'8.0.10');
GO

COMMIT;
GO


