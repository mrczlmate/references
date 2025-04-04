<?php

namespace App\Http\Controllers;

use App\Http\Requests\LoginRequest;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;
use App\Models\User;

class AuthController extends Controller
{
    public function login()
    {
        return view("authentication.login");
    }

    public function authenticate(LoginRequest $request)
    {
        $data = $request->validated();

        if(!Auth::attempt($data))
        {
            $request->session()->flash("danger","Sikertelen bejelentkezés");
            return redirect()->route("login");
        }

        $request->session()->flash("success","Sikeres bejelentkezés");
        return redirect()->route("homepage");
    }

    public function logout(Request $request)
    {
        Auth::logout();

        $request->session()->invalidate();

        $request->session()->regenerateToken();

        return redirect()->route('login');
    }

    public function adminLogin(LoginRequest $request)
    {
        $data = $request->validated();

        $user = User::where('email', '=', $data['email'])->first();

        if(!is_null($user) && Hash::check($request["password"], $user->password) && !is_null($user->admin)){
            $bytes = random_bytes(32);
            $token = bin2hex($bytes);
            $user->admin->token = $token;
            $user->admin->save();
            return response()->json([
                "status" => "success",
                "token" => $token,
            ]);
        } 
        else return response()->json([
            "status" => "failed",
            "token" => "",
        ]);
    }
}
