function validateForm() {
    var x = document.forms["createPost"]["input"].value;
    if (x == "") { // if post text area is empty then do not submit
        alert("Post cannnot be empty!");
        return false;
    }
}


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
