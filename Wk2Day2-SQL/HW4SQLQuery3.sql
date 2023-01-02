-- Owners table
CREATE TABLE Owners (
  id INTEGER PRIMARY KEY,
  first_name TEXT NOT NULL,
  last_name TEXT NOT NULL
);

-- Pets table
CREATE TABLE Pets (
  id INTEGER PRIMARY KEY,
  name TEXT NOT NULL,
  type TEXT NOT NULL,
  age INTEGER NOT NULL,
  owner_id INTEGER NOT NULL,
  FOREIGN KEY (owner_id) REFERENCES Owners(id)
);

-- Visits table
CREATE TABLE Visits (
  id INTEGER PRIMARY KEY,
  pet_id INTEGER NOT NULL,
  visit_date DATE NOT NULL,
  Procedure_Info TEXT NOT NULL,
  FOREIGN KEY (pet_id) REFERENCES Pets(id)
);

INSERT INTO Owners (id, first_name, last_name)
VALUES (1, 'SAM', 'COOK'), (2, 'TERRY', 'KIM');

INSERT INTO Pets (id, name, type, age, owner_id)
VALUES (1, 'Rover', 'Dog', 12, 1), (2, 'Spot', 'Dog', 2, 2), (3, 'Morris', 'Cat', 4, 1), (4,'TWEEDY','Bird',2,2);

INSERT INTO Visits (id, pet_id, visit_date, Procedure_Info)
VALUES (1, 1, '2022-01-13', '01-RABIES VACCINATION'), (2, 1, '2022-03-27', '10-EXAMINE and TREAT WOUND'), (3, 1, '2022-04-02', '05-HEART WORM TEST'),
       (4, 2, '2022-01-21', '08-TETANUS VACCINATION'), (5, 2, '2022-03-10', '05-HEART WORM TEST'),
       (6, 3, '2022-01-23', '01-RABIES VACCINATION'), (7, 3, '2022-01-13', '01-RABIES VACCINATION'),
       (8, 4, '2022-04-30', '20-ANNUAL CHECK UP'), (9, 4, '2022-04-30', '12-EYE WASH');



DELETE FROM Owners
WHERE first_name = 'SAM';
