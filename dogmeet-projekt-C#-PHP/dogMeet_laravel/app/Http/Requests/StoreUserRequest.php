<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreUserRequest extends FormRequest
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
            'username' => ["required", "string", "unique:users,username", "max:255"],
            'email' => ["required", "string", "unique:users,email", "max:255"],
            'password' => ["required", "confirmed", "min:8" , "max:255"],
        ];
    }

    public function messages()
    {
        return [
            "username.required" => "A(z) :attribute kitöltése kötelező.",
            "username.unique" => "A(z) :attribute már foglalt.",
            "username.max" => "A(z) :attribute legfeljebb 255 karakter lehet.",
            "email.required" => "A(z) :attribute kitöltése kötelező.",
            "email.unique" => "A(z) :attribute már foglalt.",
            "email.max" => "A(z) :attribute legfeljebb 255 karakter lehet.",
            "password.required" => "A(z) :attribute kitöltése kötelező.",
            "password.min" => "A(z) :attribute legalább 8 karakter hosszú legyen.",
            "password.max" => "A(z) :attribute legfeljebb 255 karakter lehet.",
            "password.confirmed" => "A(z) :attribute nem egyezik.",
        ];
    }

    public function attributes()
    {
        return [
            "username" => "felhasználónév",
            "email" => "email",
            "password" => "jelszó",
        ];
    }
}
