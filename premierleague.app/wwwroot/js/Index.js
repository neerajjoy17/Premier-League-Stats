$(document).ready(function () {
    // Fetch the chart data from the custom GetChartData method
    $.ajax({
        url: 'Home/GetGoalsBySeason',  // URL of the custom action
        type: 'GET',
        success: function (data) {
            // Inject the chart into the chartContainer div
            $('#chartContainer').html(data);
        },
        error: function () {
            alert("Error loading chart data.");
        }
    });
});