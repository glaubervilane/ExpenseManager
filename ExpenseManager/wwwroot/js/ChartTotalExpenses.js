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