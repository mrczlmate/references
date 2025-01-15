<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class ProfileSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {   
        DB::table('profile')->insert([
            'id' => 1,
            'user_id' => 1,
            'firstName' => 'Admin',
            'lastName' => 'Admin',
            'phoneNumber' => '+361234569'
        ]);

        DB::table('profile')->insert([
            'id' => 2,
            'user_id' => 2,
            'firstName' => 'Alabárd',
            'lastName' => 'Nagy',
            'phoneNumber' => '06301237894'
        ]);
        
        DB::table('profile')->insert([
            'id' => 3,
            'user_id' => 3,
            'firstName' => 'Ádám',
            'lastName' => 'Bajor',
            'phoneNumber' => '06208945647'
        ]);

        DB::table('profile')->insert([
            'id' => 4,
            'user_id' => 4,
            'firstName' => 'Máté',
            'lastName' => 'Merczel',
            'phoneNumber' => '+361457894'
        ]);
    }
}
