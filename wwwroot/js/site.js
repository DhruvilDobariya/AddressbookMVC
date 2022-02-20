// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

switch (window.location.pathname.split("/")[1]) {
    case "Home":
        document.getElementById("nav-items").children[0].children[0].classList.add("active");
        break;
    case "Country":
        document.getElementById("nav-items").children[1].children[0].classList.add("active");
        break;
    case "State":
        document.getElementById("nav-items").children[2].children[0].classList.add("active");
        break;
    default:
        document.getElementById("nav-items").children[0].children[0].classList.add("active");
}

$(document).ready(function () {
    $('#table').DataTable();
});