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
        fetch("https://localhost:5001/Submissions/GetSubmission/" + submissionID[i].innerText)
        .then(res => res.json())
        .then(function(data)
        {

            let styleString = "font-weight: bold;";
            if(data["status"] == "Accepted")
            {
                styleString += "color: #0a0;"
            }
            else
                if(data["status"] == "Wrong Answer")
                {
                    styleString += "color: #dc3545;"
                }
            let stringData = '<p>Nộp bởi ' + data["accountName"] + " , bài: " + data["title"] + ", <span style = " + '"' + styleString + '">' + data["status"] + "</span>" + "</p>" + '<pre><code class="language-cpp">' + data["code"] + "</code></pre>";
            
            let submissionResults = data["submissionResults"];
            let submitResultIndex = 0;

            submissionResults.forEach(sr => {
                let styleString = "font-weight: bold;";
                if(sr["status"] == "Accepted")
                {
                    styleString += "color: #0a0;"
                }
                else
                    if(data["status"] == "Wrong Answer")
                    {
                        styleString += "color: #dc3545;"
                    }

                stringData += '<p style = "font-weight: bold; margin-bottom: 0">Test: #' + String(submitResultIndex + 1) + ", trạng thái: <span style = " + '"' + styleString + '">' + sr["status"] + "</span>" + "</p>";
                stringData += '<p style = "margin: 10px 0">Input</p>' + '<pre><code>' + (sr["testCase"]["input"] == null ? "" : sr["testCase"]["input"]) + "</code></pre>";
                stringData += '<p>Output</p>' + '<pre><code>' + sr["result"] + "</code></pre>";
                stringData += '<p>Answer</p>' + '<pre><code>' + sr["testCase"]["output"] + "</code></pre>";
                console.log(sr["result"]);
                submitResultIndex ++;
            })
            detailSubmissionContent.innerHTML = stringData;
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