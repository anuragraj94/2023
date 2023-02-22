const btnEl = document.getElementById("btn");
const pEl = document.getElementById("joke");

const apiKey = "ab7QliXMtE7V2LSGLCchZ5K6LusuJL79RiOUWqhn";
const apiUrl = "https://api.api-ninjas.com/v1/dadjokes?limit=1";
const options = {
    method: "GET",
    headers: {
        "X-Api-Key": apiKey,
    },
}



async function getJoke() {
    try {
        const response = fetch(apiUrl, options)
        const data = (await response).json();
        btnEl.innerText = "Loading"
        data.then((value) => {
            //console.log(value)  
            //console.log(value[0].joke)
            pEl.innerHTML = value[0].joke;
            btnEl.innerText = "Tell me a joke"

        })
    } catch (error) {
        //console.log(error)
        pEl.innerHTML = "Please try again after sometime...";
    }
}





btnEl.addEventListener("click", getJoke)

