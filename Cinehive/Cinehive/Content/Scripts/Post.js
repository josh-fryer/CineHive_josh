// divId, profileId, firstName, lastName, imagePath
//@Url.Action("ViewProfile", "Profile", new { id = ${profileId} })
function returnPost(divId, profileId, postId, firstName, lastName, imagePath, datePosted,
     isPopular, awards, awardGiven, isUserPostOrAdimin, commentsCount) {
    console.log("returnPost called");
    var postImage = `<div class="media-left"><a href="/Profile/ViewProfile/${profileId}">`;
        if (imagePath == null)
        {
            postImage += `<img class="post-profile-img circular-image" src="/Content/Img/profile-image-placeholder.png" width="64" height="64" />`;
        }
        else
        {
           postImage += `<img class="post-profile-img circular-image" src="/${imagePath}" width="64" height="64" />`;
        }
    postImage +=`</a></div>`;

    var postHeading = `<h4 class="media-heading post-heading"><a href="/Profile/ViewProfile/${profileId}">${firstName} ${lastName}</a>
   <small class="datePosted">${datePosted}</small></h4>`;            
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
                <strong><a href="/Post/RevokeAward/${postId}"><img src="/Content/Img/SiteImg/oscar_filled_crop.png" height="46"/></a>
                <span class="badge">${awards}</span></strong>
                </li>`;
            }
            else
            {
               postButtons += `<li><a href="/Post/GiveAward/${postId}">
               <img src="/Content/Img/SiteImg/oscar_empty_crop.png" height="46"/>
               </a><span class="badge">${awards}</span></li>`;
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

    // return postImage + postBody + postAwards + postButtons;
    // post part 1 id = post1_1
    var part1 = document.getElementById(divId+"_1");
    var part2 = document.getElementById(divId+"_2");
    document.getElementById(divId+"_1").insertAdjacentHTML("afterbegin", postImage);
    document.getElementById(divId+"_2").insertAdjacentHTML("afterbegin", postHeading );
    document.getElementById(divId+"_3").insertAdjacentHTML("afterend", (postAwards + postButtons));
}
