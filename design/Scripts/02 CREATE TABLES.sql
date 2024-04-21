USE Universidad;

CREATE TABLE TBL_ESTUDIANTES(
	id INT PRIMARY KEY IDENTITY,
	nombre VARCHAR(250) NOT NULL, 
	email VARCHAR(100) NOT NULL
);

CREATE TABLE TBL_SESIONES (
	id INT PRIMARY KEY IDENTITY,
	nombre VARCHAR(250) NOT NULL,
	start_datetime DATETIME NOT NULL, 
	end_datetime DATETIME NOT NULL,
	cupo INT NOT NULL,
	ocupado INT NOT NULL DEFAULT 0
);

CREATE TABLE TBL_ASIGNACIONES (
	id INT PRIMARY KEY IDENTITY,
	fecha_asignacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	id_estudiante INT NOT NULL,
	id_sesion INT NOT NULL,	
	CONSTRAINT FK_ASIG_ESTUDIANTE FOREIGN KEY (id_estudiante) REFERENCES TBL_ESTUDIANTES(id),
	CONSTRAINT FK_ASIG_SESION FOREIGN KEY (id_sesion) REFERENCES TBL_SESIONES(id)
);