CREATE DATABASE izaque_d3_avaliacao

USE izaque_d3_avaliacao

CREATE TABLE Users(
	IdUser		VARCHAR(255) NOT NULL UNIQUE,
	[Name]		VARCHAR(255) NOT NULL,
	Email		VARCHAR(255) NOT NULL,
	[Password]	VARCHAR(255) NOT NULL
)

SELECT * FROM Users

