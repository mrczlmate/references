<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreFriendRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    public function rules()
    {
        return [
            'user_id' => ["required", "integer", "exists:users,id"],
            'friend_id' => ["required", "integer", "exists:users,id"],
        ];
    }

    public function messages()
    {
        return [
            "user_id.required" => "A(z) :attribute kitöltése kötelező.",
            "user_id.exists" => "A(z) :attribute nem létezik.",
            "friend_id.required" => "A(z) :attribute kitöltése kötelező.",
            "friend_id.exists" => "A(z) :attribute nem létezik.",
        ];
    }

    public function attributes()
    {
        return [
            "user_id" => "tulajdonos azonosító",
            "friend_id" => "barát azonosító",
        ];
    }
}
