<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreRegisterAddressRequest;
use App\Http\Requests\StoreRegisterDogRequest;
use App\Http\Requests\StoreRegisterProfileRequest;
use App\Models\Address;
use App\Models\Dog;
use App\Models\Profile;

class UpdateDatasController extends Controller
{
    public function profileupdate(StoreRegisterProfileRequest $request, Profile $profile)
    {
        $profile->update($request->validated());

        return redirect()->route("profile");
    }

    public function addressupdate(StoreRegisterAddressRequest $request, Address $address)
    {
        $address->update($request->validated());

        return redirect()->route("profile");
    }

    public function dogupdate(StoreRegisterDogRequest $request, Dog $dog)
    {
        $dog->update($request->validated());

        return redirect()->route("owneddog");
    }
}
