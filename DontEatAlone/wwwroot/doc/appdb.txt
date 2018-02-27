BEGIN TRANSACTION;
DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
	`MigrationId`	TEXT NOT NULL,
	`ProductVersion`	TEXT NOT NULL,
	CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY(`MigrationId`)
);
INSERT INTO `__EFMigrationsHistory` VALUES ('20180220183713_mydb','2.0.1-rtm-125');
DROP TABLE IF EXISTS `UserReservation`;
CREATE TABLE IF NOT EXISTS `UserReservation` (
	`userID`	TEXT NOT NULL,
	`reservationID`	INTEGER NOT NULL,
	`isHost`	INTEGER NOT NULL,
	CONSTRAINT `AK_UserReservation_reservationID_userID` UNIQUE(`reservationID`,`userID`),
	CONSTRAINT `FK_UserReservation_User_userID` FOREIGN KEY(`userID`) REFERENCES `User`(`Id`) ON DELETE RESTRICT,
	CONSTRAINT `PK_UserReservation` PRIMARY KEY(`userID`,`reservationID`),
	CONSTRAINT `FK_UserReservation_Reservation_reservationID` FOREIGN KEY(`reservationID`) REFERENCES `Reservation`(`id`) ON DELETE RESTRICT
);
INSERT INTO `UserReservation` VALUES ('86bf90b6-8a25-41bd-8f73-17568733f74a',1,1);
INSERT INTO `UserReservation` VALUES ('86bf90b6-8a25-41bd-8f73-17568733f74a',2,1);
DROP TABLE IF EXISTS `User`;
CREATE TABLE IF NOT EXISTS `User` (
	`Id`	TEXT NOT NULL,
	`dateOfBirth`	TEXT,
	`email`	TEXT,
	`firstName`	TEXT,
	`gender`	TEXT,
	`lastName`	TEXT,
	`phoneNumber`	TEXT,
	`userType`	TEXT,
	CONSTRAINT `FK_User_AspNetUsers_Id` FOREIGN KEY(`Id`) REFERENCES `AspNetUsers`(`Id`) ON DELETE CASCADE,
	CONSTRAINT `PK_User` PRIMARY KEY(`Id`)
);
INSERT INTO `User` VALUES ('86bf90b6-8a25-41bd-8f73-17568733f74a',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
INSERT INTO `User` VALUES ('0f66de44-f63c-4b79-b21f-9985e4a7e2c3',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
INSERT INTO `User` VALUES ('3b2f4613-51a3-432e-a8ab-fc2e5248f6f9',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
INSERT INTO `User` VALUES ('9e591eca-e25d-4795-ab07-bc2a444382ed',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
DROP TABLE IF EXISTS `Reservation`;
CREATE TABLE IF NOT EXISTS `Reservation` (
	`id`	INTEGER NOT NULL,
	`LocationID`	TEXT,
	`dateEnd`	TEXT NOT NULL,
	`dateStart`	TEXT NOT NULL,
	`numberOfPeople`	INTEGER NOT NULL,
	`status`	TEXT,
	`title`	TEXT,
	CONSTRAINT `PK_Reservation` PRIMARY KEY(`id`)
);
INSERT INTO `Reservation` VALUES (1,NULL,'0001-01-01 00:00:00','0001-01-01 00:00:00',0,NULL,'my_first_reservation');
INSERT INTO `Reservation` VALUES (2,NULL,'0001-01-01 00:00:00','0001-01-01 00:00:00',0,NULL,'my_second_reservation');
DROP TABLE IF EXISTS `PremiumSubscription`;
CREATE TABLE IF NOT EXISTS `PremiumSubscription` (
	`ID`	TEXT NOT NULL,
	`endDate`	TEXT NOT NULL,
	`payment`	INTEGER NOT NULL,
	`startDate`	TEXT NOT NULL,
	CONSTRAINT `FK_PremiumSubscription_User_ID` FOREIGN KEY(`ID`) REFERENCES `User`(`Id`) ON DELETE CASCADE,
	CONSTRAINT `PK_PremiumSubscription` PRIMARY KEY(`ID`)
);
DROP TABLE IF EXISTS `Limitations`;
CREATE TABLE IF NOT EXISTS `Limitations` (
	`id`	INTEGER NOT NULL,
	`age`	TEXT,
	`alcohol`	INTEGER NOT NULL,
	`cuisineType`	TEXT,
	`description`	TEXT,
	`gender`	TEXT,
	`languages`	TEXT,
	`pets`	INTEGER NOT NULL,
	`smoking`	INTEGER NOT NULL,
	CONSTRAINT `FK_Limitations_Reservation_id` FOREIGN KEY(`id`) REFERENCES `Reservation`(`id`) ON DELETE RESTRICT,
	CONSTRAINT `PK_Limitations` PRIMARY KEY(`id`)
);
INSERT INTO `Limitations` VALUES (1,'any',0,'chinese','hello welcome!','male','chinese',0,0);
INSERT INTO `Limitations` VALUES (2,'over 18',0,'Canada','welcome lady!!','female','English',0,0);
DROP TABLE IF EXISTS `Comment`;
CREATE TABLE IF NOT EXISTS `Comment` (
	`id`	INTEGER NOT NULL,
	`authorID`	TEXT,
	`body`	TEXT,
	`date`	TEXT NOT NULL,
	`reservationID`	INTEGER NOT NULL,
	CONSTRAINT `PK_Comment` PRIMARY KEY(`id`),
	CONSTRAINT `FK_Comment_Reservation_reservationID` FOREIGN KEY(`reservationID`) REFERENCES `Reservation`(`id`) ON DELETE RESTRICT
);
INSERT INTO `Comment` VALUES (1,'86bf90b6-8a25-41bd-8f73-17568733f74a','very nice man!','2018-02-27 11:23:40.8391779',1);
INSERT INTO `Comment` VALUES (2,'86bf90b6-8a25-41bd-8f73-17568733f74a','very good man!','2018-02-27 11:23:40.8485953',1);
INSERT INTO `Comment` VALUES (3,'86bf90b6-8a25-41bd-8f73-17568733f74a','very beautiful lady!','2018-02-27 11:23:40.8512513',2);
INSERT INTO `Comment` VALUES (4,'86bf90b6-8a25-41bd-8f73-17568733f74a','like her so much!','2018-02-27 11:23:40.8523045',2);
DROP TABLE IF EXISTS `AspNetUsers`;
CREATE TABLE IF NOT EXISTS `AspNetUsers` (
	`Id`	TEXT NOT NULL,
	`AccessFailedCount`	INTEGER NOT NULL,
	`ConcurrencyStamp`	TEXT,
	`Email`	TEXT,
	`EmailConfirmed`	INTEGER NOT NULL,
	`LockoutEnabled`	INTEGER NOT NULL,
	`LockoutEnd`	TEXT,
	`NormalizedEmail`	TEXT,
	`NormalizedUserName`	TEXT,
	`PasswordHash`	TEXT,
	`PhoneNumber`	TEXT,
	`PhoneNumberConfirmed`	INTEGER NOT NULL,
	`SecurityStamp`	TEXT,
	`TwoFactorEnabled`	INTEGER NOT NULL,
	`UserName`	TEXT,
	CONSTRAINT `PK_AspNetUsers` PRIMARY KEY(`Id`)
);
INSERT INTO `AspNetUsers` VALUES ('294288a3-44d3-4915-ba35-52587272f1e2',0,'9e48b259-3113-497a-bf5e-3d53835f32d6','test@user.com',0,1,NULL,'TEST@USER.COM','TEST@USER.COM','AQAAAAEAACcQAAAAEG8SOuxfGkM+V4nQIo/jiL3Xs144KuBFIZaGTAZ4d9V4ctUTEAljWsuV3KL8I7QTHg==',NULL,0,'2a5239b8-4a05-4a9a-96fe-b30a59e22198',0,'test@user.com');
INSERT INTO `AspNetUsers` VALUES ('8e704c47-05a4-419b-9461-88644c1681b7',0,'55c23393-01a2-4a9c-afac-8b20165c59f3','Karlxu0410@gmail.com',0,1,NULL,'KARLXU0410@GMAIL.COM','KARLXU0410@GMAIL.COM','AQAAAAEAACcQAAAAEB65Tj5BbhjgNpFsDlYYrAdLsUoDAd5QpoPxejB9ClHtlIhyLADJejsc+WVryb9B8g==',NULL,0,'5b6b7895-1539-42b5-b41d-f155d4e97c6c',0,'Karlxu0410@gmail.com');
INSERT INTO `AspNetUsers` VALUES ('b94c8efb-3500-40d5-ac8d-b7090b837ad7',0,'68daf810-6c36-4d24-a15f-e5dd5cbad6f6','1@1.com',0,1,NULL,'1@1.COM','1@1.COM','AQAAAAEAACcQAAAAEJ5zoWXupb8OYJsHNnh3cUe5LfSvN8+n0QUMVQt1oARCt3Fix+7qfD5a1HcbjgZ/Lw==',NULL,0,'a55a3c85-6637-4f8a-a328-75f9dd2924fc',0,'1@1.com');
INSERT INTO `AspNetUsers` VALUES ('06a8a9dc-d6f9-494a-9a87-89ab1b876688',0,'3afa23df-5517-4fc4-87a1-83bf2a9ad31e','2@2.com',0,1,NULL,'2@2.COM','2@2.COM','AQAAAAEAACcQAAAAEDiuUxCgi9KfrmoAo5rZbfJBn9uaWlbGHWBRyUtSW9pw13X8L9Re8RCcPh9nUPOGmQ==',NULL,0,'f18eb56d-d68d-4f33-af1f-af7376c4116c',0,'2@2.com');
INSERT INTO `AspNetUsers` VALUES ('86bf90b6-8a25-41bd-8f73-17568733f74a',0,'396a5a05-75dd-4a14-be25-5cb2ccd59acd','admin@user.com',0,1,NULL,'ADMIN@USER.COM','ADMIN@USER.COM','AQAAAAEAACcQAAAAEJWZIqvlJnn/omYBNvcKxFcB1D2vzYeodaKkYn46tes/hmbbingeeZ9zz0SQy1pshQ==',NULL,0,'438e70c2-dcc5-433c-ab42-cd4e4c45cf2a',0,'admin@user.com');
INSERT INTO `AspNetUsers` VALUES ('0f66de44-f63c-4b79-b21f-9985e4a7e2c3',0,'b7f69005-b934-4ece-8155-1c3e9db792a0','regular@user.com',0,1,NULL,'REGULAR@USER.COM','REGULAR@USER.COM','AQAAAAEAACcQAAAAEG4MHFVu7PgW+39uSqgzK0RyB/cv5MeSnEVpDvB140PzJMxCZ0awTovfYFVsHk+SPA==',NULL,0,'7576ae84-7ba0-4984-957e-425ed03266da',0,'regular@user.com');
INSERT INTO `AspNetUsers` VALUES ('3b2f4613-51a3-432e-a8ab-fc2e5248f6f9',0,'9b78b15e-917f-4571-acff-9f8e96a995f3','premium@user.com',0,1,NULL,'PREMIUM@USER.COM','PREMIUM@USER.COM','AQAAAAEAACcQAAAAEDeMxE+HrIf32/Mr1gXA08iXxWqKGxsWWS1jzaRJftOAkbWxWxQghC5RKt7+rBoGrw==',NULL,0,'8a9a84f9-4856-4650-ac0c-4f593b29b72e',0,'premium@user.com');
INSERT INTO `AspNetUsers` VALUES ('9e591eca-e25d-4795-ab07-bc2a444382ed',0,'5bc03fef-049e-459b-a08a-2ceaf1f94752','3@3.com',0,1,NULL,'3@3.COM','3@3.COM','AQAAAAEAACcQAAAAEBqRDL2C9xkgg9f2eCjjqaGfSA29wG5jzBKPtSxSn60l6g1JDQVXECFxYqXyhVMVGg==',NULL,0,'883ca701-6282-4ca5-aab6-77baa08e156b',0,'3@3.com');
DROP TABLE IF EXISTS `AspNetUserTokens`;
CREATE TABLE IF NOT EXISTS `AspNetUserTokens` (
	`UserId`	TEXT NOT NULL,
	`LoginProvider`	TEXT NOT NULL,
	`Name`	TEXT NOT NULL,
	`Value`	TEXT,
	CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY(`UserId`) REFERENCES `AspNetUsers`(`Id`) ON DELETE CASCADE,
	CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY(`UserId`,`LoginProvider`,`Name`)
);
DROP TABLE IF EXISTS `AspNetUserRoles`;
CREATE TABLE IF NOT EXISTS `AspNetUserRoles` (
	`UserId`	TEXT NOT NULL,
	`RoleId`	TEXT NOT NULL,
	CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY(`UserId`,`RoleId`),
	CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY(`UserId`) REFERENCES `AspNetUsers`(`Id`) ON DELETE CASCADE,
	CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY(`RoleId`) REFERENCES `AspNetRoles`(`Id`) ON DELETE CASCADE
);
INSERT INTO `AspNetUserRoles` VALUES ('b94c8efb-3500-40d5-ac8d-b7090b837ad7','Premium');
INSERT INTO `AspNetUserRoles` VALUES ('06a8a9dc-d6f9-494a-9a87-89ab1b876688','Regular');
INSERT INTO `AspNetUserRoles` VALUES ('86bf90b6-8a25-41bd-8f73-17568733f74a','Regular');
INSERT INTO `AspNetUserRoles` VALUES ('86bf90b6-8a25-41bd-8f73-17568733f74a','Admin');
INSERT INTO `AspNetUserRoles` VALUES ('0f66de44-f63c-4b79-b21f-9985e4a7e2c3','Regular');
INSERT INTO `AspNetUserRoles` VALUES ('3b2f4613-51a3-432e-a8ab-fc2e5248f6f9','Premium');
INSERT INTO `AspNetUserRoles` VALUES ('294288a3-44d3-4915-ba35-52587272f1e2','Regular');
INSERT INTO `AspNetUserRoles` VALUES ('9e591eca-e25d-4795-ab07-bc2a444382ed','Regular');
INSERT INTO `AspNetUserRoles` VALUES ('8e704c47-05a4-419b-9461-88644c1681b7','Premium');
DROP TABLE IF EXISTS `AspNetUserLogins`;
CREATE TABLE IF NOT EXISTS `AspNetUserLogins` (
	`LoginProvider`	TEXT NOT NULL,
	`ProviderKey`	TEXT NOT NULL,
	`ProviderDisplayName`	TEXT,
	`UserId`	TEXT NOT NULL,
	CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY(`UserId`) REFERENCES `AspNetUsers`(`Id`) ON DELETE CASCADE,
	CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY(`LoginProvider`,`ProviderKey`)
);
DROP TABLE IF EXISTS `AspNetUserClaims`;
CREATE TABLE IF NOT EXISTS `AspNetUserClaims` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`ClaimType`	TEXT,
	`ClaimValue`	TEXT,
	`UserId`	TEXT NOT NULL,
	CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY(`UserId`) REFERENCES `AspNetUsers`(`Id`) ON DELETE CASCADE
);
DROP TABLE IF EXISTS `AspNetRoles`;
CREATE TABLE IF NOT EXISTS `AspNetRoles` (
	`Id`	TEXT NOT NULL,
	`ConcurrencyStamp`	TEXT,
	`Name`	TEXT,
	`NormalizedName`	TEXT,
	CONSTRAINT `PK_AspNetRoles` PRIMARY KEY(`Id`)
);
INSERT INTO `AspNetRoles` VALUES ('Regular','ff1629a4-f442-43c2-b7c7-0d6b732f78ad','Regular','regular');
INSERT INTO `AspNetRoles` VALUES ('Premium','95387309-ba05-4260-bb8f-bc5ebc0fdde0','Premium','premium');
INSERT INTO `AspNetRoles` VALUES ('Admin','9ca5d3d3-0b1c-4084-ab5b-0c334943c2f8','Admin','admin');
DROP TABLE IF EXISTS `AspNetRoleClaims`;
CREATE TABLE IF NOT EXISTS `AspNetRoleClaims` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`ClaimType`	TEXT,
	`ClaimValue`	TEXT,
	`RoleId`	TEXT NOT NULL,
	CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY(`RoleId`) REFERENCES `AspNetRoles`(`Id`) ON DELETE CASCADE
);
DROP INDEX IF EXISTS `UserNameIndex`;
CREATE UNIQUE INDEX IF NOT EXISTS `UserNameIndex` ON `AspNetUsers` (
	`NormalizedUserName`
);
DROP INDEX IF EXISTS `RoleNameIndex`;
CREATE UNIQUE INDEX IF NOT EXISTS `RoleNameIndex` ON `AspNetRoles` (
	`NormalizedName`
);
DROP INDEX IF EXISTS `IX_Comment_reservationID`;
CREATE INDEX IF NOT EXISTS `IX_Comment_reservationID` ON `Comment` (
	`reservationID`
);
DROP INDEX IF EXISTS `IX_AspNetUserRoles_RoleId`;
CREATE INDEX IF NOT EXISTS `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (
	`RoleId`
);
DROP INDEX IF EXISTS `IX_AspNetUserLogins_UserId`;
CREATE INDEX IF NOT EXISTS `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (
	`UserId`
);
DROP INDEX IF EXISTS `IX_AspNetUserClaims_UserId`;
CREATE INDEX IF NOT EXISTS `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (
	`UserId`
);
DROP INDEX IF EXISTS `IX_AspNetRoleClaims_RoleId`;
CREATE INDEX IF NOT EXISTS `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (
	`RoleId`
);
DROP INDEX IF EXISTS `EmailIndex`;
CREATE INDEX IF NOT EXISTS `EmailIndex` ON `AspNetUsers` (
	`NormalizedEmail`
);
COMMIT;
