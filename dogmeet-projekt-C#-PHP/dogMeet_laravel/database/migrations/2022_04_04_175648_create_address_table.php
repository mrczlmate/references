<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateAddressTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('address', function (Blueprint $table) {
            $table->id();
            $table->foreignId('profile_id')->constrained('profile')->onDelete('cascade');
            $table->string('country', 40)->default("ismeretlen");
            $table->string('state', 40)->default("ismeretlen");
            $table->string('city', 40)->default("ismeretlen");
            $table->integer('zip')->default(0);
            $table->string('street', 100)->default("ismeretlen");
            $table->integer('houseNumber')->default(0);
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('address');
    }
}
