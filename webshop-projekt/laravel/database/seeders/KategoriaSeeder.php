<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class KategoriaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('kategoria')->insert([
            ['megnevezes' => 'Gyűrű', 'szulokategoria_id' => null],
            ['megnevezes' => 'Óra', 'szulokategoria_id' => null],
            ['megnevezes' => 'Nyaklánc', 'szulokategoria_id' => null],
            ['megnevezes' => 'Arany gyűrűk', 'szulokategoria_id' => 1],
            ['megnevezes' => 'Ezüst gyűrűk', 'szulokategoria_id' => 1],
            ['megnevezes' => 'Acél gyűrűk', 'szulokategoria_id' => 1],
            ['megnevezes' => 'Drágakőberakásos gyűrűk', 'szulokategoria_id' => 1],
            ['megnevezes' => 'Különlegességek', 'szulokategoria_id' => 1],
            ['megnevezes' => 'Gem-set', 'szulokategoria_id' => 2],
            ['megnevezes' => 'Arany óra', 'szulokategoria_id' => 2],
            ['megnevezes' => 'Stainless steel', 'szulokategoria_id' => 2],
            ['megnevezes' => 'Platinum óra', 'szulokategoria_id' => 2],
            ['megnevezes' => 'Swarovski', 'szulokategoria_id' => 3],
            ['megnevezes' => 'nyaklánc medál', 'szulokategoria_id' => 3],
            ['megnevezes' => 'Pandora', 'szulokategoria_id' => 3],
            ['megnevezes' => 'Barna gyémánt', 'szulokategoria_id' => 3],
            ['megnevezes' => 'Dior', 'szulokategoria_id' => 3],
        ]);
    }
}
