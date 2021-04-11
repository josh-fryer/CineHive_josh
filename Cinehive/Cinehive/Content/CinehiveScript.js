function validateForm() {
    var x = document.forms["createPost"]["input"].value;
    if (x == "") { // if post text area is empty then do not submit
        alert("Post cannnot be empty!");
        return false;
    }
}

// ############### Char Remaining Counter ##################
const textArea = document.getElementById("postInput");
const remainngCharsText = document.getElementById("remaining-chars");
var maxLength = textArea.getAttribute("maxlength");
remainngCharsText.textContent = "280 characters remaining";
textArea.addEventListener("input", () => {

    const remaining = maxLength - textArea.value.length;
    remainngCharsText.textContent = `${remaining} characters remaining`;
});
// ###########################################################