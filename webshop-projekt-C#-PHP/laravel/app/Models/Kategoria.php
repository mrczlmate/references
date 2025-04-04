<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Kategoria extends Model
{
    use HasFactory;
    protected $table = "kategoria";
    protected $primaryKey = "id";
    protected $keyType = "integer";
    public $timestamps = false;
    protected $fillable = [
        "megnevezes",
        "szulokategoria_id"
    ];
}
