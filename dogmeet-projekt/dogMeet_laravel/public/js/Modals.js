//dismiss modals

function dismissModal() {
    let modal = document.querySelector("#Modal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.hide();
}

//addHistory modal

function addHistory() {
    let modal = document.querySelector("#AddHistoryModal");

    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.show();
}

function dismissAddHistoryModal() {
    let modal = document.querySelector("#AddHistoryModal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.hide();
}

// image modal

function uploadImage() {
    let modal = document.querySelector("#ImageModal");

    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.show();
}

function dismissImageModal() {
    let modal = document.querySelector("#ImageModal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.hide();
}

//address Modal

function showAddress() {
    let modal = document.querySelector("#AddressModal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.show();
}

function dismissAddressModal() {
    let modal = document.querySelector("#AddressModal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.hide();
}

// profile Modal

function showProfile() {
    let modal = document.querySelector("#ProfileModal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.show();
}

function dismissProfileModal() {
    let modal = document.querySelector("#ProfileModal");
    let BSModal = bootstrap.Modal.getOrCreateInstance(modal);
    BSModal.hide();
}