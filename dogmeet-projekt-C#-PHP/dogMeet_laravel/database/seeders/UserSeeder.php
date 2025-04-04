<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;
use Carbon\Carbon;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('users')->insert([
            'id' => 1,
            'username' => 'admin',
            'email' => 'admin@admin.hu',
            'password' => Hash::make('DogMeetAdmin48'),
            'created_at' => Carbon::now()->format('Y-m-d H:i:s'),
            'updated_at' => Carbon::now()->format('Y-m-d H:i:s')
        ]);

        DB::table('users')->insert([
            'id' => 2,
            'username' => 'Nagy Alabárd',
            'email' => 'ali@gmail.com',
            'password' => Hash::make('alabardnagy11'),
            'created_at' => Carbon::now()->format('Y-m-d H:i:s'),
            'updated_at' => Carbon::now()->format('Y-m-d H:i:s')
        ]);

        DB::table('users')->insert([
            'id' => 3,
            'username' => 'Bajor Ádám',
            'email' => 'adambajor@gmail.com',
            'password' => Hash::make('bajoradiadibajor'),
            'created_at' => Carbon::now()->format('Y-m-d H:i:s'),
            'updated_at' => Carbon::now()->format('Y-m-d H:i:s')
        ]);

        DB::table('users')->insert([
            'id' => 4,
            'username' => 'Merczel Máté',
            'email' => 'mathias@dogmeet.hu',
            'password' => Hash::make('MLikeMinecraft'),
            'created_at' => Carbon::now()->format('Y-m-d H:i:s'),
            'updated_at' => Carbon::now()->format('Y-m-d H:i:s')
        ]);
    }
}
