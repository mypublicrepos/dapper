Create database Prodnet;
Use Prodnet;

CREATE TABLE User (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Contact VARCHAR(10) NOT NULL,
    Gender TINYINT,
    Status BIT,
    CreatedDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate TIMESTAMP,
    CONSTRAINT chk_gender CHECK (Gender IN (0, 1, 2))
);

CREATE TABLE Role (
    Id CHAR(36) PRIMARY KEY,
    RoleName VARCHAR(255),
    CreatedDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate TIMESTAMP
);

CREATE TABLE Credentials (
    Id CHAR(36) PRIMARY KEY,
    UserId CHAR(36),
    RoleId CHAR(36),
    Hash TEXT,
    Salt TEXT,
    CreatedDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES User(Id),
    FOREIGN KEY (RoleId) REFERENCES Role(Id)
);