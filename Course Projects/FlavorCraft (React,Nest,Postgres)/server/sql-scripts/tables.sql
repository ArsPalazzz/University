CREATE EXTENSION IF NOT EXISTS "pgcrypto";

DROP TRIGGER ratings_update_trigger on ratings;
DROP TABLE recipes_ingredients;
DROP TABLE ingredients;
DROP TABLE recipes_tags;
DROP TABLE tags;
DROP TABLE categories;
DROP TABLE banned_users;
DROP TABLE favorites;
DROP TABLE ratings;
DROP TABLE comments;
DROP TABLE recipes;
DROP TABLE cuisines;
DROP TABLE followings;
DROP TABLE users;


CREATE TABLE users (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(50) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    avatar_url TEXT,
    role VARCHAR(20) DEFAULT 'user',
    is_blocked BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE followings (
    id SERIAL PRIMARY KEY,
    follower_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    followed_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (follower_id, followed_id)
);

CREATE TABLE cuisines (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE categories (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE recipes (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
	cuisine_id INT REFERENCES cuisines(id) ON DELETE SET NULL,
	category_id INT REFERENCES categories(id) ON DELETE SET NULL,
    title VARCHAR(100) NOT NULL,
    description TEXT NOT NULL,
	image_path TEXT,
    instructions TEXT[] NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    prep_time INT NOT NULL,
	portions_min INT NOT NULL,
	portions_max INT,
	difficulty_level varchar(10) check(difficulty_level in ('Easy', 'Medium', 'Hard')),
    calories INT,
	protein INT NOT NULL,
	fat INT NOT NULL,
	carbs INT NOT NULL,
    avg_rating DECIMAL(3, 2) DEFAULT 0,
    status VARCHAR(20) DEFAULT 'pending'
);

CREATE TABLE comments (
    id SERIAL PRIMARY KEY,
    recipe_id UUID NOT NULL REFERENCES recipes(id) ON DELETE CASCADE,
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    content TEXT NOT NULL,
    status TEXT NOT NULL CHECK (status in ('active', 'blocked', 'archieved')) DEFAULT 'active',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE ratings (
    id SERIAL PRIMARY KEY,
    recipe_id UUID NOT NULL REFERENCES recipes(id) ON DELETE CASCADE,
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (recipe_id, user_id) -- Один пользователь может оставить только одну оценку для рецепта
);

CREATE TABLE favorites (
    id SERIAL PRIMARY KEY,
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    recipe_id UUID NOT NULL REFERENCES recipes(id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (user_id, recipe_id) -- Один пользователь может добавить рецепт в избранное только один раз
);

CREATE TABLE banned_users (
    id SERIAL PRIMARY KEY,
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    reason TEXT NOT NULL,
    banned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT unique_user_ban UNIQUE (user_id)
);

CREATE TABLE tags (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
	query_key VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE recipes_tags (
    recipe_id UUID NOT NULL REFERENCES recipes(id) ON DELETE CASCADE,
    tag_id INT NOT NULL REFERENCES tags(id) ON DELETE CASCADE,
    PRIMARY KEY (recipe_id, tag_id)
);

CREATE TABLE ingredients (
    id SERIAL PRIMARY KEY,
    name VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE recipes_ingredients (
    recipe_id UUID NOT NULL REFERENCES recipes(id) ON DELETE CASCADE,
    ingredient_id INT NOT NULL REFERENCES ingredients(id) ON DELETE CASCADE,
    quantity VARCHAR(50) NOT NULL,
    PRIMARY KEY (recipe_id, ingredient_id)
);

CREATE OR REPLACE FUNCTION update_avg_rating()
RETURNS TRIGGER AS $$
BEGIN
  UPDATE recipes
  SET avg_rating = (
    SELECT AVG(rating) 
    FROM ratings 
    WHERE ratings.recipe_id = NEW.recipe_id
  )
  WHERE id = NEW.recipe_id;
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION calculate_calories()
RETURNS TRIGGER AS $$
BEGIN
    NEW.calories := (NEW.protein * 4) + (NEW.fat * 9) + (NEW.carbs * 4);
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;


CREATE TRIGGER ratings_update_trigger
AFTER INSERT OR UPDATE ON ratings
FOR EACH ROW
EXECUTE FUNCTION update_avg_rating();

CREATE TRIGGER trigger_calculate_calories
BEFORE INSERT OR UPDATE ON recipes
FOR EACH ROW
EXECUTE FUNCTION calculate_calories();

delete from cuisines;
INSERT INTO cuisines (name)
VALUES
    ('French'),
    ('Italian'),
    ('Chinese'),
    ('Indian'),
    ('Mexican'),
    ('Japanese'),
    ('Thai'),
    ('Spanish'),
    ('Greek'),
    ('Lebanese'),
    ('Turkish'),
    ('Moroccan'),
    ('Russian'),
	('Ukrainian'),
    ('Belarusian'),
    ('Korean'),
    ('Vietnamese'),
    ('Brazilian'),
    ('American'),
    ('British'),
    ('German'),
    ('Caribbean'),
    ('Ethiopian'),
    ('Persian'),
    ('Filipino'),
    ('Indonesian'),
    ('South African'),
    ('Australian'),
    ('Cuban'),
    ('Argentine'),
    ('Swedish'),
    ('Polish'),
    ('Egyptian');



-- Удаление всех существующих категорий и добавление новых
DELETE FROM categories;
INSERT INTO categories (id, name) VALUES
(1, 'Breakfast'),
(2, 'Lunch'),
(3, 'Dinner'),
(4, 'Dessert'),
(5, 'Salads'),
(6, 'Soups'),
(7, 'Main Courses'),
(8, 'Drinks'),
(9, 'Baking'),
(10, 'Festive'),
(11, 'Snacks');

-- Удаление всех существующих тегов и добавление новых
DELETE FROM tags;
INSERT INTO tags (id, name, query_key) VALUES
(1, 'Fried', 'fried'),
(2, 'Boiled', 'boiled'),
(3, 'Baked', 'baked'),
(4, 'Spicy', 'spicy'),
(5, 'Light', 'light'),
(6, 'Diet', 'diet'),
(7, 'Vegetarian', 'vegetarian'),
(8, 'Gluten-Free', 'gluten-free'),
(9, 'Sugar-Free', 'sugar-free'),
(10, 'Traditional', 'traditional'),
(11, 'Quick', 'quick'),
(12, 'Seasonal', 'seasonal'),
(13, 'Cold', 'cold'),
(14, 'Hot', 'hot'),
(15, 'Creamy', 'creamy'),
(16, 'Meaty', 'meaty'),
(17, 'Fishy', 'fishy'),
(18, 'Vegetable', 'vegetable'),
(19, 'Fruity', 'fruity'),
(20, 'For Kids', 'for-kids');

ALTER TABLE users 
