CREATE DATABASE HMS;

USE HMS;

CREATE TABLE Patient ( 
 patientId INT PRIMARY KEY IDENTITY(1001, 1), 
 name VARCHAR(100), 
 dateOfBirth DATE, 
 gender VARCHAR(10), 
 contactNumber VARCHAR(15), 
 address VARCHAR(255), 
 medicalHistory TEXT 
); 

INSERT INTO Patient VALUES
('Sriraam',
'07/07/2023',
'M',
'12909092'
);

SELECT * FROM Patient;

CREATE TABLE Doctor ( 
 doctorId INT PRIMARY KEY IDENTITY(100, 1), 
 name VARCHAR(100), 
 specialization VARCHAR(100), 
 contactNumber VARCHAR(15), 
 availabilitySchedule TEXT 
);

SELECT * FROM Doctor;

CREATE TABLE Appointment ( 
 appointmentId INT PRIMARY KEY IDENTITY(001, 1), 
 patientId INT, 
 doctorId INT, 
 appointmentDate DATE, 
 timeSlot VARCHAR(20), 
 status VARCHAR(20) CHECK (status IN ('CONFIRMED', 'CANCELLED')),
 CONSTRAINT FKPATID FOREIGN KEY (patientId) REFERENCES Patient(patientId), 
 CONSTRAINT FKDOCID FOREIGN KEY (doctorId) REFERENCES Doctor(doctorId) 
); 

SELECT * FROM Appointment;

CREATE TABLE Bill ( 
 billId INT PRIMARY KEY IDENTITY(10001, 1), 
 patientId INT, 
 totalAmount DECIMAL(10, 2), 
 paymentStatus VARCHAR(10) CHECK(paymentStatus IN ('PAID','UNPAID')),
 billDate DATE, 
 CONSTRAINT FKPATIDB FOREIGN KEY (patientId) REFERENCES Patient(patientId)
);

SELECT * FROM Bill;

CREATE TABLE Users ( 
 userId INT PRIMARY KEY IDENTITY(001, 1), 
 username VARCHAR(50) UNIQUE, 
 password VARCHAR(255), 
 role VARCHAR(10) CHECK (role IN ('ADMIN', 'PATIENT', 'DOCTOR'))
); 

SELECT * FROM Users;


SELECT NAME FROM sys.tables;