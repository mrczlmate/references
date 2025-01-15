<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreDogPicturesRequest extends FormRequest
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
            'url' => ["required", "image"],
            'dog_id' => ["required", "integer", "exists:dogs,id"]
        ];
    }

    public function messages()
    {
        return [
            "url.required" => "A(z) :attribute kitöltése kötelező.",
            "url.image" => "A(z) :attribute nem sikerült feltölteni, csak kép formátum lehet.",
            "url.uploaded" => "A(z) :attribute nem sikerült feltölteni, maximum 2MB lehet.",
            "dog_id.required" => "A(z) :attribute kitöltése kötelező.",
            "dog_id.exists" => "A(z) :attribute nem létezik.",
        ];
    }

    public function attributes()
    {
        return [
            "url" => "képet",
            "dog_id" => "kutya azonosító",
        ];
    }
}
