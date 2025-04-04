@extends('layout.main')

@section('title', 'DogMeet | kutya módosítása')

@section('content')
    <div class="container containerStyle">

        @include('layout.header')

        <div class="row">
            <a href="{{route('owneddog')}}">
                <img src="{{asset('img/back.png')}}" alt="visszanyil" class="img-fluid backButton">
            </a>
            <h1 class="text-center my-4 dog editTitle">Kutya neve és adatainak szerkesztése</h1>
        </div>

        <div class="row">
            <div class="col-12 col-md-8 offset-md-2">
                {!! Form::open(['route' => ['dog.updatedata', 'dog' => $dog], 'method' => 'put']) !!}

                <div class="row mt-3">
                    <div class="col">
                        {{Form::label('name', 'A kuyta neve:', $attributes = ['class' => "white"])}}

                        @error('name')
                        {{Form::text('name', $value = $dog->name,
                            $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'name'])}}
                        <div id="nameFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('name', $value = $dog->name,
                                $attributes = ['class' => 'form-control lightBg', 'id' => 'name'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-12 col-md-6">
                        {{Form::label('gender', 'Neme:', $attributes = ['class' => "white"])}}

                        @error('gender')
                        {{Form::select('gender', $value = ["kan" => "kan", "szuka" => "szuka"], $dog->gender,
                            $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'gender'])}}
                        <div id="genderFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::select('gender', $value = ["kan" => "kan", "szuka" => "szuka"], $dog->gender,
                                $attributes = ['class' => 'form-control lightBg', 'id' => 'gender'])}}
                            @enderror
                    </div>

                    <div class="col-12 col-md-6">
                        {{Form::label('age', 'Kora:', $attributes = ['class' => "white"])}}

                        @error('age')
                        {{Form::number('age', $value = $dog->age,
                            $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'age'])}}
                        <div id="ageFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::number('age', $value = $dog->age,
                                $attributes = ['class' => 'form-control lightBg', 'id' => 'age'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        {{Form::label('type', 'Fajtája:', $attributes = ['class' => "white"])}}

                        @error('type')
                        {{Form::text('type', $value = $dog->type,
                            $attributes = ['class' => 'form-control is-invalid lightBg', 'id' => 'type'])}}
                        <div id="typeFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('type', $value = $dog->type,
                                $attributes = ['class' => 'form-control lightBg', 'id' => 'type'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        {{Form::label('description', 'Rövid leírás a kutyáról:', $attributes = ['class' => "white"])}}

                        @error('description')
                        {{Form::textarea('description', $value = $dog->description,
                            $attributes = ['class' => 'form-control is-invalid lightBg',
                                'id' => 'description', 'rows' => 5])}}
                        <div id="descriptionFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::textarea('description', $value = $dog->description,
                                $attributes = ['class' => 'form-control lightBg',
                                    'id' => 'description', 'rows' => 5])}}
                            @enderror
                    </div>
                </div>

                <div class="row my-3 text-center">
                    <div class="col-12 col-md-6 offset-md-3">
                        {{Form::submit('Szerkeszt', ['class' => 'btn brownBtn'])}}
                    </div>
                </div>
                {!! Form::close() !!}
            </div>
        </div>
    </div>

    @include('layout.footer')

@endsection