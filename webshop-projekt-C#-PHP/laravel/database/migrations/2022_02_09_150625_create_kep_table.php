<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateKepTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('kep', function (Blueprint $table) {
            $table->id();
            $table->string('url', 30);
            $table->unsignedBigInteger('termek_id');
            $table->foreign('termek_id')->references('id')->on('termek');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('kep');
    }
}
