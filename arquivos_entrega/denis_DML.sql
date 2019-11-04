USE DENIS_TREINAMENTO_LANHOUSE;

INSERT INTO USUARIOS VALUES ('admin@email', '12345');

BULK INSERT DEFEITOS
FROM 'c:\csv\defeito.csv'
with (
	fieldterminator = ',', /*A vírgula foi escolhida porque é o que separa os campos no arquivo*/
	rowterminator = '\n',
	firstrow = 1,
	codepage = 'acp'
);


BULK INSERT TIPOS_EQUIPAMENTOS
FROM 'c:\csv\tipo_equipamento.csv'
with (
	fieldterminator = ',', /*A vírgula foi escolhida porque é o que separa os campos no arquivo*/
	rowterminator = '\n',
	firstrow = 1,
	codepage = 'acp'
);


/*Tomar cuidado para que a ordem das colunas no csv seja a mesma no sql*/
BULK INSERT REGISTROS_DEFEITOS
FROM 'c:\csv\registro_defeito.csv'
with (
	fieldterminator = ',', /*A vírgula foi escolhida porque é o que separa os campos no arquivo*/
	rowterminator = '\n',
	firstrow = 1,
	codepage = 'acp'
);


SELECT * FROM DEFEITOS;

SELECT * FROM TIPOS_EQUIPAMENTOS;

SELECT * FROM REGISTROS_DEFEITOS;