
function saveUser() {
    var name = $("#name").val();
    var type = $('input[name=type]:checked').val();
    var isFull = type == "full" ? true : false;
    var salary = isFull ? $("#inputSalary").val() : 0;
    var hourly = isFull ? 0 : $("#inputHourly").val();
    emp = {
        Name: name,
        isFullTime: isFull,
        Salary: salary,
        Hourly: hourly
    }

    $.ajax({
        url: "Employees/Create",
        data: JSON.stringify(emp),
        type: 'POST',
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (response) {
            alert(response.responseText);
            document.location.href = "/";
        },
        error: function (xhr, status, error) {
            alert("Error");
        }
    });
}

function showInputSalary() {
    $("#divHourly").hide();
    $("#divSalary").show();
}

function showInputHourly() {
    $("#divSalary").hide();
    $("#divHourly").show();
}
