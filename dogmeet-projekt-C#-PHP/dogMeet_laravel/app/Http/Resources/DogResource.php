<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class DogResource extends JsonResource
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
            'name' => $this->name,
            'age' => $this->age,
            'type' => $this->type,
            'gender' => $this->gender,
            'description' => $this->description,
            'ownerUsername' => $this->user->username,
            'owner_id' => $this->user->id,
            'owner_profileid' => $this->user->profile->id,
            'url' => $this->pictures->url ?? ""
        ];
    }
}
