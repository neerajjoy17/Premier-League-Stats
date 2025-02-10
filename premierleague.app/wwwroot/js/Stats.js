var Labels = [];
var DataSets = [];
var HomeGoals = [];
var AwayGoals = [];
var Model = modelData;
console.log(modelData);
if (Model != null && Model.length > 0) {
    Model.forEach(item => {
        if (item.Name == 'Arsenal') {
            Labels.push('HomeWins', 'HomeDraws', 'HomeLoss', 'AwayWins', 'AwayDraws', 'AwayLosses')
            DataSets.push(item.HomeWins, item.HomeDraws, item.HomeLosses, item.AwayWins, item.AwayDraws, item.AwayLosses)
        }
    });
}
console.log(Labels)
console.log(DataSets)
$(function () {
    //populating graph 1
    var ctx = document.getElementById('myChart2').getContext('2d');
    var myChart2 = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: Labels,
            datasets: [{
                label: 'Arsenal - Win, Draw, Loss Distribution',
                data: DataSets,
                backgroundColor: ['rgba(128,0,0,0.8)', 'rgba(0,0,0,0.7)', 'rgba(0,0,255,0.7)', 'rgb(255,0,0,0.8)', 'rgba(0,128,128,0.7)', 'rgba(128,128,0,0.7)'],
                hoverOffset : 4
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
});