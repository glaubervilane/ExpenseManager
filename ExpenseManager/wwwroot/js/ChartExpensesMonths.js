$(".chooseMonth").on('change', function () {
    var monthId = $(".chooseMonth").val();

    $.ajax({
        url: "Expenses/MonthExpense",
        method: "POST",
        data: { monthId: monthId },
        success: function (data) {
            $("canvas#ChartExpensesMonths").remove();
            $("div.ChartExpensesMonths").append('<canvas id="ChartExpensesMonths" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('ChartExpensesMonths').getContext('2d');

            var graph = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: GetTypesOfExpenses(data),
                    datasets: [
                        {
                            label: "Expenses by Expense",
                            backgroundColor: PickColors(data.length),
                            hoverBackgroundColor: PickColors(data.length),
                            data: GetValues(data)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Expenses by Expense"
                    }
                }
            });
        }
    });
});


function LoadSpendingDataMonths() {
    var monthId = $(".chooseMonth").val();

    $.ajax({
        url: "Expenses/MonthExpense",
        method: "POST",
        data: { monthId: monthId },
        success: function (data) {
            $("canvas#ChartExpensesMonths").remove();
            $("div.ChartExpensesMonths").append('<canvas id="ChartExpensesMonths" style="height:400px;width:400px;"></canvas>');

            var ctx = document.getElementById('ChartExpensesMonths').getContext('2d');

            var graph = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: GetTypesOfExpenses(data),
                    datasets: [
                        {
                            label: "Expenses by Expense",
                            backgroundColor: PickColors(data.length),
                            hoverBackgroundColor: PickColors(data.length),
                            data: GetValues(data)
                        }
                    ]
                },
                options: {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Expenses by Expense"
                    }
                }
            });
        }
    });
};