$(document).ready(function () {
    sideNav.style.transform = "translateX(0%)";
 
    $("#searchContent").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".taskList *").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});
var scr = document.getElementById("icon1");
var sideNav = document.getElementById("listBox")
var addList = document.getElementById("AddNew")
var listName = document.getElementById("newAdd")
var mainDiv = document.getElementById("main2")

scr.addEventListener("click", function () {
    if (sideNav.style.transform == "translateX(0%)") {
        sideNav.style.transform = "translateX(-100%)"
    }
    else {
        sideNav.style.transform = "translateX(0%)"
    }
});

var d = new Date()
var f = document.getElementsByClassName("footer")[0]
f.innerHTML = "	&#169;" + d.getFullYear()