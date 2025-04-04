<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class TermekResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return [
            'id' => $this->id,
            'nev' => $this->nev,
            'leiras' => $this->leiras,
            'ar' => $this->ar,
            'url' =>  $this->kep->url ?? "",
            'mennyiseg' => $this->mennyiseg,
            'kategoria_id' => $this->kategoria_id
        ];
    }
}
