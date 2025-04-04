<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateTermekTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('termek', function (Blueprint $table) {
            $table->id();
            $table->string('nev', 100);
            $table->text('leiras');
            $table->integer('ar');
            $table->integer('mennyiseg');
            $table->unsignedBigInteger('kategoria_id');
            $table->foreign('kategoria_id')->references('id')->on('kategoria');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('termek');
    }
}
