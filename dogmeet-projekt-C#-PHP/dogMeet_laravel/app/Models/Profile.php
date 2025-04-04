<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Profile extends Model
{
    use HasFactory;

    protected $table = "profile";
    public $timestamps = false;
    protected $fillable = [
        "user_id",
        "firstName",
        "lastName",
        "phoneNumber",
        "positiveReviews",
        "negativeReviews",
    ];

    public function address()
    {
        return $this->hasOne(Address::class);
    }

    public function user()
    {
        return $this->belongsTo(User::class);
    }
}
