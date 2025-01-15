<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class FriendResource extends JsonResource
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
            'user_id' => $this->user_id,
            'friend_id' => $this->friend_id,
            'user_firstName' => $this->user->profile->firstName,
            'user_lastName' => $this->user->profile->lastName,
            'user_profId' => $this->user->profile->id,
            'friend_firstName' => $this->friend->profile->firstName,
            'friend_lastName' => $this->friend->profile->lastName,
            'friend_profId' => $this->friend->profile->id,
        ];
    }
}
