// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function calculate() {
    let calcParams = {
        rule: $('#rule').val(),
        dieCount: $('#dieCount').val(),
        dieType: $('#dieType').val(),
        targetCount: $('#targetCount').val(),
        targetValue: $('#targetValue').val()
    };
    console.log("params", calcParams);
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/calculator/calculate",
        dataType: "json",
        data: JSON.stringify(calcParams),
        success: function (response) {
            $('#probabilityResult').val(response.probabilityPcnt);
            console.log(response);
        },
        error: function (err) {}
    });
    //$.post("/calculator/calculate", JSON.stringify(params))
    //    .done(function (data) {
    //        console.log(data);
    //    })
    //    .fail(function (f, e) {
    //        console.log(f);
    //        console.log(e);
    //    })
}