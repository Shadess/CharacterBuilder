IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'USERS')
BEGIN
	CREATE TABLE USERS
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		EMAIL nvarchar(255) UNIQUE NOT NULL,
		USERNAME nvarchar(100) NOT NULL,
		PASSWORD binary(256),
		SALT binary(32),
		VERIFIED bit NOT NULL DEFAULT 0,
		SIGNUPDATE datetime NOT NULL DEFAULT GETDATE(),
		ISADMIN bit NOT NULL DEFAULT 0
	);
END
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'USERTOKENS')
BEGIN
	CREATE TABLE USERTOKENS
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		USERID_FK int NOT NULL FOREIGN KEY REFERENCES USERS(ID),
		TOKEN uniqueidentifier NOT NULL,
		TOKENTYPE int NOT NULL,
		CREATEDATE datetime NOT NULL DEFAULT GETDATE(),
	);
END
GO

/* RACES */
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RACES')
BEGIN
	CREATE TABLE RACES
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		NAME nvarchar(100) NOT NULL,
		COMMONNAME nvarchar(100) NOT NULL,
		LIFESPAN nvarchar(100) NOT NULL,
		HEIGHT nvarchar(100) NOT NULL,
		ORIGIN nvarchar(100) NOT NULL,
		SOCIALSTATUS nvarchar(100) NOT NULL,
		FLAVORTEXT nvarchar(255) NOT NULL,
		DESCRIPTION nvarchar(max) NOT NULL,
	);
END
GO

/* CLASSES */
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CLASSES')
BEGIN
	CREATE TABLE CLASSES
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		NAME nvarchar(100) NOT NULL,
		ROLE nvarchar(100) NOT NULL,
		FLAVORTEXT nvarchar(255) NOT NULL,
		DESCRIPTION nvarchar(max) NOT NULL,
	);
END
GO

/* POWERS */
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERS')
BEGIN
	CREATE TABLE POWERS
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		NAME nvarchar(100) NOT NULL,
		CATEGORY int NOT NULL,
		POWERTYPE int NOT NULL,
		ACTIONTYPE int,
		EFFECTTYPE int,
		RANGE int,
		AURARANGE int,
		DESCRIPTION nvarchar(MAX),
		TIER int NOT NULL,
		ACTIVE bit NOT NULL
	);
END
GO

/* POWERS MAP */
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERSMAP')
BEGIN
	CREATE TABLE POWERSMAP
	(
		CATEGORYOBJECTID int NOT NULL,
		POWERID_FK int NOT NULL FOREIGN KEY REFERENCES POWERS(ID)
	);
END
GO



--IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAMPAIGNS')
--BEGIN
--	CREATE TABLE CAMPAIGNS
--	(
--		ID int IDENTITY(1,1) PRIMARY KEY,
--		USERID_FK int NOT NULL FOREIGN KEY REFERENCES USERS(ID),
--		NAME nvarchar(255) NOT NULL,
--		CREATEDATE datetime NOT NULL DEFAULT GETDATE(),
--	);
--END
--GO




--/* HEROIC AWAKENINGS */
--IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'HEROICAWAKENINGS')
--BEGIN
--	CREATE TABLE HEROICAWAKENINGS
--	(
--		ID int IDENTITY(1,1) PRIMARY KEY,
--		NAME nvarchar(max) NOT NULL,
--		FLAVORTEXT nvarchar(max) NULL,
--		DESCRIPTION nvarchar(max) NULL,
--	);
--END
--GO







--IF NOT EXISTS (SELECT 1 FROM POWERS)
--BEGIN
--	INSERT INTO POWERS (NAME, CATEGORY, POWERTYPE, ACTIONTYPE, EFFECTTYPE, RANGE, AURARANGE, DESCRIPTION, TIER, ACTIVE)
--	VALUES
--	('Charming', 1, 1, 0, 0, 0, 0, 'You gain proficiency in diplomacy.', 0, 1),
--	('Child of Darkness', 1, 1, 0, 0, 0, 0, 'You gain darkvision.', 0, 1),
--	('Child of Light', 1, 1, 0, 0, 0, 0, 'You may equip one additional blessing.', 0, 1),
--	('Dark Omen', 1, 2, 3, 6, 0, 0, 'Cause the entire combat zone to be enshrouded in pitch blackness until the end of your next turn.', 0, 1),
--	('Deathblow', 1, 2, 3, 2, 0, 0, 'Instantly kill a non-elite creature within range.', 0, 1),
--	('Enduring', 1, 1, 0, 0, 0, 0, 'You gain proficiency in endurance.', 0, 1),
--	('Fast Hands', 1, 2, 3, 2, 0, 0, 'You take an item within range that is within your reach and not equipped on a creature as if you made a successful thievery check against the item. You are not noticed when you use Fast Hands.', 0, 1),
--	('Flexible', 1, 1, 0, 0, 0, 0, 'You gain +2 to every skill you are not proficient in.', 0, 1),
--	('Haunting', 1, 2, 1, 1, 0, 0, 'While you are unconscious due to falling to 0 hit points or fewer during a Combat Encounter, you may continue combat like normal as a phantom spirit. Only the creature that dropped you to 0 hit points may see you, and you may only damage and interact with the same offending creature. 
--You may not move beyond 20 squares of your physical body and the effect ends when you are revived or die.', 0, 1),
--	('Herbalism', 1, 2, 4, 1, 0, 0, 'Regain 3 hit points.', 0, 1),
--	('Heroism', 1, 2, 5, 1, 0, 0, 'Gain a Standard Action.', 0, 1),
--	('Intimidating', 1, 1, 0, 0, 0, 0, 'You gain proficiency in intimidation.', 0, 1),
--	('Mighty', 1, 1, 0, 0, 0, 0, 'You gain proficiency in athletics.', 0, 1),
--	('Overpower', 1, 2, 1, 1, 0, 0, 'When you roll damage dice and dislike the result, you may reroll the damage dice and use either result. 
--You may use Overpower twice per encounter.', 0, 1),
--	('Perfection', 1, 2, 1, 1, 0, 0, 'When you roll to hit an elite creature and miss, you may cause yourself to automatically hit the creature instead of miss.', 0, 1),
--	('Regenerative', 1, 1, 0, 0, 0, 0, 'You regain 1 hit point at the end of each of your turns during a combat encounter.', 0, 1),
--	('Stubbornness', 1, 2, 1, 1, 0, 0, 'When you are afflicted with a negative effect (Slow, Immobilized, Mind Control, etc), immediately cause that effect to end. You may use this ability any time, even during an enemy''s turn.', 0, 1),
--	('Sturdy', 1, 1, 0, 0, 0, 0, 'You gain +1 stamina and +2 hit points.', 0, 1),
--	('Superior', 1, 1, 0, 0, 0, 0, 'You gain one additional specialization point.', 0, 1),
--	('Thieving', 1, 1, 0, 0, 0, 0, 'You gain proficiency in thievery.', 0, 1),
--	('Versatile', 1, 1, 0, 0, 0, 0, 'You are considered to have the Multiclass ability on your loadout. At Paragon level, you may choose Multiclass to gain access to a third class, or you may choose to gain Knighthood in either of the classes you gained from Versatile.', 0, 1),
--	('Chloroform', 2, 2, 4, 2, 0, 0, 'Cause one creature within range to fall unconscious until the end of your next turn.', 1, 1),
--	('Hand to Hand', 2, 2, 3, 2, 0, 0, 'Disarm a creature within range, removing their ability to use their Basic Attack or any ability that requires a weapon to use. In addition, you strike their windpipe, removing their ability to make any sound. Both of these effects last until the end of your next turn.', 1, 1),
--	('Escape Plan', 2, 2, 4, 3, 0, 3, 'You and every willing ally within the aura may spend 1 Mana to successfully retreat to the place where you spent your last extended rest. If this place is more than 1 mile away, you instead travel two miles in that direction. 
--This movement is unhindered and unchallenged and unfollowed, and takes the time it would take you to sprint the distance.', 1, 1),
--	('Evasion', 2, 1, 0, 0, 0, 0, 'Once per round, when you would be hit by an attack or ability, you may roll a dice. If the result is even, then you negate the incoming damage and effects. 
--Prerequisite: You must be wearing Leather Armor to use Evasion.', 1, 1),
--	('Investigative Expertise', 2, 2, 4, 3, 0, 3, 'Within an area around you, dust for prints, pick up footprints, uncover hidden compartments, and gain truesight within the aura. If something can be found, you find it. 
--To use Investigative Expertise, you require 10 minutes unmoved and uninterrupted. At the end of 5 minutes, Investigative Expertise is used.', 1, 1),
--	('Leather Armor Specialization', 2, 4, 0, 0, 0, 0, 'You gain proficiency with Leather Armor.', 1, 1),
--	('Preparedness', 2, 1, 0, 0, 0, 0, 'Twice per day, you may produce from your pack a common non-magical item weighing no more than 10lbs that you could have realistically acquired from any settlement you’ve visited. This item is unsellable. 
--This item is not a magical conjuration, but a product of the fact that you are prepared with all the right materials for any situation you might encounter.', 1, 1),
--	('Agent''s Finesse', 2, 1, 0, 0, 0, 0, 'Once per day, you may know beyond a shadow of a doubt whether a statement you’ve just heard was a lie.', 2, 1),
--	('Flash Bang', 2, 2, 4, 1, 0, 0, 'Create a bright flash of light at your location, causing every enemy creature who can see you to become blinded until the end of your next turn. 
--Blinded creatures suffer a -3 to hit.', 2, 1),
--	('Knack for Success', 2, 2, 1, 1, 0, 0, 'When you fail a skill check, you may immediately reroll and use either result. 
--You must spend 1 Mana when using Knack for Success.', 2, 1),
--	('Network of Spies', 2, 1, 0, 0, 0, 0, 'You have underworld contacts in every settlement you’ve visited this campaign, and receive constant updates on current events, allowing you generally “know” the goings on of various civilizations and settlements across the land. Your information can be up to 3 days old depending on the distance.', 2, 1),
--	('Professional''s Tools', 2, 1, 0, 0, 0, 0, 'You gain +5 Thievery for the sake of picking locks and disarming traps. In addition, this +5 bonus can also be applied to any check required to disable devices, constructs, or systems both technological or magical. 
--You may not use Thieve’s Tools in conjunction with Professional’s Tools.', 2, 1),
--	('Defection', 2, 2, 1, 4, 30, 0, 'Choose an enemy non-elite creature within range that you can see. For the duration of this encounter, it is under your control as if you’d Mind Controlled it.', 3, 1),
--	('Exploit Weakness', 2, 2, 3, 2, 0, 0, 'Exploit the weaknesses of a target adjacent to you until the start of your next turn. While the target’s weaknesses are exploited, all damage made against it deals maximum damage.', 3, 1),
--	('Sniper Support', 2, 2, 3, 4, 30, 0, 'Choose an enemy non-boss creature you can see. The creature is immediately killed by an unseen sniper. This may only be used in a combat encounter against hostile enemy combatants.', 3, 1),
--	('Knight Excursor', 2, 5, 0, 0, 0, 0, 'Gain +1 to every Skill.', 4, 1),
--	('Holy Weapon', 3, 3, 3, 1, 0, 0, 'You may use Holy Weapon after the end of an extended rest to gain your bound Holy Weapon until the end of your next extended rest. Your Holy Weapon can take the form any kind of non-small weapon you like. You may even choose to allow it become two weapons for the sake of dual wielding. 

--The Holy Weapon is infused with the wisdom and personality of former saints and heroes who wielded it before you. It is a living being in the form of a weapon with a lawful good personality. The more you are worthy of wielding the Holy Weapon, the greater it’s power will be in your hands. You begin with 5 (Out of 10) Worthiness and at the end of each extended rest, the weapon will reassess you, and grant you anywhere between 3 and -3 Worthiness based on your deeds that day (at the DM’s discretion). It can range from 1 point for giving of your abundance to the poor to -3 points for killing an innocent man begging for his life. 

--<strong>1-3 Worthiness:</strong> 1d6 Medium Weapon (1d8 Large) with Steadiness 1. 
--<strong>4-6 Worthiness:</strong> 1d6 Medium Weapon (1d8 Large) with Steadiness 3. In addition, the weapon can shed bright light in a range of up to Aura 10 and be summoned to your hand from any location or made to fade away, hidden in an alternate plane of existence as a Minor Action. 
--<strong>7-9 Worthiness:</strong> 1d8 Medium Weapon (1d10 Large) with Steadiness 4. In addition to the previous bonuses, you no longer need to spend Mana to use Holy Weapon and Empowered. 
--<strong>10 Worthiness:</strong> 1d8 Medium Weapon (1d10 Large) with Steadiness 5. In addition to the previous bonuses, the light shed by your Holy Weapon will now deal 2 Damage to every enemy of supernatural origin within range (Fey, Vampires, Demons, Werewolves, ect). 

--Holy Weapon cannot be improved or enhanced by gold or abilities (such as Blessed Weapon or Enchanted Weapon).', 0, 1)
--END
--GO


--IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERSMAP')
--BEGIN
--	CREATE TABLE POWERSMAP
--	(
--		OBJECTID int NOT NULL,
--		POWERID_FK int NOT NULL FOREIGN KEY REFERENCES POWERS(ID),
--		CATEGORY int NOT NULL
--	);
--END
--GO

--IF NOT EXISTS (SELECT 1 FROM POWERSMAP)
--BEGIN
--	INSERT INTO POWERSMAP (OBJECTID, POWERID_FK, CATEGORY)
--	VALUES
--	(1, 3, 1),
--	(1, 19, 1),
--	(1, 15, 1),
--	(2, 13, 1),
--	(2, 18, 1),
--	(2, 14, 1),
--	(3, 6, 1),
--	(3, 18, 1),
--	(3, 17, 1),
--	(4, 1, 1),
--	(4, 3, 1),
--	(4, 11, 1),
--	(5, 2, 1),
--	(5, 20, 1),
--	(5, 7, 1),
--	(6, 8, 1),
--	(6, 21, 1),
--	(6, 10, 1),
--	(7, 2, 1),
--	(7, 16, 1),
--	(7, 9, 1),
--	(8, 2, 1),
--	(8, 19, 1),
--	(8, 4, 1),
--	(9, 12, 1),
--	(9, 19, 1),
--	(9, 5, 1),
--	(1, 22, 2),
--	(1, 23, 2),
--	(1, 24, 2),
--	(1, 25, 2),
--	(1, 26, 2),
--	(1, 27, 2),
--	(1, 28, 2),
--	(1, 29, 2),
--	(1, 30, 2),
--	(1, 31, 2),
--	(1, 32, 2),
--	(1, 33, 2),
--	(1, 34, 2),
--	(1, 35, 2),
--	(1, 36, 2),
--	(1, 37, 2),
--	(1, 38, 3)
--END
--GO




--/* POWER SPECIALIZATIONS */
--IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERSPECIALIZATIONS')
--BEGIN
--	CREATE TABLE POWERSPECIALIZATIONS
--	(
--		ID int IDENTITY(1,1) PRIMARY KEY,
--		POWERID_FK int NOT NULL FOREIGN KEY REFERENCES POWERS(ID),
--		DESCRIPTION nvarchar(MAX),
--	);
--END
--GO


--IF NOT EXISTS (SELECT 1 FROM POWERSPECIALIZATIONS)
--BEGIN
--	INSERT INTO POWERSPECIALIZATIONS (POWERID_FK, DESCRIPTION)
--	VALUES
--	(22, 'If Chloroform is used outside of combat, the creature falls unconscious for an hour and does not see you use Chloroform.'),
--	(22, 'You may use Chloroform twice per encounter.'),
--	(23, 'When you use Hand to Hand, also knock the creature prone. You may use Hand to Hand one additional time per encounter.'),
--	(23, 'You may use Hand to Hand as a Move or Minor Action.'),
--	(24, 'Escape plan no longer requires Mana from your allies.'),
--	(24, 'Escape plan is now an instant teleport, and no longer suffers the 1 mile limitation.'),
--	(25, 'You may use Evasion one additional time per round.'),
--	(25, 'You may use Evasion one additional time per round.'),
--	(26, 'Increase the size to Aura 5.'),
--	(26, 'Reduce the time required to 1 minutes.'),
--	(27, 'Gain +1 Speed while wearing Leather Armor.'),
--	(27, 'Gain +2 Stealth while wearing Leather Armor.'),
--	(28, 'You may use Preparedness four times per day.'),
--	(28, 'Increase the weight limitation to 20lbs. In addition, you gain the ability to create on the fly forgeries and other fake documentation and disguises with Preparedness, as if you had researched the people and cultures you were going to encounter today several weeks ago.')
--END
--GO