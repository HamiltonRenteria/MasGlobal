var counterC = 0, anualSalary = 0;
$(document).ready(function () {
    $("#btnSearchEmployees").click(function (e) {
        var IdEmployee = $("#idEmployee").val();
        if (IdEmployee === '') {
            $.ajax({
                url: '/Employees/searchEmployees',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json; charset=utf-8',
                //data: '{IdEmployee:' + IdEmployee + ' }',
                success: function (data) {
                    $("#dynamictable").css('display', '');
                    $("#dynamictable > tbody").empty();
                    var newRow = $("<tr id='result'>");
                    var cols = "";
                    debugger;
                    if (data.length > 0) {
                        debugger;
                        $.each(data, function (i, turno) {
                            if (turno.contractTypeName == 'MonthlySalaryEmployee') {
                                anualSalary = turno.monthlySalary * 12
                            } else if (turno.contractTypeName == 'HourlySalaryEmployee') {
                                anualSalary = 120 * turno.hourlySalary * 12
                            }

                            counterC++;
                            debugger;
                            cols += '<td>' + turno.name + '</td>';
                            cols += '<td>' + turno.contractTypeName + '</td>';
                            cols += '<td>' + turno.roleId + '</td>';
                            cols += '<td>' + turno.roleName + '</td>';
                            cols += '<td>' + turno.roleDescription + '</td>';
                            cols += '<td>' + turno.hourlySalary + '</td>';
                            cols += '<td>' + turno.monthlySalary + '</td>';
                            cols += '<td>' + anualSalary + '</td>';

                            newRow.append(cols);
                            $("#dynamictable").append(newRow);
                        });

                    } else {
                        alert('Mensaje de error');
                    }

                    debugger;
                },
                error: function (errorThrown) {
                    console.log(errorThrown);
                }
            });
        } else {
            $.ajax({
                url: '/Employees/searchEmployees',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json; charset=utf-8',
                data: '{IdEmployee:' + IdEmployee + ' }',
                success: function (data) {
                    $("#dynamictable").css('display', '');
                    $("#dynamictable > tbody").empty();
                    var newRow = $("<tr id='result'>");
                    var cols = "";
                    debugger;
                    if (data.length > 0) {
                        debugger;
                        $.each(data, function (i, turno) {
                            if (turno.contractTypeName == 'MonthlySalaryEmployee') {
                                anualSalary = turno.monthlySalary * 12
                            } else if (turno.contractTypeName == 'HourlySalaryEmployee') {
                                anualSalary = 120 * turno.hourlySalary * 12
                            }

                            counterC++;
                            debugger;
                            cols += '<td>' + turno.name + '</td>';
                            cols += '<td>' + turno.contractTypeName + '</td>';
                            cols += '<td>' + turno.roleId + '</td>';
                            cols += '<td>' + turno.roleName + '</td>';
                            cols += '<td>' + turno.roleDescription + '</td>';
                            cols += '<td>' + turno.hourlySalary + '</td>';
                            cols += '<td>' + turno.monthlySalary + '</td>';
                            cols += '<td>' + anualSalary + '</td>';

                            newRow.append(cols);
                            $("#dynamictable").append(newRow);
                        });

                    } else {
                        alert('Mensaje de error');
                    }

                    debugger;
                },
                error: function (errorThrown) {
                    console.log(errorThrown);
                }
            });
        }
    });
});