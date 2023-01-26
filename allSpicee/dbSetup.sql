CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        title VARCHAR(50) NOT NULL,
        instructions VARCHAR(500) NOT NULL,
        category VARCHAR(25) NOT NULL DEFAULT 'misc',
        img VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

ALTER TABLE recipes ADD COLUMN favCount int NOT NULL DEFAULT 0;

UPDATE recipes SET favCount = favCount +1 WHERE id = 1;

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        recipeId INT NOT NULL,
        Name VARCHAR(50) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Quantity VARCHAR(50) NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

SELECT
    recipe.*,
    COUNT(fm.id) AS calcFavCount,
    prof.*
FROM recipes recipe
    LEFT JOIN favorites fm ON recipe.id = fm.recipeId
    JOIN accounts prof ON prof.id = recipe.`creatorId`
GROUP BY (recipe.id);

CREATE TABLE
    favorites(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        recipeId INT NOT NULL,
        accountId VARCHAR(255) NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
        Foreign Key (accountId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8;

DROP TABLE Favorites 