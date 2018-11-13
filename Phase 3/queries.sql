-- Popular tags (STILL WORKING ON)
SELECT tags AS Tag, COUNT(*) AS PushPins, Count(*) AS 'Unique Corkboards'
FROM pushpin NATURAL JOIN
WHERE tags IS NOT NULL
GROUP BY tags
ORDER BY COUNT(*) DESC, COUNT(*) DESC LIMIT 5;


-- Popular Sites
SELECT url AS Site, COUNT(*) AS PushPins
FROM pushpin
WHERE tags IS NOT NULL
GROUP BY url
ORDER BY COUNT(*) DESC LIMIT 4;


-- Searching for PushPin
SELECT description AS 'PushPin Description', category_type AS CorkBoard, owner_email AS Owner
FROM pushpin NATURAL JOIN corkboard
WHERE description LIKE '%$Entry%' OR tags LIKE '%$Entry%' OR category_type LIKE '%$Entry%'
ORDER BY description ASC;

-- Corkboard Statistics
SELECT name, COUNT(DISTINCT corkboard.title) AS 'Public Corkboard', 
COUNT(pushpin.date_time) AS 'Public PushPins', 
COUNT(DISTINCT private_corkboard.title) AS 'Private Corkboards', 
COUNT(private_corkboard.owner_email) AS 'Private PushPins'
FROM ((corkboard NATURAL JOIN user) NATURAL JOIN pushpin)
LEFT JOIN private_corkboard ON corkboard.title=private_corkboard.title AND corkboard.owner_email=private_corkboard.owner_email
WHERE corkboard.owner_email=user.email AND pushpin.title=corkboard.title
GROUP BY name
ORDER BY Count(corkboard.title) DESC