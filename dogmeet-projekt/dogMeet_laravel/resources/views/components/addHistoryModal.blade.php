<div class="modal fade" id="AddHistoryModal" aria-hidden="true" aria-labelledby="AddHistoryModalTitle" tabindex="-1">
    <div class="modal-dialog modal-dialog-scrollable modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="AddHistoryModalTitle">Szaporítási előzmények szerkesztése</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body" id="AddHistoryModalBody">
                <div class="row">
                    <div class="col-10 offset-1 historyCard my-2">
                        {!! Form::open(['route' => 'doghistory.storedata', 'method' => 'post']) !!}

                        <div class="row mt-3">
                            <div class="col-12">
                                {{Form::label('breededWith_Type', 'Milyen kutyával lett szaporítva:')}}

                                @error('breededWith_Type')
                                {{Form::text('breededWith_Type', $value = old('breededWith_Type'),
                                    $attributes = ['class' => 'form-control is-invalid', 'id' => 'breededWith_Type'])}}
                                <div id="breededWith_TypeFeedback" class="invalid-feedback">
                                    {{ $message }}
                                </div>
                                @else
                                    {{Form::text('breededWith_Type', $value = old('breededWith_Type'),
                                        $attributes = ['class' => 'form-control', 'id' => 'breededWith_Type'])}}
                                    @enderror
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-12 col-md-6">
                                {{Form::label('kidsBorn', 'Kölyök született: (db)')}}

                                @error('kidsBorn')
                                {{Form::number('kidsBorn', $value = old('kidsBorn'),
                                    $attributes = ['class' => 'form-control is-invalid', 'id' => 'kidsBorn'])}}
                                <div id="kidsBornFeedback" class="invalid-feedback">
                                    {{ $message }}
                                </div>
                                @else
                                    {{Form::number('kidsBorn', $value = old('kidsBorn'),
                                        $attributes = ['class' => 'form-control', 'id' => 'kidsBorn'])}}
                                    @enderror
                            </div>

                            <div class="col-12 col-md-6 mt-3 mt-md-0">
                                {{Form::label('date', 'Születés dátuma:')}}

                                @error('date')
                                {{Form::date('date', $value = old('date'),
                                    $attributes = ['class' => 'form-control is-invalid', 'id' => 'date'])}}
                                <div id="dateFeedback" class="invalid-feedback">
                                    {{ $message }}
                                </div>
                                @else
                                    {{Form::date('date', $value = old('date'),
                                        $attributes = ['class' => 'form-control', 'id' => 'date'])}}
                                    @enderror
                            </div>

                            {{ Form::hidden('dog_id', 0, $attributes = ['id' => "dogH_id"]) }}

                        </div>

                        <div class="row my-5 text-center">
                            <div class="col-12 col-md-6 offset-md-3">
                                {{Form::submit('Mentés', ['class' => 'btn greenBtn'])}}
                            </div>
                        </div>

                        {!! Form::close() !!}
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn redBtn" onclick="dismissAddHistoryModal()">Vissza</button>
            </div>
        </div>
    </div>
</div>
