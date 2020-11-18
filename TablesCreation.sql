CREATE TABLE Movie (
    MovieID integer not null,
    Title varchar(128) not null,
    Year integer not null,
    Length interval not null,
    Audience_Rating real not null,
    Image_File_Path varchar(128),
    CONSTRAINT Movie_pk PRIMARY KEY (MovieID)
);

CREATE TABLE Genre (
    GenreID char(3) not null,
    Name varchar(32),
    Description varchar(128),
    CONSTRAINT Genre_pk PRIMARY KEY (GenreID)
);

CREATE TABLE JT_Genre_Movie (
    Genre_ID char(3),
    Movie_ID integer not null,
    CONSTRAINT JTGenreMovie_pk PRIMARY KEY (Movie_ID, Genre_ID),
    CONSTRAINT MovieID_fk FOREIGN KEY (Movie_ID) REFERENCES Movie (MovieID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT GenreID_fk FOREIGN KEY (Genre_ID) REFERENCES Genre (GenreID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Screening_Room (
    Code char(3) not null,
    Capacity integer not null,
    Description varchar(128),
    CONSTRAINT ScreeningRoom_pk PRIMARY KEY (Code)
);

CREATE TABLE Showtime (
    ShowtimeID integer not null,
    Date_Time timestamp not null,
    Movie_ID integer not null,
    S_room_code char(3),
    Ticket_Price float not null,
    CONSTRAINT Showtime_pk PRIMARY KEY (ShowtimeID),
    CONSTRAINT ScreeningRoom_fk FOREIGN KEY (S_room_code) REFERENCES Screening_Room (code) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT MovieID_fk FOREIGN KEY (Movie_ID) REFERENCES Movie (MovieID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE User_Account_Type (
    TypeID integer not null,
    Name varchar(32) not null,
    Description varchar(128) not null,
    CONSTRAINT UserAccountType_pk PRIMARY KEY (TypeID)
);

CREATE TABLE User_Account (
    UserID integer not null,
    Name varchar(128) not null,
    Username varchar(16) not null,
    Password varchar(16) not null,
    Email_Address varchar(128) not null,
    Ua_Type_ID integer not null,
    Signup_Date_Time timestamp not null,
    CONSTRAINT User_pk PRIMARY KEY (UserID),
    CONSTRAINT UserType_fk FOREIGN KEY (Ua_Type_ID) REFERENCES User_Account_Type (TypeID)
);

CREATE TABLE e_Ticket (
    ETicketID bigint not null,
    Purchase_Date_Time timestamp not null,
    Showtime_ID integer not null,
    User_Account_ID integer not null,
    CONSTRAINT ETicket_pk PRIMARY KEY (ETicketID),
    CONSTRAINT Showtime_fk FOREIGN KEY (Showtime_ID) REFERENCES Showtime (ShowtimeID),
    CONSTRAINT UserID_fk FOREIGN KEY (User_Account_ID) REFERENCES User_Account (UserID)
);