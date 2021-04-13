function validateForm() {
    var x = document.forms["createPost"]["input"].value;
    if (x == "") {
        // if post text area is empty then do not submit
        alert("Post cannnot be empty!");
        return false;
    }
}

// ############### Char Remaining Counter ##################
var textArea = document.getElementById("postInput");
var remainngCharsText = document.getElementById("remaining-chars");
var maxLength = textArea.getAttribute("maxlength");
remainngCharsText.textContent = "280 characters remaining";
textArea.addEventListener("input", function () {

    var remaining = maxLength - textArea.value.length;
    remainngCharsText.textContent = remaining + " characters remaining";
});
// ###########################################################

// ################ Show/hide div ############################

//function showHide(id) {
//    var x = document.getElementById(id);

//    if (x.style.display
//        === "block") {
//        x.style.display = "none";
//    } else {
//        x.style.display =
//            "block";
//    }
//};
//###############################################################