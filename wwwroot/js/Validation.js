var textDanger = document.getElementsByClassName('text-danger');
for(let i = 0; i < textDanger.length; i++)
{
    if(textDanger[i].innerText != "" && textDanger[i] != null)
    {
        let input = document.getElementById(textDanger[i].getAttribute("data-valmsg-for"));
        input.style.border = "1px solid #dc35459c";
    }
}