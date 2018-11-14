-- Popular tags (Needs more testing)
SELECT name AS Tag, COUNT(Tags.date_time) AS PushPins, Count(DISTINCT Tags.title) AS 'Unique Corkboards'
FROM Tags
GROUP BY name
ORDER BY COUNT(Tags.date_time) DESC, COUNT(DISTINCT Tags.title) DESC LIMIT 5


-- Popular Sites
SELECT url AS Site, COUNT(*) AS PushPins
FROM PushPin
GROUP BY url
ORDER BY COUNT(*) DESC LIMIT 4;


-- Corkboard Statistics
SELECT name, COUNT(DISTINCT Corkboard.title) AS 'Public Corkboard', 
COUNT(PushPin.date_time) AS 'Public PushPins', 
COUNT(DISTINCT Private_Corkboard.title) AS 'Private Corkboards', 
COUNT(Private_Corkboard.owner_email) AS 'Private PushPins'
FROM ((Corkboard NATURAL JOIN User) NATURAL JOIN PushPin)
LEFT JOIN Private_Corkboard ON Corkboard.title=Private_Corkboard.title AND Corkboard.owner_email=Private_Corkboard.owner_email
WHERE Corkboard.owner_email=User.email AND PushPin.title=Corkboard.title
GROUP BY name
ORDER BY Count(Corkboard.title) DESC;

-- Logging in
SELECT * FROM User WHERE User.email='$Email'; -- check if user exists
SELECT pin FROM User WHERE User.email='$Email'; -- check if entered password is correct

-- ========================================================================
-- ========================================================================
-- Populating Home Screen
-- ========================================================================
Select name FROM User WHERE User.email='$Email'; -- OR SAVE name in $Name during login

-- Recent Updates
SELECT title, name, visibility, date_time
FROM (Corkboard NATURAL JOIN User) NATURAL JOIN PushPin
WHERE (Corkboard.owner_email IN 
        (SELECT Follows.follower_email 
        FROM Follows
        WHERE Follows.email='sean@gt.edu'
        UNION 
        SELECT Watch.owner_email
        FROM Watch
        WHERE Watch.email='sean@gt.edu') 
    OR Corkboard.owner_email='sean@gt.edu') 
    AND Corkboard.owner_email=User.email
GROUP BY Corkboard.title
ORDER BY PushPin.date_time DESC Limit 4

-- My Corkboards
SELECT DISTINCT Corkboard.title AS Corkboard,
COUNT(PushPin.description) AS PushPins,
Corkboard.visibility AS Visibility 
FROM Corkboard NATURAL JOIN PushPin 
WHERE Corkboard.owner_email='$Email'
GROUP BY Corkboard
ORDER BY Corkboard.title;

-- Searching for PushPin
SELECT description AS 'PushPin Description', category_type AS CorkBoard, owner_email AS Owner
FROM Tags NATURAL JOIN Corkboard
WHERE description LIKE '%$Entry%' OR name LIKE '%$Entry%' OR category_type LIKE '%$Entry%'
ORDER BY description ASC;
-- ========================================================================
-- ========================================================================


-- Populated Category Drop Down
SELECT type AS Category
FROM Category
GROUP BY Category.type
ORDER BY type ASC;



-- ========================================================================
-- ========================================================================
-- View Corkboard
-- ========================================================================
-- Given the user must have clicked on the Hyperlinked Corkboard there should be
-- a '$Title' and a '$Owner'
-- We will perform numerous queries to simplify this page
SELECT name 
FROM User
Where User.email='$Owner'

-- if $owner=$Email from sessionID
-- enable 'Add PushPin' button

Select category_type, Corkboard.title, date_time, url
FROM Corkboard NATURAL JOIN PushPin
WHERE owner_email = '$Owner' AND title = '$Title'
ORDER BY PushPin.date_time DESC

-- Number of watchers
SELECT COUNT(*)
FROM Corkboard NATURAL JOIN Watch
WHERE title='$Title'


-- ========================================================================
-- ========================================================================
-- View PushPin
-- ========================================================================
-- Save Pushpin Info into variabls
-- $date_timte
-- $owner_email
-- $title
-- $url


-- Retrieve Likes
SELECT name
FROM PushPin AS p NATURAL JOIN User NATURAL JOIN Corkboard AS c NATURAL JOIN `Like` AS l 
WHERE '$owner_email'=l.owner_email AND '$url'=l.url AND '$date_time'=l.date_time AND '$title'=l.title

-- Retrieve Comments
SELECT name, text
FROM (PushPin AS p INNER JOIN `Comment`AS c ON '$owner_email'=c.owner_email) INNER JOIN User ON User.email=c.owner_email
WHERE '$owner_email'=c.owner_email AND '$url'=c.url AND '$date_time'=c.pushpin_date_time AND '$title'=c.title
ORDER BY c.date_time DESC

-- Retrieve Tags
SELECT DISTINCT name
FROM Tags
WHERE '$owner_email'=Tags.owner_email AND '$url'=Tags.url AND '$date_time'=Tags.date_time AND '$title'=Tags.title
ORDER BY name ASC



-- ==============================
-- validating corkboard password
-- ==============================
SELECT password
FROM Private_Corkboard
WHERE title='$Title'

-- ==============================
-- Add a Corkboard
-- ==============================
-- must first create a corkboard, and then a private corkboard referencing the corkboard
INSERT INTO Corkboard ( title, visibility, owner_email, category_type) VALUES ('This is my title', 1, 'sean@gt.edu', 'Other');
INSERT INTO Private_Corkboard( title, owner_email, password) VALUES ('This is my title', 'sean@gt.edu', 'newpassword');
