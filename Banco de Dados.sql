-- ============================================================
-- StockControl - script de criação do banco de dados
-- Execute no SQL Server (SSMS ou sqlcmd). O script pode ser
-- executado mais de uma vez: nada é recriado ou duplicado.
-- ============================================================

IF DB_ID(N'StockControlDB') IS NULL
BEGIN
    CREATE DATABASE StockControlDB;
END
GO

USE StockControlDB;
GO

IF OBJECT_ID(N'dbo.Produtos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Produtos
    (
        Id         INT IDENTITY(1,1) NOT NULL,
        Nome       NVARCHAR(150)     NOT NULL,
        Preco      DECIMAL(10,2)     NOT NULL,
        Quantidade INT               NOT NULL,

        CONSTRAINT PK_Produtos PRIMARY KEY (Id),
        CONSTRAINT CK_Produtos_Preco CHECK (Preco >= 0),
        CONSTRAINT CK_Produtos_Quantidade CHECK (Quantidade >= 0)
    );
END
GO

IF OBJECT_ID(N'dbo.Movimentacoes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Movimentacoes
    (
        Id         INT IDENTITY(1,1) NOT NULL,
        ProdutoId  INT               NOT NULL,
        Tipo       TINYINT           NOT NULL, -- 1 = Entrada, 2 = Saída
        Quantidade INT               NOT NULL,
        Data       DATETIME2         NOT NULL CONSTRAINT DF_Movimentacoes_Data DEFAULT (SYSDATETIME()),
        Observacao NVARCHAR(200)     NULL,

        CONSTRAINT PK_Movimentacoes PRIMARY KEY (Id),
        CONSTRAINT FK_Movimentacoes_Produtos FOREIGN KEY (ProdutoId) REFERENCES dbo.Produtos (Id),
        CONSTRAINT CK_Movimentacoes_Tipo CHECK (Tipo IN (1, 2)),
        CONSTRAINT CK_Movimentacoes_Quantidade CHECK (Quantidade > 0)
    );
END
GO

-- Dados de exemplo (apenas quando a tabela está vazia)
IF NOT EXISTS (SELECT 1 FROM dbo.Produtos)
BEGIN
    INSERT INTO dbo.Produtos (Nome, Preco, Quantidade) VALUES
        (N'Caneta Azul', 2.50, 100),
        (N'Caderno 200 folhas', 18.90, 40),
        (N'Lápis HB', 1.20, 250);
END
GO
