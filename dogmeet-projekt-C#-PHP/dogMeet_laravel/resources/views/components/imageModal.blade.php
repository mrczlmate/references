<div class="modal fade" id="ImageModal" aria-hidden="true" aria-labelledby="ImageModalTitle" tabindex="-1">
    <div class="modal-dialog modal-dialog-scrollable modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="ImageModalTitle">Szaporítási előzmények szerkesztése</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body" id="ImageModalBody">
                <div class="row">
                    <div class="col-10 offset-1 historyCard my-2">
                        {!! Form::open(['route' => 'pictures.upload',
                                'method' => 'post', 'enctype' => 'multipart/form-data']) !!}

                        <div class="row mt-3">
                            <div class="col-12">
                                {{Form::label('url', 'Kutya kép:', $attributes = ['class' => 'form-label'])}}

                                @error('url')
                                {{Form::file('url',
                                    $attributes = ['class' => 'form-control is-invalid', 'id' => 'url'])}}
                                <div id="urlFeedback" class="invalid-feedback">
                                    {{ $message }}
                                </div>
                                @else
                                    {{Form::file('url',
                                        $attributes = ['class' => 'form-control', 'id' => 'url'])}}
                                    @enderror
                            </div>
                        </div>

                        {{ Form::hidden('dog_id', 0, $attributes = ['id' => "dogImage_id"]) }}

                        <div class="row my-2 text-center">
                            <div class="col-12 col-md-6 offset-md-3">
                                {{Form::submit('Mentés', ['class' => 'btn greenBtn'])}}
                            </div>
                        </div>

                        {!! Form::close() !!}
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn redBtn" onclick="dismissImageModal()">Vissza</button>
            </div>
        </div>
    </div>
</div>
