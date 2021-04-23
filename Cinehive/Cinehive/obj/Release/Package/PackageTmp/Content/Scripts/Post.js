// divId, profileId, firstName, lastName, imagePath
//@Url.Action("ViewProfile", "Profile", new { id = ${profileId} })
function returnPost(divId, profileId, postId, firstName, lastName, imagePath, datePosted,
     isPopular, awards, awardGiven, isUserPostOrAdimin, commentsCount) {
    var postImage = `<div class="media-left"><a href="/Profile/ViewProfile/${profileId}">`;
        if (imagePath == null || imagePath == "")
        {
            postImage += `<img class="post-profile-img circular-image" src="/Content/Img/profile-image-placeholder.png" width="64" height="64" />`;
        }
        else
        {
           postImage += `<img class="post-profile-img circular-image" src="/${imagePath}" width="64" height="64" />`;
        }
    postImage +=`</a></div>`;

    var postHeading = `<h4 class="media-heading post-heading"><a href="/Profile/ViewProfile/${profileId}">${firstName} ${lastName}</a>
   <span class="datePosted"><small>${datePosted}</small></span></h4>`;          
    // -- post content goes here in View --

    var postAwards = `<ul class="list-inline list-unstyled">`;                
            if (isPopular == true)
            {
                postAwards += `<li><strong>Popular</strong></li>`;
            }
            postAwards += `</ul>`;

    var postButtons =         
        `<ul class="list-inline list-unstyled post-buttons">`;
            if (awardGiven)
            {
                postButtons += `<li>
                <strong><a onclick="Award(${postId}, ${awardGiven})"><img id="awardImg_${postId}" src="/Content/Img/SiteImg/oscar_filled_crop.png" height="46"/></a>
                <span id="awardsBadge_${postId}" class="badge">${awards}</span></strong>
                </li>`;
            }
            else
            {
               postButtons += `<li><a onclick="Award(${postId}, ${awardGiven})">
               <img id="awardImg_${postId}" src="/Content/Img/SiteImg/oscar_empty_crop.png" height="46"/>
               </a><span id="awardsBadge_${postId}" class="badge">${awards}</span></li>`;
            }
            postButtons += `
            <li><a href="/Comment/Create/${postId}"><span class="glyphicon glyphicon-comment"></span> Comment</a></li>
            
            <li><button type="button" class="comment-button" id="post-${postId}" name="Comment">
            <img src="/Content/Img/SiteImg/chat.png" width="24"/></button> <span class="badge">${commentsCount}</span> </li>
                 
            <li><a href="/Post/SharePost/${postId}"><span class="glyphicon glyphicon-share-alt"></span> Share</a></li>`;

            if (isUserPostOrAdimin)
            {
               postButtons += `
                <li><a href="/Post/DeletePost/${postId}"><span class="glyphicon glyphicon-trash"></span></a></li>
                
                <li> <a href="/Post/EditPost/${postId}"><span class="glyphicon glyphicon-edit"></span></a> </li>`;
            }
        postButtons += `</ul>`;

    document.getElementById(divId+"_1").insertAdjacentHTML("afterbegin", postImage); // insert as first child of div
    document.getElementById(divId+"_2").insertAdjacentHTML("afterbegin", postHeading ); 
    document.getElementById(divId+"_3").insertAdjacentHTML("afterend", (postAwards + postButtons)); // insert after </div>
}

function Award(postID) {
    console.log("award clicked");

    var awardIcon = document.getElementById("awardImg_"+postID);
    console.log("awardIcon src = " + awardIcon.getAttribute("src"));
    var url = "";
    var xhttp;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {              
            if(awardIcon.getAttribute("src") == "/Content/Img/SiteImg/oscar_filled_crop.png")
            {
                // award has been revoked so do this:
                console.log("iconimg = " + awardIcon.getAttribute("src"))
                awardIcon.setAttribute("src", "/Content/Img/SiteImg/oscar_empty_crop.png");
                UpdateAwardsCount(postID, "take");
            }
            else
            {
                // award has been awarded so do this: 
                awardIcon.setAttribute("src", "/Content/Img/SiteImg/oscar_filled_crop.png");
                UpdateAwardsCount(postID, "add");
            }
        }
    };
    
    if(awardIcon.getAttribute("src") == "/Content/Img/SiteImg/oscar_filled_crop.png") // if user has awarded this post
    {
        url = "/Post/RevokeAward?id=" + postID;
        console.log("url in if = " + url)
    }
    else
    {
        url = "/Post/GiveAward?id=" + postID;
        console.log("url at in if = " + url)
    }
    xhttp.open("GET", url, true);
    xhttp.send();
}

// Award() updates the awards in database
function UpdateAwardsCount(postID, AddOrTake) {
    var badge = document.getElementById("awardsBadge_" + postID);
    var awards = badge.innerHTML;

    if(AddOrTake == "add")
    {
        badge.innerHTML = parseInt(awards) + 1;
    }
    else
    {
        badge.innerHTML = parseInt(awards) - 1;
    }   
}
