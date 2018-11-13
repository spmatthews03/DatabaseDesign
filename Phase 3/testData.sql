
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



-- Corkboard
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Stuff For Home', 0, 'sean@gt.edu', 'Home & Garden');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Best Sports', 1, 'sean@gt.edu', 'Sports');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Random Cool Stuff', 0, 'meghan@gt.edu', 'Other');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Places To Go', 0, 'brian@gt.edu', 'Travel');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Stuff I want to Plant', 0, 'brian@gt.edu', 'Home & Garden');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Things I want in my garden', 0, 'meghan@gt.edu', 'Home & Garden');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Baseball stuff', 0, 'meghan@gt.edu', 'Sports');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Artificial Intelligence', 1, 'meghan@gt.edu', 'Technology');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Popular people', 1, 'brian@gt.edu', 'People');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Man Cave', 0, 'jake@gt.edu', 'Other');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Basement Todos', 0, 'john@gt.edu', 'Architecture');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Wedding DIY', 0, 'chelsea@gt.edu', 'Art');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Cool Cars', 0, 'jake@gt.edu', 'Technology');
INSERT INTO corkboard ( title, visibility, owner_email, category_type) VALUES ('Places To Go', 0, 'mary@gt.edu', 'Travel');


-- Private Corkboard
INSERT INTO private_corkboard( title, owner_email, password) VALUES ('Best Sports', 'sean@gt.edu', 'secret');
INSERT INTO private_corkboard( title, owner_email, password) VALUES ('Artificial Intelligence', 'meghan@gt.edu', 'password123');
INSERT INTO private_corkboard( title, owner_email, password) VALUES ('Popular people', 'brian@gt.edu', 'helloworld');

-- Tags
INSERT INTO Tags(name) VALUES ('cool');
INSERT INTO Tags(name) VALUES ('great');
INSERT INTO Tags(name) VALUES ('awesome');
INSERT INTO Tags(name) VALUES ('pretty');
INSERT INTO Tags(name) VALUES ('old');
INSERT INTO Tags(name) VALUES ('pleasing');
INSERT INTO Tags(name) VALUES ('baseball');
INSERT INTO Tags(name) VALUES ('palmtree');
INSERT INTO Tags(name) VALUES ('livingroom');
INSERT INTO Tags(name) VALUES ('bedroom');
INSERT INTO Tags(name) VALUES ('bathroom');
INSERT INTO Tags(name) VALUES ('wishlist');
INSERT INTO Tags(name) VALUES ('decor');
INSERT INTO Tags(name) VALUES ('remodel');
INSERT INTO Tags(name) VALUES ('garden');
INSERT INTO Tags(name) VALUES ('plantin');
INSERT INTO Tags(name) VALUES ('stadium');
INSERT INTO Tags(name) VALUES ('boardgames');
INSERT INTO Tags(name) VALUES ('escaperoom');
INSERT INTO Tags(name) VALUES ('football');
INSERT INTO Tags(name) VALUES ('cards');
INSERT INTO Tags(name) VALUES ('rummy');
INSERT INTO Tags(name) VALUES ('drinks');
INSERT INTO Tags(name) VALUES ('food');



-- Pushpin
INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Stuff For Home', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.fox.com/', 'Here are some of my favorite plants!', NULL);

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Here are some of my favorite Sports!', 'baseball');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://www.cnn.com/', 'Here are some of my favorite games!', NULL);

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://www.travel.com/', 'Here are some of my favorite places!', NULL);

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Stuff I want to Plant', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://www.garden.com/', 'Here are some of my favorite houses!', NULL);

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Things I want in my garden', '2018-11-08 00:01:00', 'meghan@gt.edu', 'https://www.garden.com/', 'This is a nice one!', NULL);

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Baseball stuff', '2018-11-08 00:01:00', 'meghan@gt.edu', 'https://www.mlb.com/', 'My favorite plays!', 'football');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.mlb.com/', 'Favorite athletes!', 'baseball');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Man Cave', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://www.nfl.com/', 'Favorite athletes!', 'baseball');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://www.hobbylobby.com/', 'DIY Projects', 'cool');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://www.tesla.com/', 'Electric Cars', 'awesome');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://www.travel.com/', 'Mediteranean Cruise', 'pretty');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://www.homedepot.com/', 'work to do in basement', 'football');







-- Private Pushpin
INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Best Sports', '2018-11-09 00:00:00', 'sean@gt.edu', 'https://www.espn.com/', 'Baseball stuff for fun', 'baseball');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Best Sports', '2018-11-10 00:00:00', 'sean@gt.edu', 'https://www.mlb.com/', 'Trade rumors', 'baseball');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Artificial Intelligence', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://www.cnet.com/', 'will robots take over', 'cool');

INSERT INTO `pushpin` (`title`, `date_time`, `owner_email`, `url`, `description`, `tags`)
VALUES ('Popular people', '2018-11-11 00:00:00', 'brian@gt.edu', 'https://www.forbes.com/', 'people who are good people', 'awesome');


-- Likes
INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 00:00:00', 'https://www.mlb.com/', 'Best Sports', 'sean@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('sean@gt.edu','2018-11-08 00:21:00', 'https://www.google.com/', 'meghan@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 00:05:00', 'https://www.google.com/','Places To Go' 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('sean@gt.edu','2018-11-08 00:01:00', 'https://www.google.com/','Places To Go' 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('meghan@gt.edu','2018-11-08 00:01:00', 'https://www.google.com/','Places To Go' 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('john@gt.edu','2018-11-08 00:01:00', 'https://www.google.com/','Places To Go' 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('jake@gt.edu','2018-11-08 00:01:00', 'https://www.google.com/','Places To Go' 'mary@gt.edu');

INSERT INTO `Like` (email, date_time, url, title, owner_email)
VALUES ('chelsea@gt.edu','2018-11-08 00:01:00', 'https://www.google.com/','Places To Go' 'mary@gt.edu');



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

