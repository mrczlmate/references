<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreDogHistoryRequest;
use App\Http\Requests\UpdateDogHistoryRequest;
use App\Http\Resources\DogHistoryResource;
use App\Models\Dog;
use App\Models\DogHistory;
use Illuminate\Http\Request;

class DogHistoryController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return DogHistoryResource::collection(DogHistory::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreDogHistoryRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreDogHistoryRequest $request)
    {
        return DogHistory::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param DogHistory $dogHistory
     * @return DogHistory
     */
    public function show(DogHistory $doghistory)
    {
        return $doghistory;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param UpdateDogHistoryRequest $request
     * @param DogHistory $dogHistory
     */
    public function update(UpdateDogHistoryRequest $request, DogHistory $doghistory)
    {
        $doghistory->update($request->validated());
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param DogHistory $dogHistory
     */
    public function destroy(DogHistory $doghistory)
    {
        $doghistory->delete();
    }

    public function doghistories(Dog $dog)
    {
        return $dog->histories;
    }
}
