<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class DogSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('dogs')->insert([
            'id' => 1,
            'name' => 'Bodri',
            'age' => 8,
            'type' => 'Puli',
            'gender' => 'kan',
            'description' => 'Szép állat',
            'owner_id' => 2,
        ]);

        DB::table('dogs')->insert([
            'id' => 2,
            'name' => 'Pötty',
            'age' => 2,
            'type' => 'Csivava',
            'gender' => 'szuka',
            'description' => 'Apró, de fürge.',
            'owner_id' => 3,
        ]);

        DB::table('dogs')->insert([
            'id' => 3,
            'name' => 'Loki',
            'age' => 4,
            'type' => 'Bullmastif',
            'gender' => 'kan',
            'description' => 'Nagy, erős vadász állat.',
            'owner_id' => 4,
        ]);
    }
}
