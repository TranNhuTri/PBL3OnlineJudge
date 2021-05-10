var submissionID = document.getElementsByClassName("SubmissionID");
var overlay = document.querySelector(".Overlay");
var detailSubmission = document.querySelector(".DetailSubmissionContainer");
var detailSubmissionContent = document.querySelector(".DetailSubmissionContent");
var closeButton = document.querySelector(".DetailSubmissionIcon");

closeButton.addEventListener('click', function()
{
    overlay.classList.remove("Overlay--active");
})

overlay.addEventListener('click', function(e)
{
    let top = detailSubmission.offsetTop, left = detailSubmission.offsetLeft;
    let height = detailSubmission.offsetHeight, width = detailSubmission.offsetWidth;

    if(e.clientX < left || e.clientX > left + width || e.clientY < top || e.clientY > top + height)
        overlay.classList.remove("Overlay--active");
})

for(let i = 0; i < submissionID.length; i++)
{
    submissionID[i].addEventListener('click', function(){
        fetch("https://localhost:5001/Data/Submission/" + submissionID[i].innerText)
        .then(res => res.json())
        .then(function(data)
        {

            let styleString = "font-weight: bold;";
            if(data["Status"] == "Accepted")
            {
                styleString += "color: #0a0;"
            }
            else
                if(data["Status"] == "Wrong Answer")
                {
                    styleString += "color: #dc3545;"
                }
            let stringData = '<p>Nộp bởi ' + data["UserName"] + " , bài: " + data["ProblemTitle"] + ", <span style = " + '"' + styleString + '">' + data["Status"] + "</span>" + "</p>" + '<pre><code class="language-cpp">' + data["Code"] + "</code></pre>";
            
            let submissionResults = data["SubmissionResults"];
            let submitResultIndex = 0;

            submissionResults.forEach(sr => {
                let styleString = "font-weight: bold;";
                if(sr["Status"] == "OK")
                {
                    styleString += "color: #0a0;"
                }
                else
                    if(data["Status"] == "Wrong Answer")
                    {
                        styleString += "color: #dc3545;"
                    }

                stringData += '<p style = "font-weight: bold; margin-bottom: 0">Test: #' + String(submitResultIndex + 1) + ", trạng thái: <span style = " + '"' + styleString + '">' + sr["Status"] + "</span>" + "</p>";
                stringData += '<p style = "margin: 10px 0">Input</p>' + '<pre><code>' + (sr["TestCase"]["Input"] == null ? "" : sr["TestCase"]["Input"]) + "</code></pre>";
                stringData += '<p>Output</p>' + '<pre><code>' + sr["Result"] + "</code></pre>";
                stringData += '<p>Answer</p>' + '<pre><code>' + sr["TestCase"]["Output"] + "</code></pre>";

                submitResultIndex ++;
            })
            detailSubmissionContent.innerHTML = stringData;

            document.querySelectorAll('pre code').forEach((block) => {
                if(block.classList == "")
                    block.classList.add("plaintext");
                hljs.highlightBlock(block);
            });
        })
        overlay.classList.add("Overlay--active");
        detailSubmission.style.left = String((window.innerWidth - detailSubmission.offsetWidth)/2) + "px";
    })
}