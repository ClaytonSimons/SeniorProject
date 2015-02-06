SELECT * FROM UserClient;
SELECT * FROM Timing WHERE WordID = 77;
SELECT * FROM WordData;

SELECT MAX(WordID) AS wordID FROM WordData;

INSERT INTO UserClient VALUES
(
'Clay','Simons'
);

INSERT INTO WordData (UserID,Word,KeyboardType) VALUES
(
2,'Hello',1
};
DELETE FROM WordData;
DELETE FROM UserClient WHERE UserName = 'Clay';