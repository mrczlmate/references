<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateDogHistoryTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('dog_history', function (Blueprint $table) {
            $table->id();
            $table->string('breededWith_Type', 40);
            $table->integer('kidsBorn');
            $table->date('date');
            $table->foreignId('dog_id')->constrained('dogs')->onDelete('cascade');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('dog_history');
    }
}
