// ############### Char Remaining Counter ##################
const textArea = document.getElementById("postInput");
const remainngCharsText = document.getElementById("remaining-chars");
var maxLength = textArea.getAttribute("maxlength");
remainngCharsText.textContent = "280 characters remaining";
textArea.addEventListener("input", () => {

    const remaining = maxLength - textArea.value.length;
    remainngCharsText.textContent = `${remaining} characters remaining`;
});