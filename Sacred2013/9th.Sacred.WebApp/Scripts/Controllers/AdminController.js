var AdminController = function () {
    this.tab = 1;

    this.selectTab = function (value) {
        this.tab = value;
    };

    this.isSelected = function (checkTab) {
        return this.tab === checkTab;
    };
};

AdminController.$inject = [];