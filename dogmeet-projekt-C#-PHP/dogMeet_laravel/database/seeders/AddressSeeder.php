<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class AddressSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('address')->insert([
            'id' => 1,
            'profile_id' => 1,
            'country' => 'Zed',
            'state' => 'Zed',
            'city' => 'Zed',
            'zip' => 1234,
            'street' => 'Zed Street',
            'houseNumber' => 1
        ]);

        DB::table('address')->insert([
            'id' => 2,
            'profile_id' => 2,
            'country' => 'Magyarország',
            'state' => 'Pest megye',
            'city' => 'Budapest',
            'zip' => 1134,
            'street' => 'Alma utca',
            'houseNumber' => 3
        ]);
        
        DB::table('address')->insert([
            'id' => 3,
            'profile_id' => 3,
            'country' => 'Románia',
            'state' => 'Bihar',
            'city' => 'Nagyvárad',
            'zip' => 4321,
            'street' => 'Fő út',
            'houseNumber' => 32
        ]);

        DB::table('address')->insert([
            'id' => 4,
            'profile_id' => 4,
            'country' => 'Magyarország',
            'state' => 'Pest Megye',
            'city' => 'Monor',
            'zip' => 2344,
            'street' => 'Petőfi utca',
            'houseNumber' => 21
        ]);
    }
}
