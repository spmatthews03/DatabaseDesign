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
Select name FROM User WHERE User.email='$Email';

-- Recent Updates
SELECT *
FROM (Corkboard NATURAL JOIN PushPin)
WHERE Corkboard.owner_email IN 
(SELECT Follows.follower_email 
FROM Follows
WHERE Follows.email='$Email'
UNION 
SELECT Watch.owner_email
FROM Watch
WHERE Watch.email='$Email') 
OR Corkboard.owner_email='$Email'
GROUP BY Corkboard.title
ORDER BY PushPin.date_time DESC;

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
FROM PushPin NATURAL JOIN Corkboard
WHERE description LIKE '%$Entry%' OR tags LIKE '%$Entry%' OR category_type LIKE '%$Entry%'
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
-- Populating Corkboard
-- ========================================================================





