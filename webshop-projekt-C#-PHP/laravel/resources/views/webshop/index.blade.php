
@extends('layouts.main')

@section('content')
    @include('layouts.szurok')
    <div class="container-fluid bodystyle">
        <div class="row">
            <div class="col-12 navbar navbarstyle">
                <div class="dropdown">
                    <button class="dropbtn">Termékek
                        <i class="fa fa-caret-down"></i>
                    </button>
                    <div class="dropdown-content">
                        <div class="row">
                            <div class="column">
                                <h3>peldakategoria</h3>
                                <a href="#">peldaalkategoria</a>
                                <a href="#">peldaalkategoria</a>
                                <a href="#">peldaalkategoria</a>
                            </div>
                            <div class="column">
                                <h3>peldakategoria</h3>
                                <a href="#">peldaalkategoria</a>
                                <a href="#">peldaalkategoria</a>
                                <a href="#">peldaalkategoria</a>
                            </div>
                        </div>
                    </div>
                </div>
                <p>A nap akciója</p>
                <button onclick="showCart()" class="cartbtn">Kosár</button>
            </div>
        </div>
        <div class="row" id="cards">

        </div>
    </div>

    {{--   Cart Modal --}}
    <div class="modal fade" id="CartModal" aria-hidden="true" aria-labelledby="CartModalTitle" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="CartModalTitle"></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" id="CartModalBody">

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="dismissModal()">Vissza a termékekhez</button>
                    <button type="button" class="btn btn-success" onclick="showBuy()">Kasszához</button>
                </div>
            </div>
        </div>
    </div>

    {{--    Buy Modal --}}
    <div class="modal fade" id="BuyModal" aria-hidden="true" aria-labelledby="BuyModalTitle" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="BuyModalTitle"></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" id="BuyModalBody">

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="dismissBuyModal()">Vissza a termékekhez</button>
                    <button type="button" class="btn btn-success" onclick="showResponse()">Megrendelés</button>
                </div>
            </div>
        </div>
    </div>

    {{--    Response Modal --}}
    <div class="modal fade" id="ResponseModal" aria-hidden="true" aria-labelledby="ResponseModalTitle" tabindex="-1">
        <div class="modal-dialog modal-dialog-scrollable modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ResponseModalTitle"></h5>
                </div>
                <div class="modal-body" id="ResponseModalBody">

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="dismissResponseModal()">Új vásárlás</button>
                    <button type="button" class="btn btn-success" onclick="dismissResponseModal()">Ok</button>
                </div>
            </div>
        </div>
    </div>

    {{--    Template Form --}}
    <template>
        <form action="">
            <hr>
            <h5>Szállítási adatok:</h5>
            <div class="row mb-3">
                <div class="col-6">
                    <label for="orszag" class="form-label">Ország:</label>
                    <input type="text" name="orszag" id="orszag" class="form-control" required>
                </div>
                <div class="col-6">
                    <label for="varos" class="form-label">Város:</label>
                    <input type="text" name="varos" id="varos" class="form-control" required>
                </div>
            </div>
            <div class="row mb-5">
                <div class="col-3">
                    <label for="kerulet" class="form-label">Irányítószám:</label>
                    <input type="number" name="kerulet" id="kerulet" class="form-control" required>
                </div>
                <div class="col-9">
                    <div class="row">
                        <div class="col-9">
                            <label for="utca" class="form-label">Utca:</label>
                            <input type="text" name="utca" id="utca" class="form-control" required>
                        </div>
                        <div class="col-3">
                            <label for="hazszam" class="form-label">Házszám:</label>
                            <input type="number" name="hazszam" id="hazszam" class="form-control" required>
                        </div>
                    </div>
                </div>
            </div>
            <hr>
            <div class="row mb-3">
                <div class="col-6">
                    <h5>Fizetés:</h5>
                    <p>Csak utánvétes fizetési lehetőség van.</p>
                </div>
                <div class="col-6">
                    <div class="form-check">
                        <input type="radio" class="form-check-input" name="fizetes" id="keszpenz" checked>
                        <label for="keszpenz" class="form-check-label">Készpénz</label>
                    </div>
                    <div class="form-check">
                        <input type="radio" class="form-check-input" name="fizetes" id="kartya">
                        <label for="kartya" class="form-check-label">Kártya</label>
                    </div>
                </div>
            </div>
        </form>
    </template>
@endsection

@section("js")
    <script>

        let data = []

        function Load(){

            let requestOptions = {
                method: 'GET',
                redirect: 'follow'
            }

            fetch(`http://localhost:8881/api/termek`, requestOptions).then(r => r.json()).then(d => data = d).then(a => ShowTable())
        }

        /**
         * @param {String} orderBy - Mi alapján rendezzük az adatokat
         * @param {String} order - Milyen sorrendbe
         * */
        async function OrderByPrice(orderBy, order) {
            let csokkeno = document.querySelector("#csokkeno")
            let novekvo = document.querySelector("#novekvo")
            if(csokkeno.checked == true)
            {
                order = "desc"
            }
            if(novekvo.checked == true)
            {
                order = "asc"
            }
            let extension = "";
            if (orderBy !== "" && order !== "") {
                extension = `?orderBy=${orderBy}&order=${order}`;
            }
            let resp = await fetch(`{{route("termek.index")}}` + extension);
            if (resp.status === 200) {
                let rawData = await resp.json();
                console.log(rawData);
                data = rawData.data;
                usefilters();
            } else {
                alert(`{{route("termek.index")}}` + extension);
            }
        }

        function ShowTable(){
            let cards = document.querySelector("#cards")

            cards.innerHTML = ""
            for(let item of data.data)
            {
                let col = document.createElement("div")
                col.classList.add("col-sm-6", "col-md-4", "col-lg-3", "colstyle")

                let card = document.createElement("div")
                card.classList.add("card", "cardstyle")

                let img = document.createElement("img")
                img.classList.add("card-img-top", "img-fluid")
                img.src = "/img/" + item.url

                let cardbody = document.createElement("div")
                cardbody.classList.add("card-body", "cbodystyle")

                let cardtitle = document.createElement("h5")
                cardtitle.classList.add("card-title", "cardtextstyle")
                cardtitle.textContent = item.nev

                let hr = document.createElement("hr")
                hr.style.color = ("white")

                let cardtext = document.createElement("p")
                cardtext.classList.add("card-text", "cardtextstyle")
                cardtext.textContent = item.leiras

                let cardfooter = document.createElement("footer")

                let cardbtn = document.createElement("a")
                cardbtn.classList.add("btn", "btn-success")
                cardbtn.textContent = "Kosárba"
                cardbtn.style.float = "right"
                cardbtn.onclick = function () {
                    if (cart.has(item.id)) {
                        cart.set(item.id, cart.get(item.id) + 1);
                    }
                    else {
                        cart.set(item.id, 1);
                    }
                }

                let cardar = document.createElement("p")
                cardar.classList.add("cardtextstyle")
                cardar.textContent = new Intl.NumberFormat('hu-HU').format(item.ar) + " Ft"
                cardar.style.float = "left"
                
                cardfooter.append(cardbtn,cardar)
                cardbody.append(cardtitle, hr, cardtext, cardfooter)
                card.append(img, cardbody)
                col.append(card)
                cards.append(col)
            }
        }

        // filters
        function usefilters(){
            let cards = document.querySelector("#cards")
            let csokkeno = document.querySelector("#csokkeno")
            let novekvo = document.querySelector("#novekvo")

            cards.innerHTML = ""
            for(let item of data)
            {
                let armin = document.querySelector("#armin")
                let armax = document.querySelector("#armax")

                if(armin.value <= item.ar && armax.value >= item.ar){

                    let col = document.createElement("div")
                    col.classList.add("col-sm-6", "col-md-4", "col-lg-3", "colstyle")

                    let card = document.createElement("div")
                    card.classList.add("card", "cardstyle")

                    let img = document.createElement("img")
                    img.classList.add("card-img-top", "img-fluid")
                    img.src = "/img/" + item.url

                    let cardbody = document.createElement("div")
                    cardbody.classList.add("card-body", "cbodystyle")

                    let cardtitle = document.createElement("h5")
                    cardtitle.classList.add("card-title", "cardtextstyle")
                    cardtitle.textContent = item.nev

                    let hr = document.createElement("hr")
                    hr.style.color = ("white")

                    let cardtext = document.createElement("p")
                    cardtext.classList.add("card-text", "cardtextstyle")
                    cardtext.textContent = item.leiras

                    let cardfooter = document.createElement("footer")

                    let cardbtn = document.createElement("a")
                    cardbtn.classList.add("btn", "btn-success")
                    cardbtn.textContent = "Kosárba"
                    cardbtn.style.float = "right"
                    cardbtn.onclick = function () {
                        if (cart.has(item.id)) {
                            cart.set(item.id, cart.get(item.id) + 1);
                        }
                        else {
                            cart.set(item.id, 1);
                        }
                    }

                    let cardar = document.createElement("p")
                    cardar.classList.add("cardtextstyle")
                    cardar.textContent = new Intl.NumberFormat('hu-HU').format(item.ar) + " Ft"
                    cardar.style.float = "left"
                    
                    cardfooter.append(cardbtn,cardar)
                    cardbody.append(cardtitle, hr, cardtext, cardfooter)
                    card.append(img, cardbody)
                    col.append(card)
                    cards.append(col)
                }
            }
        }

        // Cart Modal
        let cart = new Map();

        function showCart() {
            let modal = document.querySelector("#CartModal");
            modal.querySelector("#CartModalTitle").innerText = "A kosár tartalma";
            let table = document.createElement("table");
            table.classList.add("table", "table-striped", "text-center")

            let thead = document.createElement("thead")
            let trH = document.createElement("tr")

            let tdNev = document.createElement("th")
            tdNev.textContent = "Termék neve"

            let tdDb = document.createElement("th")
            tdDb.textContent = "Db"
            tdDb.colSpan = 3

            let tdAr = document.createElement("th")
            tdAr.textContent = "Ár"

            let tdDel = document.createElement("th")
            tdDel.textContent = "Törlés"

            trH.append(tdNev, tdDb, tdAr, tdDel)
            thead.append(trH)

            let tbody = document.createElement("tbody")

            let sum = 0;
            for (let [key, value] of cart.entries()) {
                let item = getItem(key);
                sum += value * item.ar

                let name = document.createElement("td")
                name.textContent = item.nev

                let q = document.createElement("td")
                q.textContent = new Intl.NumberFormat('hu-HU').format(value) + " db "

                let minus = document.createElement("button")
                minus.textContent = "-"
                minus.classList.add("btn", "btn-secondary")
                minus.onclick = function () {
                    if (cart.has(item.id)) {
                        cart.set(item.id, cart.get(item.id) - 1);
                    }
                    if(cart.get(item.id) === 0)
                    {
                        cart.delete(item.id)
                    }
                    showCart()
                }
                let tdMin = document.createElement("td")
                tdMin.append(minus)

                let plus = document.createElement("button")
                plus.textContent = "+"
                plus.classList.add("btn", "btn-secondary")
                plus.onclick = function () {
                    if (cart.has(item.id)) {
                        cart.set(item.id, cart.get(item.id) + 1);
                    }
                    showCart()
                }
                let tdPlus = document.createElement("td")
                tdPlus.append(plus)

                let price = document.createElement("td")
                price.textContent = new Intl.NumberFormat('hu-HU').format((value * item.ar)) + " Ft"

                let deleteBtn = document.createElement("button")
                deleteBtn.classList.add("btn", "btn-danger")
                deleteBtn.textContent = "Törlés"
                deleteBtn.onclick = function () {
                    cart.delete(item.id);
                    showCart();
                };
                let del = document.createElement("td");
                del.append(deleteBtn)

                let tr = document.createElement("tr");
                tr.append(name, q, tdMin, tdPlus, price, del);
                tbody.appendChild(tr);
            }
            table.append(thead, tbody)

            let summary = document.createElement("h5");
            summary.innerHTML = `Végösszeg: ${new Intl.NumberFormat('hu-HU').format(sum)} Ft`

            modal.querySelector("#CartModalBody").innerHTML = ""
            modal.querySelector("#CartModalBody").append(table, summary);
            let BSmodal = bootstrap.Modal.getOrCreateInstance(modal);
            BSmodal.show();
        }

        // Buy Modal

        let template = document.querySelector("template").content.querySelector("form")

        function showBuy() {
            dismissCartModal()
            let modal = document.querySelector("#BuyModal");
            modal.querySelector("#BuyModalTitle").innerText = "Megrendelés";
            let table = document.createElement("table");
            table.classList.add("table", "table-striped", "text-center")

            let thead = document.createElement("thead")
            let trH = document.createElement("tr")

            let tdNev = document.createElement("th")
            tdNev.textContent = "Termék neve"

            let tdDb = document.createElement("th")
            tdDb.textContent = "Db"

            let tdAr = document.createElement("th")
            tdAr.textContent = "Ár"

            trH.append(tdNev, tdDb, tdAr)
            thead.append(trH)

            let tbody = document.createElement("tbody")

            let sum = 0;
            for (let [key, value] of cart.entries()) {
                let item = getItem(key);
                sum += value * item.ar

                let name = document.createElement("td")
                name.textContent = item.nev

                let q = document.createElement("td")
                q.textContent = new Intl.NumberFormat('hu-HU').format(value) + " db "

                let price = document.createElement("td")
                price.textContent = new Intl.NumberFormat('hu-HU').format((value * item.ar)) + " Ft"

                let tr = document.createElement("tr");
                tr.append(name, q, price);
                tbody.appendChild(tr);
            }
            table.append(thead, tbody)

            let summary = document.createElement("h5");
            summary.innerHTML = `Végösszeg: ${new Intl.NumberFormat('hu-HU').format(sum)} Ft`

            modal.querySelector("#BuyModalBody").innerHTML = ""
            modal.querySelector("#BuyModalBody").append(table, summary, template);
            let BSmodal = bootstrap.Modal.getOrCreateInstance(modal);
            BSmodal.show();

        }

        // Response Modal

        function showResponse() {
            dismissBuyModal()
            let modal = document.querySelector("#ResponseModal");
            modal.querySelector("#ResponseModalTitle").innerText = "Sikeres rendelés";

            let h5 = document.createElement("h5")
            h5.textContent = "Köszönjük, hogy nálunk vásárolt!"
            let p = document.createElement("p")
            p.textContent = "Rendelését rögzítettük a rendszerünkben! Kollégáink már elkezdték előkészíteni a csomagját. További információkról email-ben értesítjük."


            modal.querySelector("#ResponseModalBody").innerHTML = ""
            modal.querySelector("#ResponseModalBody").append(h5, p);
            let BSmodal = bootstrap.Modal.getOrCreateInstance(modal);
            BSmodal.show();

        }

        function getItem(id) {
            for (let item of data.data) {
                if (item.id == id) {
                    return item
                }
            }
        }


        function dismissCartModal() {
            let modal = document.querySelector("#CartModal");
            let BSmodal = bootstrap.Modal.getOrCreateInstance(modal);
            BSmodal.hide();
        }

        function dismissBuyModal() {
            let modal = document.querySelector("#BuyModal");
            let BSmodal = bootstrap.Modal.getOrCreateInstance(modal);
            BSmodal.hide();
        }

        function dismissResponseModal() {
            cart.clear()
            let modal = document.querySelector("#ResponseModal");
            let BSmodal = bootstrap.Modal.getOrCreateInstance(modal);
            BSmodal.hide();
        }
    </script>
@endsection