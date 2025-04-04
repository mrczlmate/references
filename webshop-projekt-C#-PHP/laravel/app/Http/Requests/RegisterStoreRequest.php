<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class RegisterStoreRequest extends FormRequest
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
            "name" => ["required", "unique:users", "max:255"],
            "telefon" => ["max:15", "min:2"],
            "email" => ["required", "unique:users", "max:255"],
            "password" => ["required", "confirmed", "min:8" , "max:255"]
        ];
    }
}
