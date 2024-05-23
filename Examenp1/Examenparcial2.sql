-- Crear tabla Sucursal
--Crear tabla Cliente
CREATE TABLE cliente (
    id SERIAL PRIMARY KEY,
    idbanco INTEGER,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Documento VARCHAR(20) NOT NULL UNIQUE,
    Direccion VARCHAR(255),
    Mail VARCHAR(100) UNIQUE,
    Celular VARCHAR(20),
    Estado VARCHAR(20)
);
 
-- Crear tabla Sucursal
CREATE TABLE sucursal (
    id SERIAL PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL,
    Direccion VARCHAR(255),
    Telefono VARCHAR(20),
    Whatsapp VARCHAR(20),
    Mail VARCHAR(100),
    Estado VARCHAR(20)
);
 
-- Crear tabla Factura
CREATE TABLE factura (
    IdFact SERIAL PRIMARY KEY,
    Idcliente INTEGER NOT NULL,
    Id_sucursal INTEGER NOT NULL,
    Nrofact VARCHAR(50) NOT NULL UNIQUE,
    Fechahora TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Total NUMERIC(12, 2) NOT NULL,
    Total5 NUMERIC(12, 2),
    Total10 NUMERIC(12, 2),
    Totaliva NUMERIC(12, 2),
    Totalletras VARCHAR(255),
    Sucursal VARCHAR(100),
    CONSTRAINT fk_cliente FOREIGN KEY(Idcliente) REFERENCES Cliente(id),
    CONSTRAINT fk_sucursal FOREIGN KEY(Id_sucursal) REFERENCES Sucursal(id)
);