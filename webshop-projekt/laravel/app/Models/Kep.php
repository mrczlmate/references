<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Kep extends Model
{
    use HasFactory;
    protected $table = "kep";
    protected $primaryKey = "id";
    protected $keyType = "integer";
    public $timestamps = false;
    protected $fillable = [
        "url",
        "termek_id"
    ];

    public function termek(){
        return $this->belongsTo(Termek::class);
    }
}
