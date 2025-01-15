<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Validation\Rule;

class StoreTermekRequest extends FormRequest
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
            'nev' => ["required", "string", "min:2", "max:100"],
            'leiras' => ["required", "string"],
            'ar' => ["required", "integer"],
            'mennyiseg' => ["required", "integer"],
            'kategoria_id' => ["required", "exists:kategoria,id"]
        ];
    }
}
