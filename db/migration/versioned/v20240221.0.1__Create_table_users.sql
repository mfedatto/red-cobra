CREATE TABLE Users (
    UserId UUID PRIMARY KEY,
    Username TEXT NOT NULL,
    PasswordHash TEXT NOT NULL,
    PasswordSalt TEXT NOT NULL,
    Admin TEXT NOT NULL,
    FullName TEXT,
    Email TEXT
);

ALTER TABLE Users
ADD CONSTRAINT uk_Username UNIQUE (Username);
