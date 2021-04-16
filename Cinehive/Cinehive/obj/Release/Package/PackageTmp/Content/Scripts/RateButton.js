'use strict';

function FillStar(star) {
    console.log("button clicked: star" + star)
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const newStar = (<i id="star2" class="glyphicon glyphicon-star-empty"></i>);
            ReactDOM.render(newStar, document.getElementById('star' + star));
    };
    xhttp.open("GET", "https://localhost:44383/Movie/RateMovie?movieApiID=" + Model.MovieApi_ID.ToString() + "&stars="+star, true);
    console.log(xhttp);
    xhttp.send();

}
