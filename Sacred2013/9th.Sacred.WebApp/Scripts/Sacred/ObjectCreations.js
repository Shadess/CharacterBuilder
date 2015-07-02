// ADMIN OBJECTS --------------------------------------------------------------
function SacredRace() {
    var self = this;

    self.Id = 0;
    self.Name = '';
    self.CommonName = '';
    self.Lifespan = '';
    self.Height = '';
    self.Origin = 'Human';
    self.SocialStatus = 'Very High';
    self.FlavorText = '';
    self.Description = '';

    self.RacePowers = [];
}

function SacredRacePower() {
    var self = this;

    self.Id = 0;
    self.RaceId = 0;
    self.Name = '';
    self.Description = '';

    //public Attributes Attributes { get; set; }
}