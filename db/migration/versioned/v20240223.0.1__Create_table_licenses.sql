CREATE TABLE Licenses (
    LicenseId UUID PRIMARY KEY,
    LicenseNumber TEXT NOT NULL,
    UserId UUID NOT NULL,
    ExpirationDate DATE NOT NULL,
    ACategory BOOL NOT NULL,
    BCategory BOOL NOT NULL,
    BirthDate DATE NOT NULL,
    LicenseFileId UUID NULL,
    Issuer TEXT NULL,
    IssueDate DATE NULL
);

ALTER TABLE Licenses
ADD CONSTRAINT uk_LicenseNumber UNIQUE (LicenseNumber);
