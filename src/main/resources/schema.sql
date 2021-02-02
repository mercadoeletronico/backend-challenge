CREATE TABLE IF NOT EXISTS orders (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    id_order VARCHAR (10) NOT NULL,
    description VARCHAR (255) NOT NULL,
    price INTEGER CHECK price > 0,
    quantity INTEGER CHECK quantity > 0,
    INDEX (id_order)
);

