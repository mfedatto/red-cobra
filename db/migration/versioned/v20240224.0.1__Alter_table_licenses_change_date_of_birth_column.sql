ALTER TABLE Licenses
    ADD COLUMN DateOfBirth DATE;

UPDATE Licenses
    SET DateOfBirth = BirthDate;

ALTER TABLE Licenses
    DROP COLUMN BirthDate;

ALTER TABLE Licenses
    ALTER COLUMN DateOfBirth SET NOT NULL;
