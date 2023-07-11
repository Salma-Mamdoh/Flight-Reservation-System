<!DOCTYPE html>
<html>
	<head>
		<h1>Flight Reservation System</h1>
	</head>
	<body>
		<h2>Introduction:</h2>
		<p>The Flight Reservation System is a software application developed using C# programming language that enables users to book, cancel, and modify flights. This system is designed to simplify the process of airline reservations by making it easy for customers to search and book flights based on their preferred travel dates, source, and destination. The system also allows administrators to manage aircraft, flights, and customers.</p>
		
<h2>Functionalities:</h2>
		<ul>
			<li>Signing up a new user: The system allows new users to sign up as either an admin or a customer. Customers can search for flights and make reservations, while admins have access to additional functionalities such as managing aircraft and flights.</li>
			<li>Updating a user's details: Users can update their personal information such as name, address, and contact information.</li>
			<li>Adding an aircraft: Admins can add new aircraft to the system by providing details such as the aircraft type, capacity, and other relevant information.</li>
			<li>Updating an aircraft's details: Admins can update the details of existing aircraft such as the aircraft type, capacity, and other relevant information.</li>
			<li>Adding a flight: Admins can add new flights to the system by providing details such as the source, destination, travel dates, and other relevant information.</li>
			<li>Updating a flight's details: Admins can update the details of existing flights such as the source, destination, travel dates, and other relevant information.</li>
			<li>Showing a list of available flights: Customers can search for flights based on their preferred travel dates, source, and destination. The system displays a list of available flights that satisfy the customer's search criteria.</li>
			<li>Performing operations on flights: Customers can perform operations such as booking, cancelling, and changing flight class. The system updates the flight's status accordingly.</li>
		</ul>
		
<h2>Conceptual ERD:</h2>
		<p>The conceptual ERD for the Flight Reservation System includes entities such as User, Aircraft, Flight, Reservation, and Payment. The relationships between these entities include one-to-one, one-to-many, and many-to-many relationships. The User entity has a one-to-many relationship with the Reservation entity, while the Flight entity has a many-to-many relationship with the Reservation entity.</p>
		
<h2>Corresponding Physical ERD:</h2>
		<p>The physical ERD for the Flight Reservation System includes tables for User, Aircraft, Flight, Reservation, and Payment. The tables are linked through foreign keys, and the relationships between the tables correspond to the relationships in the conceptual ERD.</p>
		
<h2>Implemented database on MS SQL Server:</h2>
		<p>The Flight Reservation System uses MS SQL Server as the database management system. The database includes tables for User, Aircraft, Flight, Reservation, and Payment. The tables are created based on the physical ERD, and the relationships between the tables are established through foreign keys. The database is updated whenever there is a new reservation, cancellation, or modification to a flight.</p>
		
<h2>Conclusion:</h2>
		<p>The Flight Reservation System is a software application that simplifies the process of airline reservations by making it easy for customers to search and book flights based on their preferred travel dates, source, and destination. The system also allows administrators to manage aircraft, flights, and customers. The system uses a conceptual ERD to model the entities and relationships, a physical ERD to implement the database, and MS SQL Server as the database management system.</p>
	</body>
</html>

