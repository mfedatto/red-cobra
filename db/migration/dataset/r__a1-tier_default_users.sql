INSERT INTO
    Users (
        UserId,
        Username,
        PasswordHash,
        PasswordSalt,
        Admin,
        FullName,
        Email)
    VALUES (
        '7a0eed16-9430-4d68-901f-c0d4c1c3bf00'::uuid,
        'angrydog683',
        '956b3128768b6a737fdda774a07e582dd016be48ab9bb4b0fe63a1ef6dcffc04',
        'oWcQb96n',
        true,
        'Emile Andre',
        'emile.andre@redcobra.tld')
ON CONFLICT (UserId)
DO UPDATE SET
    UserId = EXCLUDED.UserId,
    Username = EXCLUDED.Username,
    PasswordHash = EXCLUDED.PasswordHash,
    PasswordSalt = EXCLUDED.PasswordSalt,
    Admin = EXCLUDED.Admin,
    FullName = EXCLUDED.FullName,
    Email = EXCLUDED.Email;

INSERT INTO
    Users (
        UserId,
        Username,
        PasswordHash,
        PasswordSalt,
        Admin,
        FullName,
        Email)
    VALUES (
        '5cb51f20-a841-4cfe-82cd-01bf338d3b71'::uuid,
        'smallbear176',
        '5633b230fb78321701e5ef9a5ec10d5a9a62a5dc3d3b6186b9509dda138cc25e',
        'FsgW06ak',
        true,
        'Joshua Smith',
        'joshua.smith@redcobra.tld')
ON CONFLICT (UserId)
DO UPDATE SET
    UserId = EXCLUDED.UserId,
    Username = EXCLUDED.Username,
    PasswordHash = EXCLUDED.PasswordHash,
    PasswordSalt = EXCLUDED.PasswordSalt,
    Admin = EXCLUDED.Admin,
    FullName = EXCLUDED.FullName,
    Email = EXCLUDED.Email;

INSERT INTO
    Users (
        UserId,
        Username,
        PasswordHash,
        PasswordSalt,
        Admin,
        FullName,
        Email)
    VALUES (
        'a8fe5f9f-77f8-4ab9-94ad-b60f31099e15'::uuid,
        'purplesnake768',
        '54d2dc144195272d3ad8b875a465e5463b95bbb33aa874cce6f945c17c56a34e',
        'ED9HMSJ2',
        false,
        'Lionel Lemke',
        'lionel.lemke@example.com')
ON CONFLICT (UserId)
DO UPDATE SET
    UserId = EXCLUDED.UserId,
    Username = EXCLUDED.Username,
    PasswordHash = EXCLUDED.PasswordHash,
    PasswordSalt = EXCLUDED.PasswordSalt,
    Admin = EXCLUDED.Admin,
    FullName = EXCLUDED.FullName,
    Email = EXCLUDED.Email;
