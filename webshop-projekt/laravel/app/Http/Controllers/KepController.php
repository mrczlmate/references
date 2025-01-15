<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreKepRequest;
use App\Http\Resources\KepResource;
use App\Models\Kep;
use Illuminate\Http\Request;

class KepController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return KepResource::collection(Kep::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreKepRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreKepRequest $request)
    {
        return Kep::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param  Kep $kep
     * @return Kep
     */
    public function show(Kep $kep)
    {
        return $kep;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  Kep $kep
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Kep $kep)
    {
        $data = $request->validate([
            'url' => ["required", "string", "min:2", "max:30"],
            'termek_id' => ["required", "integer"],
        ]);

        $kep->update($data);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  Kep $kep
     * @return \Illuminate\Http\Response
     */
    public function destroy(Kep $kep)
    {
        $kep->delete();
    }
}
