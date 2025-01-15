<div class="navbarStyle">
    <div class="navbarItems">
        <div class="navbarImg">
            <a href="{{route('homepage')}}">
                <img src="{{asset('img/home.png')}}" alt="" title="Főoldal">
                <p class="navbarText">Főoldal</p>
            </a>
        </div>
        <div class="navbarImg">
            <a href="{{route('profile')}}">
                <img src="{{asset('img/profile.png')}}" alt="" title="Profilom">
                <p class="navbarText">Profilom</p>
            </a>
        </div>
        <div class="navbarImg">
            <a href="{{route('friends')}}">
                <img src="{{asset('img/friends.png')}}" alt="" title="Barátok">
                <p class="navbarText">Kapcsolatok</p>
            </a>
        </div>
        <div class="navbarImg">
            <a href="{{route('owneddog')}}">
                <img src="{{asset('img/owneddogs.png')}}" alt="" title="Saját kutyáim">
                <p class="navbarText">Kutyáim</p>
            </a>
        </div>
        <form action="{{route('auth.logout')}}" method="post" class="logoutStyle">
            @csrf
            <button class="btn logoutImg" type="submit" id="logout"><img src="{{asset('img/logout.png')}}" alt="" title="Kilépés"></button>
            <p class="navbarText">Kijelentkezés</p>
        </form>
    </div>
</div>