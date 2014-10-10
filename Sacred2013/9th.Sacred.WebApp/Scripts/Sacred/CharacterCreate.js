/* GLOBAL VARS */
var _selectedRaceDiv;
var _selectedRaceLink;
var _selectedClassDiv;
var _selectedClassLink;

var sRACE = 0;
var sCLASS = 0;




/* DOCUMENT READY */
$(function () {
    _selectedRaceLink = $(".race-picker-wrapper").find("a.race-selected");
    _selectedRaceDiv = $(".js-race-showing-div");

    _selectedClassLink = $(".class-picker-wrapper").find("a.class-selected");
    _selectedClassDiv = $(".js-class-showing-div");
});




/* EVENTS */
$(document).on("click", ".js-race-picker-button", function () {
    var raceId = $(this).data("race-id");
    
    // Hide old selection
    $(_selectedRaceDiv).addClass("hidden");
    $(_selectedRaceLink).removeClass("race-selected");
    _selectedRaceLink = $(this);

    // Get and show new selection
    _selectedRaceDiv = $("#" + raceId);
    $(_selectedRaceDiv).removeClass("hidden");
    $(_selectedRaceLink).addClass("race-selected");

    return false;
});

$(document).on("click", ".js-race-next-button", function () {
    sRACE = $(_selectedRaceDiv).data("raw-race-id");
    $("#CreateRace").val(sRACE);

    $("#CharacterCreateForm").submit();
});

$(document).on("click", ".js-class-picker-button", function () {
    var classId = $(this).data("class-id");

    // Hide old selection
    $(_selectedClassDiv).addClass("hidden");
    $(_selectedClassLink).removeClass("class-selected");
    _selectedClassLink = $(this);

    // Get and show new selection
    _selectedClassDiv = $("#" + classId);
    $(_selectedClassDiv).removeClass("hidden");
    $(_selectedClassLink).addClass("class-selected");

    return false;
});