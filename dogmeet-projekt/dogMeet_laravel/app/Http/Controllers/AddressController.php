<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreAddressRequest;
use App\Http\Requests\UpdateAddressRequest;
use App\Http\Resources\AddressResource;
use App\Models\Address;
use Illuminate\Http\Request;

class AddressController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return AddressResource::collection(Address::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreAddressRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreAddressRequest $request)
    {
        return Address::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param Address $address
     * @return Address
     */
    public function show(Address $address)
    {
        return $address;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param UpdateAddressRequest $request
     * @param Address $address
     */
    public function update(UpdateAddressRequest $request, Address $address)
    {
        $address->update($request->validated());
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param Address $address
     */
    public function destroy(Address $address)
    {
        $address->delete();
    }
}
