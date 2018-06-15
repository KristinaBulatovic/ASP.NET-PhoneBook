CREATE DATABASE PhoneBook; 

USE PhoneBook;

CREATE TABLE "DataDirectory" (
    "ID" int IDENTITY(1,1) PRIMARY KEY,
    "FirstName" varchar(40) NOT NULL,
    "Lastname" varchar(40) NOT NULL,
	"Telephone Number" varchar(20) NOT NULL
);