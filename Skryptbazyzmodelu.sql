/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2017-03-19 18:03:39                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Email') and o.name = 'FK_EMAIL_EMAILE_KO_KONTAKT')
alter table Email
   drop constraint FK_EMAIL_EMAILE_KO_KONTAKT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Kontakt') and o.name = 'FK_KONTAKT_ADRES_KON_ADRES')
alter table Kontakt
   drop constraint FK_KONTAKT_ADRES_KON_ADRES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Notatka') and o.name = 'FK_NOTATKA_NOTATKI_U_UZYTKOWN')
alter table Notatka
   drop constraint FK_NOTATKA_NOTATKI_U_UZYTKOWN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Telefon') and o.name = 'FK_TELEFON_TELEFONY__KONTAKT')
alter table Telefon
   drop constraint FK_TELEFON_TELEFONY__KONTAKT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Wydarzenie') and o.name = 'FK_WYDARZEN_WYDARZENI_UZYTKOWN')
alter table Wydarzenie
   drop constraint FK_WYDARZEN_WYDARZENI_UZYTKOWN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('kontakty_uzytkownikow') and o.name = 'FK_KONTAKTY_KONTAKTY__UZYTKOWN')
alter table kontakty_uzytkownikow
   drop constraint FK_KONTAKTY_KONTAKTY__UZYTKOWN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('kontakty_uzytkownikow') and o.name = 'FK_KONTAKTY_KONTAKTY__KONTAKT')
alter table kontakty_uzytkownikow
   drop constraint FK_KONTAKTY_KONTAKTY__KONTAKT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Adres')
            and   type = 'U')
   drop table Adres
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Email')
            and   name  = 'emaile_kontaktu_FK'
            and   indid > 0
            and   indid < 255)
   drop index Email.emaile_kontaktu_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Email')
            and   type = 'U')
   drop table Email
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Kontakt')
            and   name  = 'adres_kontaktu_FK'
            and   indid > 0
            and   indid < 255)
   drop index Kontakt.adres_kontaktu_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Kontakt')
            and   type = 'U')
   drop table Kontakt
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Notatka')
            and   name  = 'notatki_uzytkownika_FK'
            and   indid > 0
            and   indid < 255)
   drop index Notatka.notatki_uzytkownika_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Notatka')
            and   type = 'U')
   drop table Notatka
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Telefon')
            and   name  = 'telefony_kontaktu_FK'
            and   indid > 0
            and   indid < 255)
   drop index Telefon.telefony_kontaktu_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Telefon')
            and   type = 'U')
   drop table Telefon
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Uzytkownik')
            and   type = 'U')
   drop table Uzytkownik
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Wydarzenie')
            and   name  = 'wydarzenia_u퓓tkownika_FK'
            and   indid > 0
            and   indid < 255)
   drop index Wydarzenie.wydarzenia_u퓓tkownika_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Wydarzenie')
            and   type = 'U')
   drop table Wydarzenie
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('kontakty_uzytkownikow')
            and   name  = 'kontakty_uzytkownikow2_FK'
            and   indid > 0
            and   indid < 255)
   drop index kontakty_uzytkownikow.kontakty_uzytkownikow2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('kontakty_uzytkownikow')
            and   name  = 'kontakty_uzytkownikow_FK'
            and   indid > 0
            and   indid < 255)
   drop index kontakty_uzytkownikow.kontakty_uzytkownikow_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('kontakty_uzytkownikow')
            and   type = 'U')
   drop table kontakty_uzytkownikow
go

/*==============================================================*/
/* Table: Adres                                                 */
/*==============================================================*/
create table Adres (
   miejscowosc          text                 null,
   nrdomu               int                  null,
   nrlokalu             int                  null,
   kodpocztowy          text                 null,
   wojewodztwo          text                 null,
   kraj                 text                 null,
   adres_id             int                  not null,
   constraint PK_ADRES primary key nonclustered (adres_id)
)
go

/*==============================================================*/
/* Table: Email                                                 */
/*==============================================================*/
create table Email (
   kontakt_email        text                 not null,
   kontakt_id           text                 null,
   constraint PK_EMAIL primary key nonclustered (kontakt_email)
)
go

/*==============================================================*/
/* Index: emaile_kontaktu_FK                                    */
/*==============================================================*/
create index emaile_kontaktu_FK on Email (
kontakt_id ASC
)
go

/*==============================================================*/
/* Table: Kontakt                                               */
/*==============================================================*/
create table Kontakt (
   kontakt_id           text                 not null,
   adres_id             int                  null,
   imie                 text                 null,
   imie2                text                 null,
   nazwisko             text                 null,
   data_urodzenia       date                 null,
   constraint PK_KONTAKT primary key nonclustered (kontakt_id)
)
go

/*==============================================================*/
/* Index: adres_kontaktu_FK                                     */
/*==============================================================*/
create index adres_kontaktu_FK on Kontakt (
adres_id ASC
)
go

/*==============================================================*/
/* Table: Notatka                                               */
/*==============================================================*/
create table Notatka (
   tytul                text                 null,
   opis                 text                 null,
   data                 date                 null,
   id_notatki           int                  not null,
   user_id              int                  null,
   constraint PK_NOTATKA primary key nonclustered (id_notatki)
)
go

/*==============================================================*/
/* Index: notatki_uzytkownika_FK                                */
/*==============================================================*/
create index notatki_uzytkownika_FK on Notatka (
user_id ASC
)
go

/*==============================================================*/
/* Table: Telefon                                               */
/*==============================================================*/
create table Telefon (
   numer                int                  not null,
   kontakt_id           text                 null,
   typ                  text                 null,
   constraint PK_TELEFON primary key nonclustered (numer)
)
go

/*==============================================================*/
/* Index: telefony_kontaktu_FK                                  */
/*==============================================================*/
create index telefony_kontaktu_FK on Telefon (
kontakt_id ASC
)
go

/*==============================================================*/
/* Table: Uzytkownik                                            */
/*==============================================================*/
create table Uzytkownik (
   password             text                 null,
   user_email           text                 null,
   user_id              int                  not null,
   constraint PK_UZYTKOWNIK primary key nonclustered (user_id)
)
go

/*==============================================================*/
/* Table: Wydarzenie                                            */
/*==============================================================*/
create table Wydarzenie (
   nazwa                text                 null,
   data_rozp            date                 null,
   godzina_rozp         time                 null,
   rodzaj               text                 null,
   id_wyd               int                  not null,
   user_id              int                  null,
   miejsce              text                 null,
   data_zak             date                 null,
   godzina_zak          time                 null,
   constraint PK_WYDARZENIE primary key nonclustered (id_wyd)
)
go

/*==============================================================*/
/* Index: wydarzenia_u퓓tkownika_FK                             */
/*==============================================================*/
create index wydarzenia_u퓓tkownika_FK on Wydarzenie (
user_id ASC
)
go

/*==============================================================*/
/* Table: kontakty_uzytkownikow                                 */
/*==============================================================*/
create table kontakty_uzytkownikow (
   user_id              int                  not null,
   kontakt_id           text                 not null,
   constraint PK_KONTAKTY_UZYTKOWNIKOW primary key (user_id, kontakt_id)
)
go

/*==============================================================*/
/* Index: kontakty_uzytkownikow_FK                              */
/*==============================================================*/
create index kontakty_uzytkownikow_FK on kontakty_uzytkownikow (
user_id ASC
)
go

/*==============================================================*/
/* Index: kontakty_uzytkownikow2_FK                             */
/*==============================================================*/
create index kontakty_uzytkownikow2_FK on kontakty_uzytkownikow (
kontakt_id ASC
)
go

alter table Email
   add constraint FK_EMAIL_EMAILE_KO_KONTAKT foreign key (kontakt_id)
      references Kontakt (kontakt_id)
go

alter table Kontakt
   add constraint FK_KONTAKT_ADRES_KON_ADRES foreign key (adres_id)
      references Adres (adres_id)
go

alter table Notatka
   add constraint FK_NOTATKA_NOTATKI_U_UZYTKOWN foreign key (user_id)
      references Uzytkownik (user_id)
go

alter table Telefon
   add constraint FK_TELEFON_TELEFONY__KONTAKT foreign key (kontakt_id)
      references Kontakt (kontakt_id)
go

alter table Wydarzenie
   add constraint FK_WYDARZEN_WYDARZENI_UZYTKOWN foreign key (user_id)
      references Uzytkownik (user_id)
go

alter table kontakty_uzytkownikow
   add constraint FK_KONTAKTY_KONTAKTY__UZYTKOWN foreign key (user_id)
      references Uzytkownik (user_id)
go

alter table kontakty_uzytkownikow
   add constraint FK_KONTAKTY_KONTAKTY__KONTAKT foreign key (kontakt_id)
      references Kontakt (kontakt_id)
go

