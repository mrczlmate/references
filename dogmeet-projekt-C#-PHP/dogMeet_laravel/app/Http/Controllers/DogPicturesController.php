<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreDogPicturesRequest;
use App\Http\Requests\UpdateDogPicturesRequest;
use App\Http\Resources\DogPicturesResource;
use App\Models\DogPictures;
use Illuminate\Http\Request;

class DogPicturesController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return DogPicturesResource::collection(DogPictures::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreDogPicturesRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreDogPicturesRequest $request)
    {
        return DogPictures::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param DogPictures $dogPictures
     * @return DogPictures
     */
    public function show(DogPictures $dogpictures)
    {
        return $dogpictures;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param UpdateDogPicturesRequest $request
     * @param DogPictures $dogPictures
     */
    public function update(UpdateDogPicturesRequest $request, DogPictures $dogpictures)
    {
        $dogpictures->update($request->validated());
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param DogPictures $dogPictures
     */
    public function destroy(DogPictures $dogpictures)
    {
        $dogpictures->delete();
    }
}
