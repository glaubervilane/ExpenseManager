$(".chooseMonth").on('change', function () {
    var monthId = $(".chooseMonth").val();

    $.ajax({
        url: "Expenses/TotalSpendingMonths",
        method: "POST",
        data: { monthId: monthId },
        success: function (data) {
            $("canvas#ChartCostTotalMonths").remove();
            $("div.ChartCostTotalMonths").append('<canvas id="ChartCostTotalMonths" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('ChartCostTotalMonths').getContext('2d');

            var graph = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Remaining', 'Total Spent'],
                    datasets: [
                        {
                            label: "Total Spent",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(data.salary - data.amountTotalExpenditure), data.amountTotalExpenditure]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total Spent in the Month"
                    }
                }
            });
        }
    });
});


function LoadDataTotalExpenditureMonths() {

    $.ajax({
        url: "Expenses/TotalSpendingMonths",
        method: "POST",
        data: { monthId: 1 },
        success: function (data) {
            $("canvas#ChartCostTotalMonths").remove();
            $("div.ChartCostTotalMonths").append('<canvas id="ChartCostTotalMonths" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('ChartCostTotalMonths').getContext('2d');

            var graph = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Remaining', 'Total Spent'],
                    datasets: [
                        {
                            label: "Total Spent",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(data.salary - data.amountTotalExpenditure), data.amountTotalExpenditure]
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total Spent in the Month"
                    }
                }
            });
        }
    });
}