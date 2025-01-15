<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreTermekRequest;
use App\Models\Termek;
use Illuminate\Http\Request;
use App\Http\Resources\TermekResource;
use Illuminate\Support\Facades\DB;

class TermekController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return Termek[]|\Illuminate\Database\Eloquent\Collection|\Illuminate\Http\Response
     */
    public function index(Request $request)
    {   
        $orderby = $request->input('orderBy');
        $order = $request->input('order');
        if(!is_null($orderby) && !is_null($order)){
            return TermekResource::collection(Termek::with("kep")->orderBy($orderby, $order)->get());
            // return TermekResource::collection(DB::table('termek')->join('kep','termek.id', '=', 'kep.termek_id')->orderBy($orderby, $order)->get());
        }
        return TermekResource::collection(Termek::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreTermekRequest $request)
    {
        return Termek::create($request->validated());
    }

    /**
     * Display the specified resource.
     *
     * @param  Termek $termek
     * @return Termek
     */
    public function show(Termek $termek)
    {
        return $termek;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  Termek $termek
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Termek $termek)
    {
        $data = $request->validate([
            'nev' => ["required", "string", "min:2", "max:100"],
            'leiras' => ["required", "string"],
            'ar' => ["required", "integer"],
            'mennyiseg' => ["required", "integer"],
            'kategoria_id' => ["required", "exists:kategoria,id"]
        ]);

        $termek->update($data);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  Termek $termek
     * @return \Illuminate\Http\Response
     */
    public function destroy(Termek $termek)
    {
        $termek->delete();
    }
}
