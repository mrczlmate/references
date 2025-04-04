<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class DogHistorySeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('dog_history')->insert([
            'id' => 1,
            'breededWith_Type' => 'Pitbull',
            'kidsBorn' => 4,
            'date' => '2020-06-08',
            'dog_id' => 1,
        ]);

        DB::table('dog_history')->insert([
            'id' => 2,
            'breededWith_Type' => 'Labrador',
            'kidsBorn' => 5,
            'date' => '2017-09-24',
            'dog_id' => 1,
        ]);

        DB::table('dog_history')->insert([
            'id' => 3,
            'breededWith_Type' => 'Német juhász',
            'kidsBorn' => 2,
            'date' => '2019-11-02',
            'dog_id' => 3,
        ]);
    }
}
