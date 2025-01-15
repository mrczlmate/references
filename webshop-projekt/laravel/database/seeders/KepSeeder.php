<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class KepSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('kep')->insert([
            ['url' => 'arany1.png', 'termek_id' => 1],
            ['url' => 'arany2.png', 'termek_id' => 2],
            ['url' => 'ezust1.png', 'termek_id' => 3],
            ['url' => 'ezust2.png', 'termek_id' => 4],
            ['url' => 'acel1.png', 'termek_id' => 5],
            ['url' => 'acel2.png', 'termek_id' => 6],
            ['url' => 'acel3.png', 'termek_id' => 7],
            ['url' => 'dragakoves1.png', 'termek_id' => 8],
            ['url' => 'dragakoves2.png', 'termek_id' => 9],
            ['url' => 'LOTR.png', 'termek_id' => 10],
            ['url' => 'uncharted.png', 'termek_id' => 11],
            ['url' => 'gem-set1.png', 'termek_id' => 12],
            ['url' => 'gem-set2.png', 'termek_id' => 13],
            ['url' => 'gem-set3.png', 'termek_id' => 14],
            ['url' => 'gem-set4.png', 'termek_id' => 15],
            ['url' => 'gem-set5.png', 'termek_id' => 16],
            ['url' => 'aranyora1.png', 'termek_id' => 17],
            ['url' => 'aranyora2.png', 'termek_id' => 18],
            ['url' => 'aranyora3.png', 'termek_id' => 19],
            ['url' => 'aranyora4.png', 'termek_id' => 20],
            ['url' => 'aranyora5.png', 'termek_id' => 21],
            ['url' => 'stainless1.png', 'termek_id' => 22],
            ['url' => 'stainless2.png', 'termek_id' => 23],
            ['url' => 'stainless3.png', 'termek_id' => 24],
            ['url' => 'stainless4.png', 'termek_id' => 25],
            ['url' => 'stainless5.png', 'termek_id' => 26],
            ['url' => 'platinum1.png', 'termek_id' => 27],
            ['url' => 'platinum2.png', 'termek_id' => 28],
            ['url' => 'platinum3.png', 'termek_id' => 29],
            ['url' => 'platinum4.png', 'termek_id' => 30],
            ['url' => 'platinum5.png', 'termek_id' => 31],
            ['url' => 'swarovski1.png', 'termek_id' => 32],
            ['url' => 'swarovski2.png', 'termek_id' => 33],
            ['url' => 'swarovski3.png', 'termek_id' => 34],
            ['url' => 'medal1.png', 'termek_id' => 35],
            ['url' => 'medal2.png', 'termek_id' => 36],
            ['url' => 'medal3.png', 'termek_id' => 37],
            ['url' => 'medal4.png', 'termek_id' => 38],
            ['url' => 'medal5.png', 'termek_id' => 39],
            ['url' => 'pandora1.png', 'termek_id' => 40],
            ['url' => 'pandora2.png', 'termek_id' => 41],
            ['url' => 'pandora3.png', 'termek_id' => 42],
            ['url' => 'barnagyemant1.png', 'termek_id' => 43],
            ['url' => 'barnagyemant2.png', 'termek_id' => 44],
            ['url' => 'dior1.png', 'termek_id' => 45],
            ['url' => 'dior2.png', 'termek_id' => 46],
        ]);
    }
}
