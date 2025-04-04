<div class="modal fade" id="AddressModal" aria-hidden="true" aria-labelledby="AddressModalTitle" tabindex="-1">
    <div class="modal-dialog modal-dialog-scrollable modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="AddressModalTitle"> Cím adatainak módosítása</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body" id="AddressModalBody">
                {!! Form::open(['route' => ['address.updatedata', $user->profile->address],'method' => 'put']) !!}

                <div class="row mt-3">
                    <div class="col-12 col-md-6">
                        {{Form::label('country', 'Ország:')}}

                        @error('country')
                        {{Form::text('country', $value = $user->profile->address->country,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'country'])}}
                        <div id="countryFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('country', $value = $user->profile->address->country,
                                $attributes = ['class' => 'form-control', 'id' => 'country'])}}
                            @enderror
                    </div>

                    <div class="col-12 col-md-6">
                        {{Form::label('state', 'Megye:')}}

                        @error('state')
                        {{Form::text('state', $value = $user->profile->address->state,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'state'])}}
                        <div id="stateFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('state', $value = $user->profile->address->state,
                                $attributes = ['class' => 'form-control', 'id' => 'state'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-12 col-md-6">
                        {{Form::label('city', 'Város:')}}

                        @error('city')
                        {{Form::text('city', $value = $user->profile->address->city,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'city'])}}
                        <div id="cityFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('city', $value = $user->profile->address->city,
                                $attributes = ['class' => 'form-control', 'id' => 'city'])}}
                            @enderror
                    </div>

                    <div class="col-12 col-md-6">
                        {{Form::label('zip', 'Ir. Szám:')}}

                        @error('zip')
                        {{Form::number('zip', $value = $user->profile->address->zip,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'zip'])}}
                        <div id="zipFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::number('zip', $value = $user->profile->address->zip,
                                $attributes = ['class' => 'form-control', 'id' => 'zip'])}}
                            @enderror
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-12 col-md-6">
                        {{Form::label('street', 'Utca:')}}

                        @error('street')
                        {{Form::text('street', $value = $user->profile->address->street,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'street'])}}
                        <div id="streetFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::text('street', $value = $user->profile->address->street,
                                $attributes = ['class' => 'form-control', 'id' => 'street'])}}
                            @enderror
                    </div>

                    <div class="col-12 col-md-6">
                        {{Form::label('houseNumber', 'Házszám:')}}

                        @error('houseNumber')
                        {{Form::number('houseNumber', $value = $user->profile->address->houseNumber,
                            $attributes = ['class' => 'form-control is-invalid', 'id' => 'houseNumber'])}}
                        <div id="houseNumberFeedback" class="invalid-feedback">
                            {{ $message }}
                        </div>
                        @else
                            {{Form::number('houseNumber', $value = $user->profile->address->houseNumber,
                                $attributes = ['class' => 'form-control', 'id' => 'houseNumber'])}}
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
                <button type="button" class="btn redBtn" onclick="dismissAddressModal()">Mégse</button>
            </div>
        </div>
    </div>
</div>
