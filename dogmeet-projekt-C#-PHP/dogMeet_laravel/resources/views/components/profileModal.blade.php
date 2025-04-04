<div class="modal fade" id="ProfileModal" aria-hidden="true" aria-labelledby="ProfileModalTitle" tabindex="-1">
    <div class="modal-dialog modal-dialog-scrollable modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="ProfileModalTitle">Személyes adatok módosítása:</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body" id="ProfileModalBody">
                {!! Form::open(['route' => ['profile.updatedata', 'profile' => $user->profile], 'method' => 'put']) !!}

                <div class="row mt-3">
                    <div class="col-12">
                        {{Form::label('lastName', 'Vezetéknév:')}}

                        @error('lastName')
                        {{Form::text('lastName', $user->profile->lastName,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'lastName'])}}
                        <div id="lastNameFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('lastName', $user->profile->lastName,
                                $attributes = ['class' => 'form-control', 'id' => 'lastName'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-12">
                        {{Form::label('firstName', 'Keresztnév:')}}

                        @error('firstName')
                        {{Form::text('firstName', $user->profile->firstName,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'firstName'])}}
                        <div id="firstNameFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('firstName', $user->profile->firstName,
                                $attributes = ['class' => 'form-control', 'id' => 'firstName'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-12">
                        {{Form::label('phoneNumber', 'Telefonszám:')}}

                        @error('phoneNumber')
                        {{Form::text('phoneNumber', $user->profile->phoneNumber,
                            $attributes = ['class' => 'form-control is-invalid',
                            'placeholder' => '+36301234567', 'id' => 'phoneNumber'])}}
                        <div id="phoneNumberFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('phoneNumber', $user->profile->phoneNumber,
                                $attributes = ['class' => 'form-control',
                                'placeholder' => '+36301234567', 'id' => 'phoneNumber'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-5 text-center">
                    <div class="col-8 offset-2 col-md-6 offset-md-3">
                        {{Form::submit('Frissítés', ['class' => 'btn greenBtn'])}}
                    </div>
                </div>

                {!! Form::close() !!}
            </div>
            <div class="modal-footer">
                <button type="button" class="btn redBtn" onclick="dismissProfileModal()">Mégse</button>
            </div>
        </div>
    </div>
</div>
