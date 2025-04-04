<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateKosartermekTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('kosartermek', function (Blueprint $table) {
            $table->unsignedBigInteger('termek_id');
            $table->foreign('termek_id')->references('id')->on('termek');
            $table->unsignedBigInteger('kosar_id');
            $table->foreign('kosar_id')->references('id')->on('kosar');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('kosartermek');
    }
}
