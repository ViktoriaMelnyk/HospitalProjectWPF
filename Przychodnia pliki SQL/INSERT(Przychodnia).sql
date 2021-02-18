use Przychodnia;

INSERT INTO Patients (FirstName,LastName,birthDate,PESEL,gender,postalCode,city,street_adress,phoneNb,mail) 
values ('Ada','Kowalczyk','1980-12-12','80121212345','K','31148','Kark�w','ul.Tarnowskiego 22/2','123321123','ada.kowal@gmail.com');
INSERT INTO Patients (FirstName,LastName,birthDate,PESEL,gender,postalCode,city,street_adress,phoneNb,mail) 
values ('Andrzej','Nowak','1974-08-17','74081712345','M','31145','Kark�w','ul.D�uga 4','12332987','74andrzej@gmail.com');
INSERT INTO Patients (FirstName,LastName,birthDate,PESEL,gender,postalCode,city,street_adress,phoneNb,mail) 
values ('Kamil','Winter','1995-07-11','95121212345','M','32158','Kark�w','ul.Bia�a 31/2','678321123','aaaaaaaa@gmail.com');
INSERT INTO Patients (FirstName,LastName,birthDate,PESEL,gender,postalCode,city,street_adress,phoneNb,mail) 
values ('Anna','Go��bek','1965-02-14','65021412345','K','30146','Kark�w','ul.Post�pu 1/4','123465123','m�jmail@gmail.com');
INSERT INTO Patients (FirstName,LastName,birthDate,PESEL,gender,postalCode,city,street_adress,phoneNb,mail) 
values ('Konrad','Ukupnik','1999-01-12','99011212345','M','22148','Kark�w','ul.Twoja 5','789321123','ukupnikl@gmail.com');

INSERT INTO Specializations (name) values ('lekarz rodzinny');
INSERT INTO Specializations (name) values ('pediatra');
INSERT INTO Specializations (name) values ('laryngolog');
INSERT INTO Specializations (name) values ('piel�gniarka');


INSERT INTO Doctors (FirstName,LastName,PESEL,phoneNb, mail,specializations) values ('Dariusz','Melnyk','74011234567','987765654','drdariusz@gmail.com',1);
INSERT INTO Doctors (FirstName,LastName,PESEL,phoneNb, mail,specializations) values ('Wiktoria','Melnyk','75051334567','987765655','drmelnyk@gmail.com',2);
INSERT INTO Doctors (FirstName,LastName,PESEL,phoneNb, mail,specializations) values ('Micha�','Skaba','80091234567','987765656','drmicha�@gmail.com',3);

INSERT INTO Nurses (FirstName,LastName,PESEL,phoneNb, mail,specialization) values ('Maria','Szylko','65021234587','987765657','maria@gmail.com',4);

INSERT INTO HospitalInfo (Name,NIP,REGON,KRS,adress,phoneNB) values ('MELNYK MED Sp.z o.o.','970912113','140987655','00001234','30-644 KRAK�W PUSZKARSKA 7H','123400100');
select*from HospitalInfo;
INSERT INTO Diseases (DiseaseCode) values ('A-94');
INSERT INTO Diseases (DiseaseCode) values ('CD-10');
INSERT INTO Diseases (DiseaseCode) values ('B-84');
INSERT INTO Diseases (DiseaseCode) values ('C-01');
INSERT INTO Diseases (DiseaseCode) values ('A-40');


INSERT INTO PrescriptionDrugs (DrugName) values ('Propanol');
INSERT INTO PrescriptionDrugs (DrugName) values ('Nakom');
INSERT INTO PrescriptionDrugs (DrugName) values ('Mononit');
INSERT INTO PrescriptionDrugs (DrugName) values ('Depo-Medrol');
INSERT INTO PrescriptionDrugs (DrugName) values ('Unasyn');


INSERT INTO Prescriptions (idHosInf,idDoc,idPrDr,idPat,prDate,comment) 
values (3,1,1,4,'01-12-2019',
'Doustnie. Dawk� i cz�stotliwo�� przyjmowania leku okre�la lekarz na podstawie st�enia leku we krwi oraz na podstawie tolerancji leku przez chorego');
INSERT INTO Prescriptions (idHosInf,idDoc,idPrDr,idPat,prDate,comment) 
values (3,2,3,5,'01-01-2020','Doustnie');
INSERT INTO Prescriptions (idHosInf,idDoc,idPrDr,idPat,prDate,comment) 
values (3,2,5,6,'02-12-2019',
'Dawk� i cz�stotliwo�� przyjmowania leku okre�la lekarz na podstawie st�enia leku we krwi oraz na podstawie tolerancji leku przez chorego');
INSERT INTO Prescriptions (idHosInf,idDoc,idPrDr,idPat,prDate,comment) 
values (3,1,1,4,'01-11-2019',
'Doustnie. Dawk� i cz�stotliwo�� przyjmowania leku okre�la lekarz na podstawie st�enia leku we krwi oraz na podstawie tolerancji leku przez chorego');
INSERT INTO Prescriptions (idHosInf,idDoc,idPrDr,idPat,prDate,comment) 
values (3,1,1,4,'01-10-2019',
'Doustnie. Dawk� i cz�stotliwo�� przyjmowania leku okre�la lekarz na podstawie st�enia leku we krwi oraz na podstawie tolerancji leku przez chorego');


INSERT INTO BookingVisit (idDoc,idPat,dateOfReserv,timeOfVisit) values (1,4,'05-02-2020','9:00');
INSERT INTO BookingVisit (idDoc,idPat,dateOfReserv,timeOfVisit) values (2,7,'05-02-2020','9:15'); 
INSERT INTO BookingVisit (idDoc,idPat,dateOfReserv,timeOfVisit) values (2,5,'05-02-2020','9:30'); 
INSERT INTO BookingVisit (idDoc,idPat,dateOfReserv,timeOfVisit) values (1,6,'05-02-2020','9:45'); 
INSERT INTO BookingVisit (idDoc,idPat,dateOfReserv,timeOfVisit) values (3,4,'05-03-2020','9:15'); 


Insert INTO Visits (idDoc,idPat,DateOfVisit,TimeOfVisit,Symptoms,Diagnosis,idDis,idPrescr,sickLeave,recommendations)
values (1,4,'2019-08-17','9:00','wysoka gor�czka','Grypa',1,4,'14 dni',
'Na gor�czk� i jednocze�nie inne objawy infekcji (b�l g�owy i mi�ni) pomog� NLPZ (paracetamol, ibuprofen).
Na m�cz�cy suchy kaszel dobre s� syropy nawil�aj�ce drogi oddechowe.');

Insert INTO Visits (idDoc,idPat,DateOfVisit,TimeOfVisit,Symptoms,Diagnosis,idDis,idPrescr,recommendations)
values (1,5,'2019-09-20','11:00','du�e pragnienie cz�ste oddawanie moczu','Sukrzyca',3,5,
'Leczenie rozpoczyna si� zazwyczaj od diety, redukcji masy cia�a. Wskazany jest umiarkowany wysi�ek fizyczny');

Insert INTO Visits (idDoc,idPat,DateOfVisit,TimeOfVisit,Symptoms,Diagnosis,idDis,sickLeave,recommendations)
values (2,6,'2018-08-18','10:00','kaszel','Przezi�bienie',1,'14 dni',
'Na m�cz�cy suchy kaszel dobre s� syropy nawil�aj�ce drogi oddechowe.');

Insert INTO Visits (idDoc,idPat,DateOfVisit,TimeOfVisit,Symptoms,Diagnosis,idDis, recommendations)
values (1,4,'2018-08-19','9:00','wysoka gor�czka','Angina',5,'Na gor�czk� i jednocze�nie inne objawy infekcji (b�l g�owy i mi�ni) pomog� NLPZ');

Insert INTO Visits (idDoc,idPat,DateOfVisit,TimeOfVisit,Symptoms,Diagnosis,idDis,sickLeave,recommendations)
values (3,7,'2019-08-17','12:00','Zatkany nos
G�sta, ��ta lub zielona wydzielina z nosa','Zapalenie zatok',6,'14 dni','Zapalenie zatok to zapalenie b�ony �luzowej wy�cie�aj�cej zatoki przynosowe i nos, obejmuj�ce jedn� lub kilka zatok. W zale�no�ci
od czasu trwania wyr�nia si� posta� ostr� i przewlek��.');

Insert INTO Visits (idDoc,idPat,DateOfVisit,TimeOfVisit,Symptoms,Diagnosis,idDis,idPrescr,sickLeave,recommendations)
values (3,6,'2019-08-17','11:00','wysoka gor�czka','Grypa',1,5,'14 dni','Na gor�czk� i jednocze�nie inne objawy infekcji (b�l g�owy i mi�ni) pomog� NLPZ (paracetamol, ibuprofen).
Na m�cz�cy suchy kaszel dobre s� syropy nawil�aj�ce drogi oddechowe.');
