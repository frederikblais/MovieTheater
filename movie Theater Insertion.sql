INSERT INTO movie VALUES
                         ('101', 'Murder Mystery', '2019', '1h 37m', '4.2', 'images/murderMystery.jpg'),
                         ('102', 'Lincoln', '2012', '2h 30m', '4.4', 'images/lincoln.jpg'),
                         ('103', 'Toy Story 4', '2019', '1h 40m', '4', 'images/toystory4.jpg'),
                         ('104', 'Shrek 2', '2004', '1h 45m', '4.8', 'images/shrek2.jpg'),
                         ('105', 'Flight', '2012', '2h 18m', '4.6', 'images/flight.jpg'),
                         ('106', 'James Bond: Skyfall', '2012', '2h 24m', '4.6', 'images/skyfall.jpg'),
                         ('107', 'Pirates of the Caribbean: Dead Mans Chest', '2006', '2h 31m', '4.7', 'images/piratesDMC.jpg'),
                         ('108', 'Vacation', '2015', '1h 39m', '4.1', 'images/vacation.jpg'),
                         ('109', 'The Rundown', '2003', '1h 45m', '3.4', 'images/rundown.jpg'),
                         ('110', 'Green Book', '2018', '1h 39m', '4.8', 'images/greenBook.png'),
                         ('111', 'Shrek 3', '2007', '1h 33m', '3.2', 'images/shrek3.jpg');


INSERT INTO genre VALUES
                         ('DRA', 'Drama', 'Lets cry'),
                         ('ACT', 'Action', 'A lot of guns'),
                         ('COM', 'Comedy', 'Laughing time'),
                         ('FAM', 'Family', 'OK for kids'),
                         ('ANI', 'Animation', 'Cool cartoons'),
                         ('HIS', 'History', 'Stories of the past'),
                         ('ADV', 'Adventure', 'Exploration time');


INSERT INTO jt_genre_movie VALUES
                                  ('ACT', '101'),
                                  ('COM', '101'),
                                  ('DRA', '102'),
                                  ('HIS', '102'),
                                  ('COM', '103'),
                                  ('FAM', '103'),
                                  ('ANI', '103'),
                                  ('COM', '104'),
                                  ('FAM', '104'),
                                  ('ANI', '104'),
                                  ('COM', '111'),
                                  ('FAM', '111'),
                                  ('ANI', '111'),
                                  ('ACT', '105'),
                                  ('ACT', '106'),
                                  ('ACT', '107'),
                                  ('ADV', '107'),
                                  ('COM', '108'),
                                  ('COM', '109'),
                                  ('COM', '110'),
                                  ('FAM', '110');


INSERT INTO screening_room VALUES
                                 ('SR1', '100', 'Screening Room 1 - 100 seats'),
                                 ('SR2', '200', 'Screening Room 2 - 200 seats'),
                                 ('SR3', '150', 'Screening Room 3 - 150 seats'),
                                 ('SR4', '300', 'Screening Room 4 - 400 seats');


INSERT INTO showtime VALUES
                            ('310', '25/11/2020', '105', 'SR3', '6.99'),
                            ('311', '25/11/2020', '110', 'SR1', '8.99');


INSERT INTO user_account_type VALUES
                                     ('1', 'Client', 'A regular client'),
                                     ('2', 'Manager', 'A MT Manager');


INSERT INTO user_account VALUES
                                ('10001', 'Donald Biden', 'dbiden', '=abc123', 'dbident@mt.com', '2', '11/1/2020 8:30'),
                                ('10002', 'Joe Obama', 'jobama', '=def456', 'jobama@example.mail', '1', '11/2/2020 8:30');


INSERT INTO e_ticket VALUES
                            ('700123', '11/3/2020 9:35', '311', '10002'),
                            ('700124', '11/4/2020 14:03', '310', '10002');
