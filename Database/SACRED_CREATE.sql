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
		SIGNUPDATE datetime NOT NULL DEFAULT GETDATE()
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

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CAMPAIGNS')
BEGIN
	CREATE TABLE CAMPAIGNS
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		USERID_FK int NOT NULL FOREIGN KEY REFERENCES USERS(ID),
		NAME nvarchar(255) NOT NULL,
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

IF NOT EXISTS (SELECT 1 FROM RACES)
BEGIN
	INSERT INTO RACES (NAME, COMMONNAME, LIFESPAN, HEIGHT, ORIGIN, SOCIALSTATUS, FLAVORTEXT, DESCRIPTION)
	VALUES 
	('Ashira', 'Elf', 'Immortal', '4-6 Feet Tall', 'Fey', 'High', 'Avert your eyes... it’s best not to get tangled with Fey Royalty.', 'Slender, thin, and pale humanoids. Far more graceful fighters than your standard human, but also much more frail. Well known for being intelligent, and wise, but also haughty and arrogant. They hold themselves above other races and aside from their smaller stature, have proven to be exemplary statistically to many of the other races. These creatures are also of Fey origins and have developed an everlasting life or immortality but this does not mean they can’t be killed. Ashiran societies tend to fall along a more Socialist caste system. Everyone has a job, from the King to the Farmer, and they all know magic. When an Ashiran army fights, they use massive magical assaults and elegant soldier form and tactics.'),
	('Bagrath', 'Half-Giant', '60-70 Years Old', '9-11 Feet Tall', 'Humanoid' ,'Medium', 'The Sun has set over you, the Bagraths have arrived', 'The Bagrath are considered to by many races to be a mutated strain of human but the origins are unclear. What is clear is the immense size of a Bagrath. Standing a full 3-4 feet higher than the average human being, and possessing incredible strength. They look similar to the humans in both hair, and skin, and are generally more widely accepted socially. While not well known for their intelligence, they are never a race of people you’d want to tangle with. Even an unarmed Bagrath can (and will) crush your skull if it feels insulted. Bagrath follow the strongest warriors in their War Packs. For the most part, Bagrath aren’t allowed to organize, but when they do, Bagrath often adopt fighting in Caves and mountains where they hold the advantage, or outright charging Phalanxes.'),
	('Hrugar', 'Dwarf', '300 Years Old', '4-5 Feet Tall', 'Humanoid' ,'Medium', 'There is nothing more stubborn than the convictions of a Hrugar', 'Short, Stout, greying humanoids, who stand at roughly 4-4 ½ feet tall. Well known for their thick skin and resilient presence. It is well recorded that it is easier to move a House, then it is to move a Hrugar. Though a slower race due to their smaller stature. their low center of gravity gives them the advantage in close quarters combat. They are widely considered the most stubborn race but also one of the most loyal. If you can get a Hrugar to trust you, you have their trust til you die. They are also quite brilliant when it comes to great machinery or weapons. As they are not nearly as magical as Ashirans, they make up for it with technical ingenuity, creating war machines and mining equipment used to tear apart enemies from underneath them. They are often found using phalanx fighting forms. Hrugar hierarchy is divided into Houses. The Lord House at the top, rules over each house below it.'),
	('Human', '', '60-120 Years Old', '4-7 Feet Tall', 'Humanoid' ,'High', 'You never know with a human what is going to happen. You can’t put them in a box like most races.', 'One of the most Common Races in Sacred. Humans are widely considered to have the most potential for both good and evil, and are capable of amazing and catastrophic things. They stand at about 4-7 feet tall, and don’t particularly excel at anything but are capable of becoming whatever they want with minimal restrictions. Their style of fighting changes with each country that rises and falls, and their governments have moved from republics to dictatorships at the drop of a hat. While considered to be the most faulty race, at the center of every conflict, there has been known to be at least one human on either side, who has changed the world, for better or worse.'),
	('Kuda', 'Goblin', 'Unknown', '2-3 Feet Tall', 'Humanoid' ,'Low', 'If you’ve got the coin, then we’ve got the time.', 'Kuda are one of the smallest races in Sacred. Green skinned, sharp teeth and claws and standing at 2-3 feet tall at the most, it makes them ill fit for most jobs above stealing or mercantile. However, the Kuda have developed an interesting system. Since most Kuda societies are often broken apart, Kuda have formed a Warpack technique. Three Kuda will make a Pact with each other at a young age and are forever bound to one another, they operate as one unit and this makes them a fierce opponent for anyone hoping to bully or take advantage of their small size. Kuda generally find themselves under the employment of Orcs but still manage to snake their way into Hrugar and Human societies as merchants and thieves. Rarely used for military but make for excellent scouts, Kuda are tough businessmen. Generally a cowardly bunch, their cowardice can often be turned into courage if you can test their greed.'),
	('Rashir', 'Half-Elf', 'Unknown', '4-6 Feet Tall', 'Humanoid' ,'Low-Medium', 'The fear of an abomination is irrational. No, Rashir are feared, because they are the future.', 'There is no society built upon a Rashir, or group of people that move together as one. Rashir are half breeds. The only kind of Half Breed and it is between Ashira and Human. Rashir are often looked down upon by both Ashirans and Humans for different reasons. Ashirans believe them to be abominations in open society while humans consider them to be a lesser race then themselves. However, Rashir often carry the most potential thanks to the combination of both breeds, while still more fragile than a human, they are quick witted and have high natural reflexes. Many of them are not held back or are capable of hiding that they are Rashir but due to the way they are viewed upon by these races, it will be rare to see two or more Rashir in any one place.'),
	('Vish''Kar', 'Troll', '60-80 Years Old', '7-10 Feet Tall', 'Humanoid' ,'Very Low', 'This has been a good talk mon, but my family is hungry. This is nothing personal, ya understand?', 'The Vish’Kar are large, green, tusked creatures, with long arms that practically reach the ground. They are usually hunched over, but if they stood straight up could match the size of a Bagrath(9-10 feet). They are much thinner than the Bagrath and much more attune to magic than most races, but suffer from only being able to steal magics without truly forming their own. Vish’Kar act very animalistic but are capable of rational thought and holding conversation. Usually, they are simply hunting for food or stealing supplies. They fall under the racial class of Kar. A race that Human’s and Fey generally don’t associate. Often referred to as Half Devils. Vish’Kar are usually found in tribes, following whoever the head Shaman is. They also fight in packs, using guerilla tactics and ambush techniques.'),
	('Vlorrin', 'Drow', 'Immortal', '4-6 Feet Tall', 'Fey' ,'Extremely Low', 'To betray, you must first belong.', 'The Vlorrin, for the most part, tend to hold close to the shadowy recesses of both thickly forested areas or dark subterranean areas. They are a secretive, brutal, and deadly race where even their children are trained to defend the wastes that tend to be their homes. 
Finding Vlorrin among the common surface cities and towns is a rare sight, but there are often those of the Vlorrin who become disillusioned with the ways of their kinds and turn from it, or those who have been banished from their strict society. 
For whatever reason they might have to appear in public, Vlorrin are often feared by the common races for their brutal efficiency in combat. With the ability to see in pitch blackness, Vlorrin have the advantage over every other race come nightfall, and many stories have been told to naughty children about Vlorrin coming in the night and consuming their flesh.'),
	('Zul''Kar', 'Orc', '90 Years Old', '6-8 Feet Tall', 'Humanoid' ,'Low', 'The blood challenge has been made. We fight til one of us drops dead.', 'Zul’Kar are viewed by the world as barbarians and monsters, but of all the Kar races, Zul’s are the most honorable. They are tactically intelligent, but will pursue a fair battle or a proof of worth in combat. Though they have a bloodlust and often engage Ashirans and Humans whenever possible, they are steeped in teachings of honor and glory of battle and respect their enemies and believe to die in battle is the greatest glory of them all. Zul’Kar are only slightly larger than humans but carry immense strength. Their reflexes are not nearly as great but they make up for it with their fighting strength. From birth Zul’Kar are taught how to fight and how to kill. They have a right of passage that each Zul’Kar must pass in order to become a warrior/hunter for their nation. The Society is often ran by a head Lord or Commander, whose house rules over their country. They use formation fighting and generally have the tactical advantage in most open field combats. They often employ the use of Kuda for spying and Vish’Kar to help counter magi. Zul’Kar are easily considered the strongest and most organized Kar Races.')
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

IF NOT EXISTS (SELECT 1 FROM CLASSES)
BEGIN
	INSERT INTO CLASSES (NAME, ROLE, FLAVORTEXT, DESCRIPTION)
	VALUES 
	('Agent', 'Utility', 'I''ve got a plan for every scenario, a tool for every situation.', 'When force of might may fail, cunning and subterfuge can succeed. Whether it be breaking into an impenetrable fortress or escaping from a hopeless fight the agent provides the tools and skills necessary to perform these seemingly impossible feats. 

The Agent class provides the most utility of all the classes by offering a vast amount of options of getting in and out of a situation. Whether they’re facing solid stone or an army of watchful guards, the agent provides your group the option to avoid pointless combat encounters or to escape unfavorable situations. While not providing much in a pitched battle itself, his skills can save your group time and energy much better spent elsewhere. In battle the agent will focus on disabling his enemies, allowing others to finish  the job.

Focusing fully down the Agent skill tree will allow you and your group an option for nearly all situations. Others may consider multiclassing into the Agent class if they are looking for some non combat utility.'),
	('Assassin', 'Single Target Damage', 'He has studied his target. He knows his moves, his ways, and his skills. There will be no escape. No one has ever escaped.', 'Nameless yet feared, you are known not by face but by the deeds you have performed. Countless victims you leave in your wake yet not one left alive to recall the story. Striking from the shadows you eliminate your foes before they have a chance to act. 

The Assassin class specializes in single target damage, eliminating single foes with ruthless efficiency. Utilizing a vast array of mobility and invisibility the Assassin can gain advantage over its opponents and eliminates by eliminating the targets who are hard to reach or vulnerable.

The assassin works best when working with your group to gain proper positioning to deal your most devastating attacks and to provide protection. Use your abilities to strike and escape before you gain the attention of the enemy.

Excellent damage class
Specializes in single target damage
Small weapon specialist
Also adds excellent mobility and survivability. 
Many abilities grant invisibility.'),
	('Bard', 'Support, Crowd Control', 'Music invigorates the spirit, strengthens the wavering man, and incites him to great and worthy deeds.', 'At the sound of your music the ebb and flow of battle are wrought. You have the power to turn chaos into order through your melodious hymn or turn order into chaos at the stroke of your chord. 

Through the power of your songcraft, the bard is capable of supporting and strengthening their allies by a variety of musical tunes. Or you can turn your music upon your enemies to disrupt them and weaken them greatly in the battle or even take them out of the fight completely. In and out of battle your group will find your music and abilities a great boon for many situations.

You rely greatly upon your allies though as your are vulnerable to attack but should your allies keep you protected they will find you a huge asset and capable of swinging a battle in one direction or the other.'),
	('Fighter', 'Damage, Tank', 'He cut through our lines effortlessly. There was no spear or arrow that could bring him down. It was as if he was immortal.', 'Stories and songs are written about your great deeds. Your ferocity and strength can direct the flow of battle and drive enemies into retreat. Wherever the thickest part of the battle can be found, so can you.

The fighter is a master of combat, capable of leaping into the fray and surviving to dish out a large amount of damage to all those around him with your high damaging weapons. While not the most proficient, you are also capable of tanking when necessary to protect your allies. The fighter class offers the options to fight longer and harder than most classes.

As a fighter your playstyle will be based around getting into the thick of a fight and using your abilities to damage as many enemies at a time. From time to time you may also assist in protecting the weaker members of your party with your taunt but do not be mistaken as your survivability is the least out of the tank classes.'),
	('General', 'Damage, Tank', 'Those who are victorious plan effectively and change decisively.', 'The battle unfolds under your fingertips as the pieces move around much like those of a game of chess. Alone your pieces are weak and vulnerable but together they can be greater than their individual selves. You will find victory within your grasp at the unfolding of your grand designs.

As a general you have many abilities which may impact the game board through the use of your allies. You may command your allies to make extra movement or grant additional attacks actions. Use these to better position your allies to take advantage of the enemies openings.

Furthermore the general may enter battle with various soldiers under your command to supplement your team in a variety of ways. A general will find themselves much appreciated by any team.'),
	('Guardian', 'Damage, Tank, Support', 'My steel unbendable. My will unbreakable.', 'You are the pillar upon which the group stands for around you the many wonders and skills of the group may flourish but without you they crumble into nothingness. 

The guardian is a defensive class who protects the other members of their party by standing as a shield for the weak. Your abilities revolve around controlling and moving about the battlefield and keeping enemies away from the more vulnerable members of your group and forced to face your unyielding self. Pushing, pulling, taunting are all within your arsonal to accomplish this goal.

While strong on the defensive end, guardians do not offer much in the way of offensive capabilities. You will rely more on keeping your allies safe so that they may fight to their full potential.'),
	('Hunter', 'Damage', 'Fegown! Fegown Crocket, king of the wild frontier!', 'Amongst a world full of strife you never find yourself alone. People lie, steal, and murder yet you have befriended those who are above such deceit. The wild beasts of the world are at your call and together you work as one to accomplish any goal you may require. 

As a hunter you find yourself with an arsenal of companions you may call to your side, each bringing a unique purpose to the table to help yourself and your party. Your skill at hunting and catching your enemies is unmatched and few can escape your grasp.

You will find your place in the group with great combat strength matched with the utilities that your pets can offer.'),
	('Marksman', 'Damage', 'A good marksman is not known by his weapon but by his aim.', 'Accuracy and Precision are your forte being able to eliminate threats before they may become a problem. From a distance you can affect the battlefield from the safety of your ranged weapon.

As a marksmen your role will be dedicated to eliminating key enemies who would be hard to reach by melee means. Whether it be a single foe or many you can eliminate them before they come in range to become a threat to the others in your party.'),
	('Paladin', 'Theron, Savior of the World', 'My choices are measured against my own soul. Not against the stains on theirs.', 'This is the call of the paladin: to protect the weak, to bring justice to the unjust, and to vanquish evil from the darkest corners of the world. These holy warriors are equipped with plate armor so they can confront the toughest of foes and empowered to heal the wounds of the fallen.

Paladin are a hybrid class capable of tanking, damaging, and healing, though do not excel in any of these areas compared to classes who specialize in one. Nonetheless, a paladin can fill in the gaps of any party to find an important purpose. Keep in mind what your party is lacking when you spend your specialization points to pick up the slack where it may be.'),
	('Priest', 'Caster, Support, Damage, Healer', 'I baked them cookies and they would not eat. I shouted encouragements and they would not listen. Now they will feel my wrath and I will bathe in their blood!', 'The following text is for the sake of Theron and Fegown helping me format this class. I’d like a full page dedicated to the introduction of this class, with a picture, a summary description, and maybe some flavor to go along with it. 
Healing Class
Many different kinds of heals for various situations

Damage option available by using your heals as combat abilities. 

The ultimate support class'),
	('Sorcerer', 'Damage, Stuff', 'I have a small cube like hat on my head. They will come to know my shame!', 'The following text is for the sake of Theron and Fegown helping me format this class. I’d like a full page dedicated to the introduction of this class, with a picture, a summary description, and maybe some flavor to go along with it. 
Heavy dps class
Disables on enemies
AoE powers
Focuses on the four elements
Wide area effects'),
	('Wizard', 'Damage', 'I don''t always cast spells but when I do I cast them.', 'The following text is for the sake of Theron and Fegown helping me format this class. I’d like a full page dedicated to the introduction of this class, with a picture, a summary description, and maybe some flavor to go along with it. 
Magical utility
Low damage output')
END
GO


/* HEROIC AWAKENINGS */
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'HEROICAWAKENINGS')
BEGIN
	CREATE TABLE HEROICAWAKENINGS
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		NAME nvarchar(max) NOT NULL,
		FLAVORTEXT nvarchar(max) NULL,
		DESCRIPTION nvarchar(max) NULL,
	);
END
GO


IF NOT EXISTS (SELECT 1 FROM HEROICAWAKENINGS)
BEGIN
	INSERT INTO HEROICAWAKENINGS (NAME, FLAVORTEXT, DESCRIPTION)
	VALUES
	('Chosen Champion', '', ''),
	('Elemental Avatar', '', ''),
	('Empowering Mind', '', ''),
	('Summoner''s Call', '', ''),
	('Tainted Blood', '', ''),
	('War Forge', '', '')
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


IF NOT EXISTS (SELECT 1 FROM POWERS)
BEGIN
	INSERT INTO POWERS (NAME, CATEGORY, POWERTYPE, ACTIONTYPE, EFFECTTYPE, RANGE, AURARANGE, DESCRIPTION, TIER, ACTIVE)
	VALUES
	('Charming', 1, 1, 0, 0, 0, 0, 'You gain proficiency in diplomacy.', 0, 1),
	('Child of Darkness', 1, 1, 0, 0, 0, 0, 'You gain darkvision.', 0, 1),
	('Child of Light', 1, 1, 0, 0, 0, 0, 'You may equip one additional blessing.', 0, 1),
	('Dark Omen', 1, 2, 3, 6, 0, 0, 'Cause the entire combat zone to be enshrouded in pitch blackness until the end of your next turn.', 0, 1),
	('Deathblow', 1, 2, 3, 2, 0, 0, 'Instantly kill a non-elite creature within range.', 0, 1),
	('Enduring', 1, 1, 0, 0, 0, 0, 'You gain proficiency in endurance.', 0, 1),
	('Fast Hands', 1, 2, 3, 2, 0, 0, 'You take an item within range that is within your reach and not equipped on a creature as if you made a successful thievery check against the item. You are not noticed when you use Fast Hands.', 0, 1),
	('Flexible', 1, 1, 0, 0, 0, 0, 'You gain +2 to every skill you are not proficient in.', 0, 1),
	('Haunting', 1, 2, 1, 1, 0, 0, 'While you are unconscious due to falling to 0 hit points or fewer during a Combat Encounter, you may continue combat like normal as a phantom spirit. Only the creature that dropped you to 0 hit points may see you, and you may only damage and interact with the same offending creature. 
You may not move beyond 20 squares of your physical body and the effect ends when you are revived or die.', 0, 1),
	('Herbalism', 1, 2, 4, 1, 0, 0, 'Regain 3 hit points.', 0, 1),
	('Heroism', 1, 2, 5, 1, 0, 0, 'Gain a Standard Action.', 0, 1),
	('Intimidating', 1, 1, 0, 0, 0, 0, 'You gain proficiency in intimidation.', 0, 1),
	('Mighty', 1, 1, 0, 0, 0, 0, 'You gain proficiency in athletics.', 0, 1),
	('Overpower', 1, 2, 1, 1, 0, 0, 'When you roll damage dice and dislike the result, you may reroll the damage dice and use either result. 
You may use Overpower twice per encounter.', 0, 1),
	('Perfection', 1, 2, 1, 1, 0, 0, 'When you roll to hit an elite creature and miss, you may cause yourself to automatically hit the creature instead of miss.', 0, 1),
	('Regenerative', 1, 1, 0, 0, 0, 0, 'You regain 1 hit point at the end of each of your turns during a combat encounter.', 0, 1),
	('Stubbornness', 1, 2, 1, 1, 0, 0, 'When you are afflicted with a negative effect (Slow, Immobilized, Mind Control, etc), immediately cause that effect to end. You may use this ability any time, even during an enemy''s turn.', 0, 1),
	('Sturdy', 1, 1, 0, 0, 0, 0, 'You gain +1 stamina and +2 hit points.', 0, 1),
	('Superior', 1, 1, 0, 0, 0, 0, 'You gain one additional specialization point.', 0, 1),
	('Thieving', 1, 1, 0, 0, 0, 0, 'You gain proficiency in thievery.', 0, 1),
	('Versatile', 1, 1, 0, 0, 0, 0, 'You are considered to have the Multiclass ability on your loadout. At Paragon level, you may choose Multiclass to gain access to a third class, or you may choose to gain Knighthood in either of the classes you gained from Versatile.', 0, 1),
	('Chloroform', 2, 2, 4, 2, 0, 0, 'Cause one creature within range to fall unconscious until the end of your next turn.', 1, 1),
	('Hand to Hand', 2, 2, 3, 2, 0, 0, 'Disarm a creature within range, removing their ability to use their Basic Attack or any ability that requires a weapon to use. In addition, you strike their windpipe, removing their ability to make any sound. Both of these effects last until the end of your next turn.', 1, 1),
	('Escape Plan', 2, 2, 4, 3, 0, 3, 'You and every willing ally within the aura may spend 1 Mana to successfully retreat to the place where you spent your last extended rest. If this place is more than 1 mile away, you instead travel two miles in that direction. 
This movement is unhindered and unchallenged and unfollowed, and takes the time it would take you to sprint the distance.', 1, 1),
	('Evasion', 2, 1, 0, 0, 0, 0, 'Once per round, when you would be hit by an attack or ability, you may roll a dice. If the result is even, then you negate the incoming damage and effects. 
Prerequisite: You must be wearing Leather Armor to use Evasion.', 1, 1),
	('Investigative Expertise', 2, 2, 4, 3, 0, 3, 'Within an area around you, dust for prints, pick up footprints, uncover hidden compartments, and gain truesight within the aura. If something can be found, you find it. 
To use Investigative Expertise, you require 10 minutes unmoved and uninterrupted. At the end of 5 minutes, Investigative Expertise is used.', 1, 1),
	('Leather Armor Specialization', 2, 4, 0, 0, 0, 0, 'You gain proficiency with Leather Armor.', 1, 1),
	('Preparedness', 2, 1, 0, 0, 0, 0, 'Twice per day, you may produce from your pack a common non-magical item weighing no more than 10lbs that you could have realistically acquired from any settlement you’ve visited. This item is unsellable. 
This item is not a magical conjuration, but a product of the fact that you are prepared with all the right materials for any situation you might encounter.', 1, 1),
	('Agent''s Finesse', 2, 1, 0, 0, 0, 0, 'Once per day, you may know beyond a shadow of a doubt whether a statement you’ve just heard was a lie.', 2, 1),
	('Flash Bang', 2, 2, 4, 1, 0, 0, 'Create a bright flash of light at your location, causing every enemy creature who can see you to become blinded until the end of your next turn. 
Blinded creatures suffer a -3 to hit.', 2, 1),
	('Knack for Success', 2, 2, 1, 1, 0, 0, 'When you fail a skill check, you may immediately reroll and use either result. 
You must spend 1 Mana when using Knack for Success.', 2, 1),
	('Network of Spies', 2, 1, 0, 0, 0, 0, 'You have underworld contacts in every settlement you’ve visited this campaign, and receive constant updates on current events, allowing you generally “know” the goings on of various civilizations and settlements across the land. Your information can be up to 3 days old depending on the distance.', 2, 1),
	('Professional''s Tools', 2, 1, 0, 0, 0, 0, 'You gain +5 Thievery for the sake of picking locks and disarming traps. In addition, this +5 bonus can also be applied to any check required to disable devices, constructs, or systems both technological or magical. 
You may not use Thieve’s Tools in conjunction with Professional’s Tools.', 2, 1),
	('Defection', 2, 2, 1, 4, 30, 0, 'Choose an enemy non-elite creature within range that you can see. For the duration of this encounter, it is under your control as if you’d Mind Controlled it.', 3, 1),
	('Exploit Weakness', 2, 2, 3, 2, 0, 0, 'Exploit the weaknesses of a target adjacent to you until the start of your next turn. While the target’s weaknesses are exploited, all damage made against it deals maximum damage.', 3, 1),
	('Sniper Support', 2, 2, 3, 4, 30, 0, 'Choose an enemy non-boss creature you can see. The creature is immediately killed by an unseen sniper. This may only be used in a combat encounter against hostile enemy combatants.', 3, 1),
	('Knight Excursor', 2, 5, 0, 0, 0, 0, 'Gain +1 to every Skill.', 4, 1),
	('Holy Weapon', 3, 3, 3, 1, 0, 0, 'You may use Holy Weapon after the end of an extended rest to gain your bound Holy Weapon until the end of your next extended rest. Your Holy Weapon can take the form any kind of non-small weapon you like. You may even choose to allow it become two weapons for the sake of dual wielding. 

The Holy Weapon is infused with the wisdom and personality of former saints and heroes who wielded it before you. It is a living being in the form of a weapon with a lawful good personality. The more you are worthy of wielding the Holy Weapon, the greater it’s power will be in your hands. You begin with 5 (Out of 10) Worthiness and at the end of each extended rest, the weapon will reassess you, and grant you anywhere between 3 and -3 Worthiness based on your deeds that day (at the DM’s discretion). It can range from 1 point for giving of your abundance to the poor to -3 points for killing an innocent man begging for his life. 

<strong>1-3 Worthiness:</strong> 1d6 Medium Weapon (1d8 Large) with Steadiness 1. 
<strong>4-6 Worthiness:</strong> 1d6 Medium Weapon (1d8 Large) with Steadiness 3. In addition, the weapon can shed bright light in a range of up to Aura 10 and be summoned to your hand from any location or made to fade away, hidden in an alternate plane of existence as a Minor Action. 
<strong>7-9 Worthiness:</strong> 1d8 Medium Weapon (1d10 Large) with Steadiness 4. In addition to the previous bonuses, you no longer need to spend Mana to use Holy Weapon and Empowered. 
<strong>10 Worthiness:</strong> 1d8 Medium Weapon (1d10 Large) with Steadiness 5. In addition to the previous bonuses, the light shed by your Holy Weapon will now deal 2 Damage to every enemy of supernatural origin within range (Fey, Vampires, Demons, Werewolves, ect). 

Holy Weapon cannot be improved or enhanced by gold or abilities (such as Blessed Weapon or Enchanted Weapon).', 0, 1)
END
GO


IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERSMAP')
BEGIN
	CREATE TABLE POWERSMAP
	(
		OBJECTID int NOT NULL,
		POWERID_FK int NOT NULL FOREIGN KEY REFERENCES POWERS(ID),
		CATEGORY int NOT NULL
	);
END
GO

IF NOT EXISTS (SELECT 1 FROM POWERSMAP)
BEGIN
	INSERT INTO POWERSMAP (OBJECTID, POWERID_FK, CATEGORY)
	VALUES
	(1, 3, 1),
	(1, 19, 1),
	(1, 15, 1),
	(2, 13, 1),
	(2, 18, 1),
	(2, 14, 1),
	(3, 6, 1),
	(3, 18, 1),
	(3, 17, 1),
	(4, 1, 1),
	(4, 3, 1),
	(4, 11, 1),
	(5, 2, 1),
	(5, 20, 1),
	(5, 7, 1),
	(6, 8, 1),
	(6, 21, 1),
	(6, 10, 1),
	(7, 2, 1),
	(7, 16, 1),
	(7, 9, 1),
	(8, 2, 1),
	(8, 19, 1),
	(8, 4, 1),
	(9, 12, 1),
	(9, 19, 1),
	(9, 5, 1),
	(1, 22, 2),
	(1, 23, 2),
	(1, 24, 2),
	(1, 25, 2),
	(1, 26, 2),
	(1, 27, 2),
	(1, 28, 2),
	(1, 29, 2),
	(1, 30, 2),
	(1, 31, 2),
	(1, 32, 2),
	(1, 33, 2),
	(1, 34, 2),
	(1, 35, 2),
	(1, 36, 2),
	(1, 37, 2),
	(1, 38, 3)
END
GO




/* POWER SPECIALIZATIONS */
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'POWERSPECIALIZATIONS')
BEGIN
	CREATE TABLE POWERSPECIALIZATIONS
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		POWERID_FK int NOT NULL FOREIGN KEY REFERENCES POWERS(ID),
		DESCRIPTION nvarchar(MAX),
	);
END
GO


IF NOT EXISTS (SELECT 1 FROM POWERSPECIALIZATIONS)
BEGIN
	INSERT INTO POWERSPECIALIZATIONS (POWERID_FK, DESCRIPTION)
	VALUES
	(22, 'If Chloroform is used outside of combat, the creature falls unconscious for an hour and does not see you use Chloroform.'),
	(22, 'You may use Chloroform twice per encounter.'),
	(23, 'When you use Hand to Hand, also knock the creature prone. You may use Hand to Hand one additional time per encounter.'),
	(23, 'You may use Hand to Hand as a Move or Minor Action.'),
	(24, 'Escape plan no longer requires Mana from your allies.'),
	(24, 'Escape plan is now an instant teleport, and no longer suffers the 1 mile limitation.'),
	(25, 'You may use Evasion one additional time per round.'),
	(25, 'You may use Evasion one additional time per round.'),
	(26, 'Increase the size to Aura 5.'),
	(26, 'Reduce the time required to 1 minutes.'),
	(27, 'Gain +1 Speed while wearing Leather Armor.'),
	(27, 'Gain +2 Stealth while wearing Leather Armor.'),
	(28, 'You may use Preparedness four times per day.'),
	(28, 'Increase the weight limitation to 20lbs. In addition, you gain the ability to create on the fly forgeries and other fake documentation and disguises with Preparedness, as if you had researched the people and cultures you were going to encounter today several weeks ago.')
END
GO