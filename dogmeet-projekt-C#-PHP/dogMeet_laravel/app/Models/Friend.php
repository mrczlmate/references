<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Friend extends Model
{
    use HasFactory;
    protected $table = "friends";
    public $timestamps = false;
    protected $fillable = [
        "user_id",
        "friend_id"
    ];

    public function user()
    {
        return $this->belongsTo(User::class, 'user_id', 'id');
    }

    public function friend()
    {
        return $this->belongsTo(User::class, "friend_id", "id");
    }
}
