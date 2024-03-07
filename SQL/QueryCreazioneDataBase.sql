/*CREATE TABLE Amministratori (
	IdAmministratore INT IDENTITY NOT NULL PRIMARY KEY,
	Username NVARCHAR(30) NOT NULL,
	Password NVARCHAR(30) NOT NULL,
)

CREATE TABLE Clienti (
	IdCliente INT IDENTITY NOT NULL PRIMARY KEY,
	Nome NVARCHAR(40) NOT NULL,
	Cod_Fisc NCHAR(16) NULL,
	P_Iva NCHAR(11) NULL
)

CREATE TABLE Spedizioni (
	IdSpedizione INT IDENTITY NOT NULL PRIMARY KEY,
	IdCliente INT NOT NULL,
	Numero_Identificativo NCHAR(10) NOT NULL UNIQUE,
	Data_Spedizione Date NOT NULL,
	Peso DECIMAL NOT NULL,
	Città_Destinataria NVARCHAR(50) NOT NULL,
	Indirizzo NVARCHAR(50) NOT NULL,
	Nominativo NVARCHAR(50) NOT NULL,
	Costo_Spedizione MONEY NOT NULL,
	Data_Consegna Date NOT NULL
)

CREATE TABLE Aggiornamenti (
	IdAggiornamento INT IDENTITY NOT NULL PRIMARY KEY,
	IdSpedizione INT NOT NULL,
	Stato NVARCHAR(15) NOT NULL,
	Luogo NVARCHAR(50) NOT NULL,
	Descrizione NVARCHAR(MAX) NULL,
	Ora_Registrazione DATETIME NOT NULL
)*/

/*INSERT INTO Amministratori (Username, Password) VALUES ('Admin2003', 'myPassword')*/

/*INSERT INTO Clienti (Nome, Cod_Fisc) VALUES ('Gabriele Bongio', 'BNGGRL03A05I829R'), ('Ambrogio Fornaro', 'FRNMGR59P05L123E'), ('Alma Labate', 'LBTLMA94A42E629A')

INSERT INTO Clienti (Nome, P_Iva) VALUES ('MyAgency s.p.a.', '16253748273'), ('Super Mario Agency', '12946738273'), ('Unique S.P.A.', '17482936273')*/

/*INSERT INTO Spedizioni (IdCliente, Numero_Identificativo, Data_Spedizione, Peso, Città_Destinataria, Indirizzo, Nominativo, Costo_Spedizione, Data_Consegna) VALUES
(1, '1000000000', '01/03/2024', 24.21, 'Roma (ROMA)', 'Via dei Cosimi, 71', 'Gabriele Bongio', 12, '05/03/2024'),
(2, '1000000001', '01/03/2024', 117.2, 'Rimini (RN)', 'Via dei Gelsomini, 7', 'Ambrogio Fornaro', 5, '06/03/2024'),
(3, '1000000002', '01/03/2024', 7.2, 'Crotone (KR)', 'Piazza Caduti, 2', 'Alma Labate', 3, '04/03/2024'),
(4, '1000000003', '04/03/2024', 0.221, 'Urbino (PU)', 'Via Roma, 123', 'Carlo Agente', 16, '07/03/2024'),
(5, '1000000004', '04/03/2024', 0.812, 'Bologna (BO)', 'Via San Donato, 24', 'Mario del Nero', 7, '11/03/2024'),
(6, '1000000005', '04/03/2024', 6.312, 'Cervia (RA)', 'Piazza XX Settembre, 3', 'Andrea Verdi', 12, '09/03/2024')*/

/*INSERT INTO Aggiornamenti (IdSpedizione, Stato, Luogo, Descrizione, Ora_Registrazione) VALUES 
(1, 'In transito', 'Firenze (FI)', '', '14:21 04/03/2024'),
(2, 'In Transito', 'Morbegno (SO)', '', '14:29 04/03/2024'),
(3, 'Consegnato', 'Crotone (KR)', 'Pacco consegnato con successo il giorno 04/03/2024 alle ore 9:34', '10:54 04/03/2024'),
(4, 'In Transito', 'Genova (GE)', '', '17:32 04/03/2024'),
(5, 'In Transito', 'Sevilla (ESP)', '', '15:32 04/03/2024'),
(6, 'In Transito', 'Aosta (AO)', '', '18:32 04/03/2024')*/