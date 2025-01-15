<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <link rel="stylesheet" href="{{asset("style.css")}}">
    <title>DogMeet | Regisztráció</title>
</head>
<body>
<div class="container containerStyle">
    @include('layout.header')
    <div class="row my-3">
        <div class="col">
            <h1 class="text-center mb-5 white">Regisztráció - Általános adatok megadása</h1>
            <img src="{{asset('img/register1.png')}}" alt="register1" class="img-fluid mx-auto d-block">
            {!! Form::open(['route' => 'register.store']) !!}

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('username', 'Felhasználónév:', $attributes = ['class' => "white"])}}

                    @error('username')
                    {{Form::text('username', $value = old('username'),
                        $attributes = ['class' => 'form-control is-invalid lightBg',
                        'id' => 'username'])}}
                    <div id="usernameFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('username', $value = old('username'),
                            $attributes = ['class' => 'form-control lightBg',
                            'id' => 'username'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('email', 'Email cím:', $attributes = ['class' => "white"])}}

                    @error('email')
                    {{Form::email('email', $value = old('email'),
                        $attributes = ['class' => 'form-control is-invalid lightBg',
                        'placeholder' => 'pelda@pelda.hu', 'id' => 'email'])}}
                    <div id="emailFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::email('email', $value = old('email'),
                            $attributes = ['class' => 'form-control lightBg',
                            'placeholder' => 'pelda@pelda.hu', 'id' => 'email'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('password', "Jelszó:", $attributes = ['class' => "white"])}}

                    @error('password')
                    {{Form::password('password', ['class' => 'form-control is-invalid lightBg', 'id' => 'password'])}}
                    <div id="passwordFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::password('password', ['class' => 'form-control lightBg', 'id' => 'password'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('password_confirmation', "Jelszó újra:", $attributes = ['class' => "white"])}}
                    {{Form::password('password_confirmation', ['class' => 'form-control lightBg', 'id' => 'password_confirmation'])}}
                </div>
            </div>

            <div class="row mt-5 text-center">
                <div class="col-12 col-md-6 offset-md-3">
                    <a href="{{route('login')}}" class="btn brownBtn">Mégse</a>
                    {{Form::submit('Következő', ['class' => 'btn brownBtn my-2'])}}
                </div>
            </div>
            {!! Form::close() !!}
        </div>
    </div>
</div>
@include('layout.footer')
</body>
</html>