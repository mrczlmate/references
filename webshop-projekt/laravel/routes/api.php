<?php

use App\Http\Controllers\KategoriaController;
use App\Http\Controllers\KepController;
use App\Http\Controllers\TermekController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

//Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
//    return $request->user();
//});


Route::get('/termek', [TermekController::class, 'index'])
    ->name('termek.index');
Route::get('/termek/{termek}', [TermekController::class, 'show'])
    ->name('termek.show');
Route::post('/termek', [TermekController::class, 'store'])
    ->name('termek.store');
Route::put('/termek/{termek}', [TermekController::class, 'update'])
    ->name('termek.update');
Route::delete('/termek/{termek}', [TermekController::class, 'destroy'])
    ->name('termek.destroy');

Route::get('/kep', [KepController::class, 'index'])
    ->name('kep.index');
Route::get('/kep/{kep}', [KepController::class, 'show'])
    ->name('kep.show');
Route::post('/kep', [KepController::class, 'store'])
    ->name('kep.store');
Route::put('/kep/{kep}', [KepController::class, 'update'])
    ->name('kep.update');
Route::delete('/kep/{kep}', [KepController::class, 'destroy'])
    ->name('kep.destroy');

Route::get('/kategoria', [KategoriaController::class, 'index'])
    ->name('kategoria.index');
Route::get('/kategoria/{kategoria}', [KategoriaController::class, 'show'])
    ->name('kategoria.show');
Route::post('/kategoria', [KategoriaController::class, 'store'])
    ->name('kategoria.store');
Route::put('/kategoria/{kategoria}', [KategoriaController::class, 'update'])
    ->name('kategoria.update');
Route::delete('/kategoria/{kategoria}', [KategoriaController::class, 'destroy'])
    ->name('kategoria.destroy');