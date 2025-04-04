<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreFriendRequest;
use App\Http\Requests\UpdateFriendRequest;
use App\Http\Resources\FriendResource;
use App\Models\Friend;
use Illuminate\Http\Request;

class FriendController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Resources\Json\AnonymousResourceCollection
     */
    public function index()
    {
        return FriendResource::collection(Friend::all());
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param StoreFriendRequest $request
     * @return string[]
     */
    public function store(StoreFriendRequest $request)
    {
        $friend = $request->validated();

        $user_friend = Friend::where('user_id', "=", $friend["user_id"])->where('friend_id', "=", $friend["friend_id"])->count();
        $friend_user = Friend::where('user_id', "=", $friend["friend_id"])->where('friend_id', "=", $friend["user_id"])->count();
        if ($user_friend > 0 || $friend_user > 0)
        {
            return ["message" => "Már barátok vagytok!"];
        }
        else
        {
            return Friend::create($friend);
        }
    }

    /**
     * Display the specified resource.
     *
     * @param Friend $friend
     * @return Friend
     */
    public function show(Friend $friend)
    {
        return $friend;
    }

    /**
     * Update the specified resource in storage.
     *
     * @param UpdateFriendRequest $request
     * @param Friend $friend
     */
    public function update(UpdateFriendRequest $request, Friend $friend)
    {
        $friend->update($request->validated());
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param Friend $friend
     */
    public function destroy(Friend $friend)
    {
        $friend->delete();
    }
}
