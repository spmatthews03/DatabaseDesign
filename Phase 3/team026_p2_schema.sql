CREATE TABLE Users(
	email varchar(30) NOT NULL,
	name varchar(30) NOT NULL,
	pin varchar(30) NOT NULL,
	PRIMARY KEY (email)
);

CREATE TABLE Corkboard (
	title varchar(30) NOT NULL,
	visibility boolean NOT NULL,
	owner_email varchar(30)  NOT NULL,
	category_type varchar(50) NOT NULL,
	PRIMARY KEY (title, owner_email)
);

CREATE TABLE Private_Corkboard (
	title varchar(30) NOT NULL,
	owner_email varchar(30) NOT NULL,
	password varchar(30) NOT NULL,
	PRIMARY KEY (title, owner_email)
);


CREATE TABLE `Comment`(
	date_time datetime NOT NULL,
	text varchar(100) NOT NULL,
	email varchar(30) NOT NULL,
	url varchar(100) NOT NULL,
	title varchar(30) NOT NULL,
	owner_email varchar(30) NOT NULL,
	pushpin_date_time datetime NOT NULL,
	PRIMARY KEY (date_time, email, url, pushpin_date_time, title, owner_email)
);

CREATE TABLE Follows (
	email varchar(30) NOT NULL,
	follower_email varchar(30) NOT NULL,
	PRIMARY KEY (email, follower_email)
);

CREATE TABLE Watch (
	email varchar(30) NOT NULL,
	title varchar(30) NOT NULL,
	owner_email varchar(30) NOT NULL,
	PRIMARY KEY (email, title, owner_email)
);

CREATE TABLE `Like` (
	email varchar(30) NOT NULL,
	date_time datetime NOT NULL,
	url varchar(100) NOT NULL,
	title varchar(30) NOT NULL,
	owner_email varchar(30) NOT NULL,
	PRIMARY KEY (email, date_time, url, title, owner_email),
 	KEY date_time (date_time)
);

CREATE TABLE PushPin (
	title varchar(30) NOT NULL,
	date_time datetime NOT NULL,
	owner_email varchar(30) NOT NULL,
	url varchar(300) NOT NULL,
	description varchar(200) NOT NULL,
	PRIMARY KEY (url, owner_email, date_time, title)
);

CREATE TABLE Category (
	type varchar(50),
	PRIMARY KEY (type)
);

CREATE TABLE Tags (
	name varchar(100) NOT NULL,
	title varchar(30) NOT NULL,
	date_time datetime NOT NULL,
	owner_email varchar(30) NOT NULL,
	url varchar(300) NOT NULL,
	PRIMARY KEY (name, url, owner_email, date_time, title)
);




-- Constraints Foreign Keys: fk_ChildTable_childColumn_ParentTable_parentColumn
-- If no child-parent, then: fk_Table_child
ALTER TABLE Corkboard
	ADD CONSTRAINT fk_Corkboard_email_User_email FOREIGN KEY (owner_email) REFERENCES `User` (email);

ALTER TABLE Follows
	ADD CONSTRAINT fk_Follows_email_User_email FOREIGN KEY (email) REFERENCES `User` (email),
	ADD CONSTRAINT fk_Follows_follower_email_User_email FOREIGN KEY (follower_email) REFERENCES `User` (email);

ALTER TABLE Private_Corkboard
	ADD CONSTRAINT fk_PrivateCorkboard_title_Corkboard_title FOREIGN KEY (title) REFERENCES Corkboard (title),
	ADD CONSTRAINT fk_PrivateCorkboard_owner_email_User_email FOREIGN KEY (owner_email) REFERENCES `User` (email);

ALTER TABLE Watch
	ADD CONSTRAINT fk_Watch_email_User_email FOREIGN KEY (email) REFERENCES `User` (email),
	ADD CONSTRAINT fk_Watch_owner_email_User_email FOREIGN KEY (owner_email) REFERENCES `User` (email);

ALTER TABLE PushPin
	ADD CONSTRAINT fk_PushPin_title_Corkboard_title FOREIGN KEY (title) REFERENCES Corkboard (title),
	ADD CONSTRAINT fk_PushPin_owner_email_User_email FOREIGN KEY (owner_email) REFERENCES `User` (email);


ALTER TABLE `Like`
	ADD CONSTRAINT fk_Likes_title_PushPin_title FOREIGN KEY (title) REFERENCES PushPin (title),
	ADD CONSTRAINT fk_Likes_url_PushPin_url FOREIGN KEY (url) REFERENCES PushPin (url),
	ADD CONSTRAINT fk_Likes_owner_email_User_email FOREIGN KEY (owner_email) REFERENCES `User` (email);
    
    
ALTER TABLE `Comment`
	ADD CONSTRAINT fk_Comment_url_PushPin_url FOREIGN KEY (url) REFERENCES PushPin (url),
	ADD CONSTRAINT fk_Comment_title_PushPin_title FOREIGN KEY (title) REFERENCES PushPin (title),
	ADD CONSTRAINT fk_Comment_owner_email_User_email FOREIGN KEY (owner_email) REFERENCES `User` (email);
