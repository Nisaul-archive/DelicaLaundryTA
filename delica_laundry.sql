-- DELICA LAUNDRY - skema berdasarkan file Delica Laundry.txt milik pengguna
-- MySQL 8.0+; aman dijalankan ulang untuk data dummy (berdasarkan kunci natural).
-- Database baru: lengkap 8 tabel. Database lama: tabel yang ada tidak dihapus.
-- CATATAN: Jika tabel lama memiliki nama/tipe kolom berbeda, cek sebelum ALTER.
CREATE DATABASE IF NOT EXISTS delica_laundry CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE delica_laundry;

CREATE TABLE IF NOT EXISTS customers (
 customer_id INT AUTO_INCREMENT PRIMARY KEY,
 customer_name VARCHAR(100) NOT NULL,
 phone VARCHAR(20) NOT NULL,
 address TEXT
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS users (
 user_id INT AUTO_INCREMENT PRIMARY KEY,
 customer_id INT NULL,
 username VARCHAR(50) NOT NULL UNIQUE,
 password_hash VARCHAR(255) NOT NULL,
 full_name VARCHAR(100) NOT NULL,
 role ENUM('Owner','Staff Laundry','Staff Antar-Jemput','Customer') NOT NULL,
 is_active BOOLEAN NOT NULL DEFAULT TRUE,
 created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
 UNIQUE KEY uq_users_customer_id (customer_id),
 CONSTRAINT fk_users_customer FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
   ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS services (
 service_id INT AUTO_INCREMENT PRIMARY KEY,
 service_name VARCHAR(100) NOT NULL,
 pricing_type ENUM('KG','ITEM','METER') NOT NULL,
 unit_price DECIMAL(12,2) NOT NULL,
 estimated_days INT NOT NULL,
 express_fee DECIMAL(12,2) NOT NULL DEFAULT 0,
 is_active BOOLEAN NOT NULL DEFAULT TRUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS orders (
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
 order_status ENUM('Diterima','Diproses','Siap Diambil','Dalam Pengantaran','Selesai','Dibatalkan') DEFAULT 'Diterima',
 payment_status ENUM('Belum Dibayar','Lunas') DEFAULT 'Belum Dibayar',
 CONSTRAINT fk_order_customer FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
 CONSTRAINT fk_order_service FOREIGN KEY (service_id) REFERENCES services(service_id),
 CONSTRAINT fk_order_user FOREIGN KEY (created_by) REFERENCES users(user_id)
) ENGINE=InnoDB;

-- DELICA LAUNDRY - skema berdasarkan file Delica Laundry.txt milik pengguna
-- MySQL 8.0+; aman dijalankan ulang untuk data dummy (berdasarkan kunci natural).
-- Database baru: lengkap 8 tabel. Database lama: tabel yang ada tidak dihapus.
-- CATATAN: Jika tabel lama memiliki nama/tipe kolom berbeda, cek sebelum ALTER.
CREATE DATABASE IF NOT EXISTS delica_laundry CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE delica_laundry;

CREATE TABLE IF NOT EXISTS customers (
 customer_id INT AUTO_INCREMENT PRIMARY KEY,
 customer_name VARCHAR(100) NOT NULL,
 phone VARCHAR(20) NOT NULL,
 address TEXT
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS users (
 user_id INT AUTO_INCREMENT PRIMARY KEY,
 customer_id INT NULL,
 username VARCHAR(50) NOT NULL UNIQUE,
 password_hash VARCHAR(255) NOT NULL,
 full_name VARCHAR(100) NOT NULL,
 role ENUM('Owner','Staff Laundry','Staff Antar-Jemput','Customer') NOT NULL,
 is_active BOOLEAN NOT NULL DEFAULT TRUE,
 created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
 UNIQUE KEY uq_users_customer_id (customer_id),
 CONSTRAINT fk_users_customer FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
   ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS services (
 service_id INT AUTO_INCREMENT PRIMARY KEY,
 service_name VARCHAR(100) NOT NULL,
 pricing_type ENUM('KG','ITEM','METER') NOT NULL,
 unit_price DECIMAL(12,2) NOT NULL,
 estimated_days INT NOT NULL,
 express_fee DECIMAL(12,2) NOT NULL DEFAULT 0,
 is_active BOOLEAN NOT NULL DEFAULT TRUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS orders (
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
 order_status ENUM('Diterima','Diproses','Siap Diambil','Dalam Pengantaran','Selesai','Dibatalkan') DEFAULT 'Diterima',
 payment_status ENUM('Belum Dibayar','Lunas') DEFAULT 'Belum Dibayar',
 CONSTRAINT fk_order_customer FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
 CONSTRAINT fk_order_service FOREIGN KEY (service_id) REFERENCES services(service_id),
 CONSTRAINT fk_order_user FOREIGN KEY (created_by) REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS payments (
 payment_id INT AUTO_INCREMENT PRIMARY KEY,
 order_id BIGINT NOT NULL,
 recorded_by INT NOT NULL,
 payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
 amount DECIMAL(12,2) NOT NULL,
 payment_method ENUM('Cash','Transfer','QRIS') NOT NULL,
 CONSTRAINT fk_payment_order FOREIGN KEY (order_id) REFERENCES orders(order_id),
 CONSTRAINT fk_payment_user FOREIGN KEY (recorded_by) REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS laundry_process (
 process_id INT AUTO_INCREMENT PRIMARY KEY,
 order_id BIGINT NOT NULL,
 updated_by INT NOT NULL,
 status VARCHAR(30) NOT NULL,
 updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
 notes TEXT,
 CONSTRAINT fk_process_order FOREIGN KEY (order_id) REFERENCES orders(order_id),
 CONSTRAINT fk_process_user FOREIGN KEY (updated_by) REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS delivery_tasks (
 task_id INT AUTO_INCREMENT PRIMARY KEY,
 order_id BIGINT NOT NULL,
 assigned_to INT NULL,
 task_type ENUM('Pickup','Delivery') NOT NULL,
 schedule_at DATETIME NOT NULL,
 address TEXT NOT NULL,
 task_status ENUM('Menunggu','Ditugaskan','Dalam Perjalanan','Selesai','Dibatalkan') DEFAULT 'Menunggu',
 CONSTRAINT fk_delivery_order FOREIGN KEY (order_id) REFERENCES orders(order_id),
 CONSTRAINT fk_delivery_user FOREIGN KEY (assigned_to) REFERENCES users(user_id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS order_details (
 order_detail_id BIGINT AUTO_INCREMENT PRIMARY KEY,
 order_id BIGINT NOT NULL,
 service_id INT NOT NULL,
 service_name_snapshot VARCHAR(100) NOT NULL,
 pricing_type_snapshot ENUM('KG','ITEM','METER') NOT NULL,
 quantity DECIMAL(10,2) NOT NULL,
 unit_price DECIMAL(12,2) NOT NULL,
 subtotal DECIMAL(12,2) NOT NULL,
 CONSTRAINT fk_detail_order FOREIGN KEY (order_id) REFERENCES orders(order_id),
 CONSTRAINT fk_detail_service FOREIGN KEY (service_id) REFERENCES services(service_id)
) ENGINE=InnoDB;

-- Perbaiki enum schema awal yang hanya mengenal KG dan ITEM.
ALTER TABLE services MODIFY pricing_type ENUM('KG','ITEM','METER') NOT NULL;
ALTER TABLE order_details MODIFY pricing_type_snapshot ENUM('KG','ITEM','METER') NOT NULL;

-- Data dummy Master Pelanggan: tidak membuat duplikat bila phone sudah ada.
INSERT INTO customers(customer_name,phone,address)
SELECT d.nama,d.telp,d.alamat FROM (
 SELECT 'Andi Pratama' nama,'081234567890' telp,'Jl. Melati No. 12, Surabaya' alamat
 UNION ALL SELECT 'Siti Rahmawati','081234567891','Jl. Anggrek No. 5, Surabaya'
 UNION ALL SELECT 'Budi Santoso','081234567892','Jl. Flamboyan No. 22, Surabaya'
 UNION ALL SELECT 'Dewi Lestari','081234567893','Jl. Cendana No. 8, Surabaya'
 UNION ALL SELECT 'Rizky Maulana','081234567894','Jl. Cemara No. 17, Surabaya'
 UNION ALL SELECT 'Intan Permata','081234567895','Jl. Kenanga No. 3, Surabaya'
) AS d WHERE NOT EXISTS (SELECT 1 FROM customers c WHERE c.phone=d.telp);

-- Data dummy Master Layanan; biaya Express di sini per satuan.
INSERT INTO services(service_name,pricing_type,unit_price,estimated_days,express_fee,is_active)
SELECT d.nama,d.jenis,d.harga,d.hari,d.express,d.aktif FROM (
 SELECT 'Cuci Kiloan' nama,'KG' jenis,7000 harga,2 hari,3000 express,1 aktif
 UNION ALL SELECT 'Setrika Saja','KG',5000,1,2000,1
 UNION ALL SELECT 'Dry Clean','ITEM',25000,3,10000,1
 UNION ALL SELECT 'Cuci Sepatu','ITEM',35000,3,15000,1
 UNION ALL SELECT 'Cuci Karpet','METER',20000,4,8000,1
 UNION ALL SELECT 'Cuci Bed Cover','ITEM',40000,3,15000,0
) AS d WHERE NOT EXISTS (SELECT 1 FROM services s WHERE s.service_name=d.nama);

-- AKUN DUMMY KHUSUS UJI LOKAL. Password SEMUANYA: DelicaDemo#2026
-- Hash BCrypt berbeda per akun karena salt acak; tidak menyimpan plain text.
-- SEGERA ganti/nonaktifkan akun demo sebelum distribusi/deploy.
INSERT INTO users(customer_id,username,password_hash,full_name,role,is_active)
SELECT NULL,d.username,d.hash,d.nama,d.role,d.aktif FROM (
 SELECT 'andi' username,'$2a$11$LVKGEgqIsULdsWxXbr9rMeuB6sgD5rzgCanS8xIX9coTSfvvuISYe' hash,'Andi Pratama' nama,'Owner' role,1 aktif
 UNION ALL SELECT 'siti','$2a$11$5TzTnI5p3rz2kALNCyojX.psOZ5SrQvDN3qv4pTMNFtTiLq0RtI7.','Siti Rahmawati','Staff Laundry',1
 UNION ALL SELECT 'budi','$2a$11$Mfuo.50HaGqudUlwTZxp1eewfIOEny2bcWGfoDxVIwxcVbypwTxgi','Budi Santoso','Staff Laundry',1
 UNION ALL SELECT 'dewi','$2a$11$L.0su0WEsXi4LCTZ8E5YLuzBChd0cDCSnzHZCWza2cmSKhXpqGq2m','Dewi Lestari','Staff Laundry',1
 UNION ALL SELECT 'rizky','$2a$11$M9dHOZ.AME63tAqKybOd8.dpJ6YyrQiZPGyTEe4fTQi11P/vfL/kO','Rizky Maulana','Staff Laundry',0
) AS d WHERE NOT EXISTS (SELECT 1 FROM users u WHERE u.username=d.username);

-- Verifikasi
SELECT 'customers' nama_tabel,COUNT(*) jumlah FROM customers
UNION ALL SELECT 'services',COUNT(*) FROM services
UNION ALL SELECT 'users',COUNT(*) FROM users;
SELECT customer_id,customer_name,phone,address FROM customers ORDER BY customer_id;
SELECT service_id,service_name,pricing_type,unit_price,estimated_days,express_fee,is_active FROM services ORDER BY service_id;
SELECT user_id,full_name,username,role,is_active FROM users ORDER BY user_id;

-- akun admin staf
INSERT INTO users
(customer_id, username, password_hash, full_name, role, is_active)
VALUES
(NULL, 'admin',
 '$2y$10$OzKKExrQb2qYLVSsTXs8aef8HORzfCrcq.5n6bl7l1MBOSi0HH.Oy',
 'Administrator', 'Owner', TRUE),

(NULL, 'staf',
 '$2y$10$3NoV/zORp9LSsVg/2pkivebDADAfnsKwdUge2vNKVLMM7Zap4KfP2',
 'Staff Laundry', 'Staff Laundry', TRUE);

SELECT user_id, username, full_name, role, is_active
FROM users;






