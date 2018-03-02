google.charts.load('current', { 'packages': ['corechart', 'bar'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    var googleTimeData = google.visualization.arrayToDataTable(timeData);
    var googleDistData = google.visualization.arrayToDataTable(distData);

    var timeOptions = {
        chart: {
            title: 'Race Times',
            subtitle: 'in minutes'
        },
        bars: 'vertical',
        vAxis: { format: 'decimal' },
        height: 400,
        colors: ['#00cc99', '#0066cc', '#ff00ff']
    };

    var distOptions = {
        legend: { position: 'top', maxLines: 3 },
        bars: { groupWidth: '25%' },
        width: 1600,
        height: 600,
        bars: 'horizontal',
        isStacked: true, series: {
            0: { color: '#00cc99' },
            1: { color: '#0066cc' },
            2: { color: '#ff00ff' }
        }
    };

    var timeChart = new google.charts.Bar(document.getElementById('timeChart_div'));

    timeChart.draw(googleTimeData, google.charts.Bar.convertOptions(timeOptions));

    var distChart = new google.charts.Bar(document.getElementById('distChart_div'));

    distChart.draw(googleDistData, google.charts.Bar.convertOptions(distOptions));
}