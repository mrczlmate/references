<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreRegisterAddressRequest;
use App\Http\Requests\StoreRegisterDogRequest;
use App\Http\Requests\StoreRegisterProfileRequest;
use App\Http\Requests\StoreRegisterRequest;
use App\Models\Address;
use App\Models\Dog;
use App\Models\Profile;
use App\Models\User;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;

class RegisterController extends Controller
{
    public function create(){
        return view("authentication.registerpageone");
    }

    public function store(StoreRegisterRequest $request)
    {
        $data = $request->validated();
        $data["password"] = Hash::make($data["password"]);
        $user = User::create($data);

        Auth::login($user);

        $request->session()->flash("success", "Sikeres regisztrálás");
        return redirect()->route("registertwo.show");

    }

    public function storeprofile(StoreRegisterProfileRequest $request)
    {
        $data = $request->validated() + ["user_id" => Auth::id()];
        Profile::create($data);

        $request->session()->flash("success", "Sikeres profil megadás");

        return redirect()->route("registerthree.show");
    }

    public function storeaddress(StoreRegisterAddressRequest $request)
    {
        $data = $request->validated() + ["profile_id" => Auth::user()->profile->id];
        Address::create($data);

        $request->session()->flash("success", "Sikeres cím megadás");

        return redirect()->route("registerfour.show");
    }

    public function storedog(StoreRegisterDogRequest $request)
    {
        $data = $request->validated()  + ["owner_id" => Auth::id()];

        Dog::create($data);

        $request->session()->flash("success", "Sikeres első kutya felvétele");

        return redirect()->route("owneddog");
    }
}
