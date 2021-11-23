CREATE TABLE IF NOT EXISTS products
(
    id serial,
    category_id int NOT NULL,
    name varchar(100) NOT NULL,
    description varchar(200) NOT NULL,
    price money NOT NULL,
    CONSTRAINT products_pkey PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS categories
(
    id serial,
    category_name varchar(100),
    CONSTRAINT categories_pkey PRIMARY KEY (id)
);

INSERT INTO categories(id, category_name)
VALUES (1, 'Dairy'), (2, 'Meat'), (3, 'Fruit');

INSERT INTO products(category_id, name, description, price)
VALUES (1, 'Milk', 'Stuff you put in cereal', 3.50),
       (1, 'Yogurt', 'Fermented Milk', 1.99), 
       (1, 'Sour Cream', 'Sour Fermented Milk', 1.20), 
       (1, 'Cheddar Cheese', 'Solid Milk', 2.00), 
       (1, 'Swiss Cheese', 'Its Swiss', 2.00), 
       (2, 'Ground Beef', 'Comes from cows', 6.80), 
       (2, 'Chicken', 'Comes from chickens', 8.40), 
       (2, 'Steak', 'Comes from cows', 11.30), 
       (2, 'Pork', 'Comes from pigs', 8.80), 
       (3, 'Banana', 'Yellow Fruit', 0.50), 
       (3, 'Apple', 'Red Fruit', 0.60), 
       (3, 'Orange', 'Orange Fruit', 0.80), 
       (3, 'Grapefruit', 'Pink Fruit', 0.75), 
       (3, 'Blueberries', 'Blue Fruit', 3.30);
