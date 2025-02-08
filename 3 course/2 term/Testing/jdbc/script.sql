CREATE DATABASE file_system;

CREATE TABLE IF NOT EXISTS directories (
    id SERIAL PRIMARY KEY,
    parent_id INTEGER REFERENCES directories(id) ON DELETE CASCADE,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS files (
    id SERIAL PRIMARY KEY,
    directory_id INTEGER NOT NULL REFERENCES directories(id) ON DELETE CASCADE,
    name VARCHAR(255) NOT NULL,
    size INTEGER NOT NULL
);

INSERT INTO directories (parent_id, name) VALUES
(NULL, 'Root'),
(1, 'Subdirectory1'),
(1, 'Subdirectory2');

INSERT INTO files (directory_id, name, size) VALUES
(2, 'File1.txt', 1024),
(3, 'File2.txt', 2048);

select * from directories;