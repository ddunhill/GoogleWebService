google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

    var googleTimeData = google.visualization.arrayToDataTable(timeData);
    var googleDistData = google.visualization.arrayToDataTable(distData);

    var timeOptions = {
        chart: {
            title: 'Race Times',
            subtitle: 'Hours'
        },
        bars: 'vertical',
        vAxis: { format: 'decimal' },
        height: 400,
        colors: ['#00cc99', '#0066cc', '#ff00ff']
    };

    var distOptions = {
        chart: {
            title: 'Race Distances',
            subtitle: 'Swin, Bike and Run in km'
        },
        bars: 'vertical',
        vAxis: { format: 'decimal' },
        height: 400,
        colors: ['#00cc99', '#0066cc', '#ff00ff']
    };

    var timeChart = new google.charts.Bar(document.getElementById('timeChart_div'));

    timeChart.draw(googleTimeData, google.charts.Bar.convertOptions(timeOptions));

    var distChart = new google.charts.Bar(document.getElementById('distChart_div'));

    distChart.draw(googleDistData, google.charts.Bar.convertOptions(distOptions));
}