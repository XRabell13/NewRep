create database AirplaneDataBase

use AirplaneDataBase


CREATE table Produser 
(
ID_produser int IDENTITY(1,1) NOT NULL primary key,
Named nvarchar(50) ,
Land nvarchar(30),

)

CREATE table Airplane 
(
ID_airplane int IDENTITY(1,1) NOT NULL primary key,
ID_produser int foreign key references Produser(ID_produser),
_Type nvarchar(20),
Model nvarchar(50),
Count_seats int,

Photo varbinary(MAX)
)

go
CREATE PROCEDURE insert_Airplanes(
	@ID_produser int,
    @_Type nvarchar(20),
	@Model nvarchar(50),
	@Count_seats int,
	
	@Photo varbinary(MAX)

	)
AS
    INSERT INTO Airplane (ID_produser, _Type, Model,Count_seats,Photo)
    VALUES (@ID_produser, @_Type, @Model, @Count_seats, @Photo)
    SELECT SCOPE_IDENTITY()
GO

go
CREATE PROCEDURE insert_Produsers(
    @Named nvarchar(50),
	@Land nvarchar(30)
	)
AS
    INSERT INTO Produser(Named,Land)
    VALUES (@Named, @Land)
  
    SELECT SCOPE_IDENTITY()
GO

go
CREATE PROCEDURE update_Airplanes(
   @ID_produser int,
@Type nvarchar(20),
@Model nvarchar(50),
@Count_seats int,
@Array varbinary(MAX),
@ID_airplane int
	)
AS
   UPDATE Airplane SET ID_produser =@ID_produser, _Type=@Type, Model=@Model,
                Count_seats=@Count_seats, Photo=@Array WHERE ID_airplane=@ID_airplane;
  
    SELECT SCOPE_IDENTITY()
GO

go
CREATE PROCEDURE update_AirplanesNoCHangePicture(
   @ID_produser int,
@Type nvarchar(20),
@Model nvarchar(50),
@Count_seats int,
@ID_airplane int
	)
AS
   UPDATE Airplane SET ID_produser =@ID_produser, _Type=@Type, Model=@Model,
                Count_seats=@Count_seats WHERE ID_airplane=@ID_airplane;
  
    SELECT SCOPE_IDENTITY()
GO
