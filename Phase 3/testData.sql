
-- Users
INSERT INTO Users (email, name, pin) VALUES('sean@gt.edu', 'Sean', 1234);
INSERT INTO Users (email, name, pin) VALUES('meghan@gt.edu', 'Meghan', 1234);
INSERT INTO Users (email, name, pin) VALUES('brian@gt.edu', 'Brian', 1234);
INSERT INTO Users (email, name, pin) VALUES('john@gt.edu', 'John', 1234);
INSERT INTO Users (email, name, pin) VALUES('jake@gt.edu', 'Jake', 1234);
INSERT INTO Users (email, name, pin) VALUES('mary@gt.edu', 'Mary', 1234);
INSERT INTO Users (email, name, pin) VALUES('chelsea@gt.edu', 'Chelsea', 1234);

-- logging in
-- SELECT email FROM Users WHERE email = `$Email`;

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
VALUES ('Stuff For Home', '2018-11-08 01:00:00', 'sean@gt.edu', 'http://www.thesodguy.com/wp-content/uploads/2015/03/grass-roll.png', 'Sod');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 02:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/46/48/51/4648513c9b9822c5e9fc813b48613528.jpg', 'Succulents');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 03:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/f5/ed/c7/f5edc7c7e8cab141c29f7119955b35b0.jpg', 'Roses');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 04:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/c3/79/5b/c3795b63067d60f58021f12b96833fdd.jpg', 'Orchids');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff For Home', '2018-11-08 03:20:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/f7/24/97/f724971f00cfe08ee1b99486d197d112.jpg', 'Palm Trees');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/9f/33/b9/9f33b9bd0aa7575f6628299df5e85de2.jpg', 'Here are some of my favorite games!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://i.pinimg.com/564x/fc/9b/60/fc9b6022547579a905e7897c7826d311.jpg', 'Here are some of my favorite places!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Stuff I want to Plant', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://i.pinimg.com/564x/72/ec/92/72ec92dce176d500c136829f85435f61.jpg', 'Here are some of my favorite houses!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Things I want in my garden', '2018-11-08 00:01:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/55/e8/6d/55e86d5ace0110153cd8123646788c98.jpg', 'This is a nice one!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Baseball stuff', '2018-11-08 00:01:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/36/34/f4/3634f44c1f286f66505bf0c9d8a9f78a.jpg', 'Cool baseball stuff');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/bf/2f/24/bf2f24a57ded191540a6f937e64fdf5f.jpg', 'Favorite athletes!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Man Cave', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/34/69/f8/3469f85dff712455a561e866763f5a8f.jpg', 'Favorite athletes!');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://i.pinimg.com/originals/25/5d/f7/255df7265c8f37d941a39ad931c13cc3.jpg', 'DIY Projects');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/a9/95/be/a995be4d1908e57d9132826cb8285a61.jpg', 'Electric Cars');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg', 'Mediteranean Cruise');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://i.pinimg.com/564x/f6/92/ad/f692ad36921bf00c84120cc1c5cfb03f.jpg', 'work to do in basement');

-- Tags
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Stuff For Home', '2018-11-08 03:20:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/f7/24/97/f724971f00cfe08ee1b99486d197d112.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/da/ce/c4/dacec44e7ffcbfc43a95f3d683f7af90.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/9f/33/b9/9f33b9bd0aa7575f6628299df5e85de2.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://i.pinimg.com/564x/fc/9b/60/fc9b6022547579a905e7897c7826d311.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/a9/95/be/a995be4d1908e57d9132826cb8285a61.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('cool', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://i.pinimg.com/564x/f6/92/ad/f692ad36921bf00c84120cc1c5cfb03f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('baseball', 'Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/bf/2f/24/bf2f24a57ded191540a6f937e64fdf5f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('baseball', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/da/ce/c4/dacec44e7ffcbfc43a95f3d683f7af90.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('baseball', 'Man Cave', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/34/69/f8/3469f85dff712455a561e866763f5a8f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('livingroom', 'Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://i.pinimg.com/originals/25/5d/f7/255df7265c8f37d941a39ad931c13cc3.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('livingroom', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://i.pinimg.com/564x/f6/92/ad/f692ad36921bf00c84120cc1c5cfb03f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('livingroom', 'Man Cave', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/34/69/f8/3469f85dff712455a561e866763f5a8f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('livingroom', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('awesome', 'Stuff For Home', '2018-11-08 03:20:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/f7/24/97/f724971f00cfe08ee1b99486d197d112.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('awesome', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/da/ce/c4/dacec44e7ffcbfc43a95f3d683f7af90.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('awesome', 'Random Cool Stuff', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/9f/33/b9/9f33b9bd0aa7575f6628299df5e85de2.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('awesome', 'Places To Go', '2018-11-08 00:00:00', 'brian@gt.edu', 'https://i.pinimg.com/564x/fc/9b/60/fc9b6022547579a905e7897c7826d311.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('awesome', 'Cool Cars', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/a9/95/be/a995be4d1908e57d9132826cb8285a61.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('awesome', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('bedroom', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://i.pinimg.com/564x/f6/92/ad/f692ad36921bf00c84120cc1c5cfb03f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('bedroom', 'Baseball stuff', '2018-11-08 00:02:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/bf/2f/24/bf2f24a57ded191540a6f937e64fdf5f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('bedroom', 'Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/da/ce/c4/dacec44e7ffcbfc43a95f3d683f7af90.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('remodel', 'Man Cave', '2018-11-08 00:02:00', 'jake@gt.edu', 'https://i.pinimg.com/564x/34/69/f8/3469f85dff712455a561e866763f5a8f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('remodel', 'Wedding DIY', '2018-11-08 00:02:00', 'chelsea@gt.edu', 'https://i.pinimg.com/originals/25/5d/f7/255df7265c8f37d941a39ad931c13cc3.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('remodel', 'Basement Todos', '2018-11-08 00:02:00', 'john@gt.edu', 'https://i.pinimg.com/564x/f6/92/ad/f692ad36921bf00c84120cc1c5cfb03f.jpg');
INSERT INTO Tags(name, title, date_time, owner_email, url) VALUES ('remodel', 'Places To Go', '2018-11-08 00:02:00', 'mary@gt.edu', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg');


-- Private Pushpin
INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Best Sports', '2018-11-09 00:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/65/ba/5f/65ba5fb19824551d4bb8734fa666e7d5.jpg', 'Baseball stuff for fun');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Best Sports', '2018-11-08 00:00:00', 'sean@gt.edu', 'https://i.pinimg.com/564x/da/ce/c4/dacec44e7ffcbfc43a95f3d683f7af90.jpg', 'ESPN Stuff');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Artificial Intelligence', '2018-11-08 00:00:00', 'meghan@gt.edu', 'https://i.pinimg.com/564x/3c/19/cb/3c19cb3cc41bbf50eddb7eb29194d3fb.jpg', 'will robots take over');

INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`)
VALUES ('Popular people', '2018-11-11 00:00:00', 'brian@gt.edu', 'https://i.pinimg.com/564x/72/04/a6/7204a616112e7fdc70da23c27bc54f5d.jpg', 'people who are good people');


-- Likes
INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 00:00:00', 'https://i.pinimg.com/564x/da/ce/c4/dacec44e7ffcbfc43a95f3d683f7af90.jpg', 'Best Sports', 'sean@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 03:20:00', 'https://i.pinimg.com/564x/f7/24/97/f724971f00cfe08ee1b99486d197d112.jpg', 'Stuff For Home', 'sean@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('brian@gt.edu','2018-11-08 00:02:00', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg','Places To Go', 'mary@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('sean@gt.edu','2018-11-08 00:02:00', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg','Places To Go', 'mary@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('meghan@gt.edu','2018-11-08 00:02:00', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg','Places To Go', 'mary@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('john@gt.edu','2018-11-08 00:02:00', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg','Places To Go', 'mary@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('jake@gt.edu','2018-11-08 00:02:00', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg','Places To Go', 'mary@gt.edu');

INSERT INTO Likes (email, date_time, url, title, owner_email)
VALUES ('chelsea@gt.edu','2018-11-08 00:02:00', 'https://i.pinimg.com/564x/b7/81/23/b78123972faadd8de48f7eb2c64a0d49.jpg','Places To Go', 'mary@gt.edu');






-- Commentss
INSERT INTO Comments (date_time,text,email,url,title,owner_email,pushpin_date_time) 
VALUES ('2018-11-10 00:01:00','This is great!','brian@gt.edu','https://i.pinimg.com/564x/c3/79/5b/c3795b63067d60f58021f12b96833fdd.jpg','Stuff For Home', 'sean@gt.edu','2018-11-08 04:00:00');

INSERT INTO Comments (date_time,text,email,url,title,owner_email,pushpin_date_time) 
VALUES ('2018-11-10 00:03:00','Dude this is so cool','meghan@gt.edu','https://i.pinimg.com/564x/c3/79/5b/c3795b63067d60f58021f12b96833fdd.jpg','Stuff For Home', 'sean@gt.edu','2018-11-08 04:00:00');

-- Follows
INSERT INTO Follows (email, follower_email) VALUES ('sean@gt.edu', 'meghan@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('sean@gt.edu', 'brian@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('meghan@gt.edu', 'brian@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('meghan@gt.edu', 'sean@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'meghan@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'sean@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'john@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'chelsea@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('brian@gt.edu', 'mary@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('jake@gt.edu', 'meghan@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('jake@gt.edu', 'sean@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('john@gt.edu', 'jake@gt.edu');
INSERT INTO Follows (email, follower_email) VALUES ('chelsea@gt.edu', 'sean@gt.edu');

-- Watch
INSERT INTO Watch (email, title, owner_email) VALUES ('sean@gt.edu', 'Random Cool Stuff', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('sean@gt.edu', 'Places To Go', 'brian@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('meghan@gt.edu', 'Stuff For Home', 'sean@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('meghan@gt.edu', 'Places To Go', 'brian@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('brian@gt.edu', 'Stuff For Home', 'sean@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('brian@gt.edu', 'Random Cool Stuff', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('john@gt.edu', 'Random Cool Stuff', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('chelsea@gt.edu', 'Random Cool Stuff', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('jake@gt.edu', 'Random Cool Stuff', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('mary@gt.edu', 'Random Cool Stuff', 'meghan@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('brian@gt.edu', 'Delicious Burgers', 'mary@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('sean@gt.edu', 'Delicious Burgers', 'mary@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('meghan@gt.edu', 'Delicious Burgers', 'mary@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('jake@gt.edu', 'Delicious Burgers', 'mary@gt.edu');
INSERT INTO Watch (email, title, owner_email) VALUES ('john@gt.edu', 'Delicious Burgers', 'mary@gt.edu');
