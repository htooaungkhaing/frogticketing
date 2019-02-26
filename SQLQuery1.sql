create database frogproject

create table eventdetail(
EventID uniqueidentifier not null,
EventName varchar(30) primary key not null,
Type varchar (20) not null,
Venue varchar (100) not null,
Lng float not null,
Lat float not null,
Date varchar(30) not null,
Time varchar (30) not null,
GateOpen varchar (30) not null,
PublicSale varchar (30) not null,
valiabeTicet int not null,
Price varchar (30) not null,
)



-----------------------------------------------------------------------------
-----------------------------------------------------------------------------

create table orderdetail(
VoucherID uniqueidentifier not null primary key,
UserID nvarchar(128)not null,
EventName varchar(30)not null ,
Quantity int not  null,
Name varchar(50) not null,
Phone varchar(15) not null,
SecondPhone varchar(15) ,
Address varchar(100)not null,
Email varchar(30),
PostalCode varchar(6),
)
drop table orderdetail
ALTER TABLE orderdetail
	add CONSTRAINT FK_orderdetail_UserID
	FOREIGN KEY(
	UserID
		)
	REFERENCES AspNetUsers (Id)
	On Delete Cascade
	On Update Cascade


ALTER TABLE orderdetail
	add CONSTRAINT FK_orderdetail_EventName
	FOREIGN KEY(
	EventName
		)
	REFERENCES eventdetail (EventName)
	On Delete Cascade
	On Update Cascade

	SELECT * FROM orderdetail
-----------------------------------------------------------------------------
-----------------------------------------------------------------------------


create table feedbacksession(
ID uniqueidentifier primary key not null,
UserID nvarchar (128) not null,
Email varchar (30)not null,
Feedback varchar (1000)not null,
)  

ALTER TABLE feedbacksession
	add CONSTRAINT FK_feedbacksession_UserID
	FOREIGN KEY(
	UserID
		)
	REFERENCES AspNetUsers (Id)
	On Delete Cascade
	On Update Cascade
	drop table feedbacksession

	select * from dbo.AspNetUsers
	select * from eventdetail
	select * from orderdetail
	select * from feedbacksession







