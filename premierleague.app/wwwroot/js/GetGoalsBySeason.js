var Labels = [];
var DataSets = [];
var HomeGoals = [];
var AwayGoals = [];
var Model = modelData;
console.log(modelData);
if (Model != null && Model.length > 0) {
    Model.forEach(item => {
        Labels.push(item.season)
        DataSets.push(item.totalgoals)
        HomeGoals.push(item.homegoals)
        AwayGoals.push(item.awaygoals)
    });
}
$(function () {
    //populating graph 1
    var ctx = document.getElementById('myChart2').getContext('2d');
    var myChart2 = new Chart(ctx, {
        type: 'line',
        data: {
            labels: Labels,
            datasets: [{
                label: 'Goals',
                data: DataSets,
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                fill: true,
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    title: {
                        display: true,
                        text: 'No. Of Goals Scored'
                    },
                    beginAtZero: true
                },
                x: {
                    title: {
                        display: true,
                        text: 'Year'
                    },
                    beginAtZero: true
                }
            }
        }
    });
});
$(function () {
    //populating graph 1
    var ctx = document.getElementById('myChart3').getContext('2d');
    var myChart3 = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: Labels,
            datasets: [{
                label: 'Home Team Goals',
                data: HomeGoals,
                //borderColor: 'rgba(75, 192, 192, 1)',
                //backgroundColor: 'rgba(75, 192, 192, 0.2)',
                fillColor: 'blue',
                //borderWidth: 2
            },
                {
                    label: 'Away Team Goals',
                    data: AwayGoals,
                    //borderColor: 'rgba(75, 192, 192, 1)',
                    //backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    fillColor: false,
                    //borderWidth: 2
                }]
        },
        options: {
            barValueSpacing: 20,
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    title: {
                        display: true,
                        text: 'No. Of Goals Scored'
                    },
                    beginAtZero: true,
                    ticks: {
                        min: 0,
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Year'
                    },
                    beginAtZero: true
                }
            }
        }
    });
});