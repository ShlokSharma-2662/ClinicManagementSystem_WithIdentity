$(document).ready(function () {
    PrescriptionDataTableFill("", "");
});

function PrescriptionDataTableFill(orderby, whereclause) {

    $.ajax({
        type: "GET",
        url: "/Prescription/ViewPrescription",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            $("#tblP1 tbody").empty();
            for (var i = 0; i < response.data.length; i++) {
                var tr_str = '';
                tr_str = "<tr class='datatable-row' id=" + response.data[i]["pres_id"] + ">" +
                    "<td class='datetable-cell'><span style='width:100px'>" + (i + 1) + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:100px'>" + response.data[i]["createdAt"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:70px'>" + response.data[i]["pid"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["p_FName"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["p_LName"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["medicine_name"] + "</span></td>" +
                    "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["quantity"] + "</span></td>" +                    
                    "</tr>";
                $("#tblP1 tbody").append(tr_str);
            }
        },
        error: function () {
            alert("UnExpected error occured sorry for inconvinience!!!");
        }
    });
}