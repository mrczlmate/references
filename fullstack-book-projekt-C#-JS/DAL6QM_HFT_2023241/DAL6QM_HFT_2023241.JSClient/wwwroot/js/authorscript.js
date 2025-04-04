"use strict"

let authors = []
let authorIdToUpdate = -1

async function getAuthors() {
  await fetch('http://localhost:33074/author')
      .then(x => x.json())
      .then(y => {
          authors = y
          //console.log(authors)
          displayAuthor()
      })
}

function displayAuthor() {
  document.querySelector('#resultauthor').innerHTML = ""
  authors.forEach(t => {
      document.querySelector('#resultauthor').innerHTML +=
          `<tr>
          <td>${t.authorId}</td>
          <td>${t.name}</td>
          <td><button class="btn btn-outline-success buttonalign" type="button" onclick="showUpdateAuthor(${t.authorId})">Update</button><button class="btn btn-outline-danger buttonalign" type="button" onclick="removeAuthor(${t.authorId})">Delete</button></td>
          </tr>`
  })
}

function removeAuthor(id) {
  fetch('http://localhost:33074/author/' + id, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json', },
      body: null })
      .then(response => response)
      .then(data => {
          console.log('Success:', data)
          getAuthors()
      })
      .catch((error) => { 
        console.error('Error:', error) 
      })
}

function createAuthor() {
  let authorName = document.querySelector('#authorname').value
  fetch('http://localhost:33074/author', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          { name: authorName })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getAuthors()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}

function showUpdateAuthor(id){
  document.querySelector("#authornameUpdate").value = authors.find(t => t["authorId"] == id)["name"]
  authorIdToUpdate = id
}

function updateAuthor() {
  let authorName = document.querySelector('#authornameUpdate').value
  fetch('http://localhost:33074/author', {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          { 
            authorId: authorIdToUpdate,
            name: authorName
          })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getAuthors()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}