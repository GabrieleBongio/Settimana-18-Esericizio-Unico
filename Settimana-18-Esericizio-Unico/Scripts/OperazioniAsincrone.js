fetch("/Async/NummeroSpedizioniInAttesa")
    .then(response => response.json())
    .then(data => { console.log(data); })
    .catch(error => { console.log(errorj); })

