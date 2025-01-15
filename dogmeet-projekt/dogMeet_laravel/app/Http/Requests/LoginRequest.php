<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class LoginRequest extends FormRequest
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
            "email" => ["required"],
            "password" => ["required"]
        ];
    }

    public function messages()
    {
        return [
          "email.required" => "A(z) :attribute kitöltése kötelező.",
          "password.required" => "A(z) :attribute kitöltése kötelező."
        ];
    }

    public function attributes()
    {
        return [
          "email" => "email",
          "password" => "jelszó",
        ];
    }
}
