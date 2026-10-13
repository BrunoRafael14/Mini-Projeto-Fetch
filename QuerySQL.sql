SELECT current_database()

CREATE TABLE Pessoas (
	id Serial PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL
)

SELECT * FROM Pessoas

DELETE FROM Pessoas WHERE nome = '2'