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
            <h1 class="text-center mb-5 white">Regisztráció - Cím megadása</h1>
            <img src="{{asset('img/register3.png')}}" alt="register3" class="img-fluid mx-auto d-block">
            {!! Form::open(['route' => 'registerthree.storeaddress']) !!}

            <div class="row mt-3">
                <div class="col-12 col-md-6">
                    {{Form::label('country', 'Ország:', $attributes = ['class' => "white"])}}
                    @error('country')
                    {{Form::text('country', $value = old('country'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'country'])}}
                    <div id="countryFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('country', $value = old('country'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'country'])}}
                        @enderror
                </div>

                <div class="col-12 col-md-6 mt-3 mt-md-0">
                    {{Form::label('state', 'Megye:', $attributes = ['class' => "white"])}}
                    @error('state')
                    {{Form::text('state', $value = old('state'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'state'])}}
                    <div id="stateFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('state', $value = old('state'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'state'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-12 col-md-6">
                    {{Form::label('city', 'Város:', $attributes = ['class' => "white"])}}
                    @error('city')
                    {{Form::text('city', $value = old('city'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'city'])}}
                    <div id="cityFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('city', $value = old('city'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'city'])}}
                        @enderror
                </div>

                <div class="col-12 col-md-6 mt-3 mt-md-0">
                    {{Form::label('zip', 'Ir. Szám:', $attributes = ['class' => "white"])}}
                    @error('zip')
                    {{Form::number('zip', $value = old('zip'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'zip'])}}
                    <div id="zipFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::number('zip', $value = old('zip'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'zip'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-12 col-md-6">
                    {{Form::label('street', 'Utca:', $attributes = ['class' => "white"])}}
                    @error('street')
                    {{Form::text('street', $value = old('street'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'street'])}}
                    <div id="streetFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('street', $value = old('street'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'street'])}}
                        @enderror
                </div>

                <div class="col-12 col-md-6 mt-3 mt-md-0">
                    {{Form::label('houseNumber', 'Házszám:', $attributes = ['class' => "white"])}}
                    @error('houseNumber')
                    {{Form::number('houseNumber', $value = old('houseNumber'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'houseNumber'])}}
                    <div id="houseNumberFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::number('houseNumber', $value = old('houseNumber'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'houseNumber'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-5 text-center">
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