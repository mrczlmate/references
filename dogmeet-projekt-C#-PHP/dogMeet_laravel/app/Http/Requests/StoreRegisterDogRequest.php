<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Validation\Rule;

class StoreRegisterDogRequest extends FormRequest
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
            'name' => ["required", "string", "min:2", "max:30"],
            'age' => ["required", "integer"],
            'type' => ["required", "string", "min:2", "max:40"],
            'gender' => ["required", Rule::in(['kan', 'szuka'])],
            'description' => ["required", "string", "min:2", "max:250"],
        ];
    }

    public function messages()
    {
        return [
            "name.required" => "A(z) :attribute kitöltése kötelező.",
            "name.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "name.max" => "A(z) :attribute legfeljebb 30 karakter lehet.",
            "age.required" => "A(z) :attribute kitöltése kötelező.",
            "type.required" => "A(z) :attribute kitöltése kötelező.",
            "type.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "type.max" => "A(z) :attribute legfeljebb 40 karakter lehet.",
            "gender.required" => "A(z) :attribute kitöltése kötelező.",
            "gender.rule" => "A(z) :attribute csak 'kan' vagy 'szuka' lehet.",
            "description.required" => "A(z) :attribute kitöltése kötelező.",
            "description.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "description.max" => "A(z) :attribute legfeljebb 250 karakter lehet.",
        ];
    }

    public function attributes()
    {
        return [
            "name" => "kutya neve",
            "age" => "kutya kora",
            "type" => "kutya fajtája",
            "gender" => "kutya neme",
            "description" => "kutya leírása",
        ];
    }
}
