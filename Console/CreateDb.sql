DROP SCHEMA bugdemo;
CREATE SCHEMA bugdemo;
USE bugdemo;

CREATE TABLE Demos (
  `Key`						INT NOT NULL AUTO_INCREMENT,
  Id						INT,
   PRIMARY KEY (`Key`)
);

INSERT INTO Demos (Id) VALUES (1),(2),(3),(5),(8);

SELECT * FROM Demos;
SELECT * FROM Demos WHERE Id IN (2, 5, 200);