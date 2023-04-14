// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function (event) {

    function confirmDelete() {
        var confirmed = confirm("Are you sure you want to delete this entry?");
        if (confirmed) {
            // User confirmed, submit the form
            document.getElementById("delete-form").submit();
        } else {
            // User canceled, do nothing
            event.preventDefault();
            return false;
        }
    }

    document.getElementById("delete-button").addEventListener("click", confirmDelete);

    function commenceEdit() {
        var confirmed = confirm("Are you sure you'd like to edit this entry?");
        if (confirmed) {
            // User confirmed, submit the form
            document.getElementById("edit-form").submit();
        } else {
            // User canceled, do nothing
            event.preventDefault();
            return false;
        }
    }

    document.getElementById("start-edit").addEventListener("click", commenceEdit);

   

});




 document.getElementById("predict").addEventListener("click", predictValue);


    function predictValue() {
        var sex = document.getElementById("sex").value;
        var ageatdeath = document.getElementById("ageatdeath").value;
        var adultsubadult = document.getElementById("adultsubadult").value;
        var headdirection = document.getElementById("headdirection").value;
        var haircolor = document.getElementById("haircolor").value;
        var preservation = document.getElementById("preservation").value;
        var goods = document.getElementById("goods").value;
        var depth = document.getElementById("depth").value;
        var length = document.getElementById("length").value;

        depth = parseFloat(depth);
        var prediction = ""

        if (depth < .75) {
            prediction = "Full or nearly full wrapping remains"
        }

        else if (depth < 1.3) {
            prediction = "Partial wrapping remains"
        }

        else if (depth < 4) {
            prediction = "Bones and/or only partial remnants of wrapping remains"
        }

        else {
            prediction = "Unknown"
        }

        document.getElementById("predictedValue").innerHTML = (prediction);
    }

    