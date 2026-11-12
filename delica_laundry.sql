CREATE DATABASE delica_laundry;
USE delica_laundry;

CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    full_name VARCHAR(100) NOT NULL,

    role ENUM(
        'Owner',
        'Staff Laundry',
        'Staff Antar-Jemput',
        'Customer'
    ) NOT NULL,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
        ON UPDATE CURRENT_TIMESTAMP

) ENGINE=InnoDB;

CREATE TABLE customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_name VARCHAR(100) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    address TEXT
) ENGINE=InnoDB;

CREATE TABLE services (
    service_id INT AUTO_INCREMENT PRIMARY KEY,
    service_name VARCHAR(100) NOT NULL,
    pricing_type ENUM('KG', 'ITEM') NOT NULL,
    unit_price DECIMAL(12,2) NOT NULL,
    estimated_days INT NOT NULL,
    express_fee DECIMAL(12,2) DEFAULT 0,
    is_active BOOLEAN DEFAULT TRUE
) ENGINE=InnoDB;

CREATE TABLE orders (
    order_id BIGINT AUTO_INCREMENT PRIMARY KEY,
    order_no VARCHAR(40) NOT NULL UNIQUE,
    customer_id INT NOT NULL,
    service_id INT NOT NULL,
    created_by INT NOT NULL,
    order_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    weight_kg DECIMAL(8,2) DEFAULT NULL,
    item_qty INT DEFAULT NULL,
    unit_price_snapshot DECIMAL(12,2) NOT NULL,
    subtotal DECIMAL(12,2) NOT NULL,
    is_express BOOLEAN DEFAULT FALSE,
    express_fee DECIMAL(12,2) DEFAULT 0,
    transport_fee DECIMAL(12,2) DEFAULT 0,
    final_total DECIMAL(12,2) NOT NULL,
    order_status ENUM(
        'Diterima',
        'Diproses',
        'Siap Diambil',
        'Dalam Pengantaran',
        'Selesai',
        'Dibatalkan'
    ) DEFAULT 'Diterima',

    payment_status ENUM(
        'Belum Dibayar',
        'Sebagian',
        'Lunas'
    ) DEFAULT 'Belum Dibayar',

    CONSTRAINT fk_order_customer
        FOREIGN KEY (customer_id)
        REFERENCES customers(customer_id),

    CONSTRAINT fk_order_service
        FOREIGN KEY (service_id)
        REFERENCES services(service_id),

    CONSTRAINT fk_order_user
        FOREIGN KEY (created_by)
        REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE payments (
    payment_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id BIGINT NOT NULL,
    recorded_by INT NOT NULL,
    payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    amount DECIMAL(12,2) NOT NULL,
    payment_method ENUM(
        'Cash',
        'Transfer',
        'QRIS'
    ) NOT NULL,

    FOREIGN KEY (order_id)
        REFERENCES orders(order_id),

    FOREIGN KEY (recorded_by)
        REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE laundry_process (
    process_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id BIGINT NOT NULL,
    updated_by INT NOT NULL,

    status VARCHAR(30) NOT NULL,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    notes TEXT,

    FOREIGN KEY (order_id)
        REFERENCES orders(order_id),

    FOREIGN KEY (updated_by)
        REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE delivery_tasks (
    task_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id BIGINT NOT NULL,
    assigned_to INT NULL,

    task_type ENUM('Pickup', 'Delivery') NOT NULL,
    schedule_at DATETIME NOT NULL,
    address TEXT NOT NULL,

    task_status ENUM(
        'Menunggu',
        'Ditugaskan',
        'Dalam Perjalanan',
        'Selesai',
        'Dibatalkan'
    ) DEFAULT 'Menunggu',

    FOREIGN KEY (order_id)
        REFERENCES orders(order_id),

    FOREIGN KEY (assigned_to)
        REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE order_details (
    order_detail_id BIGINT AUTO_INCREMENT PRIMARY KEY,

    order_id BIGINT NOT NULL,
    service_id INT NOT NULL,

    service_name_snapshot VARCHAR(100) NOT NULL,

    pricing_type_snapshot ENUM(
        'KG',
        'ITEM'
    ) NOT NULL,

    quantity DECIMAL(10,2) NOT NULL,
    unit_price DECIMAL(12,2) NOT NULL,
    subtotal DECIMAL(12,2) NOT NULL,

    CONSTRAINT fk_detail_order
        FOREIGN KEY (order_id)
        REFERENCES orders(order_id),

    CONSTRAINT fk_detail_service
        FOREIGN KEY (service_id)
        REFERENCES services(service_id)

) ENGINE=InnoDB;

SHOW TABLES;

DESC users;
DESC customers;
DESC services;
DESC orders;
DESC payments;
DESC laundry_process;
DESC delivery_tasks;
DESC order_details;

select*from users;

-- password dummy
ALTER TABLE users
MODIFY COLUMN role ENUM(
    'Owner',
    'Staff Laundry',
    'Staff Antar-Jemput',
    'Customer'
) NOT NULL;

CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    full_name VARCHAR(100) NOT NULL,

    role ENUM(
        'Owner',
        'Staff Laundry',
        'Staff Antar-Jemput',
        'Customer'
    ) NOT NULL,

    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
        ON UPDATE CURRENT_TIMESTAMP

) ENGINE=InnoDB;

INSERT INTO users
(username, password_hash, full_name, role, is_active)
VALUES
('owner01', 'owner123', 'Owner Delica', 'Owner', TRUE),
('staff01', 'staff123', 'Staff Laundry', 'Staff Laundry', TRUE),
('kurir01', 'kurir123', 'Staff Antar Jemput', 'Staff Antar-Jemput', TRUE),
('customer01', 'customer123', 'Customer Delica', 'Customer', TRUE);


