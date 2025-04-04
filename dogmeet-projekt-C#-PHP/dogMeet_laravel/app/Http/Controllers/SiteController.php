<?php

namespace App\Http\Controllers;

use App\Models\Dog;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class SiteController extends Controller
{
    public function index()
    {
        return view('authentication.login');
    }

    public function registertwo()
    {
        return view('authentication.registerpagetwo');
    }

    public function registerthree()
    {
        return view('authentication.registerpagethree');
    }

    public function registerfour()
    {
        return view('authentication.registerpagefour');
    }

    public function profile()
    {
        $user = Auth::user();
        return view('dogmeet.profile', ["user" => $user]);
    }

    public function newdog()
    {
        $user = Auth::user();
        return view('dogmeet.newdog', ["user" => $user]);
    }

    public function editdog(Dog $dog)
    {
        $user = Auth::user();
        return view('dogmeet.editdog', ["user" => $user, "dog" => $dog]);
    }

    public function friends()
    {
        $user = Auth::user();
        return view('dogmeet.friends', ['user' => $user]);
    }

    public function homepage()
    {
        $user = Auth::user();
        return view('dogmeet.mainpage', ['user' => $user]);
    }

    public function owneddog()
    {
        $user = Auth::user();
        return view('dogmeet.owneddogs', ['user' => $user]);
    }
}
