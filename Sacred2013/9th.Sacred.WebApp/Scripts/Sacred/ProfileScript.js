$(document).on("click", ".js-campaign-remove", function () {
    var campaignid = $(this).data('campaign-id');
    var $campaignDiv = $(this).parents(".campaign-summary");

    $.ajax({
        url: site_baseurl + '/Campaign/Delete',
        type: 'GET',
        async: true,
        traditional: true,
        data: { id: campaignid },
        success: function (data) {
            if (data)
            {
                // Slide up and hide the campaign div
                $($campaignDiv).slideUp("500");
            }
        },
        error: function (obj, status, error) {
            console.log(error);
        }
    });
});