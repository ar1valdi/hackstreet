CREATE TABLE mock_suggestions (
	id BIGINT PRIMARY KEY,
	description VARCHAR(100),
	added_by VARCHAR(100)
);

CREATE TABLE station_types (
	id INT PRIMARY KEY,
	station_name VARCHAR(50)
);

CREATE TABLE stations (
	id BIGINT PRIMARY KEY,
	latitude FLOAT,
	longitude FLOAT,
	station_type INT,
	FOREIGN KEY (station_type) REFERENCES station_types
);

CREATE TABLE sensors (
	id BIGINT PRIMARY KEY,
	station_id BIGINT NOT NULL,
	keycode VARCHAR(10),
	sensing VARCHAR(50),
	FOREIGN KEY (station_id) REFERENCES stations
);

CREATE TABLE measures (
	date TIMESTAMP,
	station_id BIGINT,
	value FLOAT,
	min_value FLOAT,
	max_value FLOAT,
	sensing varchar(100),
	PRIMARY KEY (date, station_id, sensing),
	FOREIGN KEY (station_id) REFERENCES stations
);

INSERT INTO station_types (id, station_name) VALUES 
(1, 'Stacja pomiaru jakości powietrza'),
(2, 'Stacja pomiaru zanieczyszczenia dźwiękiem');