<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;
use App\Models\Admin;

class AdminAuthentication
{
    /**
     * Handle an incoming request.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \Closure(\Illuminate\Http\Request): (\Illuminate\Http\Response|\Illuminate\Http\RedirectResponse)  $next
     * @return \Illuminate\Http\Response|\Illuminate\Http\RedirectResponse
     */
    public function handle(Request $request, Closure $next)
    {
        if(array_key_exists('token', $request->all())){
            $admin = Admin::where('token', '=', $request["token"])->first();
            if(!is_null($admin)){
                return $next($request);
            }
        }
        return abort(403, 'Nincs jogosultságod a művelet végrehajtására.');
    }
}
