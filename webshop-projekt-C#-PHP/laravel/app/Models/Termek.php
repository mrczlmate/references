<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Termek extends Model
{
    use HasFactory;
    protected $table = "termek";
    protected $primaryKey = "id";
    protected $keyType = "integer";
    public $timestamps = false;
    protected $fillable = [
        "nev",
        "leiras",
        "ar",
        "mennyiseg",
        "kategoria_id"
    ];

    public function kep(){
        return $this->hasOne(Kep::class, 'termek_id');
    }
}
