<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class DogPictures extends Model
{
    use HasFactory;

    protected $table = "dog_pictures";
    public $timestamps = false;
    protected $fillable = [
        "url",
        "dog_id"
    ];

    public function dog()
    {
        return $this->belongsTo(Dog::class);
    }
}
