<?php

namespace App\Http\Controllers;

use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\Auth;
use App\Http\Requests\StoreProfileRequest;
use App\Http\Requests\UpdateProfileRequest;
use App\Http\Resources\ProfileResource;
use App\Models\Profile;
use Illuminate\Http\Request;

class ProfileController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return ProfileResource::collection(Profile::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreProfileRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreProfileRequest $request)
    {
        Log::debug($request->getContent());
        return Profile::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param Profile $profile
     * @return ProfileResource
     */
    public function show(Profile $profile)
    {
        return new ProfileResource($profile);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param UpdateProfileRequest $request
     * @param Profile $profile
     */
    public function update(UpdateProfileRequest $request, Profile $profile)
    {
        $profile->update($request->validated());
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param Profile $profile
     */
    public function destroy(Profile $profile)
    {
        $profile->delete();
    }
}
