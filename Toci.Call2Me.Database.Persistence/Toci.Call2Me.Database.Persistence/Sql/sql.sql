drop table Friends;
drop table Users;
drop table Preferences;
drop table Status;

create table Status
(
	id serial primary key,
	name text --call to me, available, do not disturb
);

create table Preferences
(
	id serial primary key,
	AllowFlag int -- 1 2 4 8 
);

create table Users -- 1 Tomek, 2 Bartek
(
	id serial primary key,
	name text,
	surname text,
	phoneNumber text,
	idStatus int references Status(id)
);

create table Friends
(
	id serial primary key,
	idUsers int references Users(id),-- 1
	idUsersFriend int references Users(id) -- 2
);

create table InCall
(
	id serial primary key,
	idUsers int references Users(id), --2
	idUsersCall int references Users(id) -- 1
);