<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Dog extends Model
{
    use HasFactory;

    protected $table = "dogs";
    public $timestamps = false;
    protected $fillable = [
        "name",
        "age",
        "type",
        "gender",
        "description",
        "owner_id"
    ];

    public function user()
    {
        return $this->belongsTo(User::class, "owner_id", "id");
    }

    public function pictures()
    {
        return $this->hasOne(DogPictures::class, 'dog_id', 'id');
    }

    public function histories()
    {
        return $this->hasMany(DogHistory::class);
    }
}
