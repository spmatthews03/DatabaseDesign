
-- `User`
INSERT INTO `User` (email, name, pin) VALUES('sean@gt.edu', 'Sean', 1234);
INSERT INTO `User` (email, name, pin) VALUES('meghan@gt.edu', 'Meghan', 1234);
INSERT INTO `User` (email, name, pin) VALUES('brian@gt.edu', 'Brian', 1234);
INSERT INTO `User` (email, name, pin) VALUES('john@gt.edu', 'John', 1234);
INSERT INTO `User` (email, name, pin) VALUES('jake@gt.edu', 'Jake', 1234);
INSERT INTO `User` (email, name, pin) VALUES('mary@gt.edu', 'Mary', 1234);
INSERT INTO `User` (email, name, pin) VALUES('chelsea@gt.edu', 'Chelsea', 1234);

-- logging in
-- SELECT email FROM `User` WHERE email = `$Email`;

-- -- POPULAR TAGS and SITES
-- SELECT

-- Categories
INSERT INTO Category (type) VALUES('Education');
INSERT INTO Category (type) VALUES('People');
INSERT INTO Category (type) VALUES('Sports');
INSERT INTO Category (type) VALUES('Other');
INSERT INTO Category (type) VALUES('Architecture');
INSERT INTO Category (type) VALUES('Travel');
INSERT INTO Category (type) VALUES('Pets');
INSERT INTO Category (type) VALUES('Food & Drink');
INSERT INTO Category (type) VALUES('Home & Garden');
INSERT INTO Category (type) VALUES('Photography');
INSERT INTO Category (type) VALUES('Technology');
INSERT INTO Category (type) VALUES('Art');




-- Corkboard
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Stuff For Home', 0, 'sean@gt.edu', 'Home & Garden');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Best Sports', 1, 'sean@gt.edu', 'Sports');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Random Cool Stuff', 0, 'meghan@gt.edu', 'Other');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Places To Go', 0, 'brian@gt.edu', 'Travel');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Stuff I want to Plant', 0, 'brian@gt.edu', 'Home & Garden');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Things I want in my garden', 0, 'meghan@gt.edu', 'Home & Garden');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Baseball stuff', 0, 'meghan@gt.edu', 'Sports');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Artificial Intelligence', 1, 'meghan@gt.edu', 'Technology');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Popular people', 1, 'brian@gt.edu', 'People');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Man Cave', 0, 'jake@gt.edu', 'Other');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Basement Todos', 0, 'john@gt.edu', 'Architecture');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Wedding DIY', 0, 'chelsea@gt.edu', 'Art');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Cool Cars', 0, 'jake@gt.edu', 'Technology');
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('Places To Go', 0, 'mary@gt.edu', 'Travel');


-- Private Corkboard
INSERT INTO Private_Corkboard( title, owner_email, password) VALUES ('Best Sports', 'sean@gt.edu', 'secret');
INSERT INTO Private_Corkboard( title, owner_email, password) VALUES ('Artificial Intelligence', 'meghan@gt.edu', 'password123');
INSERT INTO Private_Corkboard( title, owner_email, password) VALUES ('Popular people', 'brian@gt.edu', 'helloworld');



-- Pushpin
INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 01:00:00', 'sean@gt.edu', 'https://www.nursery.com/', 'Sod');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 02:00:00', 'sean@gt.edu', 'https://www.nursery.com/', 'Succulents');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 03:00:00', 'sean@gt.edu', 'https://www.nursery.com/', 'Roses');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 04:00:00', 'sean@gt.edu', 'https://www.nursery.com/', 'Orchids');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 03:20:00', 'sean@gt.edu', 'https://www.nursery.com/', 'Palm Trees');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://www.cnn.com/', 'Here are some of my favorite games!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://www.travel.com/', 'Here are some of my favorite places!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff I want to Plant', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://www.garden.com/', 'Here are some of my favorite houses!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Things I want in my garden', '2018-11-08 00:01:00', 'meghan@gt.edu', 'https://www.garden.com/', 'This is a nice one!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Baseball stuff', '2018-11-08 00:01:00', 'meghan@gt.edu', 'https://www.mlb.com/', 'My favorite plays!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.mlb.com/', 'Favorite athletes!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Man Cave', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.nfl.com/', 'Favorite athletes!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://www.hobbylobby.com/', 'DIY Projects');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://www.tesla.com/', 'Electric Cars');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://www.travel.com/', 'Mediteranean Cruise');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://www.homedepot.com/', 'work to do in basement');

-- Tags
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Stuff For Home', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.fox.com/', 'Here are some of my favorite plants!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Here are some of my favorite Sports!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://www.cnn.com/', 'Here are some of my favorite games!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://www.travel.com/', 'Here are some of my favorite places!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://www.tesla.com/', 'Electric Cars');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://www.travel.com/', 'Mediteranean Cruise');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('cool', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://www.homedepot.com/', 'work to do in basement');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('baseball', 'Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.mlb.com/', 'Favorite athletes!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('baseball', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Here are some of my favorite Sports!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('baseball', 'Man Cave', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.nfl.com/', 'Favorite athletes!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('livingroom', 'Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://www.hobbylobby.com/', 'DIY Projects');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('livingroom', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://www.homedepot.com/', 'work to do in basement');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('livingroom', 'Man Cave', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.nfl.com/', 'Favorite athletes!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('livingroom', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://www.travel.com/', 'Mediteranean Cruise');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('awesome', 'Stuff For Home', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.fox.com/', 'Here are some of my favorite plants!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('awesome', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Here are some of my favorite Sports!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('awesome', 'Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://www.cnn.com/', 'Here are some of my favorite games!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('awesome', 'Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://www.travel.com/', 'Here are some of my favorite places!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('awesome', 'Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://www.tesla.com/', 'Electric Cars');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('awesome', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://www.travel.com/', 'Mediteranean Cruise');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('bedroom', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://www.homedepot.com/', 'work to do in basement');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('bedroom', 'Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.mlb.com/', 'Favorite athletes!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('bedroom', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Here are some of my favorite Sports!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('remodel', 'Man Cave', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.nfl.com/', 'Favorite athletes!');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('remodel', 'Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://www.hobbylobby.com/', 'DIY Projects');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('remodel', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://www.homedepot.com/', 'work to do in basement');
INSERT INTO Tags(name, title, date_time, owner_email, url, description) VALUES ('remodel', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://www.travel.com/', 'Mediteranean Cruise');


-- Private Pushpin
INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Best Sports', '2018-11-09 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Baseball stuff for fun');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Here are some of my favorite Sports!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Artificial Intelligence', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://www.cnet.com/', 'will robots take over');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Popular people', '2018-11-11 00:00:00', 'brian@gt.edu', 'https://www.forbes.com/', 'people who are good people');


-- Likes
INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 00:00:00', 'https://www.mlb.com/', 'Best Sports', 'sean@gt.edu');


INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 00:05:00', 'https://www.travel.com/','Places To Go', 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('sean@gt.edu','2018-11-08 00:01:00', 'https://www.travel.com/','Places To Go', 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('meghan@gt.edu','2018-11-08 00:01:00', 'https://www.travel.com/','Places To Go', 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('john@gt.edu','2018-11-08 00:01:00', 'https://www.travel.com/','Places To Go', 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('jake@gt.edu','2018-11-08 00:01:00', 'https://www.travel.com/','Places To Go', 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('chelsea@gt.edu','2018-11-08 00:01:00', 'https://www.travel.com/','Places To Go', 'mary@gt.edu');







-- Comments



-- Follows
INSERT INTO Follows (email, follower_email) VALUES ('sean@gt.edu', 'meghan@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('sean@gt.edu', 'brian@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('meghan@gt.edu', 'brian@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('meghan@gt.edu', 'sean@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'meghan@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'sean@gt.edu');

-- Watch
INSERT INTO Watch (email, title, owner_email) VALUES ('sean@gt.edu', 'Other', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('sean@gt.edu', 'Travel', 'brian@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('sean@gt.edu', 'Home & Garden', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('meghan@gt.edu', 'Home & Garden', 'sean@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('meghan@gt.edu', 'Sports', 'sean@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('brian@gt.edu', 'Sports', 'sean@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('brian@gt.edu', 'Other', 'meghan@gt.edu');

