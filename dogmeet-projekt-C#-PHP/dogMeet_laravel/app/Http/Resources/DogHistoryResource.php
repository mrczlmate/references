<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class DogHistoryResource extends JsonResource
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
            'breededWith_Type' => $this->breededWith_Type,
            'kidsBorn' => $this->kidsBorn,
            'date' => $this->date,
            'dogName' => $this->dog->name,
            'dog_id' => $this->dog_id
        ];
    }
}
