// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function confirmDelete() {
    var confirmed = confirm("Are you sure you want to delete this entry?");
    if (confirmed) {
        // User confirmed, submit the form
        document.getElementById("delete-form").submit();
    } else {
        // User canceled, do nothing
        return false;
    }
}

function confirmEdit() {
    var confirmed = confirm("Are you sure you'd like to submit these changes?");
    if (confirmed) {
        // User confirmed, submit the form
        document.getElementById("edit-form").submit();
    } else {
        // User canceled, do nothing
        return false;
    }
}

function commenceEdit() {
    var confirmed = confirm("Are you sure you'd like to edit this entry?");
    if (confirmed) {
        // User confirmed, submit the form
        document.getElementById("edit-form").submit();
    } else {
        // User canceled, do nothing
        return false;
    }
}