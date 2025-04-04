"use strict"

let publishers = []
let publisherIdToUpdate = -1

async function getPublishers() {
  await fetch('http://localhost:33074/publisher')
      .then(x => x.json())
      .then(y => {
          publishers = y
          //console.log(publishers)
          displayPublisher()
      })
}

function displayPublisher() {
  document.querySelector('#resultpublisher').innerHTML = ""
  publishers.forEach(t => {
      document.querySelector('#resultpublisher').innerHTML +=
          `<tr>
          <td>${t.publisherId}</td>
          <td>${t.publisherName}</td>
          <td><button class="btn btn-outline-success buttonalign" type="button" onclick="showUpdatePublisher(${t.publisherId})">Update</button><button class="btn btn-outline-danger buttonalign" type="button" onclick="removePublisher(${t.publisherId})">Delete</button></td>
          </tr>`
  })
}

function removePublisher(id) {
  fetch('http://localhost:33074/publisher/' + id, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json', },
      body: null })
      .then(response => response)
      .then(data => {
          console.log('Success:', data)
          getPublishers()
      })
      .catch((error) => { 
        console.error('Error:', error) 
      })
}

function createPublisher() {
  let name = document.querySelector('#publishername').value
  fetch('http://localhost:33074/publisher', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          { publisherName: name })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getPublishers()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}

function showUpdatePublisher(id){
  document.querySelector("#publishernameUpdate").value = publishers.find(t => t["publisherId"] == id)["publisherName"]
  publisherIdToUpdate = id
}

function updatePublisher() {
  let name = document.querySelector('#publishernameUpdate').value
  fetch('http://localhost:33074/publisher', {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          {
            publisherId: publisherIdToUpdate, 
            publisherName: name 
          })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getPublishers()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}