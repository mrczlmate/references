<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreRegisterAddressRequest extends FormRequest
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
            'country' => ["required", "string", "min:2", "max:40"],
            'state' => ["required", "string", "min:2", "max:40"],
            'city' => ["required", "string", "min:2", "max:40"],
            'zip' => ["required", "integer"],
            'street' => ["required", "string", "min:2", "max:100"],
            'houseNumber' => ["required", "integer"],
        ];
    }

    public function messages()
    {
        return [
            "country.required" => "A(z) :attribute kitöltése kötelező.",
            "country.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "country.max" => "A(z) :attribute legfeljebb 40 karakter lehet.",
            "state.required" => "A(z) :attribute kitöltése kötelező.",
            "state.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "state.max" => "A(z) :attribute legfeljebb 40 karakter lehet.",
            "city.required" => "A(z) :attribute kitöltése kötelező.",
            "city.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "city.max" => "A(z) :attribute legfeljebb 40 karakter lehet.",
            "zip.required" => "A(z) :attribute kitöltése kötelező.",
            "street.required" => "A(z) :attribute kitöltése kötelező.",
            "street.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "street.max" => "A(z) :attribute legfeljebb 100 karakter lehet.",
            "houseNumber.required" => "A(z) :attribute kitöltése kötelező.",
        ];
    }

    public function attributes()
    {
        return [
            "country" => "ország",
            "state" => "megye",
            "city" => "város",
            "zip" => "irányítószám",
            "street" => "utca",
            "houseNumber" => "házszám",
        ];
    }
}
