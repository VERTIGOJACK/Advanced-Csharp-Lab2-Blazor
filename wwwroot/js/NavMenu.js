function clickOutside(dotNetHelper) {
    window.addEventListener("click", (event) => {
        let element = document.getElementById("menu");
        if (element && !element.contains(event.target)) {
            // Call the C# function using DotNet.invokeMethodAsync
            dotNetHelper.invokeMethodAsync("CloseNavMenu")
                .then(result => {
                    console.log("result:"+ result)
                })
                .catch(error => {
                    console.log("error:" + error)
                });

        }
    })
};

