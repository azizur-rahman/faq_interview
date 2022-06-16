function drawLineChart(data, elementId) {
    var intervals = $('#' + elementId).data('intervals');

    var options = {
        title: '',
        backgroundColor: {
            fill: 'transparent'
        },
        chartArea: {
            backgroundColor: {
                fill: '#ffffff',
                stroke: '#cccccc',
                strokeWidth: 1
            },
            stroke: '#cccccc',
            strokeWidth: 1
        },
        hAxis: {
            title: 'Intervals',
            viewWindow: { min: 0, max: intervals },
            titleTextStyle: {
                color: '#333',
                italic: false
            }
        },
        vAxis: {
            title: '% MAX Heart Rate',
            minValue: 0,
            viewWindow: { min: 0, max: 100 },
            titleTextStyle: {
                color: '#333',
                italic: false
            },
            gridlines: {
                color: '#cccccc'
            },
            ticks: [{ v: 85, f: '85%' }, { v: 100, f: 'MAX' }]
        },
        series: {
            0: { lineWidth: 1, color: '#d89000', pointSize: 6, pointShape: { type: 'round' } }
        },
        tooltip: { isHtml: true }
    };

    var chart = new google.visualization.LineChart(document.getElementById(elementId));

    chart.draw(data, options);
}