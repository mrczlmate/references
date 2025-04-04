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
            <h1 class="text-center mb-5 white">Regisztráció - Első kutya felvétele</h1>
            <img src="{{asset('img/register4.png')}}" alt="register4" class="img-fluid mx-auto d-block">
            {!! Form::open(['route' => 'registerfour.storedog']) !!}

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('name', 'A kutya neve:', $attributes = ['class' => "white"])}}
                    @error('name')
                    {{Form::text('name', $value = old('name'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'name'])}}
                    <div id="nameFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('name', $value = old('name'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'name'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-12 col-md-6">
                    {{Form::label('gender', 'Neme:', $attributes = ['class' => "white"])}}
                    @error('gender')
                    {{Form::select('gender', $value = ["kan" => "kan", "szuka" => "szuka"], "kan",
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'gender'])}}
                    <div id="genderFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::select('gender', $value = ["kan" => "kan", "szuka" => "szuka"], "kan",
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'gender'])}}
                        @enderror
                </div>

                <div class="col-12 col-md-6 mt-3 mt-md-0">
                    {{Form::label('age', 'Kora:', $attributes = ['class' => "white"])}}
                    @error('age')
                    {{Form::number('age', $value = old('age'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'age'])}}
                    <div id="ageFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::number('age', $value = old('age'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'age'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('type', 'Fajtája:', $attributes = ['class' => "white"])}}

                    @error('type')
                    {{Form::text('type', $value = old('type'),
                        $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'type'])}}
                    <div id="typeFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('type', $value = old('type'),
                            $attributes = ['class' => 'form-control lightBg', 'id' => 'type'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('description', 'Rövid leírás a kutyáról:', $attributes = ['class' => "white"])}}

                    @error('description')
                    {{Form::textarea('description', $value = old('description'),
                        $attributes = ['class' => 'form-control is-invalid lightBg',
                            'id' => 'description', 'rows' => 5])}}
                    <div id="descriptionFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::textarea('description', $value = old('description'),
                            $attributes = ['class' => 'form-control lightBg',
                                'id' => 'description', 'rows' => 5])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-5 text-center">
                <div class="col-12 col-md-6 offset-md-3">
                    {{Form::submit('Befejezés', ['class' => 'btn brownBtn'])}}
                </div>
            </div>
            {!! Form::close() !!}
        </div>
    </div>
</div>
@include('layout.footer')
</body>
</html>