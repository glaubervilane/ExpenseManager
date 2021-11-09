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