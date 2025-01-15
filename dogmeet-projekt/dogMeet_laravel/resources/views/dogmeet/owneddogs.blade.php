@extends('layout.main')

@section('title', 'DogMeet | Kutyáim')

@section('content')
    <div class="container containerStyle">

        @include('layout.header')

        @include('layout.navbar')

        <h1 class="text-center white my-4">Saját kutyáim</h1>
        <div class="row" id="dogs">

        </div>
        <a href="{{route('dog.storedata')}}" class="btn greenBtn d-block w-100 mx-auto my-3">
            <span>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
                    <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                </svg>
            </span>
            Új kutya felvétele
        </a>
    </div>

    @include('layout.footer')

    @include('components.Modal')

    @include('components.addHistoryModal')

    @include('components.imageModal')

    <template id="dogCard">
        <div class="col-10 offset-1 col-md-8 offset-md-2 my-3 dogCard">
            <div class="row">
                <div class="col">
                    <img src="" alt="" class="dogImg" id="dogImage">
                    <p class="float-end fw-bold" id="dogGender"></p>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h2 class="text-center nameType"></h2>
                    <p class="text-center text-break" id="dogDescription"></p>
                </div>
            </div>
            <div class="row">
                <div class="cl-12 col-md-6 mt-2">
                    <a href="" class="btn brownBtn d-block w-100 mx-auto h-100" id="editDog">Kutya adatainak szerkesztése</a>
                </div>
                <div class="cl-12 col-md-6 mt-2">
                    <button class="btn brownBtn d-block w-100 mx-auto h-100" id="dogImage">Kép szerkesztése</button>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-6 mt-2">
                    <button class="btn brownBtn d-block w-100 mx-auto h-100" id="historyDog">Kutya történetei</button>
                </div>
                <div class="col-12 col-md-6 mt-2">
                    <button class="btn brownBtn d-block w-100 mx-auto h-100" id="addHistoryDog">Új történet felvétele</button>
                </div>
            </div>
            <div class="row">
                <div class="col mt-2">
                    <button class="btn brownBtn d-block w-100 mx-auto" id="deleteDog">Kutya törlése</button>
                </div>
            </div>
        </div>
    </template>
@endsection

@section('innerJS')
    <script>
        //load data's

        let data = []

        let requestOptions = {
            method: 'GET',
            redirect: 'follow'
        }

        fetch(`${apiURL}/api/dog/dogs/{{$user->id}}`, requestOptions)
            .then(r => r.json())
            .then(d => data = d.data)
            .then(function () {
                ShowDogs()
            })

        let template = document.querySelector("template#dogCard")
            .content.querySelector("div")

        function ShowDogs()
        {
            let dogs = document.querySelector("#dogs")

            dogs.innerHTML = ""

            for(let item of data)
            {
                let card = document.importNode(template, true)

                card.querySelector("p#dogGender").textContent = item.gender
                card.querySelector("img#dogImage").src = item.url === "" ? "{{asset('img/anonymdog.png')}}" : item.url
                card.querySelector("h2").textContent = `${item.name} - ${item.type}`
                card.querySelector("p#dogDescription").textContent = item.description
                card.querySelector("a#editDog").href = `${apiURL}/editdog/${item.id}`
                card.querySelector("button#deleteDog").onclick = function () {
                    showDeleteDog(item.id)
                }
                card.querySelector("button#historyDog").onclick = function () {
                    showHistory(item.id)
                }
                card.querySelector("button#addHistoryDog").onclick = function () {
                    document.querySelector("input#dogH_id").value = item.id
                    addHistory()
                }
                card.querySelector("button#dogImage").onclick = function () {
                    document.querySelector("input#dogImage_id").value = item.id
                    uploadImage()
                }

                dogs.append(card)
            }
        }

        //delete modal

        async function showDeleteDog(id) {
            let modal = document.querySelector("#Modal");
            let dog = []
            modal.querySelector("div.modal-body").innerHTML = ""

            await fetch(`${apiURL}/api/dog/${id}`, requestOptions)
                .then(r => r.json())
                .then(d => dog = d)
            modal.querySelector("h5.modal-title").innerHTML = dog.name + " törlése"

            let div = generateDogDelete(dog, id)

            modal.querySelector("div.modal-body").append(div)

            let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
            BSModal.show();
        }

        function generateDogDelete(dog, id)
        {
            let div = document.createElement("div")
            let p = document.createElement("p")
            p.innerHTML = `Biztos törölni akarja ${dog.name} nevű kutyáját?`
            p.classList.add("text-center")

            let btn = document.createElement("button")
            btn.classList.add("btn", "greenBtn", "d-block", "w-75", "mx-auto")
            btn.innerHTML = "Biztos törlöm"
            btn.onclick = function () {
                let myHeaders = new Headers();
                myHeaders.append("Accept", "application/json");
                myHeaders.append("Content-Type", "application/json");

                let rawDog = JSON.stringify({
                    "_token": document.querySelector("input[name='_token']").value,
                });

                let rOptionDog = {
                    method: 'DELETE',
                    headers: myHeaders,
                    body: rawDog,
                    redirect: 'follow'
                };
                fetch(`${apiURL}/api/dog/${id}`, rOptionDog)
                    .then(function () {
                        window.location.reload()
                    })
            }

            div.append(p, btn)
            return div
        }

        // dogHistory modal

        async function showHistory(id) {
            let modal = document.querySelector("#Modal");
            modal.querySelector("div.modal-body").innerHTML = ""
            let histories = []

            await fetch(`${apiURL}/api/doghistory/dog/${id}`, requestOptions)
                .then(r => r.json())
                .then(d => histories = d)

            modal.querySelector("h5.modal-title").textContent = "Szaporítási előzmények szerkesztése"

            if (histories.length === 0)
            {
                let p = document.createElement("p")
                p.textContent = "Nincs szaporítási előzménye"
                p.classList.add("text-center")

                modal.querySelector("div.modal-body").append(p)
            }
            else
            {
                let rows = historiesCard(histories)

                modal.querySelector("div.modal-body").append(rows)
            }

            let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
            BSModal.show();
        }

        function historiesCard(histories)
        {
            let row = document.createElement("div")
            row.classList.add("row")

            for(let item of histories)
            {
                let col = document.createElement("div")
                col.classList.add("col-10", "offset-1", "historyCard", "my-2")

                let type = createHistoryP(item.breededWith_Type + " fajtával")
                let date = createHistoryP("dátum: " + item.date)
                let child = createHistoryP("Kölyök született: " + item.kidsBorn + " db")

                let btnDelete = document.createElement("button")
                btnDelete.textContent = "Törlés"
                btnDelete.classList.add("btn", "redBtn", "float-end", "d-block", "mt-2", "mt-md-0")
                btnDelete.onclick = function () {
                    let myHeaders = new Headers();
                    myHeaders.append("Accept", "application/json");
                    myHeaders.append("Content-Type", "application/json");

                    let rawHistory = JSON.stringify({
                        "_token": document.querySelector("input[name='_token']").value,
                    });

                    let rOptionHistory = {
                        method: 'DELETE',
                        headers: myHeaders,
                        body: rawHistory,
                        redirect: 'follow'
                    };

                    fetch(`${apiURL}/api/doghistory/${item.id}`, rOptionHistory)
                        .then(function () {
                            showHistory(id)
                        })
                }

                col.append(type, date, child, btnDelete)
                row.append(col)
            }

            return row
        }

        function createHistoryP(text)
        {
            let p = document.createElement("p")
            p.classList.add("pHistory")
            p.textContent = text

            return p
        }
    </script>
    <script src="{{asset("js/Modals.js")}}"></script>
@endsection