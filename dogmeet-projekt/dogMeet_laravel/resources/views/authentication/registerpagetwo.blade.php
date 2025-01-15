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
            <h1 class="text-center mb-5 white">Regisztráció - Személyes adatok megadása</h1>
            <img src="{{asset('img/register2.png')}}" alt="register2" class="img-fluid mx-auto d-block">
            {!! Form::open(['route' => 'registertwo.storeprofile']) !!}

            <div class="row mt-3">
                <div class="col-12 col-md-6">
                    {{Form::label('lastName', 'Vezetéknév:', $attributes = ['class' => "white"])}}
                    @error('lastName')
                    {{Form::text('lastName', $value = old('lastName'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'lastName'])}}
                    <div id="lastNameFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('lastName', $value = old('lastName'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'lastName'])}}
                        @enderror
                </div>

                <div class="col-12 col-md-6 mt-3 mt-md-0">
                    {{Form::label('firstName', 'Keresztnév:', $attributes = ['class' => "white"])}}
                    @error('firstName')
                    {{Form::text('firstName', $value = old('firstName'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'firstName'])}}
                    <div id="firstNameFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('firstName', $value = old('firstName'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'firstName'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-12">
                    {{Form::label('phoneNumber', 'Telefonszám:', $attributes = ['class' => "white"])}}
                    @error('phoneNumber')
                    {{Form::text('phoneNumber', $value = old('phoneNumber'),
                        $attributes = ['class' => 'form-control is-invalid lightBg',
                        'placeholder' => '+36301234567', 'id' => 'phoneNumber'])}}
                    <div id="phoneNumberFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('phoneNumber', $value = old('phoneNumber'),
                            $attributes = ['class' => 'form-control lightBg',
                            'placeholder' => '+36301234567', 'id' => 'phoneNumber'])}}
                        @enderror
                </div>
            </div>

            <div class="row my-5 text-center">
                <div class="col-12 col-md-6 offset-md-3">
                    {{Form::submit('Következő', ['class' => 'btn brownBtn'])}}
                </div>
            </div>

            {!! Form::close() !!}
        </div>
    </div>
</div>
@include('layout.footer')
</body>
</html>