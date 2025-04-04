<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class UpdateDogHistoryRequest extends FormRequest
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
            'dog_id' => ["required", "exists:dogs,id"],
            'breededWith_Type' => ["required", "string", "min:2", "max:40"],
            'kidsBorn' => ["required", "integer"],
            'date' => ["required", "date"],
            'dog_id' => ["required", "integer", "exists:dogs,id"]
        ];
    }

    public function messages()
    {
        return [
            "breededWith_Type.required" => "A(z) :attribute kitöltése kötelező.",
            "breededWith_Type.min" => "A(z) :attribute legalább 2 karakter hosszú legyen.",
            "breededWith_Type.max" => "A(z) :attribute legfeljebb 40 karakter lehet.",
            "kidsBorn.required" => "A(z) :attribute kitöltése kötelező.",
            "date.required" => "A(z) :attribute kitöltése kötelező.",
            "dog_id.required" => "A(z) :attribute kitöltése kötelező.",
            "dog_id.exists" => "A(z) :attribute nem létezik.",
        ];
    }

    public function attributes()
    {
        return [
            "breededWith_Type" => "kutya fajtája",
            "kidsBorn" => "születetett kutyák száma",
            "date" => "dátum",
            "dog_id" => "kutya azonosító",
        ];
    }
}
