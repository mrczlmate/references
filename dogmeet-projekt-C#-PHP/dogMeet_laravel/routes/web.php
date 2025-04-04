<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\DogController;
use App\Http\Controllers\ProfileController;
use App\Http\Controllers\RegisterController;
use App\Http\Controllers\StoreDatasController;
use App\Http\Controllers\UpdateDatasController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\SiteController;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

//main Route
Route::get('/', [SiteController::class, 'index'])
    ->name('home');

//Login
Route::get("/login", [AuthController::class, "login"])
    ->name("login");
Route::post("/login", [AuthController::class, "authenticate"])
    ->name("auth.authenticate");
Route::post("/logout", [AuthController::class, "logout"])
    ->name("auth.logout");

//Register
Route::get("/register", [RegisterController::class, "create"])
    ->name("register.create");
Route::post("/register", [RegisterController::class, "store"])
    ->name("register.store");

Route::get("/registertwo", [SiteController::class, "registertwo"])
    ->name("registertwo.show");
Route::post("/registertwo", [RegisterController::class, "storeprofile"])
    ->name("registertwo.storeprofile");

Route::get("/registerthree", [SiteController::class, "registerthree"])
    ->name("registerthree.show");
Route::post("/registerthree", [RegisterController::class, "storeaddress"])
    ->name("registerthree.storeaddress");

Route::get("/registerfour", [SiteController::class, "registerfour"])
    ->name("registerfour.show");
Route::post("/registerfour", [RegisterController::class, "storedog"])
    ->name("registerfour.storedog");

//profile
Route::get("/profile", [SiteController::class, 'profile'])
    ->middleware("auth")
    ->name('profile');
Route::put('/profile/{profile}', [UpdateDatasController::class, "profileupdate"])
    ->name("profile.updatedata");

//address
Route::put('/address/{address}', [UpdateDatasController::class, "addressupdate"])
    ->name("address.updatedata");

//new dog
Route::get('/newdog', [SiteController::class, 'newdog'])
    ->middleware("auth")
    ->name('newdog');
Route::post('/newdog', [StoreDatasController::class, 'storedog'])
    ->name('dog.storedata');

//edit dog
Route::get('/editdog/{dog}', [SiteController::class, 'editdog'])
    ->middleware("auth")
    ->name('editdog');
Route::put('/editdog/{dog}', [UpdateDatasController::class, "dogupdate"])
    ->name("dog.updatedata");

//friend
Route::get('/friends', [SiteController::class, 'friends'])
    ->middleware("auth")
    ->name('friends');

//main page
Route::get('/homepage', [SiteController::class, 'homepage'])
    ->middleware("auth")
    ->name('homepage');

//mydog page
Route::get('/owneddog', [SiteController::class, 'owneddog'])
    ->middleware("auth")
    ->name('owneddog');

//doghistory
Route::post('/doghistory/add', [StoreDatasController::class, 'storedoghistory'])
    ->name('doghistory.storedata');

//dogpictures
Route::post('/dog/picture/upload', [StoreDatasController::class, 'dogpictures'])
    ->name('pictures.upload');