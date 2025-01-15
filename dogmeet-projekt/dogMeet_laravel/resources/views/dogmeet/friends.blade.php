@extends('layout.main')

@section('title', 'DogMeet | Kapcsolatok')

@section('content')
    <div class="container containerStyle">

        @include('layout.header')

        @include('layout.navbar')

        <h1 class="text-center white my-4">Kapcsolatok</h1>
        <div class="row" id="friends">

        </div>
    </div>

    @include('layout.footer')

    @include('components.Modal')

    <template id="friendDiv">
        <div class="col-10 offset-1 col-md-8 offset-md-2 my-2 friendStyle">
            <div class="row">
                <div class="col-12 col-md-6 col-lg-8 text-center my-auto">
                    <h3 id="friendName"></h3>
                </div>
                <div class="col-12 col-md-6 col-lg-4">
                    <button class="btn brownBtn mt-1 d-block w-75 mx-auto" id="more">Részletek</button>
                    <button class="btn redBtn mt-1 d-block w-75 mx-auto" id="deleteFriend">Törlés</button>
                </div>
            </div>
        </div>
    </template>

    <template id="emptyFriend">
        <div class="col-10 offset-1 col-md-8 offset-md-2 my-2 friendStyle">
            <div class="row">
                <div class="col-12 text-center my-auto">
                    <h3 id="response"></h3>
                </div>
            </div>
        </div>
    </template>

    <template id="dogCard">
        <div class="col-10 offset-1 col-md-8 offset-md-2 my-3 dogCard">
            <div class="row">
                <div class="col">
                    <img src="{{asset('img/anonymdog.png')}}" alt="" class="dogImg" id="dogImage">
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h2 class="text-center nameType"></h2>
                    <p class="text-center"></p>
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

        fetch(`${apiURL}/api/friend`, requestOptions)
            .then(r => r.json())
            .then(d => data = d.data)
            .then(function () {
                showFriends()
            })

        let templateEmpty = document.querySelector("template#emptyFriend").content.querySelector("div")
        let template = document.querySelector("template#friendDiv").content.querySelector("div")

        function showFriends()
        {
            let friends = document.querySelector("#friends")

            friends.innerHTML = ""

            if (data.length === 0)
            {
                let cardEmpty = document.importNode(templateEmpty, true)

                cardEmpty.querySelector("h3#response").textContent = "Még nincsennek kapcsolataid"
                
                friends.append(cardEmpty)
            }
            else {
                for(let item of data)
                {
                    let card = document.importNode(template, true)

                    if({{$user->id}} === item.user_id)
                    {
                        card.querySelector("h3#friendName").textContent =
                            item.friend_lastName + ' ' + item.friend_firstName

                        card.querySelector("button#deleteFriend").onclick = function () {
                            showDeleteFriend(item.id, item.friend_profId)
                        }

                        card.querySelector("button#more").onclick = function () {
                            showMore(item.friend_profId)
                        }

                        friends.append(card)
                    }
                    if({{$user->id}} === item.friend_id)
                    {
                        card.querySelector("h3#friendName").textContent =
                            item.user_lastName + ' ' + item.user_firstName

                        card.querySelector("button#deleteFriend").onclick = function () {
                            showDeleteFriend(item.id, item.user_profId)
                        }

                        card.querySelector("button#more").onclick = function () {
                            showMore(item.user_profId)
                        }

                        friends.append(card)
                    }
                }
            }
        }

        // delete modal

        async function showDeleteFriend(id, friendId)
        {
            let modal = document.querySelector("#Modal");
            let friend = []
            modal.querySelector("div.modal-body").innerHTML = ""

            await fetch(`${apiURL}/api/profile/${friendId}`, requestOptions)
                .then(r => r.json())
                .then(d => friend = d.data)
            modal.querySelector("h5.modal-title").innerHTML = friend.lastName + " " + friend.firstName + " törlése"

            let div = generateDeleteCard(friend, id)

            modal.querySelector("div.modal-body").append(div)

            let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
            BSModal.show();
        }

        function generateDeleteCard(friend, id)
        {
            let div = document.createElement("div")

            let p = document.createElement("p")
            p.innerHTML = `Biztos törölni akarja ${friend.lastName} ${friend.firstName} nevű barátját?`
            p.classList.add("text-center")

            let btn = document.createElement("button")
            btn.classList.add("btn", "greenBtn", "d-block", "w-75", "mx-auto")
            btn.innerHTML = "Biztosan törlöm"
            btn.onclick = function () {
                let myHeaders = new Headers();
                myHeaders.append("Accept", "application/json");
                myHeaders.append("Content-Type", "application/json");

                let rawFriend = JSON.stringify({
                    "_token": document.querySelector("input[name='_token']").value,
                });

                let rOptionFriend = {
                    method: 'DELETE',
                    headers: myHeaders,
                    body: rawFriend,
                    redirect: 'follow'
                };
                fetch(`${apiURL}/api/friend/${id}`, rOptionFriend)
                    .then(function () {
                        window.location.reload()
                    })
            }

            div.append(p, btn)

            return div
        }

        //friend data modal

        async function showMore(id)
        {
            let modal = document.querySelector("#Modal");
            modal.querySelector("div.modal-body").innerHTML = ""
            let owners = []

            await fetch(`${apiURL}/api/profile/${id}`, requestOptions)
                .then(r => r.json())
                .then(d => owners = d.data)

            modal.querySelector("h5.modal-title").textContent = "Barát adatai"

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

            let btnDogs = document.createElement("button")
            btnDogs.classList.add("btn", "greenBtn", "d-block", "w-100", "mx-auto")
            btnDogs.textContent = "Barát kutyái"
            btnDogs.onclick = function () {
                showDogsModal(owners.user_id)
            }

            div.append(table, btnDogs)

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

        // dogs modal

        let templateDog = document.querySelector("template#dogCard")
            .content.querySelector("div")

        async function showDogsModal(id) {
            let modal = document.querySelector("#Modal");
            modal.querySelector("div.modal-body").innerHTML = ""
            let dogs = []

            await fetch(`${apiURL}/api/dog/dogs/${id}`, requestOptions)
                .then(r => r.json())
                .then(d => dogs = d)

            modal.querySelector("h5.modal-title").textContent = "Barát kutyái"

            for(let item of dogs.data)
            {
                let card = document.importNode(templateDog, true)

                card.querySelector("h2").textContent = `${item.name} - ${item.type}`
                card.querySelector("p").textContent = item.description

                modal.querySelector("div.modal-body").append(card)
            }

            let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
            BSModal.show();
        }
    </script>
    <script src="{{asset('js/Modals.js')}}"></script>
@endsection