<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreDogHistoryRequest;
use App\Http\Requests\StoreDogPicturesRequest;
use App\Http\Requests\StoreRegisterDogRequest;
use App\Models\Dog;
use App\Models\DogHistory;
use App\Models\DogPictures;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Validation\Rule;

class StoreDatasController extends Controller
{
    public function storedog(StoreRegisterDogRequest $request)
    {
        $data = $request->validated()
            + ["owner_id" => Auth::id()];

        Dog::create($data);

        return redirect()->route("owneddog");
    }

    public function storedoghistory(StoreDogHistoryRequest $request)
    {
        $data = $request->validated();

        DogHistory::create($data);

        return redirect()->route("owneddog");
    }

    public function dogpictures(StoreDogPicturesRequest $request)
    {
        $data = $request->validated();
        $filename = $data["url"]->store("images");
        $data["url"] = $filename;

        if(DogPictures::where("dog_id", $data["dog_id"])->first())
        {
            $dogpicture = DogPictures::where("dog_id", $data["dog_id"]);

            $dogpicture->update($data);
        }
        else
        {
            DogPictures::create($data);
        }

        return redirect()->route('owneddog');
    }
}
