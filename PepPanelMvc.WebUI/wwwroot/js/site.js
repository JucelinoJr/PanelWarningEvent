// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#searchBarMed").keyup(function () {
    $(".rowMed").hide();
    var term = $(this).val();
    $(".rowMed:contains('" + term + "')").show();
});

$("#searchBarAss").keyup(function () {
    $(".rowAss").hide();
    var term = $(this).val();
    $(".rowAss:contains('" + term + "')").show();
});