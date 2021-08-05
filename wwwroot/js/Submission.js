var submissionID = document.getElementsByClassName("submissionID");
var overlay = document.querySelector(".overlay");
var detailSubmission = document.querySelector(".detailSubmissionContainer");
var detailSubmissionContent = document.querySelector(".detailSubmissionContent");
var closeButton = document.querySelector(".detailSubmissionIcon");

closeButton.addEventListener('click', function()
{
    overlay.classList.remove("overlay--active");
})

overlay.addEventListener('click', function(e)
{
    let top = detailSubmission.offsetTop, left = detailSubmission.offsetLeft;
    let height = detailSubmission.offsetHeight, width = detailSubmission.offsetWidth;

    if(e.clientX < left || e.clientX > left + width || e.clientY < top || e.clientY > top + height)
        overlay.classList.remove("overlay--active");
})

for(let i = 0; i < submissionID.length; i++)
{
    submissionID[i].addEventListener('click', function(){
        let url = '/Submissions/GetSubmission/' + submissionID[i].getAttribute("data-id");
        console.log(url);
        fetch(url)
        .then(res => res.text())
        .then(function(data)
        {
            detailSubmissionContent.innerHTML = data;

            detailSubmissionContent.scrollTop = 0;

            document.querySelectorAll('pre code').forEach((block) => {
                if(block.classList == "")
                    block.classList.add("plaintext");
                hljs.highlightBlock(block);
            });
        })
        overlay.classList.add("overlay--active");
        detailSubmission.style.left = String((window.innerWidth - detailSubmission.offsetWidth)/2) + "px";
    })
}