"use strict"

let books = []
let bookToUpdate = null

async function getBooks() {
  await fetch('http://localhost:33074/book')
      .then(x => x.json())
      .then(y => {
          books = y
          //console.log(books)
          displayBook()
      })
}

function displayBook() {
  document.querySelector('#resultbook').innerHTML = ""
  books.forEach(t => {
    const authorName = t.author && t.author.name ? t.author.name : "ismeretlen"
    const publisherName = t.publisher && t.publisher.publisherName ? t.publisher.publisherName : "ismeretlen"
    const categoryName = t.category && t.category.categoryName ? t.category.categoryName : "ismeretlen"
    document.querySelector('#resultbook').innerHTML +=
        `<tr>
        <td>${t.bookId}</td>
        <td>${t.title}</td>
        <td>${t.price} Ft</td>
        <td>${authorName}</td>
        <td>${publisherName}</td>
        <td>${categoryName}</td>
        <td><button class="btn btn-outline-success buttonalign" type="button" onclick="showUpdateBook(${t.bookId})">Update</button><button class="btn btn-outline-danger buttonalign" type="button" onclick="removeBook(${t.bookId})">Delete</button></td>
        </tr>`
  })
}

function removeBook(id) {
  fetch('http://localhost:33074/book/' + id, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json', },
      body: null })
      .then(response => response)
      .then(data => {
          console.log('Success:', data)
          getBooks()
      })
      .catch((error) => { 
        console.error('Error:', error) 
      })
}

function createBook() {
  let bookTitle = document.querySelector('#title').value
  let bookPrice = document.querySelector('#price').value 
  fetch('http://localhost:33074/book', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json', },
      body: JSON.stringify(
          { 
            title: bookTitle,
            price: bookPrice
          })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getBooks()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}

function showUpdateBook(id){
  bookToUpdate = books.find(t => t["bookId"] == id)
  document.querySelector("#titleUpdate").value = bookToUpdate["title"]
  document.querySelector("#priceUpdate").value = bookToUpdate["price"] 
}

function updateBook() {
  let bookTitle = document.querySelector('#titleUpdate').value
  let bookPrice = document.querySelector('#priceUpdate').value 

  fetch('http://localhost:33074/book', {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json', },
    body: JSON.stringify(
      { 
        bookId: bookToUpdate["bookId"],
        title: bookTitle,
        price: bookPrice,
        authorName: bookToUpdate.author.name,
        publisherName: bookToUpdate.publisher.publisherName,
        categoryName: bookToUpdate.category.categoryName
      })})
      .then(response => response)
      .then(data =>
      {
          console.log('Success:', data)
          getBooks()
      })
      .catch((error) => { 
        console.error('Error:', error)
      })
}