@extends('layout.main')

@section('title', 'DogMeet | Főoldal')

@section('content')
    <div class="container containerStyle">

        @include('layout.header')

        @include('layout.navbar')

        <div class="row" id="dogs">

        </div>
    </div>

    @include('layout.footer')

    @include('components.Modal')

    <template id="dogCard">
        <div class="col-10 offset-1 col-md-8 offset-md-2 my-3 dogCard">
            <div class="row">
                <div class="col">
                    <img src="{{asset('img/anonymdog.png')}}" alt="" class="dogImg" id="dogImage">
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
                <div class="col col-md-6">
                    <button class="btn brownBtn d-block w-100 mx-auto h-100 mt-2 mt-md-0" id="historyBtn">Szaporítási előzmények</button>
                </div>
                <div class="col col-md-6">
                    <button class="btn brownBtn d-block w-100 mx-auto h-100 mt-2 mt-md-0" id="ownerBtn">Kapcsolat felvétele a gazdával</button>
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

        fetch(`${apiURL}/api/dog`, requestOptions)
            .then(r => r.json())
            .then(d => data = d)
            .then(function () {
                ShowDogs()
            })

        let template = document.querySelector("template#dogCard")
            .content.querySelector("div")

        function ShowDogs()
        {
            let dogs = document.querySelector("#dogs")

            dogs.innerHTML = ""

            for(let item of data.data)
            {
                let card = document.importNode(template, true)

                card.querySelector("p#dogGender").textContent = item.gender
                card.querySelector("img#dogImage").src = item.url === "" ? "{{asset('img/anonymdog.png')}}" : item.url
                card.querySelector("h2").textContent = `${item.name} - ${item.type}`
                card.querySelector("p#dogDescription").textContent = item.description
                card.querySelector("button#ownerBtn").onclick = function () {
                    showOwner(item.owner_profileid)
                }
                card.querySelector("button#historyBtn").onclick = function () {
                    showHistory(item.id)
                }

                dogs.append(card)
            }
        }

        //owner modal

        async function showOwner(id) {
            let modal = document.querySelector("#Modal");
            modal.querySelector("div.modal-body").innerHTML = ""
            let owners = []

            await fetch(`${apiURL}/api/profile/${id}`, requestOptions)
                .then(r => r.json())
                .then(d => owners = d.data)

            modal.querySelector("h5.modal-title").textContent = "Gazda adatai"

            let div = generateTable(owners)

            modal.querySelector("div.modal-body").append(div)

            let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
            BSModal.show();
        }

        function generateTable(owners)
        {
            let div = document.createElement("div")
            let table = document.createElement("table")

            let tr1 = generateRow("Gazda neve:", `${owners.lastName} ${owners.firstName}`)
            let tr2 = generateRow("Email:", owners.email)
            let tr3 = generateRow("Tel.:", owners.phoneNumber)

            table.classList.add("table")

            table.append(tr1, tr2, tr3)

            let btnFriend = document.createElement("button")
            btnFriend.classList.add("btn", "greenBtn", "d-block", "w-100", "mx-auto")
            btnFriend.textContent = "Kapcsolatokba mentése"
            btnFriend.onclick = async function () {
                if({{$user->id}} !== owners.user_id) {
                    let myHeaders = new Headers();
                    myHeaders.append("Accept", "application/json");
                    myHeaders.append("Content-Type", "application/json");

                    let raw = JSON.stringify({
                        "_token": document.querySelector("input[name='_token']").value,
                        "user_id": {{$user->id}},
                        "friend_id": owners.user_id
                    });

                    let rOption = {
                        method: 'POST',
                        headers: myHeaders,
                        body: raw,
                        redirect: 'follow'
                    };

                    fetch(`${apiURL}/api/friend`, rOption)
                        .then(function () {
                            dismissModal()
                            alert(`Mostantól ${owners.lastName} ${owners.firstName} elmentette a kacsolatok.`)
                        })
                }
                else
                {
                    dismissModal()
                    alert("Önmagaddal nem lehetsz kapcsolatban!")
                }
            }
            div.append(table, btnFriend)

            return div
        }

        function generateRow(textType, textValue)
        {
            let tr = document.createElement("tr")

            let td1 = document.createElement("td")
            td1.textContent = textType
            let td2 = document.createElement("td")
            td2.textContent = textValue
            td2.classList.add("text-end")

            tr.append(td1, td2)
            return tr
        }

        // dogHistory modal

        async function showHistory(id) {
            let modal = document.querySelector("#Modal");
            modal.querySelector("div.modal-body").innerHTML = ""
            let histories = []

            await fetch(`${apiURL}/api/doghistory/dog/${id}`, requestOptions)
                .then(r => r.json())
                .then(d => histories = d)

            modal.querySelector("h5.modal-title").textContent = "Szaporítási előzmények"

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

                let type = document.createElement("p")
                let date = document.createElement("p")
                let child = document.createElement("p")

                type.classList.add("pHistory")
                date.classList.add("pHistory")
                child.classList.add("pHistory")

                type.textContent = item.breededWith_Type + " fajtával"
                date.textContent = "dátum: " + item.date
                child.textContent = "Kölyök született: " + item.kidsBorn + " db"

                col.append(type, date, child)
                row.append(col)
            }

            return row
        }
    </script>
    <script src="{{asset('js/Modals.js')}}"></script>
@endsection