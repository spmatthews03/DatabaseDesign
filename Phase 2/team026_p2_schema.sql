
CREATE TABLE `User`(
	email varchar(30) NOT NULL,
	first_name varchar(30) NOT NULL,
	last_name varchar(30) NOT NULL,
	password varchar(30) NOT NULL,
	PRIMARY KEY (email)
);

CREATE TABLE Corkboard (
	title varchar(30) NOT NULL,
	visibility boolean NOT NULL,
	email varchar(30)  NOT NULL,
	PRIMARY KEY (title, email)
);

CREATE TABLE `Comment`(
	date_time datetime NOT NULL,
	text varchar(100) NOT NULL,
	email varchar(30) NOT NULL,
	su_email varchar(30) NOT NULL,
	su_date_time datetime NOT NULL,
	PRIMARY KEY (email, date_time),
	KEY su_email (su_email,su_date_time)
);

CREATE TABLE `Like` (
	email varchar(30) NOT NULL,
	date_time datetime NOT NULL,
	url varchar(100) NOT NULL,
	PRIMARY KEY (email, date_time),
 	KEY date_time (date_time)
);

CREATE TABLE PushPin (
	date_time datetime NOT NULL,
	owner_email varchar(30) NOT NULL,
	url varchar(100) NOT NULL,
	descrition varchar(200) NOT NULL,
	tags varchar(100) NULL,
	likes integer NULL,
	comments varchar(100) NULL,
	PRIMARY KEY (owner_email, date_time)
);

CREATE TABLE Category (
	type varchar(50)
);


-- Constraints Foreign Keys





