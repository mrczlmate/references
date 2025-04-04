<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreDogRequest;
use App\Http\Requests\UpdateDogRequest;
use App\Http\Resources\DogResource;
use App\Models\Dog;
use App\Models\User;
use Illuminate\Http\Request;

class DogController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return DogResource::collection(Dog::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreDogRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreDogRequest $request)
    {
        return Dog::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param Dog $dog
     * @return Dog
     */
    public function show(Dog $dog)
    {
        return $dog;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param UpdateDogRequest $request
     * @param Dog $dog
     */
    public function update(UpdateDogRequest $request, Dog $dog)
    {
        $dog->update($request->validated());
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param Dog $dog
     */
    public function destroy(Dog $dog)
    {
        $dog->delete();
    }

    public function mydogs(User $user)
    {
        return DogResource::collection($user->dogs);
    }
}
