create database e_banking;

use e_banking;

-- Creating tables --

create table clients (
	id int primary key not null identity(1,1),
	fname varchar (45) not null,
	lname varchar (45) not null,
	cedula char (11) unique not null,
	email varchar(100) unique not null,
	phone char(10) not null,
	birth_date date
)

create table users (
	id int primary key not null identity (1,1),
	username varchar (60) unique not null,
	password varchar (256) not null,
	role varchar (45) not null,
	userid int not null 
)

create table accounts (
	id int primary key not null identity(1,1),
	userid int not null,
	account_number varchar (50) not null,
	type varchar (45) not null,
	balance decimal (13,2) not null,
	balance_available decimal (13,2) not null 
)

create table cards (
	id int primary key not null identity (1,1),
	userid int not null,
	card_number varchar (50) unique not null,
	type varchar (50) not null,
	credit_limit decimal (13,2) not null,
	balance decimal (13,2) not null,
	cutoff_date date not null,
	expiration_date date not null,
	status  bit not null
)

create table loans (
	id int primary key not null identity (1,1),
	userid int not null,
	loan_number varchar (50) unique not null,
	type varchar (50) not null,
	amount decimal (13,2) not null,
	quotes int not null,
	months int not null,
	rate decimal (3,2) not null,
	begin_date date not null,
	end_date date not null
)

create table cards_payments (
	id int primary key not null identity(1,1),
	card_number int not null,
	date datetime not null
) 

create table loans_payments (
	id int primary key not null identity(1,1),
	account_number int not null,
	date datetime not null
) 

create table transactions (
	id int primary key not null identity (1,1),
	transaction_number varchar (50) unique not null,
	type varchar (50) not null,
	account_number int not null,
	account_number_destination int not null,
	amount decimal (13,2) not null,
	date datetime not null,
	status bit not null
)

create table beneficiary (
	id int primary key not null identity (1,1),
	userid int not null,
	name varchar (150) unique not null,
	account varchar (50) unique not null,
	email varchar (100) unique not null,
	type varchar (50) not null
)
-- End creating tables --

-- Creating relationships --

alter table users add constraint fk_users_userid foreign key (userid) references clients(id);
alter table accounts add constraint fk_accounts_userid foreign key (userid) references clients(id)
alter table cards add constraint fk_cards_userid foreign key (userid) references clients(id);
alter table loans add constraint fk_loans_userid foreign key (userid) references clients(id);
alter table cards_payments add constraint fk_cards_payments_card_number foreign key (card_number) references cards(id);
alter table cards_payments add constraint fk_loans_payments_account_number foreign key (account_number) references loans(id);
alter table beneficiary add constraint fk_beneficiary_userid foreign key (userid) references clients (id);

-- End creating relationships