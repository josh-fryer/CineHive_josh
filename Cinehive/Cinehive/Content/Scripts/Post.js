function ReturnPost(divId, profileId, postId, firstName, lastName, imagePath, datePosted,
    isPopular, awards, awardGiven, isUserPostOrAdimin, isEdited, isShared, commentsCount) {
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

    var postHeading = `<h4 class="media-heading post-heading"><a href="/Profile/ViewProfile/${profileId}">${firstName} ${lastName}</a>`;
    if (isEdited)
    {
        postHeading += `<span class="datePosted"><small>edited - ${datePosted}</small></span></h4>`;    
    }
    else
    {
        postHeading += `<span class="datePosted"><small>${datePosted}</small></span></h4>`;    
    }     
    // -- post content goes here in View --

    var postAwards = ``;                
            if (isPopular == true)
            {
                postAwards += `<div class="popularTag"><strong class="popularText">Popular</strong></div>`;
            }

    var postButtons =         
        `<ul class="list-inline list-unstyled post-buttons">`;
            if (awardGiven)
            {
                postButtons += `<li>
                <strong><a onclick="Award(${postId})"><img id="awardImg_${postId}" src="/Content/Img/SiteImg/oscar_filled_crop.png" height="46"/></a>
                <span id="awardsBadge_${postId}" class="badge">${awards}</span></strong>
                </li>`;
            }
            else
            {
               postButtons += `<li><a onclick="Award(${postId})">
               <img id="awardImg_${postId}" src="/Content/Img/SiteImg/oscar_empty_crop.png" height="46"/>
               </a><span id="awardsBadge_${postId}" class="badge">${awards}</span></li>`;
            }
            postButtons +=
            `<li><a href="/Post/ViewPostComments/${postId}"><span class="glyphicon glyphicon-comment"></span> Comment</a></li>
            
            <li><button type="button" class="comment-button" id="post-${postId}" name="Comment">
            <img src="/Content/Img/SiteImg/chat.png" width="24"/></button> <span class="badge">${commentsCount}</span> </li>`
                 
            if(!isShared)
            {
                postButtons+=`<li><a href="/Post/SharePost/${postId}"><span class="glyphicon glyphicon-share-alt"></span> Share</a></li>`;
            }

            if (isUserPostOrAdimin)
            {
               postButtons +=
                `<li><a href="/Post/DeletePost/${postId}"><span class="glyphicon glyphicon-trash"></span></a></li>
                
                <li> <a href="/Post/EditPost/${postId}"><span class="glyphicon glyphicon-edit"></span></a> </li>`;
            }
        postButtons += `</ul>`;

    document.getElementById(divId+"_1").insertAdjacentHTML("afterbegin", postImage); // insert as first child of div
    document.getElementById(divId+"_2").insertAdjacentHTML("afterbegin", postHeading ); 
    document.getElementById(divId+"_3").insertAdjacentHTML("afterend", (postAwards + postButtons)); // insert after </div>
}

function ViewCommentsPost(divId, profileId, postId, firstName, lastName, imagePath, datePosted,
    isPopular, awards, awardGiven, isUserPostOrAdimin, isEdited, canShare) {
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

   var postHeading = `<h4 class="media-heading post-heading"><a href="/Profile/ViewProfile/${profileId}">${firstName} ${lastName}</a>`;
   if (isEdited)
   {
       postHeading += `<span class="datePosted"><small>edited - ${datePosted}</small></span></h4>`;    
   }
   else
   {
       postHeading += `<span class="datePosted"><small>${datePosted}</small></span></h4>`;    
   }     
   // -- post content goes here in View --

   var popular = ``;                
           if (isPopular == true)
           {
               popular += `<div class="popularTag"><strong class="popularText">Popular</strong></div>`;
           }

   var postButtons =         
       `<ul class="list-inline list-unstyled post-buttons">`;
           if (awardGiven)
           {
               postButtons += `<li>
               <strong><a onclick="Award(${postId})"><img id="awardImg_${postId}" src="/Content/Img/SiteImg/oscar_filled_crop.png" height="46"/></a>
               <span id="awardsBadge_${postId}" class="badge">${awards}</span></strong>
               </li>`;
           }
           else
           {
              postButtons += `<li><a onclick="Award(${postId})">
              <img id="awardImg_${postId}" src="/Content/Img/SiteImg/oscar_empty_crop.png" height="46"/>
              </a><span id="awardsBadge_${postId}" class="badge">${awards}</span></li>`;
           }       

           if (canShare)
           {
             postButtons += `<li><a href="/Post/SharePost/${postId}"><span class="glyphicon glyphicon-share-alt"></span> Share</a></li>`;
           }     
           
           if (isUserPostOrAdimin)
           {
              postButtons +=
               `<li><a href="/Post/DeletePost/${postId}"><span class="glyphicon glyphicon-trash"></span></a></li>          
               <li> <a href="/Post/EditPost/${postId}"><span class="glyphicon glyphicon-edit"></span></a> </li>`;
           }
       postButtons += `</ul>`;

   document.getElementById(divId+"_1").insertAdjacentHTML("afterbegin", postImage); // insert as first child of div
   document.getElementById(divId+"_2").insertAdjacentHTML("afterbegin", postHeading ); 
   document.getElementById(divId+"_3").insertAdjacentHTML("afterend", (popular + postButtons)); // insert after </div>
}

function ReturnComment(divId, profileId, commId, postId,firstName, lastName, imagePath, datePosted,
    awards, awardGiven, isUserCommOrAdimin, isEdited) {
   var commImage = `<div class="media-left"><a href="/Profile/ViewProfile/${profileId}">`;
       if (imagePath == null || imagePath == "")
       {
        commImage += `<img class="post-profile-img circular-image" src="/Content/Img/profile-image-placeholder.png" width="64" height="64" />`;
       }
       else
       {
        commImage += `<img class="post-profile-img circular-image" src="/${imagePath}" width="64" height="64" />`;
       }
       commImage +=`</a></div>`;

   var commHeading = `<h4 class="media-heading post-heading"><a href="/Profile/ViewProfile/${profileId}">${firstName} ${lastName}</a>`;
   if (isEdited)
   {
    commHeading += `<span class="datePosted"><small>edited - ${datePosted}</small></span></h4>`;    
   }
   else
   {
    commHeading += `<span class="datePosted"><small>${datePosted}</small></span></h4>`;    
   }     
   // Comment body here in cshtml

   var commButtons =         
    `<ul class="list-inline list-unstyled post-buttons">`;
        if (awardGiven)
        {
            commButtons += `<li>
            <strong><a onclick="AwardComment(${commId})"><img id="awardImg_${commId}" src="/Content/Img/SiteImg/oscar_filled_crop.png" height="36"/></a>
            <span id="awardsBadge_${commId}" class="badge">${awards}</span></strong>
            </li>`;
        }
        else
        {
            commButtons += `<li><a onclick="AwardComment(${commId})">
            <img id="awardImg_${commId}" src="/Content/Img/SiteImg/oscar_empty_crop.png" height="36"/>
            </a><span id="awardsBadge_${commId}" class="badge">${awards}</span></li>`;
        }

        if (isUserCommOrAdimin)
        {
            commButtons +=
            `<li><a href="/Comment/Delete?id=${commId}&postid=${postId}"><span class="glyphicon glyphicon-trash"></span></a></li>
            
            <li> <a href="/Comment/Edit?id=${commId}&postid=${postId}"><span class="glyphicon glyphicon-edit"></span></a> </li>`;
        }
    commButtons += `</ul>`;

   document.getElementById(divId+"_1").insertAdjacentHTML("afterbegin", commImage); // insert as first child of div
   document.getElementById(divId+"_2").insertAdjacentHTML("afterbegin", commHeading ); 
   document.getElementById(divId+"_3").insertAdjacentHTML("afterend", commButtons); // insert after </div>
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

function AwardComment(commID) {
    console.log("award comment clicked");

    var awardIcon = document.getElementById("awardImg_"+commID);
    console.log("awardIcon src = " + awardIcon.getAttribute("src"));
    var url = "";
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {              
            if(awardIcon.getAttribute("src") == "/Content/Img/SiteImg/oscar_filled_crop.png")
            {
                // award has been revoked so do this:
                console.log("iconimg = " + awardIcon.getAttribute("src"))
                awardIcon.setAttribute("src", "/Content/Img/SiteImg/oscar_empty_crop.png");
                UpdateAwardsCount(commID, "take");
            }
            else
            {
                // award has been awarded so do this: 
                awardIcon.setAttribute("src", "/Content/Img/SiteImg/oscar_filled_crop.png");
                UpdateAwardsCount(commID, "add");
            }
        }
    };
    
    if(awardIcon.getAttribute("src") == "/Content/Img/SiteImg/oscar_filled_crop.png") // if user has awarded this post
    {
        url = "/Comment/RevokeAward?id=" + commID; 
    }
    else
    {
        url = "/Comment/GiveAward?id=" + commID;
    }
    xhttp.open("GET", url, true);
    xhttp.send();
}

// Award() updates the awards in database
function UpdateAwardsCount(ID, AddOrTake) {
    var badge = document.getElementById("awardsBadge_" + ID);
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
