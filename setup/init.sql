CREATE DATABASE crafstman_beer;

\c crafstman_beer;

CREATE EXTENSION "uuid-ossp";

CREATE TABLE customer_base (
	id SERIAL PRIMARY KEY,
	customer_id uuid DEFAULT uuid_generate_v4(),
	customner_fullname VARCHAR(50),
	customer_name VARCHAR(15),
	customer_document VARCHAR(11),
	customer_email VARCHAR(100),
	customer_birthdate DATE NOT NULL,
	customer_street VARCHAR(100),
	customer_zipcode VARCHAR(100),
	customer_country VARCHAR(100),
	customer_city VARCHAR(100)
);