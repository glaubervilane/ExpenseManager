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
function LoadDataTotalExpenses() {
    $.ajax({
        url: 'Expenses/TotalExpenses',
        method: 'POST',
        success: function (data) {
            new Chart(document.getElementById("ChartTotalExpenses"), {
                type: 'line',

                data: {
                    labels: GetMonth(data),

                    datasets: [{
                        label: "Total Expense",
                        data: GetValues(data),
                        backgroundColor: "#ecf0f1",
                        borderColor: "#2980b9",
                        fill: false,
                        spanGaps: false
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: "Total Expense"
                    }
                }
            });
        }
    });
}
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
function GetValues(data) {
    var values = [];
    var size = data.length;
    var index = 0;

    while (index < size) {
        values.push(data[index].values);
        index++;
    }

    return values;
}

function GetTypesOfExpenses(data) {

    var labels = [];
    var size = data.length;
    var index = 0;

    while (index < size) {
        labels.push(data[index].expenseType);
        index++;
    }

    return labels;
}

function GetMonth(data) {
    var labels = [];
    var size = data.length;
    var index = 0;
    while (index < size) {
        labels.push(data[index].nameMonths[0]);
        index++;
    }

    return labels;
}

function PickColors(quantity) {
    var colors = [];

    while (quantity > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        colors.push("rgb(" + r + ", " + g + "," + b + ")");

        quantity--;
    }
    return colors;
}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.