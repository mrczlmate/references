<nav class="navbar navbar-light bg_green">
    <div class="container-fluid filter">
        <div class="row" id="header">
            <h1>BMB-Webshop</h1>
            <p>Ékszerek melyek kézzel és szívvel készülnek.</p>
        </div>
        <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNavbar" aria-labelledby="offcanvasNavbarLabel">
            <div class="offcanvas-body bg_green">
                @auth
                    <form action="{{route('auth.logout')}}" method="post" class="d-flex">
                        @csrf
                        <button class="btn btn-outline-danger" type="submit">Kijelentkezés</button>
                    </form>
                @else
                    <a href="{{route('auth.login')}}" class="btn btn-success">Bejelentkezés</a>
                    <a href="{{route('register.create')}}" class="btn btn-success">Regisztráció</a>
                @endauth
                <hr>
                <h4>Szűrők</h4>
                <hr>
                <h5>Ár</h5>
                <form>
                    @csrf
                    <input type="radio" class="btn-check" name="options-outlined" id="csokkeno" autocomplete="off" checked>
                    <label class="btn btn-outline-success" for="csokkeno">Ár szerint csökkenő</label>

                    <input type="radio" class="btn-check" name="options-outlined" id="novekvo" autocomplete="off">
                    <label class="btn btn-outline-success" for="novekvo">Ár szerint növekvő</label>

                    <p><b>Min. ár:</b></p>
                    <input type="number" name="armin" id="armin" placeholder="0">
                    <p><b>Max. ár:</b></p>
                    <input type="number" name="armax" id="armax" placeholder="0">
                </form>
                <hr>
                <a class="btn btn-success" onclick="OrderByPrice('ar','desc')">Szűrés</a>
                <hr>
                <h4>Kapcsolat</h4>
                <hr>
                <p>Tel:</p>
                <p>06 30 420 0420</p>
                <hr>
                <p>Email:</p>
                <p>bmbshop@gmail.com</p>
                <hr>
                <p>Cím</p>
                <p>A legtöbb helyi sikátor</p>
            </div>
        </div>
    </div>
</nav>

