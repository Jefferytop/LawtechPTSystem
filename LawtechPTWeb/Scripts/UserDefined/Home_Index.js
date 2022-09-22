$(document).ready(function () {

    var basicdoughnutChart = echarts.init(document.getElementById('basicDoughnut'));
    basicdoughnutChart.showLoading();  // 开启 loading 效果
    $.get('/PatentInfo/GetPatentStatusStatistics', function (data1) {   
    var option = {
        // Add title
        title: {
            text: '專利案件階段統計',
            subtext: '統計各案件階段的案件量',
            x: 'left',
            y: 'top'
        },
         
        // Enable drag recalculate
        calculable: true,

        // Add series
        series: [
            {
                name: 'Browsers',
                type: 'pie',
                radius: ['50%', '70%'],
                center: ['50%', '57.5%'],
                itemStyle: {
                    normal: {
                        label: {
                            show: true
                        },
                        labelLine: {
                            show: true
                        }
                    },
                    emphasis: {
                        label: {
                            show: true,
                            formatter: '{b}' + '\n\n' + '{c} ({d}%)',
                            position: 'center',
                            textStyle: {
                                fontSize: '17',
                                fontWeight: '500'
                            }
                        }
                    }
                },

                data: data1
                
            }
        ]
    };

    basicdoughnutChart.setOption(option);
    basicdoughnutChart.hideLoading();  // 隐藏 loading 效果
    });
});

