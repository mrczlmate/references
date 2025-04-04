<!doctype html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="loginregister.css">
    <title>Bejelentkezés</title>
</head>
<body>
    <div class="row my-5">
        <div class="col-6 offset-3">
            <h1 class="text-center">Bejelentkezés</h1>
            {!! Form::open(['route' => 'auth.authenticate']) !!}

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('email', 'Email')}}

                    @error('email')
                    {{Form::text('email', $value = old('email'), $attributes = ['class' => 'form-control is-invalid', 'placeholder' => 'example@gmail.com', 'id' => 'email'])}}
                    <div id="emailFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::text('email', $value = old('email'), $attributes = ['class' => 'form-control', 'placeholder' => 'example@gmail.com', 'id' => 'email'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::label('password', "Jelszó")}}

                    @error('password')
                    {{Form::password('password', ['class' => 'form-control is-invalid', 'id' => 'password'])}}
                    <div id="passwordFeedback" class="invalid-feedback">
                        {{ $message }}
                    </div>
                    @else
                        {{Form::password('password', ['class' => 'form-control', 'id' => 'password'])}}
                        @enderror
                </div>
            </div>

            <div class="row mt-3">
                <div class="col">
                    {{Form::submit('Bejelentkezés', ['class' => 'btn formbtn'])}}
                </div>
            </div>
            {!! Form::close() !!}
        </div>
    </div>
</body>
</html>