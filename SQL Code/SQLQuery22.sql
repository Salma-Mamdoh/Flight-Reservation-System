
CREATE TABLE [User] (
  User_ID      int IDENTITY NOT NULL, 
  Password     varchar(20) NOT NULL, 
  Street       varchar(255) NULL, 
  City         varchar(255) NULL, 
  Country      varchar(255) NULL, 
  Fname        varchar(255) NOT NULL, 
  Mname        varchar(255) NOT NULL, 
  Lname        varchar(255) NOT NULL, 
  Email        varchar(255) NOT NULL UNIQUE, 
  DateOfBirth  date NULL, 
  Age          int NULL, 
  Phone_Number varchar(11) NOT NULL UNIQUE, 
  Role         varchar(255) NOT NULL, 
  CONSTRAINT User_ID 
    PRIMARY KEY (User_ID));
 
CREATE TABLE Admin (
  Admin_ID int NOT NULL, 
  Permissions varchar(255) NOT NULL, 
  PRIMARY KEY (Admin_ID),
  constraint user_admin_fk foreign key(Admin_ID) references [User](User_ID));
 
 
 
  CREATE TABLE Customer (
  Customer_ID  int NOT NULL, 
  Payment_info varchar(255) NOT NULL, 
  PRIMARY KEY (Customer_ID),
  constraint user_customer_fk foreign key(Customer_ID) references [User](User_ID));
 
 
CREATE TABLE Aircraft (
  Aircraft_ID       int IDENTITY NOT NULL, 
  Model             varchar(255) NOT NULL, 
  SeatsCapacity     int NOT NULL, 
  CountryMade       varchar(255) NOT NULL, 
  AvailabiltyStatus bit NOT NULL, 
  adminID     int NOT NULL, 
  PRIMARY KEY (Aircraft_ID),
  Constraint admin_aircraft_fk foreign key(adminID) references Admin(Admin_ID));
 
  CREATE TABLE Airport (
  Airport_Code      varchar(25) NOT NULL, 
  AirportCountry    varchar(255) NOT NULL, 
  AirportCity       varchar(255) NOT NULL, 
  AirportName       varchar(255) NOT NULL, 
  OperationalStatus varchar(255) NOT NULL, 
  PRIMARY KEY (Airport_Code));
 
  CREATE TABLE Has (
  aircraftID int NOT NULL, 
  airportCode varchar(25) NOT NULL,
  CONSTRAINT aircraft_has_fk FOREIGN KEY (aircraftID) REFERENCES Aircraft (Aircraft_ID),
  CONSTRAINT airport_has_fk FOREIGN KEY (airportCode) REFERENCES Airport (Airport_Code));
 
  CREATE TABLE Flight (
  Flight_ID           int IDENTITY NOT NULL, 
  SourceAirport       varchar(255) NOT NULL, 
  Destination_Airport varchar(255) NOT NULL, 
  FlightCalss_Type    varchar(255) NOT NULL, 
  NumOfAvaliableSeats int NOT NULL, 
  TakeOFF_time        time(7) NOT NULL, 
  ArrivaTime          time(7) NOT NULL, 
  adminID       int NOT NULL, 
  Flight_aircraftID  int NOT NULL, 
  aircraftID int NOT NULL, 
  airportCode varchar(25) NOT NULL, 
  PRIMARY KEY (Flight_ID),
  Constraint admin_flight_fk foreign key(adminID) references Admin(Admin_ID),
  Constraint aircraft_flight_fk foreign key(aircraftID) references Aircraft(Aircraft_ID),
  Constraint [Source/ Destination Airport] foreign key (airportCode) references Airport (Airport_Code)
  );
 
 
CREATE TABLE Booking (
  Booking_ID              int IDENTITY NOT NULL, 
  Customer_Name           varchar(255) NULL, 
  Booking_Date            date NOT NULL, 
  NumSeats                int NOT NULL, 
 [Customer Customer_ID]  int NOT NULL, 
  flightID         int NOT NULL, 
  PRIMARY KEY (Booking_ID),
  Constraint flight_booking_fk foreign key(flightID) references Flight(Flight_ID),
  constraint customer_book_fk foreign key([Customer Customer_ID]) references Customer(Customer_ID));
 
CREATE TABLE Booking_Details (
  [Booking_Details ID] int IDENTITY NOT NULL, 
  Booking_Date         date NULL, 
  SeatNumber           int NULL, 
  bookingID    int NOT NULL, 
  PRIMARY KEY ([Booking_Details ID],bookingID),
  Constraint booking_detalis_fk foreign key(bookingID) references Booking(Booking_ID));
 
  -- Insert values into [User] table
INSERT INTO [User] (Password, Street, City, Country, Fname, Mname, Lname, Email, DateOfBirth, Age, Phone_Number, Role)
VALUES ('password1', '123 Main St', 'New York', 'USA', 'John', 'A', 'Doe', 'johndoe@example.com', '2000-01-01', 21, '555-1234', 'customer');
 
INSERT INTO [User] (Password, Street, City, Country, Fname, Mname, Lname, Email, DateOfBirth, Age, Phone_Number, Role)
VALUES ('password2', '456 Elm St', 'San Francisco', 'USA', 'Jane', 'B', 'Smith', 'janesmith@example.com', '1995-05-05', 26, '555-5678', 'admin');
 
select * from [User];
 
-- Insert values into Admin table
INSERT INTO Admin (Admin_ID,Permissions) VALUES (1,'full access');
 
select* from Admin;
 
-- Insert values into Customer table
INSERT INTO Customer (Customer_ID,Payment_info) VALUES (2,'credit card');
 
select * from Customer;
 
-- Insert values into Aircraft table
INSERT INTO Aircraft (Model, SeatsCapacity, CountryMade, AvailabiltyStatus, adminID)
VALUES ('Boeing 747', 416, 'USA', 1, 1);
 
select * from Aircraft;
 
-- Insert values into Airport table
INSERT INTO Airport (Airport_Code, AirportCountry, AirportCity, AirportName, OperationalStatus)
VALUES ('LAX', 'USA', 'Los Angeles', 'Los Angeles International Airport', 'open');
 
select * from Airport;
 
-- Insert values into Has table
INSERT INTO Has (aircraftID, airportCode) VALUES (1, 'LAX');
 
select * from Has;
 
-- Insert values into Flight table
INSERT INTO Flight (SourceAirport, Destination_Airport, FlightCalss_Type, NumOfAvaliableSeats, TakeOFF_time, ArrivaTime, adminID, Flight_aircraftID, aircraftID, airportCode)
VALUES ('LAX', 'SFO', 'Economy', 100, '08:00:00', '10:00:00', 1, 1, 1, 'LAX');
 
select * from Flight;
 
-- Insert values into Booking table
INSERT INTO Booking (Customer_Name, Booking_Date, NumSeats, [Customer Customer_ID], flightID)
VALUES ('John Doe', '2023-05-18', 2, 2, 1);
 
 
select * from Booking;
 
-- Insert values into Booking_Details table
INSERT INTO Booking_Details ( Booking_Date, SeatNumber, bookingID)
VALUES ('2023-05-18', 1, 1);

select * from Booking_Details;

select *from Booking
use FlightReservation
Alter table Booking
Add Fsource varchar(255)
Alter table Booking
Add Destination varchar(255)
Alter table Booking
Add FlightClass varchar(255)


EXEC sp_rename 'Booking.[Customer Customer_ID]', 'Customer_Customer_ID', 'COLUMN';
use FlightReservation
ALTER TABLE Flight
DROP COLUMN Flight_aircraftID;

