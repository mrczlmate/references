<?php

use App\Http\Controllers\AddressController;
use App\Http\Controllers\DogController;
use App\Http\Controllers\DogHistoryController;
use App\Http\Controllers\DogPicturesController;
use App\Http\Controllers\FriendController;
use App\Http\Controllers\ProfileController;
use App\Http\Controllers\UserController;
use App\Http\Controllers\AuthController;
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

//profile
Route::get('/profile', [ProfileController::class, 'index'])
    ->name('profile.index');
Route::get('/profile/{profile}', [ProfileController::class, 'show'])
    ->name('profile.show');
Route::post('/profile', [ProfileController::class, 'store'])
    ->name('profile.store');
Route::put('/profile/{profile}', [ProfileController::class, 'update'])
    ->name('profile.update');
Route::delete('/profile/{profile}', [ProfileController::class, 'destroy'])
    ->name('profile.destroy');
//address
Route::get('/address', [AddressController::class, 'index'])
    ->name('address.index');
Route::get('/address/{address}', [AddressController::class, 'show'])
    ->name('address.show');
Route::post('/address', [AddressController::class, 'store'])
    ->name('address.store');
Route::put('/address/{address}', [AddressController::class, 'update'])
    ->name('address.update');
Route::delete('/address/{address}', [AddressController::class, 'destroy'])
    ->name('address.destroy');
//dog
Route::get('/dog', [DogController::class, 'index'])
    ->name('dog.index');
Route::get('/dog/{dog}', [DogController::class, 'show'])
    ->name('dog.show');
Route::post('/dog', [DogController::class, 'store'])
    ->name('dog.store');
Route::put('/dog/{dog}', [DogController::class, 'update'])
    ->name('dog.update');
Route::delete('/dog/{dog}', [DogController::class, 'destroy'])
    ->name('dog.destroy');
Route::get('/dog/dogs/{user}', [DogController::class, 'mydogs'])
    ->name('mydogs');
//dog history
Route::get('/doghistory', [DogHistoryController::class, 'index'])
    ->name('doghistory.index');
Route::get('/doghistory/{doghistory}', [DogHistoryController::class, 'show'])
    ->name('doghistory.show');
Route::post('/doghistory', [DogHistoryController::class, 'store'])
    ->name('doghistory.store');
Route::put('/doghistory/{doghistory}', [DogHistoryController::class, 'update'])
    ->name('doghistory.update');
Route::delete('/doghistory/{doghistory}', [DogHistoryController::class, 'destroy'])
    ->name('doghistory.destroy');
Route::get('/doghistory/dog/{dog}', [DogHistoryController::class, 'doghistories'])
    ->name('doghistories');
//dog picture
Route::get('/dogpicture', [DogPicturesController::class, 'index'])
    ->name('dogpicture.index');
Route::get('/dogpicture/{dogpicture}', [DogPicturesController::class, 'show'])
    ->name('dogpicture.show');
Route::post('/dogpicture', [DogPicturesController::class, 'store'])
    ->name('dogpicture.store');
Route::put('/dogpicture/{dogpicture}', [DogPicturesController::class, 'update'])
    ->name('dogpicture.update');
Route::delete('/dogpicture/{dogpicture}', [DogPicturesController::class, 'destroy'])
    ->name('dogpicture.destroy');
//user
Route::get('/user', [UserController::class, 'index'])
    ->name('user.index');
Route::get('/user/{user}', [UserController::class, 'show'])
    ->name('user.show');
Route::post('/user', [UserController::class, 'store'])
    ->name('user.store');
Route::put('/user/{user}', [UserController::class, 'update'])
    ->name('user.update');
Route::delete('/user/{user}', [UserController::class, 'destroy'])
    ->name('user.destroy');
//friend
Route::get('/friend', [FriendController::class, 'index'])
    ->name('friend.index');
Route::get('/friend/{friend}', [FriendController::class, 'show'])
    ->name('friend.show');
Route::post('/friend', [FriendController::class, 'store'])
    ->name('friend.store');
Route::put('/friend/{friend}', [FriendController::class, 'update'])
    ->name('friend.update');
Route::delete('/friend/{friend}', [FriendController::class, 'destroy'])
    ->name('friend.destroy');

//admin
Route::get('/admin/login', [AuthController::class, 'adminLogin']);

//profile
Route::get('/admin/profile', [ProfileController::class, 'index'])
    ->name('profile.index')->middleware(['admin.authenticate']);
Route::get('/admin/profile/{profile}', [ProfileController::class, 'show'])
    ->name('profile.show')->middleware(['admin.authenticate']);
Route::post('/admin/profile', [ProfileController::class, 'store'])
    ->name('profile.store')->middleware(['admin.authenticate']);
Route::put('/admin/profile/{profile}', [ProfileController::class, 'update'])
    ->name('profile.update')->middleware(['admin.authenticate']);
Route::delete('/admin/profile/{profile}', [ProfileController::class, 'destroy'])
    ->name('profile.destroy')->middleware(['admin.authenticate']);
//address
Route::get('/admin/address', [AddressController::class, 'index'])
    ->name('address.index')->middleware(['admin.authenticate']);
Route::get('/admin/address/{address}', [AddressController::class, 'show'])
    ->name('address.show')->middleware(['admin.authenticate']);
Route::post('/admin/address', [AddressController::class, 'store'])
    ->name('address.store')->middleware(['admin.authenticate']);
Route::put('/admin/address/{address}', [AddressController::class, 'update'])
    ->name('address.update')->middleware(['admin.authenticate']);
Route::delete('/admin/address/{address}', [AddressController::class, 'destroy'])
    ->name('address.destroy')->middleware(['admin.authenticate']);
//dog
Route::get('/admin/dog', [DogController::class, 'index'])
    ->name('dog.index')->middleware(['admin.authenticate']);
Route::get('/admin/dog/{dog}', [DogController::class, 'show'])
    ->name('dog.show')->middleware(['admin.authenticate']);
Route::post('/admin/dog', [DogController::class, 'store'])
    ->name('dog.store')->middleware(['admin.authenticate']);
Route::put('/admin/dog/{dog}', [DogController::class, 'update'])
    ->name('dog.update')->middleware(['admin.authenticate']);
Route::delete('/admin/dog/{dog}', [DogController::class, 'destroy'])
    ->name('dog.destroy')->middleware(['admin.authenticate']);
Route::get('/admin/dog/dogs/{user}', [DogController::class, 'mydogs'])
    ->name('mydogs')->middleware(['admin.authenticate']);
//dog history
Route::get('/admin/doghistory', [DogHistoryController::class, 'index'])
    ->name('doghistory.index')->middleware(['admin.authenticate']);
Route::get('/admin/doghistory/{doghistory}', [DogHistoryController::class, 'show'])
    ->name('doghistory.show')->middleware(['admin.authenticate']);
Route::post('/admin/doghistory', [DogHistoryController::class, 'store'])
    ->name('doghistory.store')->middleware(['admin.authenticate']);
Route::put('/admin/doghistory/{doghistory}', [DogHistoryController::class, 'update'])
    ->name('doghistory.update')->middleware(['admin.authenticate']);
Route::delete('/admin/doghistory/{doghistory}', [DogHistoryController::class, 'destroy'])
    ->name('doghistory.destroy')->middleware(['admin.authenticate']);
Route::get('/admin/doghistory/dog/{dog}', [DogHistoryController::class, 'doghistories'])
    ->name('doghistories')->middleware(['admin.authenticate']);
//dog picture
Route::get('/admin/dogpicture', [DogPicturesController::class, 'index'])
    ->name('dogpicture.index')->middleware(['admin.authenticate']);
Route::get('/admin/dogpicture/{dogpicture}', [DogPicturesController::class, 'show'])
    ->name('dogpicture.show')->middleware(['admin.authenticate']);
Route::post('/admin/dogpicture', [DogPicturesController::class, 'store'])
    ->name('dogpicture.store')->middleware(['admin.authenticate']);
Route::put('/admin/dogpicture/{dogpicture}', [DogPicturesController::class, 'update'])
    ->name('dogpicture.update')->middleware(['admin.authenticate']);
Route::delete('/admin/dogpicture/{dogpicture}', [DogPicturesController::class, 'destroy'])
    ->name('dogpicture.destroy')->middleware(['admin.authenticate']);
//user
Route::get('/admin/user', [UserController::class, 'index'])
    ->name('user.index')->middleware(['admin.authenticate']);
Route::get('/admin/user/{user}', [UserController::class, 'show'])
    ->name('user.show')->middleware(['admin.authenticate']);
Route::post('/admin/user', [UserController::class, 'store'])
    ->name('user.store')->middleware(['admin.authenticate']);
Route::put('/admin/user/{user}', [UserController::class, 'update'])
    ->name('user.update')->middleware(['admin.authenticate']);
Route::delete('/admin/user/{user}', [UserController::class, 'destroy'])
    ->name('user.destroy')->middleware(['admin.authenticate']);
//friend
Route::get('/admin/friend', [FriendController::class, 'index'])
    ->name('friend.index')->middleware(['admin.authenticate']);
Route::get('/admin/friend/{friend}', [FriendController::class, 'show'])
    ->name('friend.show')->middleware(['admin.authenticate']);
Route::post('/admin/friend', [FriendController::class, 'store'])
    ->name('friend.store')->middleware(['admin.authenticate']);
Route::put('/admin/friend/{friend}', [FriendController::class, 'update'])
    ->name('friend.update')->middleware(['admin.authenticate']);
Route::delete('/admin/friend/{friend}', [FriendController::class, 'destroy'])
    ->name('friend.destroy')->middleware(['admin.authenticate']);