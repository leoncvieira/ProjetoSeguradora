create schema T68;
use t68;

create table Pessoa (
Idpessoa int primary key,
nome varchar(50) not null,
fone varchar(11) not null,
endereco varchar(50),
bairro varchar(30),
cep varchar(20) not null
);

create table Cliente (
Idpessoa int primary key,
cpf varchar(20) not null,
rg varchar(20),
sexo char not null,
datanascimento date not null,
foreign key (Idpessoa) references Pessoa(Idpessoa) 
);

create table Apolice (
Idpessoa int,
Idapolice int primary key,
Idveiculo int,
numeroapolice varchar(20) not null,
datainicio date not null,
datafim date not null,
valor double,
franquia double,
datacontrato date,
foreign key (Idpessoa) references Cliente(Idpessoa),
foreign key (Idveiculo) references Veiculo(Idveiculo)
);

create table Veiculo (
Idveiculo int primary key,
Idmodelo int,
placa varchar(7) not null,
ano int,
foreign key (Idmodelo) references Modelo(Idmodelo)
);

create table Modelo (
Idmodelo int primary key,
Idmarca int,
descricao varchar(50),
foreign key (Idmarca) references Marca(Idmarca)
);

create table Marca (
Idmarca int primary key,
descricao varchar(50)
);