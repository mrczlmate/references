<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreKategoriaRequest;
use App\Http\Resources\KategoriaResource;
use App\Models\Kategoria;
use Illuminate\Http\Request;

class KategoriaController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return KategoriaResource::collection(Kategoria::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreKategoriaRequest $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreKategoriaRequest $request)
    {
        return Kategoria::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param  Kategoria $kategoria
     * @return Kategoria
     */
    public function show(Kategoria $kategoria)
    {
        return $kategoria;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Kategoria $kategoria)
    {
        $data = $request->validate([
            'megnevezes' => ["required", "string", "min:2", "max:30"],
            'szulokategoria_id' => ["integer", "nullable"],
        ]);

        $kategoria->update($data);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param Kategoria $kategoria
     * @return \Illuminate\Http\Response
     */
    public function destroy(Kategoria $kategoria)
    {
        $kategoria->delete();
    }
}
