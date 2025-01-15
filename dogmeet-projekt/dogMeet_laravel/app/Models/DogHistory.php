<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class DogHistory extends Model
{
    use HasFactory;

    protected $table = "dog_history";
    public $timestamps = false;
    protected $fillable = [
        "breededWith_Type",
        "kidsBorn",
        "date",
        "dog_id"
    ];

    public function dog()
    {
        return $this->belongsTo(Dog::class);
    }
}
