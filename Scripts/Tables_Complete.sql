create database CustomerDelivery
use CustomerDelivery

CREATE TABLE Cliente (
    ClienteId INT IDENTITY PRIMARY KEY,
    Identificacion VARCHAR(20) NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    Direccion VARCHAR(250) NOT NULL,

    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(100) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Producto (
    ProductoId INT IDENTITY PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    ValorUnitario DECIMAL(18,2) NOT NULL,

    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(100) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE OrdenPedido (
    OrdenPedidoId INT IDENTITY PRIMARY KEY,
    ClienteId INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    DireccionEntrega VARCHAR(250) NOT NULL,
    Prioridad VARCHAR(10) NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL,

    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(100) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_OrdenPedido_Cliente 
        FOREIGN KEY (ClienteId) REFERENCES Cliente(ClienteId)
);

CREATE TABLE OrdenPedidoDetalle (
    DetalleId INT IDENTITY PRIMARY KEY,
    OrdenPedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    ValorUnitario DECIMAL(18,2) NOT NULL,
    Cantidad INT NOT NULL,
    ValorParcial DECIMAL(18,2) NOT NULL,

    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion VARCHAR(100) NOT NULL,
    FechaModificacion DATETIME NULL,
    UsuarioModificacion VARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Detalle_Orden 
        FOREIGN KEY (OrdenPedidoId) REFERENCES OrdenPedido(OrdenPedidoId),

    CONSTRAINT FK_Detalle_Producto 
        FOREIGN KEY (ProductoId) REFERENCES Producto(ProductoId)
);
