// CONTROLLER: sacred.core.js - COPYRIGHT TYLER BOETTCHER 2014
//==========================================================================================

// VARIABLES --------------------------------------------------------
var site_domain;
var site_baseurl;
var api_baseurl;

var SITE_URL;
var API_URL;
var SACRED_COOKIE;


// ENUMS -----------------------------------------------------------
var PowerCategory = {
    Race: 1,
    Class: 2,
    Heroic: 3
};

var PowerType = {
    Passive: 1,
    Encounter: 2,
    Mana: 3,
    Armor: 4,
    Paragon: 5
};

var ActionType = {
    None: 0,
    Free: 1,
    Move: 2,
    Major: 3,
    Minor: 4,
    MoveOrMinor: 5
};

var EffectType = {
    None: 0,
    Personal: 1,
    MeleeTouch: 2,
    Aura: 3,
    Range: 4,
    WeaponRange: 5,
    CombatZone: 6,
    CompanionRange: 7
};