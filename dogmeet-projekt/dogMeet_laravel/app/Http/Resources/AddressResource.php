<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class AddressResource extends JsonResource
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
            'profile_id' => $this->profile_id,
            'profileName' => $this->profile->fullName,
            'country' => $this->country,
            'state' => $this->state,
            'city' => $this->city,
            'zip' => $this->zip,
            'street' => $this->street,
            'houseNumber' => $this->houseNumber,
        ];
    }
}
