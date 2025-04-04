@extends('layout.main')

@section('title', 'DogMeet | Profil')

@section('content')
    <div class="container containerStyle">

        @include('layout.header')

        @include('layout.navbar')

        <h1 class="text-center my-4 white">Személyes adataim:</h1>
        <div class="row">
            <div class="col-10 offset-1 col-md-8 offset-md-2">
                <table class="table profilePageTables">
                    <tr>
                        <th>Vezetéknév:</th>
                        <td>{{$user->profile->lastName}}</td>
                    </tr>
                    <tr>
                        <th>Keresztnév:</th>
                        <td>{{$user->profile->firstName}}</td>
                    </tr>
                    <tr>
                        <th>Telefonszám:</th>
                        <td>{{$user->profile->phoneNumber}}</td>
                    </tr>
                </table>
                <button class="btn mx-auto d-block  mt-5 brownBtn" onclick="showProfile()">Módosítás</button>
            </div>
        </div>

        <h1 class="text-center my-4 white">Cím adataim:</h1>
        <div class="row">
            <div class="col-10 offset-1 col-md-8 offset-md-2">
                <table class="table profilePageTables">
                    <tr>
                        <th>Ország:</th>
                        <td>{{$user->profile->address->country}}</td>
                    </tr>
                    <tr>
                        <th>Megye:</th>
                        <td>{{$user->profile->address->state}}</td>
                    </tr>
                    <tr>
                        <th>Város:</th>
                        <td>{{$user->profile->address->city}}</td>
                    </tr>
                    <tr>
                        <th>Irányítószám:</th>
                        <td>{{$user->profile->address->zip}}</td>
                    </tr>
                    <tr>
                        <th>Utca:</th>
                        <td>{{$user->profile->address->street}}</td>
                    </tr>
                    <tr>
                        <th>Házszám:</th>
                        <td>{{$user->profile->address->houseNumber}}</td>
                    </tr>
                </table>
                <button class="btn mx-auto d-block my-5 brownBtn" onclick="showAddress()">Módosítás</button>
            </div>
        </div>
    </div>
    @include('layout.footer')

    @include('components.profileModal')

    @include('components.addressModal')

@endsection

@section('innerJS')
    <script src="{{asset('js/Modals.js')}}"></script>
@endsection