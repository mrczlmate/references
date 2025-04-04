<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class FriendsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('friends')->insert([
            'user_id' => 2,
            'friend_id' => 3,
            'id' => 1,
        ]);

        DB::table('friends')->insert([
            'user_id' => 2,
            'friend_id' => 4,
            'id' => 2,
        ]);
    }
}
