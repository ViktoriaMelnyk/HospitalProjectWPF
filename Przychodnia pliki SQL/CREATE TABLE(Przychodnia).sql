use Przychodnia;

create table Patients (idPat int primary key identity (1,1),
						FirstName nvarchar(30) NOT NULL,
						LastName nvarchar(50) NOT NULL,
						birthDate date NOT NULL,
						PESEL char(11),
						gender char(1),
						postalCode varchar(8)NOT NULL,
						city nvarchar(50)NOT NULL,
						street_adress nvarchar(50)NOT NULL,
						phoneNb nvarchar (9) NOT NULL,
						mail nvarchar(20) NOT NULL)
						;

create table Specializations(idSpec int primary key identity (1,1),
                             name nvarchar(100)); 

create table  Doctors(idDoc int primary key identity (1,1),
						FirstName nvarchar(30) NOT NULL,
						LastName nvarchar(50) NOT NULL,
						PESEL char(11),
						phoneNb nvarchar (9) NOT NULL,
						mail nvarchar(20) NOT NULL,
						specializations int references Specializations(idSpec))
						;
create table  Nurses(idNurs int primary key identity (1,1),
						FirstName nvarchar(30) NOT NULL,
						LastName nvarchar(50) NOT NULL,
						PESEL char(11),
						phoneNb nvarchar (9) NOT NULL,
						mail nvarchar(20) NOT NULL,
						specialization int references Specializations(idSpec));
						;
create table HospitalInfo(idHosInf int primary key identity (1,1),
                          Name nvarchar (100) NOT NULL,
						  NIP int NOT NULL,
						  REGON int NOT NULL,
						  KRS int ,
						  adress nvarchar (250)NOT NULL,
						  phoneNb nvarchar (9) NOT NULL)
						  ;

create table Diseases(idDis int primary key identity (1,1),
                      DiseaseCode nvarchar(5))
					  ;

create table PrescriptionDrugs(idPrDr int primary key identity (1,1),
                               DrugName nvarchar(45))
		                       ;

create table Prescriptions(idPrescr int primary key identity (1,1),
                           idHosInf int references HospitalInfo(idHosInf),
						   idDoc int references Doctors (idDoc),
						   idPrDr int references PrescriptionDrugs(idPrDr),
						   idPat int references Patients(idPat),
						   prDate date,
						   comment nvarchar(300))
						   ;
create table Visits (idVis int primary key identity (1,1),
                     idDoc int references Doctors (idDoc),
					  idPat int references Patients(idPat),
					  DateOfVisit date,
					  TimeOfVisit time,
					  Symptoms nvarchar(200),
					  Diagnosis nvarchar(200), 
					  idDis int references Diseases(idDis),
					  idPrescr int references Prescriptions(idPrescr),
					  sickLeave nvarchar(20),
					  recommendations nvarchar(300))
					  ;
create table BookingVisit(idBV int primary key identity (1,1),
                          idDoc int references Doctors (idDoc),
					      idPat int references Patients(idPat),
						  dateOfReserv date,
						  timeOfVisit time)
						  ;
						  