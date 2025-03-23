IF EXISTS (SELECT * FROM sys.databases WHERE name = 'LyceumDB')
BEGIN
    DROP DATABASE LyceumDB;
END
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'ClientDB')
BEGIN
    DROP DATABASE ClientDB;
END
GO

CREATE DATABASE LyceumDB;
GO

USE LyceumDB;
GO

CREATE TABLE TURMAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(255),
    Email VARCHAR(255),
    Disciplina VARCHAR(255),
    Turma VARCHAR(50),
    NumeroAlunos INT,
    Curso VARCHAR(255),
    Docente VARCHAR(255),
    Sala VARCHAR(50),
    Predio VARCHAR(50),
    DataInicio DATETIME,
    DataFim DATETIME,
    Periodo INT
);
GO

CREATE TABLE STG_TURMA_LYCEUM (
    Id INT PRIMARY KEY IDENTITY,
    TurmaId INT,
    Nome NVARCHAR(100),
	Email VARCHAR(255),
    Disciplina NVARCHAR(100),
    NumeroAlunos INT,
    Curso NVARCHAR(100),
    Docente NVARCHAR(100),
    Sala NVARCHAR(100),
    Predio NVARCHAR(100),
    DataInicio DATE,
    DataFim DATE,
    Periodo INT,
    TipoOperacao CHAR(1),
    DataOperacao DATETIME DEFAULT GETDATE(),
    Processado BIT DEFAULT 0,
    ProcessadoComSucesso BIT,
	Message NVARCHAR(200)
);
GO

CREATE TRIGGER trg_Insert_Turma
ON TURMAS
AFTER INSERT
AS
BEGIN
    INSERT INTO STG_TURMA_LYCEUM (TurmaId, Nome, Disciplina, Email, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo, TipoOperacao)
    SELECT Id, Nome, Disciplina, Email, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo, 'I'
    FROM inserted;
END;
GO


CREATE TRIGGER trg_Update_Turma
ON TURMAS
AFTER UPDATE
AS
BEGIN
    INSERT INTO STG_TURMA_LYCEUM (TurmaId, Nome, Disciplina, Email, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo, TipoOperacao)
    SELECT Id, Nome, Disciplina, Email, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo, 'U'
    FROM inserted;
END;
GO


CREATE TRIGGER trg_Delete_Turma
ON TURMAS
AFTER DELETE
AS
BEGIN
    INSERT INTO STG_TURMA_LYCEUM (TurmaId, Nome, Disciplina, Email, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo, TipoOperacao)
    SELECT Id, Nome, Disciplina, Email, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo, 'D'
    FROM deleted;
END;
GO

INSERT INTO TURMAS (Nome, Email, Disciplina, Turma, NumeroAlunos, Curso, Docente, Sala, Predio, DataInicio, DataFim, Periodo) 
VALUES ('Engenharia Computacional', 'instituto@email.com', 'Matemática', 'A1', 30, 'Engenharia', 'Prof. João', '101', 'Bloco A', '2024-02-01', '2024-06-30', 61);
GO


--*******************************************



CREATE DATABASE ClientDB;
GO

USE ClientDB;
GO

CREATE TABLE TURMAS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(255),
    Email VARCHAR(255),
    Disciplina VARCHAR(255),
    Turma VARCHAR(50),
    NumeroAlunos INT,
    Curso VARCHAR(255),
    Docente VARCHAR(255),
    Sala VARCHAR(50),
    Predio VARCHAR(50),
    DataInicio DATETIME,
    DataFim DATETIME,
    Periodo INT
);
